/* Motion Tracking and Entropy Generator Copyright (C) 2014 Joel Ruhland

This program is free software: you can redistribute it and/or modify it under the terms of the 
GNU General Public License as published by the Free Software Foundation, either version 3 of 
the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

Please view the included "GNUGPLv3" file for full licencing terms.*/

//All Project Code is available at https://github.com/underdiver/Motion-Tracking-BASEF/


//Imports standard system libraries
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

//Imports Random Number Generator (Mersenne Twister) 
using MathNet.Numerics.Random;
using MathNet.Numerics.Distributions;


//Imports file in/out library
using System.IO;

namespace motiontracking
{


    public partial class MainWindow : Form
    {
        //Creates objecst to store information on availible capture devices
        private FilterInfoCollection videosources;
        private VideoCaptureDevice videoSource;

        //Code that runs on program startup, initialises the program
        public MainWindow()
        {
            //Lists all available video sources
            InitializeComponent();
            videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Adds each webcams to options list
            foreach (FilterInfo VideoCaptureDevice in videosources)
            {
                webcams.Items.Add(VideoCaptureDevice.Name);
            }

            //Sets default webcam to first in list
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

        //Code that runs when the start button is pushed
        private void start_Click(object sender, EventArgs e)
        {
                //Clears an existing video footage and sets video source/resolution
                frames.Clear();
                videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString); 
                videoSource.VideoResolution = videoSource.VideoCapabilities[resolutionlist.SelectedIndex];

                //Creates NewFrame event handler that triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Starts recording
                videoSource.Start();
            
        }

        //Code that runs when a new frame event occurs 
        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            //Casts the frame as a Bitmap object
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            //Displays frames as they come in, as a semi-live video feed
            stream.BackgroundImage = bitmap;

            //Adds frame to frame list for playback
            frames.Add(bitmap);
        }

