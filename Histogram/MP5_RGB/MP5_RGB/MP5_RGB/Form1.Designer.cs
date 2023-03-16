namespace MP5_RGB
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
            this.picBoxRGB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zgHistogram = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxRGB
            // 
            this.picBoxRGB.Location = new System.Drawing.Point(12, 37);
            this.picBoxRGB.Name = "picBoxRGB";
            this.picBoxRGB.Size = new System.Drawing.Size(500, 381);
            this.picBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxRGB.TabIndex = 0;
            this.picBoxRGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình gốc RGB";
            // 
            // zgHistogram
            // 
            this.zgHistogram.Location = new System.Drawing.Point(519, 37);
            this.zgHistogram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zgHistogram.Name = "zgHistogram";
            this.zgHistogram.ScrollGrace = 0D;
            this.zgHistogram.ScrollMaxX = 0D;
            this.zgHistogram.ScrollMaxY = 0D;
            this.zgHistogram.ScrollMaxY2 = 0D;
            this.zgHistogram.ScrollMinX = 0D;
            this.zgHistogram.ScrollMinY = 0D;
            this.zgHistogram.ScrollMinY2 = 0D;
            this.zgHistogram.Size = new System.Drawing.Size(811, 500);
            this.zgHistogram.TabIndex = 2;
            this.zgHistogram.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 653);
            this.Controls.Add(this.zgHistogram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxRGB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRGB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxRGB;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zgHistogram;
    }
}

