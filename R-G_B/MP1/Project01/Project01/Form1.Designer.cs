namespace Project01
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
            this.lblHinhHienThi = new System.Windows.Forms.Label();
            this.picBox_HinhGoc = new System.Windows.Forms.PictureBox();
            this.picBox_Red = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picBox_Green = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picBox_Blue = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Blue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHinhHienThi
            // 
            this.lblHinhHienThi.AutoSize = true;
            this.lblHinhHienThi.Location = new System.Drawing.Point(67, 20);
            this.lblHinhHienThi.Name = "lblHinhHienThi";
            this.lblHinhHienThi.Size = new System.Drawing.Size(133, 17);
            this.lblHinhHienThi.TabIndex = 3;
            this.lblHinhHienThi.Text = "Hình màu RGB gốc ";
            this.lblHinhHienThi.Click += new System.EventHandler(this.lblHinhHienThi_Click);
            // 
            // picBox_HinhGoc
            // 
            this.picBox_HinhGoc.Location = new System.Drawing.Point(69, 39);
            this.picBox_HinhGoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox_HinhGoc.Name = "picBox_HinhGoc";
            this.picBox_HinhGoc.Size = new System.Drawing.Size(384, 384);
            this.picBox_HinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_HinhGoc.TabIndex = 4;
            this.picBox_HinhGoc.TabStop = false;
            this.picBox_HinhGoc.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picBox_Red
            // 
            this.picBox_Red.Location = new System.Drawing.Point(552, 39);
            this.picBox_Red.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox_Red.Name = "picBox_Red";
            this.picBox_Red.Size = new System.Drawing.Size(384, 384);
            this.picBox_Red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Red.TabIndex = 6;
            this.picBox_Red.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red";
            // 
            // picBox_Green
            // 
            this.picBox_Green.Location = new System.Drawing.Point(69, 449);
            this.picBox_Green.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox_Green.Name = "picBox_Green";
            this.picBox_Green.Size = new System.Drawing.Size(384, 384);
            this.picBox_Green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Green.TabIndex = 8;
            this.picBox_Green.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Green";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // picBox_Blue
            // 
            this.picBox_Blue.Location = new System.Drawing.Point(552, 449);
            this.picBox_Blue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox_Blue.Name = "picBox_Blue";
            this.picBox_Blue.Size = new System.Drawing.Size(384, 384);
            this.picBox_Blue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Blue.TabIndex = 10;
            this.picBox_Blue.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Blue";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "NguyenLePhong_20146516";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 1055);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picBox_Blue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBox_Green);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBox_Red);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBox_HinhGoc);
            this.Controls.Add(this.lblHinhHienThi);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Tách ảnh màu RGB cho từng kênh RED-GREEN-BLUE";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Blue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHinhHienThi;
        private System.Windows.Forms.PictureBox picBox_HinhGoc;
        private System.Windows.Forms.PictureBox picBox_Red;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBox_Green;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBox_Blue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

