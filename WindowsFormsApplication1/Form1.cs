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
                //(This one triggers every time a new frame/image is captured
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

            foreach (Bitmap bitmap in frames)
            {   
                //Color viewer
                //if (xcoordinate.Text != null && ycoordinate.Text != null)
                //{
                //    int x = int.Parse(xcoordinate.Text);
                //    int y = int.Parse(ycoordinate.Text);
                //    colordata.Items.Add(bitmap.GetPixel(x, y));
                //}

                //Sets imagebox bg to image from bitmap array
                stream.BackgroundImage = bitmap;
                Application.DoEvents();

                //Code to draw rectangle around selected pixel for color viewer
                //Pen pen = new Pen(Color.White, 2);
                //Graphics bgimage = Graphics.FromImage(stream.BackgroundImage);
                //bgimage.DrawRectangle(pen, x, y, 7, 7);

                
                //Goes through image as a pixel array and assigns number values to rgb colors, then assigns each r, g or b pixel a marking space in an array
                int[,] data = new int[320, 240];


                /*Makes sure colors have been calibrated
                if (backgcolor == Color.FromArgb(0, 0, 0))
                        {
                            colordata.Items.Add("Please calibrate");
                            break;
                        }
                 * 
                else {
                  */
                    for (int i = 0; i < 320; i++)
                    {
                        for (int j = 0; j < 240; j++)
                        {   

                            Color PixelColor = bitmap.GetPixel(i, j);

                            //1 is added to color value to prevent dividing by 0

                            if (Math.Abs(PixelColor.R - black.R) < 20 && Math.Abs(PixelColor.G - black.B) < 20 && Math.Abs(PixelColor.B - black.B) < 20)
                            {
                                data[i, j] = 1;
                                Debug.Write("1");
                                if (visuallytrack.Checked)
                                {
                                    Pen pen = new Pen(Color.White, 2);
                                    Graphics bgimage = Graphics.FromImage(stream.BackgroundImage);
                                    bgimage.DrawRectangle(pen, i, j, 2, 2);
                                }
                            }
                            //else if (Math.Abs(PixelColor.R - green.R) < 20 && Math.Abs(PixelColor.G - green.G) < 20 && Math.Abs(PixelColor.B - green.B) < 20)
                            //{
                            //    data[i, j] = 2;
                            //    Debug.Write("2");
                            //    ;
                            //}
                            //else if (Math.Abs(PixelColor.R - blue.R) < 20 && Math.Abs(PixelColor.G - blue.G) < 20 && Math.Abs(PixelColor.B - blue.B) < 20)
                            //{
                            //    data[i, j] = 3;
                            //    Debug.Write("3");
                            //}
                            else
                            {
                                data[i, j] = 0;

                            }
                        }

                    
                    }
                
            }
        }

            // Passes colored pixels to debug console

            //    for (int i = 0; i < 320; i++)
            ////    {

            ////        for (int j = 0; j < 240; j++)
            ////        {

            ////            if (data[i, j] > 0)
            ////            {
            ////                Debug.Write(data[i, j] + ",");
            ////            }
            ////        }

            ////    }
            ////}


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
 
        

    }
}
