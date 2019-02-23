namespace MultiFaceRec
{
    partial class FrmAverageFace
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
            this.picAverageFace = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAverageFace)).BeginInit();
            this.SuspendLayout();
            // 
            // picAverageFace
            // 
            this.picAverageFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAverageFace.Location = new System.Drawing.Point(45, 44);
            this.picAverageFace.Name = "picAverageFace";
            this.picAverageFace.Size = new System.Drawing.Size(207, 199);
            this.picAverageFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAverageFace.TabIndex = 0;
            this.picAverageFace.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Average Face:";
            // 
            // FrmAverageFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAverageFace);
            this.Name = "FrmAverageFace";
            this.Text = "Average Face";
            this.Load += new System.EventHandler(this.FrmAverageFace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAverageFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAverageFace;
        private System.Windows.Forms.Label label1;
    }
}