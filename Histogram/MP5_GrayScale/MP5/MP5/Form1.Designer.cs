namespace MP5
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
            this.picBoxGoc = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxXam = new System.Windows.Forms.PictureBox();
            this.zgHistogram = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXam)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxGoc
            // 
            this.picBoxGoc.Location = new System.Drawing.Point(82, 28);
            this.picBoxGoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxGoc.Name = "picBoxGoc";
            this.picBoxGoc.Size = new System.Drawing.Size(524, 416);
            this.picBoxGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxGoc.TabIndex = 0;
            this.picBoxGoc.TabStop = false;
            this.picBoxGoc.Click += new System.EventHandler(this.picBoxGoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình gốc";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình mức xám";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // picBoxXam
            // 
            this.picBoxXam.Location = new System.Drawing.Point(82, 489);
            this.picBoxXam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxXam.Name = "picBoxXam";
            this.picBoxXam.Size = new System.Drawing.Size(524, 416);
            this.picBoxXam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXam.TabIndex = 2;
            this.picBoxXam.TabStop = false;
            this.picBoxXam.Click += new System.EventHandler(this.picBoxXam_Click);
            // 
            // zgHistogram
            // 
            this.zgHistogram.Location = new System.Drawing.Point(714, 27);
            this.zgHistogram.Margin = new System.Windows.Forms.Padding(5);
            this.zgHistogram.Name = "zgHistogram";
            this.zgHistogram.ScrollGrace = 0D;
            this.zgHistogram.ScrollMaxX = 0D;
            this.zgHistogram.ScrollMaxY = 0D;
            this.zgHistogram.ScrollMaxY2 = 0D;
            this.zgHistogram.ScrollMinX = 0D;
            this.zgHistogram.ScrollMinY = 0D;
            this.zgHistogram.ScrollMinY2 = 0D;
            this.zgHistogram.Size = new System.Drawing.Size(1017, 632);
            this.zgHistogram.TabIndex = 4;
            this.zgHistogram.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 1055);
            this.Controls.Add(this.zgHistogram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxXam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxGoc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxGoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxXam;
        private ZedGraph.ZedGraphControl zgHistogram;
    }
}

