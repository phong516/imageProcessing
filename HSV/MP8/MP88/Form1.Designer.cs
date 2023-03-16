namespace MP88
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
            this.picboxH = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picboxS = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picboxV = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picboxHSV = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHSV)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxRGB
            // 
            this.picboxRGB.Location = new System.Drawing.Point(19, 28);
            this.picboxRGB.Name = "picboxRGB";
            this.picboxRGB.Size = new System.Drawing.Size(384, 384);
            this.picboxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxRGB.TabIndex = 0;
            this.picboxRGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình Hue";
            // 
            // picboxH
            // 
            this.picboxH.Location = new System.Drawing.Point(19, 447);
            this.picboxH.Name = "picboxH";
            this.picboxH.Size = new System.Drawing.Size(384, 384);
            this.picboxH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxH.TabIndex = 2;
            this.picboxH.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hình Saturation";
            // 
            // picboxS
            // 
            this.picboxS.Location = new System.Drawing.Point(438, 447);
            this.picboxS.Name = "picboxS";
            this.picboxS.Size = new System.Drawing.Size(384, 384);
            this.picboxS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxS.TabIndex = 4;
            this.picboxS.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(857, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hình Value";
            // 
            // picboxV
            // 
            this.picboxV.Location = new System.Drawing.Point(860, 447);
            this.picboxV.Name = "picboxV";
            this.picboxV.Size = new System.Drawing.Size(384, 384);
            this.picboxV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxV.TabIndex = 6;
            this.picboxV.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hình HSV";
            // 
            // picboxHSV
            // 
            this.picboxHSV.Location = new System.Drawing.Point(438, 28);
            this.picboxHSV.Name = "picboxHSV";
            this.picboxHSV.Size = new System.Drawing.Size(384, 384);
            this.picboxHSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxHSV.TabIndex = 8;
            this.picboxHSV.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 843);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picboxHSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picboxV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picboxS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picboxH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picboxH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picboxS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picboxV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picboxHSV;
    }
}

