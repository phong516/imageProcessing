namespace MP14
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
            this.picboxGray = new System.Windows.Forms.PictureBox();
            this.picBoxEdgeGray = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEdgeGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxGray
            // 
            this.picboxGray.Location = new System.Drawing.Point(89, 35);
            this.picboxGray.Name = "picboxGray";
            this.picboxGray.Size = new System.Drawing.Size(512, 512);
            this.picboxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxGray.TabIndex = 0;
            this.picboxGray.TabStop = false;
            // 
            // picBoxEdgeGray
            // 
            this.picBoxEdgeGray.Location = new System.Drawing.Point(709, 35);
            this.picBoxEdgeGray.Name = "picBoxEdgeGray";
            this.picBoxEdgeGray.Size = new System.Drawing.Size(512, 512);
            this.picBoxEdgeGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxEdgeGray.TabIndex = 1;
            this.picBoxEdgeGray.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(198, 637);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(772, 56);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(598, 617);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(16, 17);
            this.lblThreshold.TabIndex = 3;
            this.lblThreshold.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 699);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 78);
            this.button1.TabIndex = 4;
            this.button1.Text = "Edge Detection Button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hình mức xám";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hình tách đường biên";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 791);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.picBoxEdgeGray);
            this.Controls.Add(this.picboxGray);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picboxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEdgeGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxGray;
        private System.Windows.Forms.PictureBox picBoxEdgeGray;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

