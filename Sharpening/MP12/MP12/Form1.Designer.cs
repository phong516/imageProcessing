namespace MP12
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
            this.picboxGoc = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picboxSharpen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSharpen)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxGoc
            // 
            this.picboxGoc.Location = new System.Drawing.Point(51, 53);
            this.picboxGoc.Name = "picboxGoc";
            this.picboxGoc.Size = new System.Drawing.Size(384, 384);
            this.picboxGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxGoc.TabIndex = 0;
            this.picboxGoc.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hình gốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hình làm nét";
            // 
            // picboxSharpen
            // 
            this.picboxSharpen.Location = new System.Drawing.Point(484, 53);
            this.picboxSharpen.Name = "picboxSharpen";
            this.picboxSharpen.Size = new System.Drawing.Size(384, 384);
            this.picboxSharpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxSharpen.TabIndex = 2;
            this.picboxSharpen.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picboxSharpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxGoc);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picboxGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSharpen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxGoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picboxSharpen;
    }
}

