namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.stream = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.analyse = new System.Windows.Forms.Button();
            this.colordata = new System.Windows.Forms.ListBox();
            this.pixelpickerlabel = new System.Windows.Forms.Label();
            this.calibratered = new System.Windows.Forms.Button();
            this.colorlabel = new System.Windows.Forms.Label();
            this.colordisplay = new System.Windows.Forms.Panel();
            this.colorviewred = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.visuallytrack = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.stream)).BeginInit();
            this.SuspendLayout();
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
            this.analyse.Click += new System.EventHandler(this.button1_Click);
            // 
            // colordata
            // 
            this.colordata.FormattingEnabled = true;
            this.colordata.Location = new System.Drawing.Point(366, 13);
            this.colordata.Name = "colordata";
            this.colordata.Size = new System.Drawing.Size(248, 238);
            this.colordata.TabIndex = 4;
            this.colordata.SelectedIndexChanged += new System.EventHandler(this.colordata_SelectedIndexChanged);
            // 
            // pixelpickerlabel
            // 
            this.pixelpickerlabel.AutoSize = true;
            this.pixelpickerlabel.Location = new System.Drawing.Point(620, 13);
            this.pixelpickerlabel.Name = "pixelpickerlabel";
            this.pixelpickerlabel.Size = new System.Drawing.Size(132, 13);
            this.pixelpickerlabel.TabIndex = 5;
            this.pixelpickerlabel.Text = "Click a pixel to get its color";
            this.pixelpickerlabel.Click += new System.EventHandler(this.pixelpickerlabel_Click);
            // 
            // calibratered
            // 
            this.calibratered.Location = new System.Drawing.Point(366, 274);
            this.calibratered.Name = "calibratered";
            this.calibratered.Size = new System.Drawing.Size(94, 23);
            this.calibratered.TabIndex = 6;
            this.calibratered.Text = "Calibrate";
            this.calibratered.UseVisualStyleBackColor = true;
            this.calibratered.Click += new System.EventHandler(this.button1_Click_1);
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
            // colorviewred
            // 
            this.colorviewred.Location = new System.Drawing.Point(366, 303);
            this.colorviewred.Name = "colorviewred";
            this.colorviewred.Size = new System.Drawing.Size(18, 15);
            this.colorviewred.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Visually Track?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // visuallytrack
            // 
            this.visuallytrack.AutoSize = true;
            this.visuallytrack.Location = new System.Drawing.Point(710, 135);
            this.visuallytrack.Name = "visuallytrack";
            this.visuallytrack.Size = new System.Drawing.Size(14, 13);
            this.visuallytrack.TabIndex = 15;
            this.visuallytrack.TabStop = true;
            this.visuallytrack.UseVisualStyleBackColor = true;
            this.visuallytrack.CheckedChanged += new System.EventHandler(this.visuallytrack_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 330);
            this.Controls.Add(this.visuallytrack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorviewred);
            this.Controls.Add(this.colordisplay);
            this.Controls.Add(this.colorlabel);
            this.Controls.Add(this.calibratered);
            this.Controls.Add(this.pixelpickerlabel);
            this.Controls.Add(this.colordata);
            this.Controls.Add(this.analyse);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.stream);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stream;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button analyse;
        private System.Windows.Forms.ListBox colordata;
        private System.Windows.Forms.Label pixelpickerlabel;
        private System.Windows.Forms.Button calibratered;
        private System.Windows.Forms.Label colorlabel;
        private System.Windows.Forms.Panel colordisplay;
        private System.Windows.Forms.Panel colorviewred;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton visuallytrack;
    }
}

