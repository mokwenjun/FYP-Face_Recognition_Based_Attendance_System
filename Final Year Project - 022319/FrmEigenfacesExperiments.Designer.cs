namespace MultiFaceRec
{
    partial class FrmEigenfacesExperiments
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnloadimagefromfolder = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltotalfacesdetected = new System.Windows.Forms.Label();
            this.OpenImagDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnAddImageToTrainingSet = new System.Windows.Forms.Button();
            this.btnLoadImageFromDatabase = new System.Windows.Forms.Button();
            this.btnAddTestingImageToDatabase = new System.Windows.Forms.Button();
            this.lblTestingImgNo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCorrectRecognition = new System.Windows.Forms.Label();
            this.label300 = new System.Windows.Forms.Label();
            this.lblActualRecognition = new System.Windows.Forms.Label();
            this.label301 = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            this.txtRecognizerName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ImgDisplayFace = new Emgu.CV.UI.ImageBox();
            this.picTestingImage = new System.Windows.Forms.PictureBox();
            this.PicTrainingSetViewerImage = new System.Windows.Forms.PictureBox();
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblWrong = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalImagesTested = new System.Windows.Forms.Label();
            this.lblTotalTested = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPercentageAccuracyOfResults = new System.Windows.Forms.Label();
            this.lblRecognizerValue = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbEpsilonValue = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAverageFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEigenDistanceThreshold = new System.Windows.Forms.Label();
            this.trkEigenDistanceThreshold = new System.Windows.Forms.TrackBar();
            this.pnlFaceDetectionSettings = new System.Windows.Forms.Panel();
            this.lblFaceDetSettings_label = new System.Windows.Forms.Label();
            this.lblMinDetectionScale = new System.Windows.Forms.Label();
            this.trkMinDetectionScale = new System.Windows.Forms.TrackBar();
            this.lblMinNeighbors = new System.Windows.Forms.Label();
            this.trkMinNeighbors = new System.Windows.Forms.TrackBar();
            this.lblScaleIncreaseRate = new System.Windows.Forms.Label();
            this.trkScaleIncreaseRate = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFaceNumber = new System.Windows.Forms.Label();
            this.lblNoOfRecognizedImages = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlAddTrainingImage = new System.Windows.Forms.Panel();
            this.btnAddTrainingImagesFromFolder = new System.Windows.Forms.Button();
            this.pnlExperimentalResults = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblTotalProcessingTime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trkChangeResolution = new System.Windows.Forms.TrackBar();
            this.lblResolutionScaleFactor = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblPercentageOfProgress = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlProcessing = new System.Windows.Forms.Panel();
            this.cmb_Select_Data_Set = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.pnlFaceRecSettings = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHighlightRecognizedFace = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.tmrRun = new System.Windows.Forms.Timer(this.components);
            this.txtImageFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTestingImageName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplayFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrainingSetViewerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkEigenDistanceThreshold)).BeginInit();
            this.pnlFaceDetectionSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinDetectionScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinNeighbors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScaleIncreaseRate)).BeginInit();
            this.pnlAddTrainingImage.SuspendLayout();
            this.pnlExperimentalResults.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkChangeResolution)).BeginInit();
            this.pnlProcessing.SuspendLayout();
            this.pnlFaceRecSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Scale Increase Rate:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnloadimagefromfolder
            // 
            this.btnloadimagefromfolder.Enabled = false;
            this.btnloadimagefromfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloadimagefromfolder.Location = new System.Drawing.Point(-1, 831);
            this.btnloadimagefromfolder.Name = "btnloadimagefromfolder";
            this.btnloadimagefromfolder.Size = new System.Drawing.Size(662, 82);
            this.btnloadimagefromfolder.TabIndex = 13;
            this.btnloadimagefromfolder.Text = "Browse Image For Face Recognition Test";
            this.btnloadimagefromfolder.UseVisualStyleBackColor = true;
            this.btnloadimagefromfolder.Click += new System.EventHandler(this.btnloadimagefromfolder_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1261, 841);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 45);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total faces detected:";
            this.label4.Visible = false;
            // 
            // lbltotalfacesdetected
            // 
            this.lbltotalfacesdetected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbltotalfacesdetected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltotalfacesdetected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalfacesdetected.ForeColor = System.Drawing.Color.Red;
            this.lbltotalfacesdetected.Location = new System.Drawing.Point(1359, 841);
            this.lbltotalfacesdetected.Name = "lbltotalfacesdetected";
            this.lbltotalfacesdetected.Size = new System.Drawing.Size(54, 47);
            this.lbltotalfacesdetected.TabIndex = 15;
            this.lbltotalfacesdetected.Text = "0";
            this.lbltotalfacesdetected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltotalfacesdetected.Visible = false;
            // 
            // OpenImagDlg
            // 
            this.OpenImagDlg.FileName = "openFileDialog1";
            // 
            // btnAddImageToTrainingSet
            // 
            this.btnAddImageToTrainingSet.Enabled = false;
            this.btnAddImageToTrainingSet.Location = new System.Drawing.Point(158, 43);
            this.btnAddImageToTrainingSet.Name = "btnAddImageToTrainingSet";
            this.btnAddImageToTrainingSet.Size = new System.Drawing.Size(138, 85);
            this.btnAddImageToTrainingSet.TabIndex = 30;
            this.btnAddImageToTrainingSet.Text = "Add Image To Training Set";
            this.btnAddImageToTrainingSet.UseVisualStyleBackColor = true;
            this.btnAddImageToTrainingSet.Click += new System.EventHandler(this.btnAddImageToTrainingSet_Click);
            // 
            // btnLoadImageFromDatabase
            // 
            this.btnLoadImageFromDatabase.Enabled = false;
            this.btnLoadImageFromDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImageFromDatabase.Location = new System.Drawing.Point(0, 746);
            this.btnLoadImageFromDatabase.Name = "btnLoadImageFromDatabase";
            this.btnLoadImageFromDatabase.Size = new System.Drawing.Size(661, 79);
            this.btnLoadImageFromDatabase.TabIndex = 41;
            this.btnLoadImageFromDatabase.Text = "Start Test";
            this.btnLoadImageFromDatabase.UseVisualStyleBackColor = true;
            this.btnLoadImageFromDatabase.Click += new System.EventHandler(this.btnLoadImageFromDatabase_Click);
            // 
            // btnAddTestingImageToDatabase
            // 
            this.btnAddTestingImageToDatabase.Enabled = false;
            this.btnAddTestingImageToDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTestingImageToDatabase.Location = new System.Drawing.Point(12, 598);
            this.btnAddTestingImageToDatabase.Name = "btnAddTestingImageToDatabase";
            this.btnAddTestingImageToDatabase.Size = new System.Drawing.Size(648, 85);
            this.btnAddTestingImageToDatabase.TabIndex = 46;
            this.btnAddTestingImageToDatabase.Text = "Add Testing Image To Database";
            this.btnAddTestingImageToDatabase.UseVisualStyleBackColor = true;
            this.btnAddTestingImageToDatabase.Click += new System.EventHandler(this.btnAddTestingImageToDatabase_Click);
            // 
            // lblTestingImgNo
            // 
            this.lblTestingImgNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTestingImgNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestingImgNo.Location = new System.Drawing.Point(591, 470);
            this.lblTestingImgNo.Name = "lblTestingImgNo";
            this.lblTestingImgNo.Size = new System.Drawing.Size(70, 39);
            this.lblTestingImgNo.TabIndex = 50;
            this.lblTestingImgNo.Text = "0";
            this.lblTestingImgNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(34, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 51);
            this.label11.TabIndex = 55;
            this.label11.Text = "Correct Answer:";
            // 
            // lblCorrectRecognition
            // 
            this.lblCorrectRecognition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblCorrectRecognition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCorrectRecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectRecognition.Location = new System.Drawing.Point(117, 92);
            this.lblCorrectRecognition.Name = "lblCorrectRecognition";
            this.lblCorrectRecognition.Size = new System.Drawing.Size(512, 64);
            this.lblCorrectRecognition.TabIndex = 56;
            this.lblCorrectRecognition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label300
            // 
            this.label300.Location = new System.Drawing.Point(14, 25);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(99, 54);
            this.label300.TabIndex = 57;
            this.label300.Text = "Recognized Face:";
            // 
            // lblActualRecognition
            // 
            this.lblActualRecognition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblActualRecognition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActualRecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualRecognition.Location = new System.Drawing.Point(119, 13);
            this.lblActualRecognition.Name = "lblActualRecognition";
            this.lblActualRecognition.Size = new System.Drawing.Size(510, 68);
            this.lblActualRecognition.TabIndex = 58;
            this.lblActualRecognition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Location = new System.Drawing.Point(34, 197);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(62, 20);
            this.label301.TabIndex = 59;
            this.label301.Text = "Match?";
            // 
            // lblMatch
            // 
            this.lblMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblMatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch.Location = new System.Drawing.Point(119, 168);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(512, 69);
            this.lblMatch.TabIndex = 60;
            this.lblMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecognizerName
            // 
            this.txtRecognizerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecognizerName.Location = new System.Drawing.Point(7, 280);
            this.txtRecognizerName.Name = "txtRecognizerName";
            this.txtRecognizerName.Size = new System.Drawing.Size(289, 35);
            this.txtRecognizerName.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 20);
            this.label12.TabIndex = 64;
            this.label12.Text = "Training Image Name:";
            // 
            // ImgDisplayFace
            // 
            this.ImgDisplayFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ImgDisplayFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgDisplayFace.Location = new System.Drawing.Point(11, 39);
            this.ImgDisplayFace.Name = "ImgDisplayFace";
            this.ImgDisplayFace.Size = new System.Drawing.Size(144, 144);
            this.ImgDisplayFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgDisplayFace.TabIndex = 2;
            this.ImgDisplayFace.TabStop = false;
            // 
            // picTestingImage
            // 
            this.picTestingImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTestingImage.Location = new System.Drawing.Point(129, 52);
            this.picTestingImage.Name = "picTestingImage";
            this.picTestingImage.Size = new System.Drawing.Size(400, 400);
            this.picTestingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTestingImage.TabIndex = 49;
            this.picTestingImage.TabStop = false;
            // 
            // PicTrainingSetViewerImage
            // 
            this.PicTrainingSetViewerImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PicTrainingSetViewerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicTrainingSetViewerImage.Location = new System.Drawing.Point(1265, 691);
            this.PicTrainingSetViewerImage.Name = "PicTrainingSetViewerImage";
            this.PicTrainingSetViewerImage.Size = new System.Drawing.Size(153, 135);
            this.PicTrainingSetViewerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTrainingSetViewerImage.TabIndex = 31;
            this.PicTrainingSetViewerImage.TabStop = false;
            this.PicTrainingSetViewerImage.Visible = false;
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(6, 36);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(523, 428);
            this.CamImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            this.CamImageBox.Visible = false;
            // 
            // lblRight
            // 
            this.lblRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.Location = new System.Drawing.Point(230, 267);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(81, 63);
            this.lblRight.TabIndex = 75;
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWrong
            // 
            this.lblWrong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblWrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrong.Location = new System.Drawing.Point(477, 267);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(74, 63);
            this.lblWrong.TabIndex = 76;
            this.lblWrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(245, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 20);
            this.label18.TabIndex = 77;
            this.label18.Text = "Match:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(473, 242);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 20);
            this.label19.TabIndex = 78;
            this.label19.Text = "Not Match:";
            // 
            // lblTotalImagesTested
            // 
            this.lblTotalImagesTested.Location = new System.Drawing.Point(27, 347);
            this.lblTotalImagesTested.Name = "lblTotalImagesTested";
            this.lblTotalImagesTested.Size = new System.Drawing.Size(67, 78);
            this.lblTotalImagesTested.TabIndex = 79;
            this.lblTotalImagesTested.Text = "Total Images Tested:";
            // 
            // lblTotalTested
            // 
            this.lblTotalTested.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTotalTested.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalTested.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTested.Location = new System.Drawing.Point(128, 344);
            this.lblTotalTested.Name = "lblTotalTested";
            this.lblTotalTested.Size = new System.Drawing.Size(479, 78);
            this.lblTotalTested.TabIndex = 80;
            this.lblTotalTested.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPercentageAccuracyOfResults
            // 
            this.lblPercentageAccuracyOfResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPercentageAccuracyOfResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPercentageAccuracyOfResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentageAccuracyOfResults.Location = new System.Drawing.Point(128, 429);
            this.lblPercentageAccuracyOfResults.Name = "lblPercentageAccuracyOfResults";
            this.lblPercentageAccuracyOfResults.Size = new System.Drawing.Size(479, 92);
            this.lblPercentageAccuracyOfResults.TabIndex = 81;
            this.lblPercentageAccuracyOfResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecognizerValue
            // 
            this.lblRecognizerValue.Location = new System.Drawing.Point(3, 41);
            this.lblRecognizerValue.Name = "lblRecognizerValue";
            this.lblRecognizerValue.Size = new System.Drawing.Size(123, 53);
            this.lblRecognizerValue.TabIndex = 83;
            this.lblRecognizerValue.Text = "Eigen Distance Threshold:";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(14, 445);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 67);
            this.label20.TabIndex = 85;
            this.label20.Text = "Accuracy in percentage:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 20);
            this.label22.TabIndex = 91;
            this.label22.Text = "MinNeighbors:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 114);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 20);
            this.label24.TabIndex = 92;
            this.label24.Text = "Epsilon Value:";
            // 
            // cmbEpsilonValue
            // 
            this.cmbEpsilonValue.FormattingEnabled = true;
            this.cmbEpsilonValue.Items.AddRange(new object[] {
            "0.001",
            "0.002",
            "0.004",
            "0.006",
            "0.008",
            "0.01",
            "0.02",
            "0.04",
            "0.06",
            "0.08",
            "0.1",
            "0.15",
            "0.2",
            "0.25",
            "0.3",
            "0.35",
            "0.4",
            "0.6",
            "0.8",
            "1",
            "1.2"});
            this.cmbEpsilonValue.Location = new System.Drawing.Point(176, 106);
            this.cmbEpsilonValue.Name = "cmbEpsilonValue";
            this.cmbEpsilonValue.Size = new System.Drawing.Size(188, 28);
            this.cmbEpsilonValue.TabIndex = 93;
            this.cmbEpsilonValue.Text = "0.01";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1907, 33);
            this.menuStrip1.TabIndex = 95;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAverageFaceToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.defaultSettingsToolStripMenuItem,
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // viewAverageFaceToolStripMenuItem
            // 
            this.viewAverageFaceToolStripMenuItem.Name = "viewAverageFaceToolStripMenuItem";
            this.viewAverageFaceToolStripMenuItem.Size = new System.Drawing.Size(433, 30);
            this.viewAverageFaceToolStripMenuItem.Text = "View Average Face";
            this.viewAverageFaceToolStripMenuItem.Click += new System.EventHandler(this.viewAverageFaceToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(433, 30);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // defaultSettingsToolStripMenuItem
            // 
            this.defaultSettingsToolStripMenuItem.Name = "defaultSettingsToolStripMenuItem";
            this.defaultSettingsToolStripMenuItem.Size = new System.Drawing.Size(433, 30);
            this.defaultSettingsToolStripMenuItem.Text = "Default Settings";
            this.defaultSettingsToolStripMenuItem.Click += new System.EventHandler(this.defaultSettingsToolStripMenuItem_Click);
            // 
            // deleteWronglyRecognizedImagesFolderToolStripMenuItem
            // 
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem.Name = "deleteWronglyRecognizedImagesFolderToolStripMenuItem";
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem.Size = new System.Drawing.Size(433, 30);
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem.Text = "Delete Wrongly Recognized Images Folder";
            this.deleteWronglyRecognizedImagesFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteWronglyRecognizedImagesFolderToolStripMenuItem_Click);
            // 
            // lblEigenDistanceThreshold
            // 
            this.lblEigenDistanceThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEigenDistanceThreshold.Location = new System.Drawing.Point(467, 41);
            this.lblEigenDistanceThreshold.Name = "lblEigenDistanceThreshold";
            this.lblEigenDistanceThreshold.Size = new System.Drawing.Size(84, 31);
            this.lblEigenDistanceThreshold.TabIndex = 96;
            this.lblEigenDistanceThreshold.Text = "0";
            // 
            // trkEigenDistanceThreshold
            // 
            this.trkEigenDistanceThreshold.AutoSize = false;
            this.trkEigenDistanceThreshold.Location = new System.Drawing.Point(176, 41);
            this.trkEigenDistanceThreshold.Maximum = 30;
            this.trkEigenDistanceThreshold.Minimum = 7;
            this.trkEigenDistanceThreshold.Name = "trkEigenDistanceThreshold";
            this.trkEigenDistanceThreshold.Size = new System.Drawing.Size(264, 48);
            this.trkEigenDistanceThreshold.TabIndex = 95;
            this.trkEigenDistanceThreshold.Value = 30;
            this.trkEigenDistanceThreshold.Scroll += new System.EventHandler(this.trkEigenDistanceThreshold_Scroll);
            // 
            // pnlFaceDetectionSettings
            // 
            this.pnlFaceDetectionSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFaceDetectionSettings.Controls.Add(this.lblFaceDetSettings_label);
            this.pnlFaceDetectionSettings.Controls.Add(this.lblMinDetectionScale);
            this.pnlFaceDetectionSettings.Controls.Add(this.trkMinDetectionScale);
            this.pnlFaceDetectionSettings.Controls.Add(this.lblMinNeighbors);
            this.pnlFaceDetectionSettings.Controls.Add(this.trkMinNeighbors);
            this.pnlFaceDetectionSettings.Controls.Add(this.lblScaleIncreaseRate);
            this.pnlFaceDetectionSettings.Controls.Add(this.trkScaleIncreaseRate);
            this.pnlFaceDetectionSettings.Controls.Add(this.label3);
            this.pnlFaceDetectionSettings.Controls.Add(this.label22);
            this.pnlFaceDetectionSettings.Controls.Add(this.label1);
            this.pnlFaceDetectionSettings.Location = new System.Drawing.Point(694, 45);
            this.pnlFaceDetectionSettings.Name = "pnlFaceDetectionSettings";
            this.pnlFaceDetectionSettings.Size = new System.Drawing.Size(565, 189);
            this.pnlFaceDetectionSettings.TabIndex = 101;
            // 
            // lblFaceDetSettings_label
            // 
            this.lblFaceDetSettings_label.Location = new System.Drawing.Point(3, 0);
            this.lblFaceDetSettings_label.Name = "lblFaceDetSettings_label";
            this.lblFaceDetSettings_label.Size = new System.Drawing.Size(195, 26);
            this.lblFaceDetSettings_label.TabIndex = 100;
            this.lblFaceDetSettings_label.Text = "Face Detection Settings:";
            // 
            // lblMinDetectionScale
            // 
            this.lblMinDetectionScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinDetectionScale.Location = new System.Drawing.Point(467, 138);
            this.lblMinDetectionScale.Name = "lblMinDetectionScale";
            this.lblMinDetectionScale.Size = new System.Drawing.Size(93, 29);
            this.lblMinDetectionScale.TabIndex = 99;
            this.lblMinDetectionScale.Text = "0";
            // 
            // trkMinDetectionScale
            // 
            this.trkMinDetectionScale.AutoSize = false;
            this.trkMinDetectionScale.Location = new System.Drawing.Point(176, 130);
            this.trkMinDetectionScale.Maximum = 20;
            this.trkMinDetectionScale.Minimum = 1;
            this.trkMinDetectionScale.Name = "trkMinDetectionScale";
            this.trkMinDetectionScale.Size = new System.Drawing.Size(264, 37);
            this.trkMinDetectionScale.TabIndex = 98;
            this.trkMinDetectionScale.Value = 4;
            this.trkMinDetectionScale.Scroll += new System.EventHandler(this.trkMinDetectionScale_Scroll);
            // 
            // lblMinNeighbors
            // 
            this.lblMinNeighbors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinNeighbors.Location = new System.Drawing.Point(467, 93);
            this.lblMinNeighbors.Name = "lblMinNeighbors";
            this.lblMinNeighbors.Size = new System.Drawing.Size(93, 31);
            this.lblMinNeighbors.TabIndex = 97;
            this.lblMinNeighbors.Text = "0";
            // 
            // trkMinNeighbors
            // 
            this.trkMinNeighbors.AutoSize = false;
            this.trkMinNeighbors.Location = new System.Drawing.Point(176, 83);
            this.trkMinNeighbors.Maximum = 30;
            this.trkMinNeighbors.Name = "trkMinNeighbors";
            this.trkMinNeighbors.Size = new System.Drawing.Size(264, 41);
            this.trkMinNeighbors.TabIndex = 96;
            this.trkMinNeighbors.Value = 4;
            this.trkMinNeighbors.Scroll += new System.EventHandler(this.trkMinNeighbors_Scroll);
            // 
            // lblScaleIncreaseRate
            // 
            this.lblScaleIncreaseRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaleIncreaseRate.Location = new System.Drawing.Point(467, 41);
            this.lblScaleIncreaseRate.Name = "lblScaleIncreaseRate";
            this.lblScaleIncreaseRate.Size = new System.Drawing.Size(93, 28);
            this.lblScaleIncreaseRate.TabIndex = 95;
            this.lblScaleIncreaseRate.Text = "0";
            // 
            // trkScaleIncreaseRate
            // 
            this.trkScaleIncreaseRate.AutoSize = false;
            this.trkScaleIncreaseRate.Location = new System.Drawing.Point(176, 41);
            this.trkScaleIncreaseRate.Maximum = 80;
            this.trkScaleIncreaseRate.Minimum = 51;
            this.trkScaleIncreaseRate.Name = "trkScaleIncreaseRate";
            this.trkScaleIncreaseRate.Size = new System.Drawing.Size(264, 38);
            this.trkScaleIncreaseRate.TabIndex = 94;
            this.trkScaleIncreaseRate.Value = 55;
            this.trkScaleIncreaseRate.Scroll += new System.EventHandler(this.trkScaleIncreaseRate_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 92;
            this.label3.Text = "Min Detection Scale:";
            // 
            // lblFaceNumber
            // 
            this.lblFaceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaceNumber.Location = new System.Drawing.Point(173, 190);
            this.lblFaceNumber.Name = "lblFaceNumber";
            this.lblFaceNumber.Size = new System.Drawing.Size(107, 50);
            this.lblFaceNumber.TabIndex = 107;
            this.lblFaceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOfRecognizedImages
            // 
            this.lblNoOfRecognizedImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoOfRecognizedImages.Location = new System.Drawing.Point(176, 133);
            this.lblNoOfRecognizedImages.Name = "lblNoOfRecognizedImages";
            this.lblNoOfRecognizedImages.Size = new System.Drawing.Size(104, 50);
            this.lblNoOfRecognizedImages.TabIndex = 104;
            this.lblNoOfRecognizedImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoOfRecognizedImages.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(151, 20);
            this.label17.TabIndex = 103;
            this.label17.Text = "Add Training Image:";
            // 
            // pnlAddTrainingImage
            // 
            this.pnlAddTrainingImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddTrainingImage.Controls.Add(this.btnAddTrainingImagesFromFolder);
            this.pnlAddTrainingImage.Controls.Add(this.lblNoOfRecognizedImages);
            this.pnlAddTrainingImage.Controls.Add(this.label17);
            this.pnlAddTrainingImage.Controls.Add(this.lblFaceNumber);
            this.pnlAddTrainingImage.Controls.Add(this.label12);
            this.pnlAddTrainingImage.Controls.Add(this.txtRecognizerName);
            this.pnlAddTrainingImage.Controls.Add(this.ImgDisplayFace);
            this.pnlAddTrainingImage.Controls.Add(this.btnAddImageToTrainingSet);
            this.pnlAddTrainingImage.Location = new System.Drawing.Point(694, 407);
            this.pnlAddTrainingImage.Name = "pnlAddTrainingImage";
            this.pnlAddTrainingImage.Size = new System.Drawing.Size(493, 325);
            this.pnlAddTrainingImage.TabIndex = 104;
            // 
            // btnAddTrainingImagesFromFolder
            // 
            this.btnAddTrainingImagesFromFolder.Location = new System.Drawing.Point(305, 43);
            this.btnAddTrainingImagesFromFolder.Name = "btnAddTrainingImagesFromFolder";
            this.btnAddTrainingImagesFromFolder.Size = new System.Drawing.Size(135, 85);
            this.btnAddTrainingImagesFromFolder.TabIndex = 108;
            this.btnAddTrainingImagesFromFolder.Text = "Add Training Images From Folder";
            this.btnAddTrainingImagesFromFolder.UseVisualStyleBackColor = true;
            this.btnAddTrainingImagesFromFolder.Visible = false;
            this.btnAddTrainingImagesFromFolder.Click += new System.EventHandler(this.btnAddTrainingImagesFromFolder_Click);
            // 
            // pnlExperimentalResults
            // 
            this.pnlExperimentalResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExperimentalResults.Controls.Add(this.lblPercentageAccuracyOfResults);
            this.pnlExperimentalResults.Controls.Add(this.lblTotalTested);
            this.pnlExperimentalResults.Controls.Add(this.lblTotalImagesTested);
            this.pnlExperimentalResults.Controls.Add(this.label19);
            this.pnlExperimentalResults.Controls.Add(this.label18);
            this.pnlExperimentalResults.Controls.Add(this.lblWrong);
            this.pnlExperimentalResults.Controls.Add(this.lblRight);
            this.pnlExperimentalResults.Controls.Add(this.label20);
            this.pnlExperimentalResults.Controls.Add(this.lblMatch);
            this.pnlExperimentalResults.Controls.Add(this.label301);
            this.pnlExperimentalResults.Controls.Add(this.lblActualRecognition);
            this.pnlExperimentalResults.Controls.Add(this.label300);
            this.pnlExperimentalResults.Controls.Add(this.lblCorrectRecognition);
            this.pnlExperimentalResults.Controls.Add(this.label11);
            this.pnlExperimentalResults.Location = new System.Drawing.Point(1265, 152);
            this.pnlExperimentalResults.Name = "pnlExperimentalResults";
            this.pnlExperimentalResults.Size = new System.Drawing.Size(642, 533);
            this.pnlExperimentalResults.TabIndex = 106;
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(5, 919);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(178, 63);
            this.btnRestart.TabIndex = 107;
            this.btnRestart.Text = "Reset";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblTotalProcessingTime
            // 
            this.lblTotalProcessingTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalProcessingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProcessingTime.Location = new System.Drawing.Point(8, 42);
            this.lblTotalProcessingTime.Name = "lblTotalProcessingTime";
            this.lblTotalProcessingTime.Size = new System.Drawing.Size(272, 42);
            this.lblTotalProcessingTime.TabIndex = 109;
            this.lblTotalProcessingTime.Text = "0";
            this.lblTotalProcessingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(4, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(284, 25);
            this.label14.TabIndex = 110;
            this.label14.Text = "Total time taken to process all images:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblTotalProcessingTime);
            this.panel2.Location = new System.Drawing.Point(694, 756);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 93);
            this.panel2.TabIndex = 115;
            // 
            // trkChangeResolution
            // 
            this.trkChangeResolution.AutoSize = false;
            this.trkChangeResolution.Location = new System.Drawing.Point(1551, 991);
            this.trkChangeResolution.Maximum = 20;
            this.trkChangeResolution.Minimum = 1;
            this.trkChangeResolution.Name = "trkChangeResolution";
            this.trkChangeResolution.Size = new System.Drawing.Size(288, 57);
            this.trkChangeResolution.TabIndex = 126;
            this.trkChangeResolution.Value = 20;
            this.trkChangeResolution.Visible = false;
            this.trkChangeResolution.Scroll += new System.EventHandler(this.trkChangeResolution_Scroll);
            // 
            // lblResolutionScaleFactor
            // 
            this.lblResolutionScaleFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolutionScaleFactor.Location = new System.Drawing.Point(1845, 991);
            this.lblResolutionScaleFactor.Name = "lblResolutionScaleFactor";
            this.lblResolutionScaleFactor.Size = new System.Drawing.Size(34, 36);
            this.lblResolutionScaleFactor.TabIndex = 127;
            this.lblResolutionScaleFactor.Text = "x1";
            this.lblResolutionScaleFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResolutionScaleFactor.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(631, 39);
            this.progressBar1.TabIndex = 134;
            // 
            // lblPercentageOfProgress
            // 
            this.lblPercentageOfProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentageOfProgress.Location = new System.Drawing.Point(224, 6);
            this.lblPercentageOfProgress.Name = "lblPercentageOfProgress";
            this.lblPercentageOfProgress.Size = new System.Drawing.Size(390, 46);
            this.lblPercentageOfProgress.TabIndex = 135;
            this.lblPercentageOfProgress.Text = "0%   Complete";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(3, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(215, 46);
            this.label23.TabIndex = 136;
            this.label23.Text = "Processing...";
            // 
            // pnlProcessing
            // 
            this.pnlProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessing.Controls.Add(this.label23);
            this.pnlProcessing.Controls.Add(this.lblPercentageOfProgress);
            this.pnlProcessing.Controls.Add(this.progressBar1);
            this.pnlProcessing.Location = new System.Drawing.Point(1265, 45);
            this.pnlProcessing.Name = "pnlProcessing";
            this.pnlProcessing.Size = new System.Drawing.Size(642, 99);
            this.pnlProcessing.TabIndex = 137;
            this.pnlProcessing.Visible = false;
            // 
            // cmb_Select_Data_Set
            // 
            this.cmb_Select_Data_Set.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Select_Data_Set.FormattingEnabled = true;
            this.cmb_Select_Data_Set.Items.AddRange(new object[] {
            "Select a Data Set",
            "Student Data Set 1",
            "Student Data Set 2",
            "Student Data Set 3"});
            this.cmb_Select_Data_Set.Location = new System.Drawing.Point(218, 696);
            this.cmb_Select_Data_Set.Name = "cmb_Select_Data_Set";
            this.cmb_Select_Data_Set.Size = new System.Drawing.Size(443, 37);
            this.cmb_Select_Data_Set.TabIndex = 139;
            this.cmb_Select_Data_Set.Text = "Select a Data Set";
            this.cmb_Select_Data_Set.SelectedIndexChanged += new System.EventHandler(this.cmb_Select_Data_Set_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 702);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(201, 30);
            this.label26.TabIndex = 140;
            this.label26.Text = "Choose Data Set:";
            // 
            // pnlFaceRecSettings
            // 
            this.pnlFaceRecSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFaceRecSettings.Controls.Add(this.label2);
            this.pnlFaceRecSettings.Controls.Add(this.lblEigenDistanceThreshold);
            this.pnlFaceRecSettings.Controls.Add(this.cmbEpsilonValue);
            this.pnlFaceRecSettings.Controls.Add(this.trkEigenDistanceThreshold);
            this.pnlFaceRecSettings.Controls.Add(this.label24);
            this.pnlFaceRecSettings.Controls.Add(this.lblRecognizerValue);
            this.pnlFaceRecSettings.Location = new System.Drawing.Point(694, 244);
            this.pnlFaceRecSettings.Name = "pnlFaceRecSettings";
            this.pnlFaceRecSettings.Size = new System.Drawing.Size(565, 146);
            this.pnlFaceRecSettings.TabIndex = 141;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Face Recognition Settings:";
            // 
            // chkHighlightRecognizedFace
            // 
            this.chkHighlightRecognizedFace.Checked = true;
            this.chkHighlightRecognizedFace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightRecognizedFace.Enabled = false;
            this.chkHighlightRecognizedFace.Location = new System.Drawing.Point(694, 858);
            this.chkHighlightRecognizedFace.Name = "chkHighlightRecognizedFace";
            this.chkHighlightRecognizedFace.Size = new System.Drawing.Size(233, 41);
            this.chkHighlightRecognizedFace.TabIndex = 130;
            this.chkHighlightRecognizedFace.Text = "Highlight Recognized Face";
            this.chkHighlightRecognizedFace.UseVisualStyleBackColor = true;
            this.chkHighlightRecognizedFace.CheckedChanged += new System.EventHandler(this.chkHighlightRecognizedFace_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(493, 919);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(168, 63);
            this.btnExit.TabIndex = 142;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tmrRun
            // 
            this.tmrRun.Interval = 1000;
            this.tmrRun.Tick += new System.EventHandler(this.tmrRun_Tick);
            // 
            // txtImageFileName
            // 
            this.txtImageFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageFileName.Location = new System.Drawing.Point(129, 470);
            this.txtImageFileName.Name = "txtImageFileName";
            this.txtImageFileName.Size = new System.Drawing.Size(442, 39);
            this.txtImageFileName.TabIndex = 143;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 44);
            this.label5.TabIndex = 144;
            this.label5.Text = "Image File Name:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 531);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 47);
            this.label6.TabIndex = 145;
            this.label6.Text = "Image Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTestingImageName
            // 
            this.lblTestingImageName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTestingImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTestingImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestingImageName.Location = new System.Drawing.Point(125, 528);
            this.lblTestingImageName.Name = "lblTestingImageName";
            this.lblTestingImageName.Size = new System.Drawing.Size(446, 47);
            this.lblTestingImageName.TabIndex = 146;
            this.lblTestingImageName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmEigenfacesExperiments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1907, 994);
            this.Controls.Add(this.lblTestingImageName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImageFileName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.PicTrainingSetViewerImage);
            this.Controls.Add(this.chkHighlightRecognizedFace);
            this.Controls.Add(this.pnlFaceRecSettings);
            this.Controls.Add(this.lblResolutionScaleFactor);
            this.Controls.Add(this.trkChangeResolution);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmb_Select_Data_Set);
            this.Controls.Add(this.pnlProcessing);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.pnlExperimentalResults);
            this.Controls.Add(this.pnlAddTrainingImage);
            this.Controls.Add(this.pnlFaceDetectionSettings);
            this.Controls.Add(this.picTestingImage);
            this.Controls.Add(this.lblTestingImgNo);
            this.Controls.Add(this.btnAddTestingImageToDatabase);
            this.Controls.Add(this.btnLoadImageFromDatabase);
            this.Controls.Add(this.lbltotalfacesdetected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnloadimagefromfolder);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CamImageBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmEigenfacesExperiments";
            this.Text = "Conduct Face Experiments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEigenfacesExperiments_FormClosing);
            this.Load += new System.EventHandler(this.FrmEigenfacesExperiments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplayFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrainingSetViewerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkEigenDistanceThreshold)).EndInit();
            this.pnlFaceDetectionSettings.ResumeLayout(false);
            this.pnlFaceDetectionSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinDetectionScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinNeighbors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScaleIncreaseRate)).EndInit();
            this.pnlAddTrainingImage.ResumeLayout(false);
            this.pnlAddTrainingImage.PerformLayout();
            this.pnlExperimentalResults.ResumeLayout(false);
            this.pnlExperimentalResults.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkChangeResolution)).EndInit();
            this.pnlProcessing.ResumeLayout(false);
            this.pnlFaceRecSettings.ResumeLayout(false);
            this.pnlFaceRecSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnloadimagefromfolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltotalfacesdetected;
        private System.Windows.Forms.OpenFileDialog OpenImagDlg;
        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button btnAddImageToTrainingSet;
        private System.Windows.Forms.PictureBox PicTrainingSetViewerImage;
        private System.Windows.Forms.Button btnLoadImageFromDatabase;
        private System.Windows.Forms.Button btnAddTestingImageToDatabase;
        private System.Windows.Forms.PictureBox picTestingImage;
        private System.Windows.Forms.Label lblTestingImgNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCorrectRecognition;
        private System.Windows.Forms.Label label300;
        private System.Windows.Forms.Label lblActualRecognition;
        private System.Windows.Forms.Label label301;
        private System.Windows.Forms.Label lblMatch;
        private Emgu.CV.UI.ImageBox ImgDisplayFace;
        private System.Windows.Forms.TextBox txtRecognizerName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTotalImagesTested;
        private System.Windows.Forms.Label lblTotalTested;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPercentageAccuracyOfResults;
        private System.Windows.Forms.Label lblRecognizerValue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbEpsilonValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFaceDetectionSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pnlAddTrainingImage;
        private System.Windows.Forms.Panel pnlExperimentalResults;
        private System.Windows.Forms.Label lblFaceNumber;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblNoOfRecognizedImages;
        private System.Windows.Forms.Label lblTotalProcessingTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEigenDistanceThreshold;
        private System.Windows.Forms.TrackBar trkEigenDistanceThreshold;
        private System.Windows.Forms.Label lblScaleIncreaseRate;
        private System.Windows.Forms.TrackBar trkScaleIncreaseRate;
        private System.Windows.Forms.Label lblMinNeighbors;
        private System.Windows.Forms.TrackBar trkMinNeighbors;
        private System.Windows.Forms.Label lblMinDetectionScale;
        private System.Windows.Forms.TrackBar trkMinDetectionScale;
        private System.Windows.Forms.TrackBar trkChangeResolution;
        private System.Windows.Forms.Label lblResolutionScaleFactor;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPercentageOfProgress;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ToolStripMenuItem viewAverageFaceToolStripMenuItem;
        private System.Windows.Forms.Panel pnlProcessing;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_Select_Data_Set;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripMenuItem defaultSettingsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFaceRecSettings;
        private System.Windows.Forms.CheckBox chkHighlightRecognizedFace;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFaceDetSettings_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTrainingImagesFromFolder;
        private System.Windows.Forms.Timer tmrRun;
        private System.Windows.Forms.TextBox txtImageFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTestingImageName;
        private System.Windows.Forms.ToolStripMenuItem deleteWronglyRecognizedImagesFolderToolStripMenuItem;
    }
}