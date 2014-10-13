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

//Imports AForge libraries
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
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
            videoSource.SignalToStop();
            videoSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stream.BackgroundImage = null;

            foreach (Bitmap bitmap in frames)
            {
                stream.BackgroundImage = bitmap;

                Application.DoEvents();

                //Goes through image as a pixel array and assigns number values to rgb colors

                int[,] data = new int[320, 240];

                for (int i = 0; i < 320; i++)
                {
                    for (int j = 0; j < 240; j++)
                    {
                        Color Color = bitmap.GetPixel( i, j);
                        if (Color.R > 0.5f && Color.R < 1f)
                        {
                            data[i, i] = 1;
                        }
                        else if (Color.G > 0.5f && Color.G < 1f)
                        {
                            data[i, j] = 2;
                        }
                        else if (Color.B > 0.5f && Color.B < 1f)
                        {
                            data[i, j] = 3;
                            Console.Write("Blue");
                        }
                        else
                        {
                            data[i, j] = 0;
                            
                        }

                    }
                }

                //Passes colored pixels to array display box

                for (int i = 0; i < 320; i++)
                {

                    for (int j = 0; j < 240; j++)
                    {

                        if (data[i, j] > 0)
                        {
                            colordata.Items.Add(data[i, j].ToString());
                        }
                    }

                }
            }
        }
        private void colordata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
        

    }
}
