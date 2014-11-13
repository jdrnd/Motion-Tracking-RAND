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
        List<Bitmap> frames = new List<Bitmap>();

        public Form1()
        {
            InitializeComponent();
        }

        //Create webcam object
        VideoCaptureDevice videoSource;

        //Declares blank RGB colors
        public static Color black = Color.FromArgb(0,0,0);

        private void start_Click(object sender, EventArgs e)
        {
            //List all available video sources
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources != null)
            {

                //Use first video source
                videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                try
                {
                    videoSource.VideoResolution = videoSource.VideoCapabilities[2];  
                }
                

                catch { }

                //Create NewFrame event handler
                //This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                videoSource.Start();
            }
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

                //Goes through image as a pixel array and assigns number values to rgb colors, then assigns each black pixel a marking space in an array
                int[,] data = new int[320, 240];

                    for (int i = 0; i < 320; i++)
                    {
                        for (int j = 0; j < 240; j++)
                        {   

                            Color PixelColor = bitmap.GetPixel(i, j);

                            if (Math.Abs(PixelColor.R - black.R) < 20 && Math.Abs(PixelColor.G - black.B) < 20 && Math.Abs(PixelColor.B - black.B) < 20)
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
                        //Sort points to find highest and lowest for each axis
                        List<Point> pointlistx = (from p in colorpts
                                                  orderby p.X ascending
                                                  select p).ToList<Point>();

                        centerx = pointlistx.ToArray<Point>()[pointlistx.Count / 2].X;

                        List<Point> pointlisty = (from p in colorpts
                                                  orderby p.Y ascending
                                                  select p).ToList<Point>();


                        centery = pointlisty.ToArray<Point>()[pointlisty.Count / 2].Y;

                        
                        center = new Point(centerx, centery);

                        //Add center to list of center points 
                        centerpts.Add(center);

                        //Adds center point to displayed list
                        colordata.Items.Add(center);

                    }

                    if (visuallytrack.Checked) //Puts red point at center if visual tracking is enabled
                    {
                        Pen pen = new Pen(Color.Red, 3);
                        Graphics bgimage = Graphics.FromImage(bitmap);
                        bgimage.DrawRectangle(pen, center.X, center.Y, 3, 3);
                    }

                    //Sets imagebox bg to image from bitmap array
                    stream.BackgroundImage = bitmap;
                    Application.DoEvents();
    
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

                    if (xy!=0 && combo != "0.0" && deltaxy !=0) 
                    {
                        //Creates large number based off generator data

                        var reallybignumber = Convert.ToDouble(combo) * deltaxy;
                        string bgnum = reallybignumber.ToString();

                        //Gets last 8 digits of large number

                        double randomnum = Convert.ToDouble(bgnum.Substring(bgnum.Length - 8, 8));
                        randoms.Add(randomnum);
                        colordata.Items.Add(randomnum);

                    }

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
            black = colordisplay.BackColor;
            colorviewred.BackColor = black;
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
 
        

    }
}
