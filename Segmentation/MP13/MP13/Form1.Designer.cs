namespace MP13
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
            this.components = new System.ComponentModel.Container();
            this.picBoxSegment = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxGoc = new System.Windows.Forms.PictureBox();
            this.tbX1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbY1 = new System.Windows.Forms.TextBox();
            this.tbY2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbX2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trbarThreshold = new System.Windows.Forms.TrackBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.bSegment = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxSegment
            // 
            this.picBoxSegment.Location = new System.Drawing.Point(679, 33);
            this.picBoxSegment.Name = "picBoxSegment";
            this.picBoxSegment.Size = new System.Drawing.Size(512, 512);
            this.picBoxSegment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSegment.TabIndex = 0;
            this.picBoxSegment.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình phân đoạn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình gốc";
            // 
            // picBoxGoc
            // 
            this.picBoxGoc.Location = new System.Drawing.Point(28, 33);
            this.picBoxGoc.Name = "picBoxGoc";
            this.picBoxGoc.Size = new System.Drawing.Size(512, 512);
            this.picBoxGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxGoc.TabIndex = 2;
            this.picBoxGoc.TabStop = false;
            // 
            // tbX1
            // 
            this.tbX1.Location = new System.Drawing.Point(118, 705);
            this.tbX1.Name = "tbX1";
            this.tbX1.Size = new System.Drawing.Size(117, 22);
            this.tbX1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 705);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "x1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 764);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "y1:";
            // 
            // tbY1
            // 
            this.tbY1.Location = new System.Drawing.Point(118, 764);
            this.tbY1.Name = "tbY1";
            this.tbY1.Size = new System.Drawing.Size(117, 22);
            this.tbY1.TabIndex = 7;
            // 
            // tbY2
            // 
            this.tbY2.Location = new System.Drawing.Point(370, 764);
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(117, 22);
            this.tbY2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 764);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "y2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 705);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "x2:";
            // 
            // tbX2
            // 
            this.tbX2.Location = new System.Drawing.Point(370, 705);
            this.tbX2.Name = "tbX2";
            this.tbX2.Size = new System.Drawing.Size(117, 22);
            this.tbX2.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 671);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Chọn vùng ảnh để tính vector trung bình màu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 625);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Ngưỡng: ";
            // 
            // trbarThreshold
            // 
            this.trbarThreshold.Location = new System.Drawing.Point(142, 612);
            this.trbarThreshold.Maximum = 255;
            this.trbarThreshold.Name = "trbarThreshold";
            this.trbarThreshold.Size = new System.Drawing.Size(673, 56);
            this.trbarThreshold.TabIndex = 14;
            this.trbarThreshold.Scroll += new System.EventHandler(this.trbarThreshold_Scroll);
            this.trbarThreshold.ValueChanged += new System.EventHandler(this.trbarThreshold_Scroll);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(410, 592);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(16, 17);
            this.lblThreshold.TabIndex = 15;
            this.lblThreshold.Text = "0";
            // 
            // bSegment
            // 
            this.bSegment.Location = new System.Drawing.Point(931, 625);
            this.bSegment.Name = "bSegment";
            this.bSegment.Size = new System.Drawing.Size(138, 110);
            this.bSegment.TabIndex = 16;
            this.bSegment.Text = "Phân đoạn ảnh";
            this.bSegment.UseVisualStyleBackColor = true;
            this.bSegment.Click += new System.EventHandler(this.bSegment_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 805);
            this.Controls.Add(this.bSegment);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.trbarThreshold);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbY2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbX2);
            this.Controls.Add(this.tbY1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbX1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxGoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxSegment);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxSegment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxGoc;
        private System.Windows.Forms.TextBox tbX1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbY1;
        private System.Windows.Forms.TextBox tbY2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbX2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trbarThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Button bSegment;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

