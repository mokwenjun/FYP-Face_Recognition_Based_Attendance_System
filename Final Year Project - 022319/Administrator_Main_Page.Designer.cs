namespace MultiFaceRec
{
    partial class FrmAdministratorMainPage
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
            this.btnTakeStudentsAttendance = new System.Windows.Forms.Button();
            this.btnConductFaceRecognitionExperiments = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTakeStudentsAttendance
            // 
            this.btnTakeStudentsAttendance.BackColor = System.Drawing.Color.Yellow;
            this.btnTakeStudentsAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeStudentsAttendance.Location = new System.Drawing.Point(125, 12);
            this.btnTakeStudentsAttendance.Name = "btnTakeStudentsAttendance";
            this.btnTakeStudentsAttendance.Size = new System.Drawing.Size(748, 120);
            this.btnTakeStudentsAttendance.TabIndex = 0;
            this.btnTakeStudentsAttendance.Text = "Obtain Training Images of Students";
            this.btnTakeStudentsAttendance.UseVisualStyleBackColor = false;
            this.btnTakeStudentsAttendance.Click += new System.EventHandler(this.btnTakeStudentsAttendance_Click);
            // 
            // btnConductFaceRecognitionExperiments
            // 
            this.btnConductFaceRecognitionExperiments.BackColor = System.Drawing.Color.Yellow;
            this.btnConductFaceRecognitionExperiments.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConductFaceRecognitionExperiments.Location = new System.Drawing.Point(125, 149);
            this.btnConductFaceRecognitionExperiments.Name = "btnConductFaceRecognitionExperiments";
            this.btnConductFaceRecognitionExperiments.Size = new System.Drawing.Size(748, 125);
            this.btnConductFaceRecognitionExperiments.TabIndex = 1;
            this.btnConductFaceRecognitionExperiments.Text = "Conduct Face Recognition Experiments using EigenFaces";
            this.btnConductFaceRecognitionExperiments.UseVisualStyleBackColor = false;
            this.btnConductFaceRecognitionExperiments.Click += new System.EventHandler(this.btnConductFaceRecognitionExperiments_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Yellow;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(125, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(748, 115);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmAdministratorMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(953, 422);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConductFaceRecognitionExperiments);
            this.Controls.Add(this.btnTakeStudentsAttendance);
            this.Name = "FrmAdministratorMainPage";
            this.Text = "Administrator\'s Main Page";
            this.Load += new System.EventHandler(this.FrmAdministratorMainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTakeStudentsAttendance;
        private System.Windows.Forms.Button btnConductFaceRecognitionExperiments;
        private System.Windows.Forms.Button btnExit;
    }
}