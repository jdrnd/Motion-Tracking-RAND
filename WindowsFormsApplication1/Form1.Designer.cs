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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xcoordinate = new System.Windows.Forms.TextBox();
            this.ycoordinate = new System.Windows.Forms.TextBox();
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
            this.pixelpickerlabel.Size = new System.Drawing.Size(135, 13);
            this.pixelpickerlabel.TabIndex = 5;
            this.pixelpickerlabel.Text = "Enter coordinates of a pixel";
            this.pixelpickerlabel.Click += new System.EventHandler(this.pixelpickerlabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(623, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "y";
            // 
            // xcoordinate
            // 
            this.xcoordinate.Location = new System.Drawing.Point(651, 30);
            this.xcoordinate.Name = "xcoordinate";
            this.xcoordinate.Size = new System.Drawing.Size(100, 20);
            this.xcoordinate.TabIndex = 8;
            // 
            // ycoordinate
            // 
            this.ycoordinate.Location = new System.Drawing.Point(651, 57);
            this.ycoordinate.Name = "ycoordinate";
            this.ycoordinate.Size = new System.Drawing.Size(100, 20);
            this.ycoordinate.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 330);
            this.Controls.Add(this.ycoordinate);
            this.Controls.Add(this.xcoordinate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pixelpickerlabel);
            this.Controls.Add(this.colordata);
            this.Controls.Add(this.analyse);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.stream);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xcoordinate;
        private System.Windows.Forms.TextBox ycoordinate;
    }
}

