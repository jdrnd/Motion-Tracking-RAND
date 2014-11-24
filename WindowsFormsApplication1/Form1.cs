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


namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {
        private FilterInfoCollection videosources;
        private VideoCaptureDevice videoSource;
        public Form1()
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

            int centerx;
            int centery;

            List<Point> colorpts = new List<Point>();
            List<Point> centerpts = new List<Point>();
            List<Double> randoms = new List<Double>();
            Point center = new Point(0, 0);


            var oldx = 1;
            var oldy = 1;

            foreach (Bitmap bitmap in frames)
            {   

                //Goes through image as a pixel array and assigns number values to rgb colors, then assigns each selectedcolor pixel a marking space in an array
                int[,] data = new int[320, 240];

                    for (int i = 0; i < 320; i++)
                    {
                        for (int j = 0; j < 240; j++)
                        {   

                            Color PixelColor = bitmap.GetPixel(i, j);

                            if (Math.Abs(PixelColor.R - selectedcolor.R) < sensitivity.Value && Math.Abs(PixelColor.G - selectedcolor.B) < sensitivity.Value && Math.Abs(PixelColor.B - selectedcolor.B) < sensitivity.Value)
                            {

                                colorpts.Add(new Point(i,j));
                                
                                if (visuallytrack.Checked) //If option is checked, highlight pixels that fit color criteria 
                                {
                                    Pen pen = new Pen(Color.White, 2);
                                    Graphics bgimage = Graphics.FromImage(bitmap);
                                    bgimage.DrawRectangle(pen, i, j, 2, 2);
                                }

                            }
                        }
                    }

                    if (colorpts.Count > 0) //Center-finding code
                    {
                        /* Sort points to find highest and lowest for each axis
                        List<Point> pointlistx = (from p in colorpts
                                                  orderby p.X ascending
                                                  select p).ToList<Point>();
                        */
                        int totalx = 0;
                        int totaly = 0;

                        foreach (Point p in colorpts)
                        {
                            totalx += p.X;
                            totaly += p.Y;
                        }

                        centerx = totalx / colorpts.Count;
                        centery = totaly / colorpts.Count;

                        //centerx = pointlistx.Sum / pointlistx.Count;

                        //centerx = pointlistx.ToArray<Point>()[pointlistx.Count / 2].X;

                        /* List<Point> pointlisty = (from p in colorpts
                                                  //orderby p.Y ascending
                                                  select p).ToList<Point>();
                        */

                        //centery = pointlisty.ToArray<Point>()[pointlisty.Count / 2].Y;


                        center = new Point(centerx, centery);

                        if (visuallytrack.Checked) //Puts red point at center if visual tracking is enabled
                        {
                            Pen pen = new Pen(Color.Red, 3);
                            Graphics bgimage = Graphics.FromImage(bitmap);
                            bgimage.DrawRectangle(pen, center.X, center.Y, 3, 3);
                        }
                        else { };

                        //Add center to list of center points 
                        centerpts.Add(center);

                        //Adds center point to displayed list
                        colordata.Items.Add(center);

                    }
                    else { };

                    //Sets imagebox bg to image from bitmap array
                    stream.BackgroundImage = bitmap;
                    Application.DoEvents();
                    colorpts.Clear();

            }//End of foreach frame loop

            foreach (Point centerpt in centerpts) 
            {
                //Random number generator code
                var x = centerpt.X;
                var y = centerpt.Y;

                if (oldx != 1 && oldy != 1) //Ensures first point is rejected
                {
                    var deltax = x - oldx;
                    var deltay = y - oldy;
                    var deltaxy = deltax*deltay;

                    string combo = (Math.Abs(deltax + y) + "." + Math.Abs(deltay + x));

                    double xy = x * y;

                    /* if (xy!=0 && combo != "0.0" && deltaxy !=0) 
                    {
                        //Creates large number based off generator data

                        var seedvalue = Math.Floor((Convert.ToDouble(combo) * deltaxy + Math.Pow(x,2) * Math.Pow(y,2)));
                        string bignum = seedvalue.ToString();

                        //Gets last 8 digits of seed number

                        int randomnum = Convert.ToInt32(bignum.Substring(bignum.Length - 8, 8));

                        var rand = new Random(randomnum).Next();
                        randoms.Add(randomnum);
                        colordata.Items.Add(randomnum);

                    } */

                }

                oldx = x;
                oldy = y;
            }

        }




        private void colordata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pixelpickerlabel_Click(object sender, EventArgs e)
        {

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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void visuallytrack_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void webcamselect_Click(object sender, EventArgs e)
        {

        }

        private void webcams_SelectedIndexChanged(object sender, EventArgs e)
        {

            resolutionlist.Items.Clear();
            frames.Clear();


            //Use first video source
            videoSource = new VideoCaptureDevice(videosources[webcams.SelectedIndex].MonikerString);

            try
            { }

            catch { }

            //Populates webcam resolution list
            for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
            {
                resolutionlist.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString()); 
            }

            
        }

        private void sensitivity_Scroll(object sender, EventArgs e)
        {

        }

        private void chop_Click(object sender, EventArgs e)
        {
            int chopped = Convert.ToInt32(numbertoremove.Text);
            frames.RemoveRange(0, chopped);
        }
 
        

    }
}
