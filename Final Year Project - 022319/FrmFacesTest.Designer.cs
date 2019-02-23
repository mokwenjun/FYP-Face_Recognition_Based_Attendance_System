namespace MultiFaceRec
{
    partial class FrmFacesTest
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
            this.ImgCameraVideoBox = new Emgu.CV.UI.ImageBox();
            this.btnstartvideo = new System.Windows.Forms.Button();
            this.picbox3 = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCameraVideoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox3)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgCameraVideoBox
            // 
            this.ImgCameraVideoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgCameraVideoBox.Location = new System.Drawing.Point(12, 12);
            this.ImgCameraVideoBox.Name = "ImgCameraVideoBox";
            this.ImgCameraVideoBox.Size = new System.Drawing.Size(593, 360);
            this.ImgCameraVideoBox.TabIndex = 2;
            this.ImgCameraVideoBox.TabStop = false;
            // 
            // btnstartvideo
            // 
            this.btnstartvideo.Location = new System.Drawing.Point(457, 383);
            this.btnstartvideo.Name = "btnstartvideo";
            this.btnstartvideo.Size = new System.Drawing.Size(137, 49);
            this.btnstartvideo.TabIndex = 3;
            this.btnstartvideo.Text = "Start Video";
            this.btnstartvideo.UseVisualStyleBackColor = true;
            this.btnstartvideo.Click += new System.EventHandler(this.btnstartvideo_Click);
            // 
            // picbox3
            // 
            this.picbox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox3.Location = new System.Drawing.Point(12, 383);
            this.picbox3.Name = "picbox3";
            this.picbox3.Size = new System.Drawing.Size(71, 55);
            this.picbox3.TabIndex = 4;
            this.picbox3.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(635, 383);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(123, 51);
            this.btnsave.TabIndex = 5;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // FrmFacesTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 459);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.picbox3);
            this.Controls.Add(this.btnstartvideo);
            this.Controls.Add(this.ImgCameraVideoBox);
            this.Name = "FrmFacesTest";
            this.Text = "Testing Faces";
            ((System.ComponentModel.ISupportInitialize)(this.ImgCameraVideoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ImgCameraVideoBox;
        private System.Windows.Forms.Button btnstartvideo;
        private System.Windows.Forms.PictureBox picbox3;
        private System.Windows.Forms.Button btnsave;
    }
}