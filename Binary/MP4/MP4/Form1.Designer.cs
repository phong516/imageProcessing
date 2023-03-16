namespace MP4
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
            this.picBoxRGB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxBinary = new System.Windows.Forms.PictureBox();
            this.ScrollBar = new System.Windows.Forms.VScrollBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblThresholdDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBoxXam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBinary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXam)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxRGB
            // 
            this.picBoxRGB.Location = new System.Drawing.Point(23, 33);
            this.picBoxRGB.Name = "picBoxRGB";
            this.picBoxRGB.Size = new System.Drawing.Size(512, 512);
            this.picBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxRGB.TabIndex = 0;
            this.picBoxRGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình màu RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình Binary";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // picBoxBinary
            // 
            this.picBoxBinary.Location = new System.Drawing.Point(551, 33);
            this.picBoxBinary.Name = "picBoxBinary";
            this.picBoxBinary.Size = new System.Drawing.Size(512, 512);
            this.picBoxBinary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBinary.TabIndex = 2;
            this.picBoxBinary.TabStop = false;
            // 
            // ScrollBar
            // 
            this.ScrollBar.LargeChange = 20;
            this.ScrollBar.Location = new System.Drawing.Point(1105, 110);
            this.ScrollBar.Maximum = 255;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(35, 414);
            this.ScrollBar.SmallChange = 10;
            this.ScrollBar.TabIndex = 4;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            this.ScrollBar.ValueChanged += new System.EventHandler(this.ScrollBar_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(1069, 64);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(66, 17);
            this.lblThreshold.TabIndex = 5;
            this.lblThreshold.Text = "Ngưỡng: ";
            this.lblThreshold.Click += new System.EventHandler(this.lblThreshold_Click);
            // 
            // lblThresholdDisplay
            // 
            this.lblThresholdDisplay.AutoSize = true;
            this.lblThresholdDisplay.Location = new System.Drawing.Point(1069, 81);
            this.lblThresholdDisplay.Name = "lblThresholdDisplay";
            this.lblThresholdDisplay.Size = new System.Drawing.Size(0, 17);
            this.lblThresholdDisplay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1219, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hình mức xám";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // picBoxXam
            // 
            this.picBoxXam.Location = new System.Drawing.Point(1222, 33);
            this.picBoxXam.Name = "picBoxXam";
            this.picBoxXam.Size = new System.Drawing.Size(512, 512);
            this.picBoxXam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXam.TabIndex = 7;
            this.picBoxXam.TabStop = false;
            this.picBoxXam.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 1055);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBoxXam);
            this.Controls.Add(this.lblThresholdDisplay);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxBinary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBinary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxBinary;
        private System.Windows.Forms.VScrollBar ScrollBar;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblThresholdDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBoxXam;
    }
}

