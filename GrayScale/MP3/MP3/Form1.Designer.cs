namespace MP3
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
            this.picBoxGoc = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxXamAverage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picBoxXamLightness = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picBoxXamLuminance = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamLuminance)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxGoc
            // 
            this.picBoxGoc.Location = new System.Drawing.Point(42, 32);
            this.picBoxGoc.Name = "picBoxGoc";
            this.picBoxGoc.Size = new System.Drawing.Size(384, 384);
            this.picBoxGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxGoc.TabIndex = 0;
            this.picBoxGoc.TabStop = false;
            this.picBoxGoc.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình RGB gốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình mức xám Average";
            // 
            // picBoxXamAverage
            // 
            this.picBoxXamAverage.Location = new System.Drawing.Point(475, 32);
            this.picBoxXamAverage.Name = "picBoxXamAverage";
            this.picBoxXamAverage.Size = new System.Drawing.Size(384, 384);
            this.picBoxXamAverage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXamAverage.TabIndex = 2;
            this.picBoxXamAverage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hình mức xám Lightness";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // picBoxXamLightness
            // 
            this.picBoxXamLightness.Location = new System.Drawing.Point(42, 455);
            this.picBoxXamLightness.Name = "picBoxXamLightness";
            this.picBoxXamLightness.Size = new System.Drawing.Size(384, 384);
            this.picBoxXamLightness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXamLightness.TabIndex = 4;
            this.picBoxXamLightness.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hình mức xám Luminance";
            // 
            // picBoxXamLuminance
            // 
            this.picBoxXamLuminance.Location = new System.Drawing.Point(475, 455);
            this.picBoxXamLuminance.Name = "picBoxXamLuminance";
            this.picBoxXamLuminance.Size = new System.Drawing.Size(384, 384);
            this.picBoxXamLuminance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXamLuminance.TabIndex = 6;
            this.picBoxXamLuminance.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(865, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nguyễn Lê Phong 20146516";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 1055);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picBoxXamLuminance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBoxXamLightness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxXamAverage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxGoc);
            this.Name = "Form1";
            this.Text = "RGBtoGrayScale";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXamLuminance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxGoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxXamAverage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBoxXamLightness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBoxXamLuminance;
        private System.Windows.Forms.Label label5;
    }
}

