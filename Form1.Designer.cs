namespace motiontracking
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button chop;
            System.Windows.Forms.Button chop2;
            this.stream = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.analyse = new System.Windows.Forms.Button();
            this.output_window = new System.Windows.Forms.ListBox();
            this.pixelpickerlabel = new System.Windows.Forms.Label();
            this.calibrate = new System.Windows.Forms.Button();
            this.colorlabel = new System.Windows.Forms.Label();
            this.colordisplay = new System.Windows.Forms.Panel();
            this.colorview = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.webcams = new System.Windows.Forms.ComboBox();
            this.webcamselect = new System.Windows.Forms.Label();
            this.reslist = new System.Windows.Forms.Label();
            this.resolutionlist = new System.Windows.Forms.ComboBox();
            this.sensitivity = new System.Windows.Forms.TrackBar();
            this.sensitive = new System.Windows.Forms.Label();
            this.choplabel = new System.Windows.Forms.Label();
            this.numbertoremove = new System.Windows.Forms.TextBox();
            this.chop2label = new System.Windows.Forms.Label();
            this.numbertoremove2 = new System.Windows.Forms.TextBox();
            this.digitslabel = new System.Windows.Forms.Label();
            this.digitsofentropy = new System.Windows.Forms.TextBox();
            this.visuallytrack = new System.Windows.Forms.CheckBox();
            this.number_of_numbers = new System.Windows.Forms.TextBox();
            this.numbers = new System.Windows.Forms.Label();
            chop = new System.Windows.Forms.Button();
            chop2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // chop
            // 
            chop.Location = new System.Drawing.Point(343, 26);
            chop.Name = "chop";
            chop.Size = new System.Drawing.Size(75, 23);
            chop.TabIndex = 24;
            chop.Text = "Chop";
            chop.UseVisualStyleBackColor = true;
            chop.Click += new System.EventHandler(this.chop_Click);
            // 
            // chop2
            // 
            chop2.Location = new System.Drawing.Point(345, 90);
            chop2.Name = "chop2";
            chop2.Size = new System.Drawing.Size(75, 23);
            chop2.TabIndex = 27;
            chop2.Text = "Chop";
            chop2.UseVisualStyleBackColor = true;
            chop2.Click += new System.EventHandler(this.chop2_Click);
            // 
            // stream
            // 
            this.stream.Location = new System.Drawing.Point(13, 13);
            this.stream.Name = "stream";
            this.stream.Size = new System.Drawing.Size(320, 240);
            this.stream.TabIndex = 0;
            this.stream.TabStop = false;
            this.stream.Click += new System.EventHandler(this.stream_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 274);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(93, 274);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // analyse
            // 
            this.analyse.Location = new System.Drawing.Point(174, 274);
            this.analyse.Name = "analyse";
            this.analyse.Size = new System.Drawing.Size(75, 23);
            this.analyse.TabIndex = 3;
            this.analyse.Text = "Analyse";
            this.analyse.UseVisualStyleBackColor = true;
            this.analyse.Click += new System.EventHandler(this.analyse_Click);
            // 
            // output_window
            // 
            this.output_window.FormattingEnabled = true;
            this.output_window.Location = new System.Drawing.Point(510, 12);
            this.output_window.Name = "output_window";
            this.output_window.Size = new System.Drawing.Size(104, 238);
            this.output_window.TabIndex = 4;
            // 
            // pixelpickerlabel
            // 
            this.pixelpickerlabel.AutoSize = true;
            this.pixelpickerlabel.Location = new System.Drawing.Point(620, 13);
            this.pixelpickerlabel.Name = "pixelpickerlabel";
            this.pixelpickerlabel.Size = new System.Drawing.Size(132, 13);
            this.pixelpickerlabel.TabIndex = 5;
            this.pixelpickerlabel.Text = "Click a pixel to get its color";
            // 
            // calibrate
            // 
            this.calibrate.Location = new System.Drawing.Point(630, 274);
            this.calibrate.Name = "calibrate";
            this.calibrate.Size = new System.Drawing.Size(94, 23);
            this.calibrate.TabIndex = 6;
            this.calibrate.Text = "Calibrate";
            this.calibrate.UseVisualStyleBackColor = true;
            this.calibrate.Click += new System.EventHandler(this.calibrate_Click_1);
            // 
            // colorlabel
            // 
            this.colorlabel.AutoSize = true;
            this.colorlabel.Location = new System.Drawing.Point(623, 45);
            this.colorlabel.Name = "colorlabel";
            this.colorlabel.Size = new System.Drawing.Size(68, 13);
            this.colorlabel.TabIndex = 9;
            this.colorlabel.Text = "Current Color";
            // 
            // colordisplay
            // 
            this.colordisplay.Location = new System.Drawing.Point(626, 74);
            this.colordisplay.Name = "colordisplay";
            this.colordisplay.Size = new System.Drawing.Size(56, 38);
            this.colordisplay.TabIndex = 10;
            // 
            // colorview
            // 
            this.colorview.Location = new System.Drawing.Point(630, 303);
            this.colorview.Name = "colorview";
            this.colorview.Size = new System.Drawing.Size(18, 15);
            this.colorview.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Visually Track?";
            // 
            // webcams
            // 
            this.webcams.FormattingEnabled = true;
            this.webcams.Location = new System.Drawing.Point(366, 275);
            this.webcams.Name = "webcams";
            this.webcams.Size = new System.Drawing.Size(121, 21);
            this.webcams.TabIndex = 16;
            this.webcams.SelectedIndexChanged += new System.EventHandler(this.webcams_SelectedIndexChanged);
            // 
            // webcamselect
            // 
            this.webcamselect.AutoSize = true;
            this.webcamselect.Location = new System.Drawing.Point(366, 258);
            this.webcamselect.Name = "webcamselect";
            this.webcamselect.Size = new System.Drawing.Size(104, 13);
            this.webcamselect.TabIndex = 17;
            this.webcamselect.Text = "1. Select a Webcam";
            // 
            // reslist
            // 
            this.reslist.AutoSize = true;
            this.reslist.Location = new System.Drawing.Point(514, 258);
            this.reslist.Name = "reslist";
            this.reslist.Size = new System.Drawing.Size(104, 13);
            this.reslist.TabIndex = 18;
            this.reslist.Text = "2. SelectResolutions";
            // 
            // resolutionlist
            // 
            this.resolutionlist.FormattingEnabled = true;
            this.resolutionlist.Location = new System.Drawing.Point(517, 274);
            this.resolutionlist.Name = "resolutionlist";
            this.resolutionlist.Size = new System.Drawing.Size(97, 21);
            this.resolutionlist.TabIndex = 19;
            this.resolutionlist.SelectedIndexChanged += new System.EventHandler(this.resolutionlist_SelectedIndexChanged);
            // 
            // sensitivity
            // 
            this.sensitivity.LargeChange = 10;
            this.sensitivity.Location = new System.Drawing.Point(256, 273);
            this.sensitivity.Maximum = 100;
            this.sensitivity.Name = "sensitivity";
            this.sensitivity.Size = new System.Drawing.Size(104, 45);
            this.sensitivity.SmallChange = 5;
            this.sensitivity.TabIndex = 20;
            this.sensitivity.TickFrequency = 10;
            this.sensitivity.UseWaitCursor = true;
            this.sensitivity.Value = 20;
            // 
            // sensitive
            // 
            this.sensitive.AutoSize = true;
            this.sensitive.Location = new System.Drawing.Point(279, 303);
            this.sensitive.Name = "sensitive";
            this.sensitive.Size = new System.Drawing.Size(54, 13);
            this.sensitive.TabIndex = 21;
            this.sensitive.Text = "Sensitivity";
            // 
            // choplabel
            // 
            this.choplabel.AutoSize = true;
            this.choplabel.Location = new System.Drawing.Point(340, 10);
            this.choplabel.Name = "choplabel";
            this.choplabel.Size = new System.Drawing.Size(128, 13);
            this.choplabel.TabIndex = 22;
            this.choplabel.Text = "Remove Leading Frames:";
            // 
            // numbertoremove
            // 
            this.numbertoremove.Location = new System.Drawing.Point(474, 10);
            this.numbertoremove.Name = "numbertoremove";
            this.numbertoremove.Size = new System.Drawing.Size(28, 20);
            this.numbertoremove.TabIndex = 23;
            // 
            // chop2label
            // 
            this.chop2label.AutoSize = true;
            this.chop2label.Location = new System.Drawing.Point(342, 74);
            this.chop2label.Name = "chop2label";
            this.chop2label.Size = new System.Drawing.Size(124, 13);
            this.chop2label.TabIndex = 25;
            this.chop2label.Text = "Remove Trailing Frames:";
            // 
            // numbertoremove2
            // 
            this.numbertoremove2.Location = new System.Drawing.Point(474, 71);
            this.numbertoremove2.Name = "numbertoremove2";
            this.numbertoremove2.Size = new System.Drawing.Size(28, 20);
            this.numbertoremove2.TabIndex = 26;
            // 
            // digitslabel
            // 
            this.digitslabel.AutoSize = true;
            this.digitslabel.Location = new System.Drawing.Point(342, 135);
            this.digitslabel.Name = "digitslabel";
            this.digitslabel.Size = new System.Drawing.Size(108, 13);
            this.digitslabel.TabIndex = 28;
            this.digitslabel.Text = "Digits of Entropy (1-8)";
            this.digitslabel.UseWaitCursor = true;
            // 
            // digitsofentropy
            // 
            this.digitsofentropy.Location = new System.Drawing.Point(474, 132);
            this.digitsofentropy.Name = "digitsofentropy";
            this.digitsofentropy.Size = new System.Drawing.Size(28, 20);
            this.digitsofentropy.TabIndex = 29;
            this.digitsofentropy.Text = "5";
            // 
            // visuallytrack
            // 
            this.visuallytrack.AutoSize = true;
            this.visuallytrack.Location = new System.Drawing.Point(711, 135);
            this.visuallytrack.Name = "visuallytrack";
            this.visuallytrack.Size = new System.Drawing.Size(15, 14);
            this.visuallytrack.TabIndex = 30;
            this.visuallytrack.UseVisualStyleBackColor = true;
            // 
            // number_of_numbers
            // 
            this.number_of_numbers.Location = new System.Drawing.Point(341, 189);
            this.number_of_numbers.Name = "number_of_numbers";
            this.number_of_numbers.Size = new System.Drawing.Size(163, 20);
            this.number_of_numbers.TabIndex = 31;
            this.number_of_numbers.Text = "100";
            // 
            // numbers
            // 
            this.numbers.AutoSize = true;
            this.numbers.Location = new System.Drawing.Point(343, 170);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(108, 13);
            this.numbers.TabIndex = 32;
            this.numbers.Text = "Numbers to Generate";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(767, 330);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.number_of_numbers);
            this.Controls.Add(this.visuallytrack);
            this.Controls.Add(this.digitsofentropy);
            this.Controls.Add(this.digitslabel);
            this.Controls.Add(chop2);
            this.Controls.Add(this.numbertoremove2);
            this.Controls.Add(this.chop2label);
            this.Controls.Add(chop);
            this.Controls.Add(this.numbertoremove);
            this.Controls.Add(this.choplabel);
            this.Controls.Add(this.sensitive);
            this.Controls.Add(this.sensitivity);
            this.Controls.Add(this.resolutionlist);
            this.Controls.Add(this.reslist);
            this.Controls.Add(this.webcamselect);
            this.Controls.Add(this.webcams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorview);
            this.Controls.Add(this.colordisplay);
            this.Controls.Add(this.colorlabel);
            this.Controls.Add(this.calibrate);
            this.Controls.Add(this.pixelpickerlabel);
            this.Controls.Add(this.output_window);
            this.Controls.Add(this.analyse);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.stream);
            this.Name = "MainWindow";
            this.Text = "Motion Tracking";
            ((System.ComponentModel.ISupportInitialize)(this.stream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stream;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button analyse;
        private System.Windows.Forms.ListBox output_window;
        private System.Windows.Forms.Label pixelpickerlabel;
        private System.Windows.Forms.Button calibrate;
        private System.Windows.Forms.Label colorlabel;
        private System.Windows.Forms.Panel colordisplay;
        private System.Windows.Forms.Panel colorview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox webcams;
        private System.Windows.Forms.Label webcamselect;
        private System.Windows.Forms.Label reslist;
        private System.Windows.Forms.ComboBox resolutionlist;
        private System.Windows.Forms.TrackBar sensitivity;
        private System.Windows.Forms.Label sensitive;
        private System.Windows.Forms.Label choplabel;
        private System.Windows.Forms.TextBox numbertoremove;
        private System.Windows.Forms.Label chop2label;
        private System.Windows.Forms.TextBox numbertoremove2;
        private System.Windows.Forms.Label digitslabel;
        private System.Windows.Forms.TextBox digitsofentropy;
        private System.Windows.Forms.CheckBox visuallytrack;
        private System.Windows.Forms.TextBox number_of_numbers;
        private System.Windows.Forms.Label numbers;
    }
}