        //Code that runs when the stop button is pushed
        private void stop_Click(object sender, EventArgs e)
        {

            //Checks to make sure a video source is selected and stops the source if it is
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }

        }

        //Code that runs whenthe analize button is pushed
        private void analyse_Click(object sender, EventArgs e)
        {

            //Checks to ensure that the number in the digits of entropy box is in the correct range
            if (0 < (Convert.ToInt32(digitsofentropy.Text)) &&  (Convert.ToInt32(digitsofentropy.Text)) < 9) 
            {
            }
            else
            {
                output_window.Items.Add("Please enter a number of digits between 1 and 8");
                return;
            }

            //Clear the display screen
            stream.BackgroundImage = null;

            //Declares lists to be used 
            List<Point> colorpts = new List<Point>();
            List<Point> centerpts = new List<Point>();
            List<Double> randoms = new List<Double>();

            //Declared variables to be used
            int randoms_generated = 0;
            int centerx = 0;
            int centery = 0;
            var oldx = 0;
            var oldy = 0;

            //Declares center point 'holder' variable
            Point center = new Point(0, 0);

            //Copies all frames into a backup list
            //(So that if frames are drawn on the originals can be restored)
            List<Bitmap> framesbackup = new List<Bitmap>();
            foreach (Bitmap frame in frames) 
            {
                framesbackup.Add((Bitmap)frame.Clone());
            }


            //Main center-finding code
            for (int z = 0; z < frames.Count; z++)
            {

                //Selects the bitmap image to be processed
                Bitmap frame = frames[z];
                Graphics bgimage = Graphics.FromImage(frame); 

                //Goes through image as a pixel array and checks if pixels fit color criteria
                int[,] data = new int[320, 240];

                    //Loops through all x-coordinates
                    for (int i = 0; i < 320; i++)
                    {
                        //Loops throught all y-coordinates
                        for (int j = 0; j < 240; j++)
                        {   
                            //Gets pixel color at selected pixel
                            Color PixelColor = frames[z].GetPixel(i, j);

                            //Checks if pixel's red, green, and blue values meets color criteria
                            if (Math.Abs(PixelColor.R - selectedcolor.R) < sensitivity.Value 
                                && Math.Abs(PixelColor.G - selectedcolor.B) < sensitivity.Value 
                                && Math.Abs(PixelColor.B - selectedcolor.B) < sensitivity.Value)
                            {
                                //If pixel mathces, it is added to a list of matching pixels
                                colorpts.Add(new Point(i,j));

                                //If option is checked, highlight pixels that fit color criteria 
                                if (visuallytrack.Checked) 
                                {
                                    //Highlights pixels by drawing on the displayed image
                                    Pen pen = new Pen(Color.White, 2);
                                    bgimage.DrawRectangle(pen, i, j, 2, 2);
                                }

                            }
                        }
                    }

                    //Center-finding code, makes sure frame contains at least 1 matching pixel before continuing 
                    if (colorpts.Count > 0) 
                    {
                        //Declares variables to be used in finding the center
                        int totalx = 0;
                        int totaly = 0;

                        //Finds mean x and y coordinates
                        foreach (Point p in colorpts)
                        {
                            totalx += p.X;
                            totaly += p.Y;
                        }
                        centerx = totalx / colorpts.Count;
                        centery = totaly / colorpts.Count;

                        //Creates combined center point and highlights it if option is checked
                        center = new Point(centerx, centery);
                        if (visuallytrack.Checked) 
                        {
                            Pen pen = new Pen(Color.Red, 3);
                            bgimage.DrawRectangle(pen, center.X, center.Y, 3, 3);
                        }

                        //Add center to list of center points 
                        centerpts.Add(center);

                        //Adds center point to displayed list
                        output_window.Items.Add(center);

                    }
                    
                    //Sets imagebox display to image from bitmap array
                    stream.BackgroundImage = frame;
                    Application.DoEvents();

                    //Clears pixel data from the frame
                    colorpts.Clear();

            }//End of foreach frame loop

            //Processes all centerpoints from the video
            foreach (Point centerpt in centerpts) 
            {

                //Breaks centerpoint into x and y components
                var x = centerpt.X;
                var y = centerpt.Y;

                //Exits if enough numbers have been generated
                if (randoms_generated >= Convert.ToInt32(number_of_numbers.Text) ) 
                {
                    break;
                }

                //Does not process the first frame because there is no preceding frame to compare with
                if (oldx != 0 && oldy != 0)
                {

                    //Finds change in position in x and y
                    var deltax = x - oldx;
                    var deltay = y - oldy;

                    //Declares the products of the coordinates and the changes thereof
                    double xy = x * y;
                    double deltaxy = deltax * deltay;

                    //Disregards frames in which there is no change in position
                    if (xy!=0 && deltaxy !=0) 
                    {
                        
                        //Creates a seed value
                        var seedvalue = Math.Abs( ((xy*deltax)/deltay) * (DateTime.Now.Millisecond + 1) );

                        //Creates random number generator instance with the derived seed value
                        var random = new MersenneTwister(Convert.ToInt32(seedvalue)); 
                        int randint = random.Next();

                        //Does not add generated number to randoms list if enough random numbers have been generated
                        if (randoms.Count < Convert.ToInt32(number_of_numbers.Text))
                        {
                            randoms_generated += 1;
                            randoms.Add(randint);
                            
                        }

                        //Generates 20 random numbers
                        for (int z = 0; z < 20; z++)
                        {
                            //Ensures that the program does not generate more numbers than needed
                            if (randoms.Count < Convert.ToInt32(number_of_numbers.Text))
                            {
                                randint = random.Next();
                                randoms.Add(randint);
                                randoms_generated += 1;

                            }

                            //Exits subroutine if enough number have been generated
                            else
                            {
                                break;
                            }
                      } 

                    }

                }

                //Decleares 'old' x and y values to use with the enxt frame
                oldx = x;
                oldy = y;
            }

            //Initialises file writer
            string filepath = "C:\\Users\\Pi\\Desktop\\random.txt";
            StreamWriter writer = new StreamWriter(filepath, true);

            //Removes leading digits of random numbers so output numbers are the correct number of digits
            foreach (int randint in randoms)
            {
                string randintstr = Convert.ToString(randint);
                randintstr = randintstr.Substring(randintstr.Length - Convert.ToInt32(digitsofentropy.Text) );
                output_window.Items.Add(randintstr);
                writer.WriteLine(randintstr);
            }

            //Closes file writer
            writer.Close();

            //Restores video frames from backup list and clears backup list
            frames = new List<Bitmap>();
            foreach (Bitmap frame in framesbackup)
            {
                frames.Add(frame);

            }
            framesbackup.Clear();


            //Clears all stored color, center, and random data 
            output_window.Items.Clear();
            centerpts.Clear();
            randoms.Clear();
        }

        //Code that runs when a pixel in the display area is clicked
        private void stream_Click(object sender, EventArgs e)
        {
            //Outputs color data from a pixel on the display screen when it is clicked
            //Used for exact color calibration
            Bitmap bitmap = (Bitmap)stream.BackgroundImage;
            MouseEventArgs me = (MouseEventArgs)e;
            Color selectedpixel = bitmap.GetPixel(me.X, me.Y);
            output_window.Items.Add(selectedpixel);
            colordisplay.BackColor = selectedpixel;
        }

        //Code that runs when the calibrate button is pushed
        private void calibrate_Click_1(object sender, EventArgs e)
        {
            //Shows selected color in preview area
            selectedcolor = colordisplay.BackColor;
            colorview.BackColor = selectedcolor;
        }


        //Code that runs when the selected webcam device is changed
        private void webcams_SelectedIndexChanged(object sender, EventArgs e)
        {

            resolutionlist.Items.Clear();
            frames.Clear();

            //Changes video source to selected webcam
            videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString);

            //Populates webcam resolution list
            for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
            {
                resolutionlist.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString()); 
            }            
        }


        //Chops the selected number of frames from the beginning on the video
        private void chop_Click(object sender, EventArgs e)
        {
            int chopped = Convert.ToInt32(numbertoremove.Text);
            frames.RemoveRange(0, chopped);
        }

        //Chops the selected number of frames from the end of the video
        private void chop2_Click(object sender, EventArgs e)
        {
            int chopped = Convert.ToInt32(numbertoremove2.Text);

            for (int n = 0; n < chopped; n++)
            {
                frames.RemoveAt(frames.Count -1);
            }
        }

        //When the webcam resolution is change, changes the webcam resolution option
        //And resizes the video display area
        private void resolutionlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString); 
            videoSource.VideoResolution = videoSource.VideoCapabilities[resolutionlist.SelectedIndex];
            stream.Size = new Size(videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height);
        }



    }
}
