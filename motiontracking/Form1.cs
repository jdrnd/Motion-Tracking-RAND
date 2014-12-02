/* Motion Tracking and Entropy Generator Copyright (C) 2014 Joel Ruhland

This program is free software: you can redistribute it and/or modify it under the terms of the 
GNU General Public License as published by the Free Software Foundation, either version 3 of 
the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

Please view the included "GNUGPLv3" file for full licencing terms.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

//Imports AForge libraries
using AForge.Video;
using AForge.Video.DirectShow;

//Imports file in/out library
using System.IO;

namespace motiontracking
{


    public partial class MainWindow : Form
    {
        private FilterInfoCollection videosources;
        private VideoCaptureDevice videoSource;
        public MainWindow()
        {
            InitializeComponent();

            //List all available video sources
            videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Adds each webcams to options list
            foreach (FilterInfo VideoCaptureDevice in videosources)
            {
                webcams.Items.Add(VideoCaptureDevice.Name);
            }

            webcams.SelectedIndex = 0;

            videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString); 

            //Populates resolution list for default webcam
            for (int i = 0; i < videoSource.VideoCapabilities.Length; i++ )
            {
                resolutionlist.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString()); 
            }

            resolutionlist.SelectedIndex = 0;  
        }


        //Declares blank RGB colors
        public static Color selectedcolor = Color.FromArgb(0,0,0);

        //Declares list to be used to store image frames
        List<Bitmap> frames = new List<Bitmap>();

        private void start_Click(object sender, EventArgs e)
        {
                frames.Clear();
                videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString); 
                videoSource.VideoResolution = videoSource.VideoCapabilities[resolutionlist.SelectedIndex];

                //Create NewFrame event handler
                //This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                videoSource.Start();
            
        }
        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Cast the frame as a Bitmap object  
            
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            stream.BackgroundImage = bitmap;

            frames.Add(bitmap);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            stream.BackgroundImage = null;
            colordata.Items.Clear();

            int centerx = 0;
            int centery = 0;

            List<Point> colorpts = new List<Point>();
            List<Point> centerpts = new List<Point>();
            List<Double> randoms = new List<Double>();

            centerpts.Clear();
            randoms.Clear();

            Point center = new Point(0, 0);

            List<Bitmap> framesbackup = new List<Bitmap>();

            foreach (Bitmap frame in frames) 
            {
                framesbackup.Add((Bitmap)frame.Clone());
            }

            var oldx = 0;
            var oldy = 0;

            for (int z = 0; z < frames.Count; z++)
            {
                Bitmap frame = frames[z];
                Graphics bgimage = Graphics.FromImage(frame); 

                //Goes through image as a pixel array and assigns number values to rgb colors, then assigns each selectedcolor pixel a marking space in an array
                int[,] data = new int[320, 240];
                
                    for (int i = 0; i < 320; i++)
                    {
                        for (int j = 0; j < 240; j++)
                        {   

                            Color PixelColor = frames[z].GetPixel(i, j);

                            if (Math.Abs(PixelColor.R - selectedcolor.R) < sensitivity.Value && Math.Abs(PixelColor.G - selectedcolor.B) < sensitivity.Value && Math.Abs(PixelColor.B - selectedcolor.B) < sensitivity.Value)
                            {

                                colorpts.Add(new Point(i,j));
                                
                                if (visuallytrack.Checked) //If option is checked, highlight pixels that fit color criteria 
                                {
                                    Pen pen = new Pen(Color.White, 2);
                                    bgimage.DrawRectangle(pen, i, j, 2, 2);
                                }

                            }
                        }
                    }

                    if (colorpts.Count > 0) //Center-finding code
                    {
                        int totalx = 0;
                        int totaly = 0;

                        foreach (Point p in colorpts)
                        {
                            totalx += p.X;
                            totaly += p.Y;
                        }

                        centerx = totalx / colorpts.Count;
                        centery = totaly / colorpts.Count;

                        center = new Point(centerx, centery);

                        if (visuallytrack.Checked) //Puts red point at center if visual tracking is enabled
                        {
                            Pen pen = new Pen(Color.Red, 3);
                            bgimage.DrawRectangle(pen, center.X, center.Y, 3, 3);
                        }

                        //Add center to list of center points 
                        centerpts.Add(center);

                        //Adds center point to displayed list
                        colordata.Items.Add(center);

                    }
                    
                    //Sets imagebox bg to image from bitmap array
                    stream.BackgroundImage = frame;
                    Application.DoEvents();
                    colorpts.Clear();

            }//End of foreach frame loop

            foreach (Point centerpt in centerpts) 
            {
                //Random number generator code
                var x = centerpt.X;
                var y = centerpt.Y;

                if (oldx != 0 && oldy != 0) //Ensures first point is rejected
                {
                    var deltax = x - oldx;
                    var deltay = y - oldy;
                    var deltaxy = deltax*deltay;

                    string combo = (Math.Abs(deltax + y) + "." + Math.Abs(deltay + x));

                    double xy = x * y;

                    if (xy!=0 && combo != "0.0" && deltaxy !=0) 
                    {
                        //Creates large number based off generator data

                        var seedvalue = Math.Ceiling( Math.Pow( Convert.ToDouble(combo) * Math.Abs(deltaxy) 
                            + Math.Pow(x,2), Convert.ToInt32(digitsofentropy.Text)  ) * Math.Pow(y,2) ) * (DateTime.Now.Millisecond + 1);
                        double bignumnoexp = double.Parse(Convert.ToString(seedvalue));
                        string bignum = bignumnoexp.ToString();

                        bignum = bignum.Substring(0, bignum.Length - 5);
                        //Gets last digits of seed number
                        int digits = Convert.ToInt32(digitsofentropy.Text);
                        int randomnum = Convert.ToInt32(bignum.Substring(bignum.Length - digits, digits));

                        var rand = new Random(randomnum).Next();
                        string randstr = Convert.ToString(rand);
                        randstr = randstr.Substring(randstr.Length - digits, digits);

                        if (randstr.Length == digits && randstr != null)
                        {
                            randoms.Add(Convert.ToDouble(randstr));
                            colordata.Items.Add(randstr);

                            StreamWriter writer = new StreamWriter("C:\\Users\\Pi\\Desktop\\random.txt", true);
                            writer.WriteLine(randstr);
                            writer.Close();
                        }

                        else { };

                    }

                }

                oldx = x;
                oldy = y;
            }

            frames = new List<Bitmap>();
            foreach (Bitmap frame in framesbackup)
            {
                frames.Add(frame);
            }
        }

        private void stream_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)stream.BackgroundImage;
            MouseEventArgs me = (MouseEventArgs)e;
            Color selectedpixel = bitmap.GetPixel(me.X, me.Y);
            colordata.Items.Add(selectedpixel);
            colordisplay.BackColor = selectedpixel;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            selectedcolor = colordisplay.BackColor;
            colorviewred.BackColor = selectedcolor;
        }

        private void webcams_SelectedIndexChanged(object sender, EventArgs e)
        {

            resolutionlist.Items.Clear();
            frames.Clear();

            //Use first video source
            videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString);

            //Populates webcam resolution list
            for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
            {
                resolutionlist.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString()); 
            }            
        }

        private void chop_Click(object sender, EventArgs e)
        {
            int chopped = Convert.ToInt32(numbertoremove.Text);
            frames.RemoveRange(0, chopped);
        }

        private void chop2_Click(object sender, EventArgs e)
        {
            int chopped = Convert.ToInt32(numbertoremove2.Text);

            for (int n = 0; n < chopped; n++)
            {
                frames.RemoveAt(frames.Count -1);
            }
        }
    }
}
