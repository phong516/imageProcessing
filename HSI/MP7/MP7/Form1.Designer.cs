namespace MP7
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
            this.picboxRGB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picboxIntensity = new System.Windows.Forms.PictureBox();
            this.picboxHue = new System.Windows.Forms.PictureBox();
            this.picboxSaturation = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picboxHSI = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHSI)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxRGB
            // 
            this.picboxRGB.Location = new System.Drawing.Point(12, 24);
            this.picboxRGB.Name = "picboxRGB";
            this.picboxRGB.Size = new System.Drawing.Size(512, 512);
            this.picboxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxRGB.TabIndex = 0;
            this.picboxRGB.TabStop = false;
            this.picboxRGB.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình Hue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hình Saturation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hình Intensity";
            // 
            // picboxIntensity
            // 
            this.picboxIntensity.Location = new System.Drawing.Point(569, 558);
            this.picboxIntensity.Name = "picboxIntensity";
            this.picboxIntensity.Size = new System.Drawing.Size(512, 512);
            this.picboxIntensity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxIntensity.TabIndex = 6;
            this.picboxIntensity.TabStop = false;
            this.picboxIntensity.Click += new System.EventHandler(this.picboxIntensity_Click);
            // 
            // picboxHue
            // 
            this.picboxHue.Location = new System.Drawing.Point(569, 24);
            this.picboxHue.Name = "picboxHue";
            this.picboxHue.Size = new System.Drawing.Size(512, 512);
            this.picboxHue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxHue.TabIndex = 2;
            this.picboxHue.TabStop = false;
            this.picboxHue.Click += new System.EventHandler(this.picboxHue_Click);
            // 
            // picboxSaturation
            // 
            this.picboxSaturation.Location = new System.Drawing.Point(12, 558);
            this.picboxSaturation.Name = "picboxSaturation";
            this.picboxSaturation.Size = new System.Drawing.Size(512, 512);
            this.picboxSaturation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxSaturation.TabIndex = 4;
            this.picboxSaturation.TabStop = false;
            this.picboxSaturation.Click += new System.EventHandler(this.picboxS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1115, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hình HSI";
            // 
            // picboxHSI
            // 
            this.picboxHSI.Location = new System.Drawing.Point(1104, 246);
            this.picboxHSI.Name = "picboxHSI";
            this.picboxHSI.Size = new System.Drawing.Size(512, 512);
            this.picboxHSI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxHSI.TabIndex = 8;
            this.picboxHSI.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 1055);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picboxHSI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picboxIntensity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picboxSaturation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picboxHue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHSI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picboxIntensity;
        private System.Windows.Forms.PictureBox picboxHue;
        private System.Windows.Forms.PictureBox picboxSaturation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picboxHSI;
    }
}

