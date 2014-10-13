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
            this.Analyse = new System.Windows.Forms.Button();
            this.colordata = new System.Windows.Forms.ListBox();
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
            // Analyse
            // 
            this.Analyse.Location = new System.Drawing.Point(174, 274);
            this.Analyse.Name = "Analyse";
            this.Analyse.Size = new System.Drawing.Size(75, 23);
            this.Analyse.TabIndex = 3;
            this.Analyse.Text = "Analyse";
            this.Analyse.UseVisualStyleBackColor = true;
            this.Analyse.Click += new System.EventHandler(this.button1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 330);
            this.Controls.Add(this.colordata);
            this.Controls.Add(this.Analyse);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.stream);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stream)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox stream;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button Analyse;
        private System.Windows.Forms.ListBox colordata;
    }
}

