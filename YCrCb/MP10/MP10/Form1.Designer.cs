namespace MP10
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
            this.picboxYCrCb = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picboxY = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picboxCr = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picboxCb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxYCrCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCb)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxRGB
            // 
            this.picboxRGB.Location = new System.Drawing.Point(15, 29);
            this.picboxRGB.Name = "picboxRGB";
            this.picboxRGB.Size = new System.Drawing.Size(384, 384);
            this.picboxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxRGB.TabIndex = 0;
            this.picboxRGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình YCrCb";
            // 
            // picboxYCrCb
            // 
            this.picboxYCrCb.Location = new System.Drawing.Point(448, 29);
            this.picboxYCrCb.Name = "picboxYCrCb";
            this.picboxYCrCb.Size = new System.Drawing.Size(384, 384);
            this.picboxYCrCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxYCrCb.TabIndex = 2;
            this.picboxYCrCb.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hình Y";
            // 
            // picboxY
            // 
            this.picboxY.Location = new System.Drawing.Point(15, 445);
            this.picboxY.Name = "picboxY";
            this.picboxY.Size = new System.Drawing.Size(384, 384);
            this.picboxY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxY.TabIndex = 4;
            this.picboxY.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hình Cr";
            // 
            // picboxCr
            // 
            this.picboxCr.Location = new System.Drawing.Point(448, 445);
            this.picboxCr.Name = "picboxCr";
            this.picboxCr.Size = new System.Drawing.Size(384, 384);
            this.picboxCr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxCr.TabIndex = 6;
            this.picboxCr.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(872, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hình Cb";
            // 
            // picboxCb
            // 
            this.picboxCb.Location = new System.Drawing.Point(875, 445);
            this.picboxCb.Name = "picboxCb";
            this.picboxCb.Size = new System.Drawing.Size(384, 384);
            this.picboxCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxCb.TabIndex = 8;
            this.picboxCb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 841);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picboxCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picboxCr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picboxY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picboxYCrCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picboxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxYCrCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picboxYCrCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picboxY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picboxCr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picboxCb;
    }
}

