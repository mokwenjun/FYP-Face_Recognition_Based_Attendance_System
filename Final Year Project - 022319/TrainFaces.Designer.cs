namespace MultiFaceRec
{
    partial class FrmTrainFaces
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
            this.ImgCamera = new Emgu.CV.UI.ImageBox();
            this.txtAddTrainingFace = new System.Windows.Forms.TextBox();
            this.ImgTrainedFaces = new Emgu.CV.UI.ImageBox();
            this.btnAddTrainingImage = new System.Windows.Forms.Button();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCapturedFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudentAttendanceLogFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamesExtracted = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalFacesDetected = new System.Windows.Forms.Label();
            this.the_open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadVideo = new System.Windows.Forms.Button();
            this.btnTurnOffCamera = new System.Windows.Forms.Button();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.cmbSelectTrainingMethod = new System.Windows.Forms.ComboBox();
            this.lblSelectTrainingMethod = new System.Windows.Forms.Label();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.btnLoadFolderOfImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPathOfSelectedFolder = new System.Windows.Forms.Label();
            this.pnlTrainFromCamera = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTrainFromImage = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlTrainFacesFromFolder = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTrainFromVideo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrRunImagesInFolder = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImgCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgTrainedFaces)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlTrainFromCamera.SuspendLayout();
            this.pnlTrainFromImage.SuspendLayout();
            this.pnlTrainFacesFromFolder.SuspendLayout();
            this.pnlTrainFromVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgCamera
            // 
            this.ImgCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgCamera.Location = new System.Drawing.Point(56, 36);
            this.ImgCamera.Name = "ImgCamera";
            this.ImgCamera.Size = new System.Drawing.Size(610, 433);
            this.ImgCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgCamera.TabIndex = 2;
            this.ImgCamera.TabStop = false;
            // 
            // txtAddTrainingFace
            // 
            this.txtAddTrainingFace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddTrainingFace.Location = new System.Drawing.Point(808, 417);
            this.txtAddTrainingFace.Name = "txtAddTrainingFace";
            this.txtAddTrainingFace.Size = new System.Drawing.Size(306, 39);
            this.txtAddTrainingFace.TabIndex = 3;
            // 
            // ImgTrainedFaces
            // 
            this.ImgTrainedFaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgTrainedFaces.Location = new System.Drawing.Point(852, 216);
            this.ImgTrainedFaces.Name = "ImgTrainedFaces";
            this.ImgTrainedFaces.Size = new System.Drawing.Size(203, 177);
            this.ImgTrainedFaces.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgTrainedFaces.TabIndex = 2;
            this.ImgTrainedFaces.TabStop = false;
            // 
            // btnAddTrainingImage
            // 
            this.btnAddTrainingImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrainingImage.Location = new System.Drawing.Point(839, 462);
            this.btnAddTrainingImage.Name = "btnAddTrainingImage";
            this.btnAddTrainingImage.Size = new System.Drawing.Size(216, 61);
            this.btnAddTrainingImage.TabIndex = 6;
            this.btnAddTrainingImage.Text = "Add Trained Face";
            this.btnAddTrainingImage.UseVisualStyleBackColor = true;
            this.btnAddTrainingImage.Click += new System.EventHandler(this.btnAddTrainingImage_Click);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCamera.Location = new System.Drawing.Point(27, 54);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(238, 56);
            this.btnStartCamera.TabIndex = 7;
            this.btnStartCamera.Text = "Start Camera";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1455, 33);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.otherSettingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // otherSettingsToolStripMenuItem
            // 
            this.otherSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCapturedFramesToolStripMenuItem,
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem,
            this.deleteStudentAttendanceLogFolderToolStripMenuItem});
            this.otherSettingsToolStripMenuItem.Name = "otherSettingsToolStripMenuItem";
            this.otherSettingsToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.otherSettingsToolStripMenuItem.Text = "Other Settings";
            // 
            // saveCapturedFramesToolStripMenuItem
            // 
            this.saveCapturedFramesToolStripMenuItem.Name = "saveCapturedFramesToolStripMenuItem";
            this.saveCapturedFramesToolStripMenuItem.Size = new System.Drawing.Size(432, 30);
            this.saveCapturedFramesToolStripMenuItem.Text = "Save Captured Frames";
            this.saveCapturedFramesToolStripMenuItem.Click += new System.EventHandler(this.saveCapturedFramesToolStripMenuItem_Click);
            // 
            // enableDetectionAndRecognitionOfFacesToolStripMenuItem
            // 
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yesToolStripMenuItem,
            this.noToolStripMenuItem});
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem.Name = "enableDetectionAndRecognitionOfFacesToolStripMenuItem";
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem.Size = new System.Drawing.Size(432, 30);
            this.enableDetectionAndRecognitionOfFacesToolStripMenuItem.Text = "Enable Detection and Recognition of Faces";
            // 
            // yesToolStripMenuItem
            // 
            this.yesToolStripMenuItem.Name = "yesToolStripMenuItem";
            this.yesToolStripMenuItem.Size = new System.Drawing.Size(121, 30);
            this.yesToolStripMenuItem.Text = "Yes";
            this.yesToolStripMenuItem.Click += new System.EventHandler(this.yesToolStripMenuItem_Click);
            // 
            // noToolStripMenuItem
            // 
            this.noToolStripMenuItem.Name = "noToolStripMenuItem";
            this.noToolStripMenuItem.Size = new System.Drawing.Size(121, 30);
            this.noToolStripMenuItem.Text = "No";
            this.noToolStripMenuItem.Click += new System.EventHandler(this.noToolStripMenuItem_Click);
            // 
            // deleteStudentAttendanceLogFolderToolStripMenuItem
            // 
            this.deleteStudentAttendanceLogFolderToolStripMenuItem.Name = "deleteStudentAttendanceLogFolderToolStripMenuItem";
            this.deleteStudentAttendanceLogFolderToolStripMenuItem.Size = new System.Drawing.Size(432, 30);
            this.deleteStudentAttendanceLogFolderToolStripMenuItem.Text = "Delete Student Attendance Log Folder";
            this.deleteStudentAttendanceLogFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteStudentAttendanceLogFolderToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(672, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 41);
            this.label2.TabIndex = 12;
            this.label2.Text = "Names Extracted:";
            // 
            // lblNamesExtracted
            // 
            this.lblNamesExtracted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNamesExtracted.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamesExtracted.Location = new System.Drawing.Point(771, 36);
            this.lblNamesExtracted.Name = "lblNamesExtracted";
            this.lblNamesExtracted.Size = new System.Drawing.Size(343, 76);
            this.lblNamesExtracted.TabIndex = 13;
            this.lblNamesExtracted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(672, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 46);
            this.label3.TabIndex = 14;
            this.label3.Text = "No of Faces Detected:";
            // 
            // lblTotalFacesDetected
            // 
            this.lblTotalFacesDetected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalFacesDetected.Location = new System.Drawing.Point(771, 134);
            this.lblTotalFacesDetected.Name = "lblTotalFacesDetected";
            this.lblTotalFacesDetected.Size = new System.Drawing.Size(64, 57);
            this.lblTotalFacesDetected.TabIndex = 15;
            this.lblTotalFacesDetected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // the_open_file_dialog
            // 
            this.the_open_file_dialog.FileName = "openFileDialog1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadVideo
            // 
            this.btnLoadVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadVideo.Location = new System.Drawing.Point(14, 55);
            this.btnLoadVideo.Name = "btnLoadVideo";
            this.btnLoadVideo.Size = new System.Drawing.Size(260, 58);
            this.btnLoadVideo.TabIndex = 16;
            this.btnLoadVideo.Text = "Load Video";
            this.btnLoadVideo.UseVisualStyleBackColor = true;
            this.btnLoadVideo.Click += new System.EventHandler(this.btnLoadVideo_Click);
            // 
            // btnTurnOffCamera
            // 
            this.btnTurnOffCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnOffCamera.Location = new System.Drawing.Point(27, 127);
            this.btnTurnOffCamera.Name = "btnTurnOffCamera";
            this.btnTurnOffCamera.Size = new System.Drawing.Size(238, 58);
            this.btnTurnOffCamera.TabIndex = 17;
            this.btnTurnOffCamera.Text = "Turn Off Camera";
            this.btnTurnOffCamera.UseVisualStyleBackColor = true;
            this.btnTurnOffCamera.Click += new System.EventHandler(this.btnTurnOffCamera_Click);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImage.Location = new System.Drawing.Point(20, 98);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(258, 64);
            this.btnBrowseImage.TabIndex = 18;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // cmbSelectTrainingMethod
            // 
            this.cmbSelectTrainingMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectTrainingMethod.FormattingEnabled = true;
            this.cmbSelectTrainingMethod.Items.AddRange(new object[] {
            "From a Camera",
            "From a Video",
            "From an Image"});
            this.cmbSelectTrainingMethod.Location = new System.Drawing.Point(199, 475);
            this.cmbSelectTrainingMethod.Name = "cmbSelectTrainingMethod";
            this.cmbSelectTrainingMethod.Size = new System.Drawing.Size(467, 37);
            this.cmbSelectTrainingMethod.TabIndex = 19;
            this.cmbSelectTrainingMethod.Text = "Select Training Method";
            this.cmbSelectTrainingMethod.SelectedIndexChanged += new System.EventHandler(this.cmbSelectTrainingMethod_SelectedIndexChanged);
            // 
            // lblSelectTrainingMethod
            // 
            this.lblSelectTrainingMethod.Location = new System.Drawing.Point(52, 475);
            this.lblSelectTrainingMethod.Name = "lblSelectTrainingMethod";
            this.lblSelectTrainingMethod.Size = new System.Drawing.Size(141, 27);
            this.lblSelectTrainingMethod.TabIndex = 20;
            this.lblSelectTrainingMethod.Text = "Training Method:";
            // 
            // btnStopVideo
            // 
            this.btnStopVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopVideo.Location = new System.Drawing.Point(14, 139);
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.Size = new System.Drawing.Size(260, 58);
            this.btnStopVideo.TabIndex = 21;
            this.btnStopVideo.Text = "Stop Video";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);
            // 
            // btnLoadFolderOfImages
            // 
            this.btnLoadFolderOfImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFolderOfImages.Location = new System.Drawing.Point(109, 38);
            this.btnLoadFolderOfImages.Name = "btnLoadFolderOfImages";
            this.btnLoadFolderOfImages.Size = new System.Drawing.Size(263, 67);
            this.btnLoadFolderOfImages.TabIndex = 22;
            this.btnLoadFolderOfImages.Text = "Select Folder";
            this.btnLoadFolderOfImages.UseVisualStyleBackColor = true;
            this.btnLoadFolderOfImages.Click += new System.EventHandler(this.btnLoadFolderOfImages_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 69);
            this.label1.TabIndex = 23;
            this.label1.Text = "Path of Selected Folder:";
            // 
            // lblPathOfSelectedFolder
            // 
            this.lblPathOfSelectedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPathOfSelectedFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathOfSelectedFolder.Location = new System.Drawing.Point(100, 114);
            this.lblPathOfSelectedFolder.Name = "lblPathOfSelectedFolder";
            this.lblPathOfSelectedFolder.Size = new System.Drawing.Size(304, 83);
            this.lblPathOfSelectedFolder.TabIndex = 24;
            this.lblPathOfSelectedFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTrainFromCamera
            // 
            this.pnlTrainFromCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrainFromCamera.Controls.Add(this.label4);
            this.pnlTrainFromCamera.Controls.Add(this.btnTurnOffCamera);
            this.pnlTrainFromCamera.Controls.Add(this.btnStartCamera);
            this.pnlTrainFromCamera.Location = new System.Drawing.Point(28, 565);
            this.pnlTrainFromCamera.Name = "pnlTrainFromCamera";
            this.pnlTrainFromCamera.Size = new System.Drawing.Size(297, 214);
            this.pnlTrainFromCamera.TabIndex = 25;
            this.pnlTrainFromCamera.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Train Faces From a Camera";
            // 
            // pnlTrainFromImage
            // 
            this.pnlTrainFromImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrainFromImage.Controls.Add(this.label6);
            this.pnlTrainFromImage.Controls.Add(this.btnBrowseImage);
            this.pnlTrainFromImage.Location = new System.Drawing.Point(676, 565);
            this.pnlTrainFromImage.Name = "pnlTrainFromImage";
            this.pnlTrainFromImage.Size = new System.Drawing.Size(297, 227);
            this.pnlTrainFromImage.TabIndex = 27;
            this.pnlTrainFromImage.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "Train Faces From an Image";
            // 
            // pnlTrainFacesFromFolder
            // 
            this.pnlTrainFacesFromFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrainFacesFromFolder.Controls.Add(this.label7);
            this.pnlTrainFacesFromFolder.Controls.Add(this.lblPathOfSelectedFolder);
            this.pnlTrainFacesFromFolder.Controls.Add(this.label1);
            this.pnlTrainFacesFromFolder.Controls.Add(this.btnLoadFolderOfImages);
            this.pnlTrainFacesFromFolder.Location = new System.Drawing.Point(1011, 565);
            this.pnlTrainFacesFromFolder.Name = "pnlTrainFacesFromFolder";
            this.pnlTrainFacesFromFolder.Size = new System.Drawing.Size(431, 227);
            this.pnlTrainFacesFromFolder.TabIndex = 28;
            this.pnlTrainFacesFromFolder.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(417, 31);
            this.label7.TabIndex = 25;
            this.label7.Text = "Train Faces From a Folder of Images";
            // 
            // pnlTrainFromVideo
            // 
            this.pnlTrainFromVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrainFromVideo.Controls.Add(this.label5);
            this.pnlTrainFromVideo.Controls.Add(this.btnStopVideo);
            this.pnlTrainFromVideo.Controls.Add(this.btnLoadVideo);
            this.pnlTrainFromVideo.Location = new System.Drawing.Point(347, 565);
            this.pnlTrainFromVideo.Name = "pnlTrainFromVideo";
            this.pnlTrainFromVideo.Size = new System.Drawing.Size(291, 214);
            this.pnlTrainFromVideo.TabIndex = 29;
            this.pnlTrainFromVideo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Train Faces From a Video";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(28, 795);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(638, 104);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(672, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 48);
            this.label8.TabIndex = 31;
            this.label8.Text = "Training Image Name:";
            // 
            // tmrRunImagesInFolder
            // 
            this.tmrRunImagesInFolder.Interval = 1000;
            this.tmrRunImagesInFolder.Tick += new System.EventHandler(this.tmrRunImagesInFolder_Tick);
            // 
            // FrmTrainFaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1455, 920);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlTrainFromVideo);
            this.Controls.Add(this.pnlTrainFacesFromFolder);
            this.Controls.Add(this.pnlTrainFromImage);
            this.Controls.Add(this.pnlTrainFromCamera);
            this.Controls.Add(this.lblSelectTrainingMethod);
            this.Controls.Add(this.cmbSelectTrainingMethod);
            this.Controls.Add(this.lblTotalFacesDetected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNamesExtracted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddTrainingImage);
            this.Controls.Add(this.ImgTrainedFaces);
            this.Controls.Add(this.txtAddTrainingFace);
            this.Controls.Add(this.ImgCamera);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTrainFaces";
            this.Text = "TrainFaces";
            this.Load += new System.EventHandler(this.TrainFaces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgTrainedFaces)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlTrainFromCamera.ResumeLayout(false);
            this.pnlTrainFromImage.ResumeLayout(false);
            this.pnlTrainFacesFromFolder.ResumeLayout(false);
            this.pnlTrainFromVideo.ResumeLayout(false);
            this.pnlTrainFromVideo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ImgCamera;
        private System.Windows.Forms.TextBox txtAddTrainingFace;
        private Emgu.CV.UI.ImageBox ImgTrainedFaces;
        private System.Windows.Forms.Button btnAddTrainingImage;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNamesExtracted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalFacesDetected;
        private System.Windows.Forms.OpenFileDialog the_open_file_dialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadVideo;
        private System.Windows.Forms.Button btnTurnOffCamera;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.ComboBox cmbSelectTrainingMethod;
        private System.Windows.Forms.Label lblSelectTrainingMethod;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Button btnLoadFolderOfImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPathOfSelectedFolder;
        private System.Windows.Forms.Panel pnlTrainFromCamera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlTrainFromImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlTrainFacesFromFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlTrainFromVideo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmrRunImagesInFolder;
        private System.Windows.Forms.ToolStripMenuItem otherSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCapturedFramesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDetectionAndRecognitionOfFacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStudentAttendanceLogFolderToolStripMenuItem;
    }
}