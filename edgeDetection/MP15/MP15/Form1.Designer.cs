namespace MP15
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxEdgeRGB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEdgeRGB)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxRGB
            // 
            this.picBoxRGB.Location = new System.Drawing.Point(11, 28);
            this.picBoxRGB.Name = "picBoxRGB";
            this.picBoxRGB.Size = new System.Drawing.Size(512, 512);
            this.picBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxRGB.TabIndex = 0;
            this.picBoxRGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình RGB";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(835, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 104);
            this.button1.TabIndex = 2;
            this.button1.Text = "Edge Detection RGB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(325, 657);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(440, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(553, 637);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(16, 17);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 657);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngưỡng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hình tách biên RGB";
            // 
            // picBoxEdgeRGB
            // 
            this.picBoxEdgeRGB.Location = new System.Drawing.Point(605, 28);
            this.picBoxEdgeRGB.Name = "picBoxEdgeRGB";
            this.picBoxEdgeRGB.Size = new System.Drawing.Size(512, 512);
            this.picBoxEdgeRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxEdgeRGB.TabIndex = 6;
            this.picBoxEdgeRGB.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 804);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxEdgeRGB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEdgeRGB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxEdgeRGB;
    }
}

