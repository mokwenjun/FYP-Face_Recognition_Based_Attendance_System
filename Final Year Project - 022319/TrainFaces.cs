using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Media;
using System.Drawing.Drawing2D;

//====================Adding the OpenCV libraries================================
//Go to OpenCV file
//Add Emgu.CV.dll as a Reference
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace MultiFaceRec
{
    public partial class FrmTrainFaces : Form
    {
        //Gets a current frame
        Image<Bgr, byte> currentFrame;
        //Gets the frame from the image
        Image<Bgr, byte> the_image_frame;
        //Gets the frame from the image
        //Start the camera
        Capture grabber;
        HaarCascade face;
        //In the result variable, the detected face will be saved
        Image<Gray, byte> result, TrainedFace = null;
        //==========Convert to gray for camera=============================//
        Image<Gray, byte> gray = null;
        //Initialize faces and name storage array
        //======================Store Training Images for the camera============//
        List<Image<Gray, byte>> TrainingImages = new List<Image<Gray, byte>>();
        //=============================Font===================================//
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5d, 0.5d);
        //==========Initialize name storage array for frame from camera===//
        List<string> labels = new List<string>();
        //=====Store a list of names from training images captured by camera==//
        List<string> NamePersons = new List<string>();
        //====Store the variables for images captured by camera===============//
        int ContTrain, NumLabels, t;
        //===To indicate that the camera is still capturing information=======//
        private bool captureInProgress;
        //=====names to indicate the recognized images from the camera=======//
        string name, names = null;
        private bool whether_camera_is_on = false;
        private bool saveToFileWithoutFaceRecognition = false;
        private bool enable_detection_and_recognition_of_faces = true;
        //===================Indicates the number of faces detected==========//
        int No_Faces_Detected = 0;
        public FrmTrainFaces()
        {
            InitializeComponent();
            //Load HaarCascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "Face" + tf + ".bmp";
                    TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in the training set. Please train at least a face.", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            whether_camera_is_on = true;
            //if there is nothing captured by the camera
            if(grabber == null)
            {
                try
                {
                    grabber = new Capture(0);
                }
                catch(NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if(grabber !=null)
            {
                if(captureInProgress)
                {
                    //If camera is getting frames, then pause the capture and set button text to "Resume Camera" for resuming capture
                    btnStartCamera.Text = "Resume Camera";
                    Application.Idle -= FrameGrabber;
                }
                else
                {
                    //If camera is not getting frames then start the capture and set button text to "Pause" for pausing capture
                    btnStartCamera.Text = "Pause Camera";
                    Application.Idle += FrameGrabber;
                }
                captureInProgress = !captureInProgress;
            }
        }

        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            whether_camera_is_on = true;
            btnTurnOffCamera.Text = "Stop Video";
            if (grabber == null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Video Files |*.mp4";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    grabber = new Capture(ofd.FileName);
                }
            }
            if (grabber != null)
            {
                if (captureInProgress)
                {
                    btnLoadVideo.Text = "Resume Video";
                    Application.Idle -= FrameGrabber;
                }
                else
                {
                    btnLoadVideo.Text = "Pause Video";
                    Application.Idle += FrameGrabber;
                }
                captureInProgress = !captureInProgress;
            }
        }

        private void btnTurnOffCamera_Click(object sender, EventArgs e)
        {
            whether_camera_is_on = false;
            txtAddTrainingFace.Clear();
            lblTotalFacesDetected.Text = "";
            lblNamesExtracted.Text = "";
            ImgTrainedFaces.Image = null;
            if (grabber != null)
            {
                if (captureInProgress)
                {
                    //If camera is getting frames then pause the capture and set button text to "Resume" for resuming capture
                    btnStartCamera.Text = "Start Camera";
                    Application.Idle -= FrameGrabber;
                    ReleaseData();
                    grabber = null;
                    ImgCamera.Image = null;
                }
                else
                {
                    ReleaseData();
                    grabber = null;
                    ImgCamera.Image = null;
                }
                captureInProgress = !captureInProgress;
            }
            //btnStartCamera.Text = "Turn Off Camera";
        }
        private void ReleaseData()
        {
            if (grabber != null)
            {
                grabber.Dispose();
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (whether_camera_is_on == false)
            {
                //=================Check if I have selected some image or not===========================//
                OpenFileDialog the_open_file_dialog = new OpenFileDialog();
                the_open_file_dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.bmp";
                if (the_open_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    //========Get the file name without extension and place to indicate the name of the image==//
                    //string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    //lblImgName.Text = fileName;
                    Image theInputImg = Image.FromFile(the_open_file_dialog.FileName);
                    try
                    {
                        if (theInputImg == null)
                        {
                            throw new Exception("Please select an image");
                        }
                        the_image_frame = new Image<Bgr, byte>(new Bitmap(theInputImg));
                        ImgCamera.Image = the_image_frame;
                        string fileName = Path.GetFileName(the_open_file_dialog.FileName);
                        //var match = fileName.IndexOfAny("_0123456789.".ToCharArray()) != -1;
                            int index = fileName.IndexOfAny("_0123456789.".ToCharArray());
                            string extracted_training_label = fileName.Substring(0, index);
                            if (index > 0)
                            {
                                txtAddTrainingFace.Text = extracted_training_label;
                            }


                        DetectFaces();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Turn off the camera first!");
            }
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                lblTotalFacesDetected.Text = "0";
                No_Faces_Detected = 0;
                NamePersons.Add("");
                //Initialize grabber event
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                if (currentFrame != null)
                {
                    //Obtain the captured frame in Bitmap
                    Bitmap ConvertedTobitmap = new Bitmap(grabber.QueryFrame().Bitmap);
                    //If the save menu strip item is being selected
                    if (saveToFileWithoutFaceRecognition)
                    {
                        //Save image frame in the desired location
                        SaveFileDialog save_Frame_Without_Face_Recognized = new SaveFileDialog();
                        save_Frame_Without_Face_Recognized.Filter = "Images|*.png;*.bmp;*.jpg";
                        ImageFormat format = ImageFormat.Png;
                        if (save_Frame_Without_Face_Recognized.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string ext = System.IO.Path.GetExtension(save_Frame_Without_Face_Recognized.FileName);
                            switch (ext)
                            {
                                case ".jpg":
                                    format = ImageFormat.Jpeg;
                                    break;
                                case ".bmp":
                                    format = ImageFormat.Bmp;
                                    break;
                            }
                            ConvertedTobitmap.Save(save_Frame_Without_Face_Recognized.FileName, format);
                        }
                        saveToFileWithoutFaceRecognition = !saveToFileWithoutFaceRecognition;
                    }
                    else
                    {

                    }
                    if (enable_detection_and_recognition_of_faces == true)
                    {
                        gray = currentFrame.Convert<Gray, byte>();
                        //Face Detector
                        MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                        face,
                        1.2,
                        8,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20));
                        if (facesDetected[0].Length > 0)
                        {
                            foreach (MCvAvgComp f in facesDetected[0])
                            {
                                //If the face is found, increment t
                                t = t + 1;
                                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                                //Now see the result by copying the detected face in a frame name as result
                                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                                //The face detected in channel 0 (grey) is drawn with a red rectangle of thickness 2
                                if (TrainingImages.ToArray().Length != 0)
                                {
                                    //termcriteria against each image to find a match with it to perform different iterations
                                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                                    //Call class by creating object and pass parameters 
                                    EigenFaceRecognizer recognizer = new EigenFaceRecognizer(
                                        TrainingImages.ToArray(),
                                        labels.ToArray(),
                                        5000,
                                        ref termCrit
                                        );
                                    //100 - needs to be in the same orientation but increasing it to 2000 or 3000 is otherwise
                                    //Next step is to name find for recognized face
                                    name = recognizer.Recognize(result);
                                    if (string.IsNullOrEmpty(name) == true)
                                    {
                                        name = "UNKNOWN";
                                    }
                                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                                }
                                //Now draw the rectangle on the detected image
                                NamePersons[t - 1] = name;
                                NamePersons.Add("");
                                lblTotalFacesDetected.Text = facesDetected[0].Length.ToString();
                                ImgTrainedFaces.Image = result;
                            }
                        }
                        else if(facesDetected[0].Length==0)
                        {
                            ImgTrainedFaces.Image = null;
                        }
                        else
                        {
                        }
                        t = 0;
                        ImgCamera.Image = currentFrame;
                        if (facesDetected[0].Length < 1)
                        {
                            lblNamesExtracted.Text = "";
                            names = "";
                            NamePersons.Clear();
                        }
                        else if (facesDetected[0].Length >= 1)
                        {
                            for (int namelabel = 0; namelabel < facesDetected[0].Length; namelabel++)
                            {
                                names = names + NamePersons[namelabel] + ",";
                            }
                            //Show the faces procesed and recognized                           
                            string names_without_comma_at_the_end = names.Remove(names.Length - 1);
                            lblNamesExtracted.Text = names_without_comma_at_the_end;
                            names = "";
                            //Clear the list(vector) of names
                            NamePersons.Clear();
                        }
                    }
                    else if(enable_detection_and_recognition_of_faces==false)
                    {
                        ImgCamera.Image = currentFrame;
                    }
                    else
                    {
                    }
                }                
            }
            catch(Exception)
            {

            }
        }
        private void Get_the_Trained_Face_Extracted()
        {
            if (whether_camera_is_on == true)
            {
                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.1,
                3,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
            }
            else
            {
            }
            //resize face detected image for force to compare the same size with the test image with cubic interpolation type method
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
        }
        private void btnAddTrainingImage_Click(object sender, EventArgs e)
        {
            //======================Create the trained faces folder if it does not exist============================//
            string folder_name = Application.StartupPath + "/TrainedFaces/";
            if (!Directory.Exists(folder_name))
            {
                Directory.CreateDirectory(folder_name);
            }
            string file_name = "TrainedLabels.txt";
            string path_string = Path.Combine(folder_name, file_name);
            Console.WriteLine("Path to my file {0}\n", path_string);
            if (!File.Exists(path_string))
            {
                {
                    using (FileStream fs = File.Create(path_string))
                    {
                    }
                }
            }
            //========================Add Training Image from camera================================//     
            if (txtAddTrainingFace.Text == "")
            {
                MessageBox.Show("Please key in the name of the face to be added to the training set", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //Trained face counter
                    ContTrain = ContTrain + 1;
                    Get_the_Trained_Face_Extracted();
                    ImgTrainedFaces.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    labels.Add(txtAddTrainingFace.Text);

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", TrainingImages.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/Face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }

                    MessageBox.Show(txtAddTrainingFace.Text + "´s face detected and added to the training set", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("A face needs to be detected first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cmbSelectTrainingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSelectTrainingMethod.Text =="Select Training Method")
            {
                MessageBox.Show("Please select a method to train faces!");
            }
            else if(cmbSelectTrainingMethod.Text == "From a Camera")
            {
                pnlTrainFromCamera.Visible = true;
                pnlTrainFromVideo.Visible = false;
                pnlTrainFromImage.Visible = false;
                pnlTrainFacesFromFolder.Visible = false;
            }
            else if(cmbSelectTrainingMethod.Text == "From a Video")
            {
                btnTurnOffCamera.PerformClick();
                pnlTrainFromCamera.Visible = false;
                pnlTrainFromVideo.Visible = true;
                pnlTrainFromImage.Visible = false;
                pnlTrainFacesFromFolder.Visible = false;
            }
            else if(cmbSelectTrainingMethod.Text == "From an Image")
            {
                btnTurnOffCamera.PerformClick();
                pnlTrainFromCamera.Visible = false;
                pnlTrainFromVideo.Visible = false;
                pnlTrainFromImage.Visible = true;
                pnlTrainFacesFromFolder.Visible = false;
            }
            else if(cmbSelectTrainingMethod.Text =="From a Folder")
            {
                btnTurnOffCamera.PerformClick();
                pnlTrainFromCamera.Visible = false;
                pnlTrainFromVideo.Visible = false;
                pnlTrainFromImage.Visible = false;
                pnlTrainFacesFromFolder.Visible = true;
            }
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            whether_camera_is_on = false;
            txtAddTrainingFace.Clear();
            lblTotalFacesDetected.Text = "";
            lblNamesExtracted.Text = "";
            ImgTrainedFaces.Image = null;
            if (grabber != null)
            {
                if (captureInProgress)
                {                
                    Application.Idle -= FrameGrabber;
                    ReleaseData();
                    grabber = null;
                    ImgCamera.Image = null;
                }
                else
                {
                    ReleaseData();
                    grabber = null;
                    ImgCamera.Image = null;
                }
                captureInProgress = !captureInProgress;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrainFaces NwTrainFaces = new FrmTrainFaces();
            NwTrainFaces.Show();
            this.Dispose(false);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmlog = new FrmLogin();
            frmlog.Show();
            this.Hide();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnTurnOffCamera.PerformClick();
            FrmAdministratorMainPage frm_am = new FrmAdministratorMainPage();
            frm_am.Show();
            this.Hide();
        }
        string folder_path = "";
        private void btnLoadFolderOfImages_Click(object sender, EventArgs e)
        {
            //==================Create the TrainedFaces folder if it does not exist=====================//
            string folder_name = Application.StartupPath + "/TrainedFaces/";
            if (!Directory.Exists(folder_name))
            {
                Directory.CreateDirectory(folder_name);
            }
            string file_name = "TrainedLabels.txt";
            string path_string = Path.Combine(folder_name, file_name);
            Console.WriteLine("Path to my file {0}\n", path_string);
            if (!File.Exists(path_string))
            {
                {
                    using (FileStream fs = File.Create(path_string))
                    {
                    }
                }
            }
            FolderBrowserDialog folder_selected = new FolderBrowserDialog();
            if(folder_selected.ShowDialog()==DialogResult.OK)
            {
                folder_selected.Description = "Select the folder which you want to load the training images";
                folder_path = folder_selected.SelectedPath;
                lblPathOfSelectedFolder.Text = folder_path;
            }
            else if(folder_selected.ShowDialog()==DialogResult.Cancel)
            {
                return;
            }
            else
            {
            }
                tmrRunImagesInFolder.Start();   
        }
        int img_counter = 0;

        private void saveCapturedFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToFileWithoutFaceRecognition = !saveToFileWithoutFaceRecognition;
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enable_detection_and_recognition_of_faces = true;
        }
        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enable_detection_and_recognition_of_faces = false;
        }

        private void deleteStudentAttendanceLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Student_Attendance_Log_Path = Application.StartupPath + "\\Student Attendance Log\\";
            try
            {
                if (Directory.Exists(Student_Attendance_Log_Path) == true)
                {
                    var dir = new DirectoryInfo(Application.StartupPath + "\\Student Attendance Log\\");
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                    dir.Delete(true);
                    MessageBox.Show("(Student Attendance Log) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tmrRunImagesInFolder_Tick(object sender, EventArgs e)
        {
            try
            {
                //  string[] images = Directory.GetFiles(Application.StartupPath+ "\\Data Sets\\Training Set\\Training Set of Faces With Names", "*.bmp");
                string[] images = Directory.GetFiles(folder_path);
                Image image_from_file = Image.FromFile(images[img_counter]);
                the_image_frame = new Image<Bgr, byte>((Bitmap)image_from_file);
                ImgCamera.Image = the_image_frame;
                string ImageName = Path.GetFileName(images[img_counter]);
                int index = ImageName.IndexOfAny("_0123456789.".ToCharArray());
                string extracted_training_label = ImageName.Substring(0, index);
                if (index > 0)
                {
                    txtAddTrainingFace.Text = extracted_training_label;
                }
                DetectFaces();
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                ImgTrainedFaces.Image = TrainedFace;
                TrainingImages.Add(TrainedFace);
                labels.Add(txtAddTrainingFace.Text);
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", TrainingImages.ToArray().Length.ToString() + "%");
                //Write label or data name to the file
                for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                {
                    //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                    TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/Face" + i + ".bmp");
                    //Save names to text file
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");

                }
                //btnAddImageToTrainingSet.PerformClick();         
                //TestingImage();
                if (img_counter < images.Length - 1)
                {
                    img_counter = img_counter + 1;
                }
                else
                {
                    tmrRunImagesInFolder.Stop();
                    MessageBox.Show("All images were added to the training set folder (TrainedFaces) successfully!");
                    img_counter = 0;
                }
            }
            catch(Exception)
            {
               
            }
        }
        private void loadImageFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //=================Check if I have selected some image or not===========================//
            OpenFileDialog the_open_file_dialog = new OpenFileDialog();
            the_open_file_dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.bmp";
            if (the_open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                Image theInputImg = Image.FromFile(the_open_file_dialog.FileName);
                the_image_frame = new Image<Bgr, Byte>(new Bitmap(theInputImg));
                ImgCamera.Image = the_image_frame;
                DetectFaces();
            }
         }

        private void DetectFaces()
        {
            NamePersons.Add("");
            Image<Gray, byte> grayframe = the_image_frame.Convert<Gray, byte>();
            ImgCamera.Image = the_image_frame;
            MCvAvgComp[][] facesDetected = grayframe.DetectHaarCascade(
            face,
            1.1,
            2,
            Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            new Size(20, 20));
            lblTotalFacesDetected.Text = facesDetected[0].Length.ToString();
            if (facesDetected[0].Length > 0)
            {
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = the_image_frame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    the_image_frame.Draw(f.rect, new Bgr(Color.Green), 3);
                    if (TrainingImages.ToArray().Length != 0)
                    {
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.01);
                        EigenFaceRecognizer recognizer = new EigenFaceRecognizer(
                             TrainingImages.ToArray(),
                             labels.ToArray(),
                             5000,
                             ref termCrit
                             );
                        name = recognizer.Recognize(result);
                        if (string.IsNullOrEmpty(name) == true)
                        {
                            name = "UNKNOWN";
                        }
                        the_image_frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));
                    }
                    //Now draw the rectangle on the detected image
                    NamePersons[t - 1] = name;
                    NamePersons.Add("");
                }
                lblTotalFacesDetected.Text = facesDetected[0].Length.ToString();
            }
            t = 0;
            ImgTrainedFaces.Image = result;
            for (int namelabel = 0; namelabel < facesDetected[0].Length; namelabel++)
            {
                names = names + NamePersons[namelabel] + ",";
            }
            string names_without_comma_at_the_end = names.Remove(names.Length - 1);
            lblNamesExtracted.Text = names_without_comma_at_the_end;
            names = "";
            NamePersons.Clear();
        }   
        private void TrainFaces_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            this.Size = new Size(1000, 650);
        }
    }
}
