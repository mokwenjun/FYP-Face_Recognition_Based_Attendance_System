namespace MultiFaceRec
{
    partial class FrmMainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartTheCamera = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStudentDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourFormatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseWhatToDetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectFaceOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectFaceAndEyesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToGrayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseImageToRecognizeFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.save_Frame_With_Face_Recognized = new System.Windows.Forms.SaveFileDialog();
            this.save_Frame_Without_Face_Recognized = new System.Windows.Forms.SaveFileDialog();
            this.btnSubmitAttendance = new System.Windows.Forms.Button();
            this.btnStopCamera = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.btnTrainFaces = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(362, 484);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 54);
            this.label3.TabIndex = 15;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 493);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 45);
            this.label2.TabIndex = 14;
            this.label2.Text = "No faces detected: ";
            // 
            // btnStartTheCamera
            // 
            this.btnStartTheCamera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartTheCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTheCamera.Location = new System.Drawing.Point(712, 509);
            this.btnStartTheCamera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartTheCamera.Name = "btnStartTheCamera";
            this.btnStartTheCamera.Size = new System.Drawing.Size(547, 84);
            this.btnStartTheCamera.TabIndex = 2;
            this.btnStartTheCamera.Text = "Start Camera";
            this.btnStartTheCamera.UseVisualStyleBackColor = true;
            this.btnStartTheCamera.Click += new System.EventHandler(this.btnStartTheCamera_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(659, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Name(s):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(672, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Module:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(695, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "Class:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(703, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 32);
            this.label9.TabIndex = 13;
            this.label9.Text = "Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(703, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 32);
            this.label10.TabIndex = 14;
            this.label10.Text = "Time:";
            // 
            // lbldate
            // 
            this.lbldate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbldate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(808, 315);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(451, 63);
            this.lbldate.TabIndex = 18;
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltime
            // 
            this.lbltime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbltime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.Location = new System.Drawing.Point(809, 404);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(448, 63);
            this.lbltime.TabIndex = 19;
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbModule
            // 
            this.cmbModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmbModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Items.AddRange(new object[] {
            "CZ1005",
            "CZ1006",
            "CZ1007",
            "CZ1011",
            "CZ1012",
            "CZ2001",
            "CZ2002",
            "CZ2003",
            "CZ2004",
            "CZ2005",
            "CZ2006",
            "CZ2007",
            "CZ3001",
            "CZ3002",
            "CZ3003",
            "CZ3004",
            "CZ3005",
            "CZ3006",
            "CZ3007",
            "CZ4062",
            "CZ4064",
            "CZ4046",
            "CZ4065",
            "CZ0001"});
            this.cmbModule.Location = new System.Drawing.Point(805, 171);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(451, 40);
            this.cmbModule.TabIndex = 23;
            // 
            // cmbClass
            // 
            this.cmbClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "FSP1",
            "FSP2",
            "FSP3",
            "FSP4",
            "FSP5",
            "FSP6",
            "FSP7",
            "BCG1",
            "BCG2",
            "BCG3"});
            this.cmbClass.Location = new System.Drawing.Point(805, 245);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(451, 40);
            this.cmbClass.TabIndex = 24;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(805, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(451, 92);
            this.lblName.TabIndex = 27;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1290, 33);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearStudentDatabaseToolStripMenuItem,
            this.otherSettingsToolStripMenuItem,
            this.browseImageToRecognizeFaceToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // clearStudentDatabaseToolStripMenuItem
            // 
            this.clearStudentDatabaseToolStripMenuItem.Name = "clearStudentDatabaseToolStripMenuItem";
            this.clearStudentDatabaseToolStripMenuItem.Size = new System.Drawing.Size(355, 30);
            this.clearStudentDatabaseToolStripMenuItem.Text = "Clear Student Database";
            this.clearStudentDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearStudentDatabaseToolStripMenuItem_Click);
            // 
            // otherSettingsToolStripMenuItem
            // 
            this.otherSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeFormatToolStripMenuItem,
            this.chooseWhatToDetectToolStripMenuItem,
            this.convertToGrayScaleToolStripMenuItem});
            this.otherSettingsToolStripMenuItem.Name = "otherSettingsToolStripMenuItem";
            this.otherSettingsToolStripMenuItem.Size = new System.Drawing.Size(355, 30);
            this.otherSettingsToolStripMenuItem.Text = "Other Settings";
            // 
            // timeFormatToolStripMenuItem
            // 
            this.timeFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourFormatToolStripMenuItem,
            this.hourFormatToolStripMenuItem1});
            this.timeFormatToolStripMenuItem.Name = "timeFormatToolStripMenuItem";
            this.timeFormatToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.timeFormatToolStripMenuItem.Text = "Time Format";
            // 
            // hourFormatToolStripMenuItem
            // 
            this.hourFormatToolStripMenuItem.Name = "hourFormatToolStripMenuItem";
            this.hourFormatToolStripMenuItem.Size = new System.Drawing.Size(223, 30);
            this.hourFormatToolStripMenuItem.Text = "12 Hour Format";
            this.hourFormatToolStripMenuItem.Click += new System.EventHandler(this.hourFormatToolStripMenuItem_Click);
            // 
            // hourFormatToolStripMenuItem1
            // 
            this.hourFormatToolStripMenuItem1.Name = "hourFormatToolStripMenuItem1";
            this.hourFormatToolStripMenuItem1.Size = new System.Drawing.Size(223, 30);
            this.hourFormatToolStripMenuItem1.Text = "24 Hour Format";
            this.hourFormatToolStripMenuItem1.Click += new System.EventHandler(this.hourFormatToolStripMenuItem1_Click);
            // 
            // chooseWhatToDetectToolStripMenuItem
            // 
            this.chooseWhatToDetectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detectFaceOnlyToolStripMenuItem,
            this.detectFaceAndEyesToolStripMenuItem});
            this.chooseWhatToDetectToolStripMenuItem.Name = "chooseWhatToDetectToolStripMenuItem";
            this.chooseWhatToDetectToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.chooseWhatToDetectToolStripMenuItem.Text = "Choose what to Detect";
            // 
            // detectFaceOnlyToolStripMenuItem
            // 
            this.detectFaceOnlyToolStripMenuItem.Name = "detectFaceOnlyToolStripMenuItem";
            this.detectFaceOnlyToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.detectFaceOnlyToolStripMenuItem.Text = "Detect Face Only";
            this.detectFaceOnlyToolStripMenuItem.Click += new System.EventHandler(this.detectFaceOnlyToolStripMenuItem_Click);
            // 
            // detectFaceAndEyesToolStripMenuItem
            // 
            this.detectFaceAndEyesToolStripMenuItem.Name = "detectFaceAndEyesToolStripMenuItem";
            this.detectFaceAndEyesToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.detectFaceAndEyesToolStripMenuItem.Text = "Detect Face and Eyes";
            this.detectFaceAndEyesToolStripMenuItem.Click += new System.EventHandler(this.detectFaceAndEyesToolStripMenuItem_Click);
            // 
            // convertToGrayScaleToolStripMenuItem
            // 
            this.convertToGrayScaleToolStripMenuItem.Name = "convertToGrayScaleToolStripMenuItem";
            this.convertToGrayScaleToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.convertToGrayScaleToolStripMenuItem.Text = "Convert To GrayScale";
            this.convertToGrayScaleToolStripMenuItem.Click += new System.EventHandler(this.convertToGrayScaleToolStripMenuItem_Click);
            // 
            // browseImageToRecognizeFaceToolStripMenuItem
            // 
            this.browseImageToRecognizeFaceToolStripMenuItem.Name = "browseImageToRecognizeFaceToolStripMenuItem";
            this.browseImageToRecognizeFaceToolStripMenuItem.Size = new System.Drawing.Size(355, 30);
            this.browseImageToRecognizeFaceToolStripMenuItem.Text = "Browse Image To Recognize Face";
            this.browseImageToRecognizeFaceToolStripMenuItem.Click += new System.EventHandler(this.browseImageToRecognizeFaceToolStripMenuItem_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(705, 840);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(554, 86);
            this.btnLogOut.TabIndex = 35;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSubmitAttendance
            // 
            this.btnSubmitAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitAttendance.Location = new System.Drawing.Point(709, 730);
            this.btnSubmitAttendance.Name = "btnSubmitAttendance";
            this.btnSubmitAttendance.Size = new System.Drawing.Size(550, 93);
            this.btnSubmitAttendance.TabIndex = 38;
            this.btnSubmitAttendance.Text = "Submit Attendance";
            this.btnSubmitAttendance.UseVisualStyleBackColor = true;
            this.btnSubmitAttendance.Click += new System.EventHandler(this.btnSubmitAttendance_Click);
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopCamera.Location = new System.Drawing.Point(711, 617);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Size = new System.Drawing.Size(548, 85);
            this.btnStopCamera.TabIndex = 41;
            this.btnStopCamera.Text = "Turn Off Camera";
            this.btnStopCamera.UseVisualStyleBackColor = true;
            this.btnStopCamera.Click += new System.EventHandler(this.btnStopCamera_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(35, 46);
            this.imageBoxFrameGrabber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(610, 433);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // btnTrainFaces
            // 
            this.btnTrainFaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainFaces.Location = new System.Drawing.Point(36, 564);
            this.btnTrainFaces.Name = "btnTrainFaces";
            this.btnTrainFaces.Size = new System.Drawing.Size(400, 85);
            this.btnTrainFaces.TabIndex = 45;
            this.btnTrainFaces.Text = "Train Faces";
            this.btnTrainFaces.UseVisualStyleBackColor = true;
            this.btnTrainFaces.Click += new System.EventHandler(this.btnAddTrainingImage_Click);
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1290, 981);
            this.Controls.Add(this.btnTrainFaces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStopCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubmitAttendance);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnStartTheCamera);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.cmbModule);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMainForm";
            this.Text = "Face Recognition";
            this.Load += new System.EventHandler(this.FrmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartTheCamera;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbModule;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearStudentDatabaseToolStripMenuItem;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.ToolStripMenuItem otherSettingsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog save_Frame_With_Face_Recognized;
        private System.Windows.Forms.ToolStripMenuItem timeFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourFormatToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog save_Frame_Without_Face_Recognized;
        private System.Windows.Forms.Button btnSubmitAttendance;
        private System.Windows.Forms.Button btnStopCamera;
        private System.Windows.Forms.ToolStripMenuItem chooseWhatToDetectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectFaceOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectFaceAndEyesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseImageToRecognizeFaceToolStripMenuItem;
        private System.Windows.Forms.Button btnTrainFaces;
        private System.Windows.Forms.ToolStripMenuItem convertToGrayScaleToolStripMenuItem;
    }
}

