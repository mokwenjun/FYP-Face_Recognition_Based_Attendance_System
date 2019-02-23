using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System.Diagnostics;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
namespace MultiFaceRec
{
    public partial class FrmEigenfacesExperiments : Form
    { 
        HaarCascade haar2; //The viola jones classifier or detector
        HaarCascade eye2;
        //In the result variable, the detected face will be saved
        Image<Gray, byte> result, TrainedFace = null;
        //Initialize faces and name storage array
        List<Image<Gray, byte>> TrainingImages = new List<Image<Gray, byte>>();
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.8d, 0.8d);
        List<string> labels = new List<string>();
        //Initialize a list to save recognized names
        List<string> NamePersons = new List<string>();
        string name,names = null;
        int NumLabels, ContTrain, t;
        Image<Bgr, byte> ImageFrame;
        string Image_File_Name = "";
        //declaring global variables
        //Set the default values of the parameters, to be used as a variable in Call to detect HaarCascade
        private int WindowSize = 20;
        private Double ScaleIncreaseRate = 1.1;
        private int MinNeighbors = 2;
        private int RecognizerValue = 5000;
        int faceNo = 0;
        double resolution_scale_factor = 1;
        string Percent_unknown_faces = "";
        Bitmap[] ExtFaces;
        private bool matched = true;
        long total_processing_time = 0;
        double correct_matches = 0;
        double wrong_matches = 0;
        double unknown_faces = 0;
        double total_number_of_tests = 0;
        double percentageAccuracyOfResults = 0;
        double percentageOfUnknownFaces = 0;
        int total_faces_detected_in_test = 0;
        double epsilon = 0;
        private bool is_recognized_face_highlighted = true;
        private double process_complete = 0;
        public static Bitmap the_average_face;
        int total_number_of_testing_images = 0;
        string display_av_speed_per_image = "";
        //Obtain an array of testing images from the Student_Data_Set_Testing_Images folder
        string[] images_SDS = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images\\");
        string[] images_SDS2 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_2\\");
        string[] images_SDS3 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_3\\");       
        //Counter to iterate through the images in the student data set
        int counter_SDS = 0;
        //Counter to iterate through the images in the student data set 2
        int counter_SDS2 = 0;
        //Counter to iterate through the images in the student data set 3
        int counter_SDS3 = 0;
        //States the number of faces detected
        int NumberOfFacesDetected = 0;
        //=========================Load Previously Trained Faces=================================//
        public FrmEigenfacesExperiments()
        {
            //Load cascade file by giving file name
            haar2 = new HaarCascade("haarcascade_frontalface_default.xml");
            eye2 = new HaarCascade("haarcascade_eye.xml");
            InitializeComponent();
            /* try
               {
                   //Load previous trained faces and labels for each image
                   string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt");
                   //Separate the labels by '%' sign
                   string[] Labels = LabelsInfo.Split('%');
                   NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                   ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                   string LoadFaces;
                   for(int trainf=1;trainf<NumLabels+1;trainf++)
                   {
                       LoadFaces = "face" + trainf + ".bmp";
                       TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath+ "/TheFaces/" + LoadFaces));
                       labels.Add(Labels[trainf]);
                   }
               }
               catch(Exception ex)
               {
                   MessageBox.Show("Train an item if its the first time you are training an item");
               }*/
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        //=================Start the Face Recognition Test===============================//
        private void btnLoadImageFromDatabase_Click(object sender, EventArgs e)
        {
            //Set the arrays of images which contains images in the corresponding folders where the images are stored
            images_SDS = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images\\");
            images_SDS2 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_2\\");
            images_SDS3 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_3\\");
            //=============================Set up the default settings============================//
            btnloadimagefromfolder.Enabled = false;
            chkHighlightRecognizedFace.Enabled = false;
            btnAddTrainingImagesFromFolder.Enabled = false;
            pnlProcessing.Visible = true;
            txtImageFileName.Enabled = false;
            cmbEpsilonValue.Enabled = false;
            trkEigenDistanceThreshold.Enabled = false;
            trkScaleIncreaseRate.Enabled = false;
            trkMinNeighbors.Enabled = false;
            trkMinDetectionScale.Enabled = false;
            txtRecognizerName.Enabled = false;
            btnAddImageToTrainingSet.Enabled = false;
            btnAddTestingImageToDatabase.Enabled = false;
            //=============Set the stopwatch=======================//
            var watch = Stopwatch.StartNew();
            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                //================If the user has selected the student Data Set===============//
                total_number_of_testing_images = images_SDS.Length;
                    try
                    {
                    //==========================Obtain the images from the student dataset array=================//
                    Image image_from_file = Image.FromFile(images_SDS[counter_SDS]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS[counter_SDS]);
                    int index = Image_File_Name.IndexOfAny("_0123456789".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                   //Increase the progress bar by 1%
                    this.progressBar1.Maximum = total_number_of_testing_images;
                    this.progressBar1.Increment(1);
                    double temp_store_total_number_of_testing_images = total_number_of_testing_images;
                    process_complete = ((this.progressBar1.Value) / (temp_store_total_number_of_testing_images)) * 100;
                    lblPercentageOfProgress.Text = string.Format("{0:0}", process_complete) + "%" + "  Complete";
                    DetectFaces();
                    TestingImage();
                    timer1.Start();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS < images_SDS.Length - 1)
                        {
                        counter_SDS = counter_SDS + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS);
                        }
                        else
                        {
                            counter_SDS = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show(ex.Message);
                    }
                }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                //================If the user has selected the student Data Set===============//
                total_number_of_testing_images = images_SDS2.Length;
                try
                {
                    //==========================Obtain the images from the student dataset array=================//
                    Image image_from_file = Image.FromFile(images_SDS2[counter_SDS2]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS2[counter_SDS2]);
                    int index = Image_File_Name.IndexOfAny("_0123456789".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                    //Increase the progress bar by 1%
                    this.progressBar1.Maximum = total_number_of_testing_images;
                    this.progressBar1.Increment(1);
                    double temp_store_total_number_of_testing_images = total_number_of_testing_images;
                    process_complete = ((this.progressBar1.Value) / (temp_store_total_number_of_testing_images)) * 100;
                    lblPercentageOfProgress.Text = string.Format("{0:0}", process_complete) + "%" + "  Complete";
                    DetectFaces();
                    TestingImage();
                    timer1.Start();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS2 < images_SDS2.Length - 1)
                    {
                        counter_SDS2 = counter_SDS2 + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS2);
                    }
                    else
                    {
                        counter_SDS2 = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                //================If the user has selected the student Data Set===============//
                total_number_of_testing_images = images_SDS3.Length;
                try
                {
                    //==========================Obtain the images from the student dataset array=================//
                    Image image_from_file = Image.FromFile(images_SDS3[counter_SDS3]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS3[counter_SDS3]);
                    int index = Image_File_Name.IndexOfAny("_0123456789".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                    //Increase the progress bar by 1%
                    this.progressBar1.Maximum = total_number_of_testing_images;
                    this.progressBar1.Increment(1);
                    double temp_store_total_number_of_testing_images = total_number_of_testing_images;
                    process_complete = ((this.progressBar1.Value) / (temp_store_total_number_of_testing_images)) * 100;
                    lblPercentageOfProgress.Text = string.Format("{0:0}", process_complete) + "%" + "  Complete";
                    DetectFaces();
                    TestingImage();
                    timer1.Start();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS3 < images_SDS3.Length - 1)
                    {
                        counter_SDS3 = counter_SDS3 + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS3);
                    }
                    else
                    {
                        counter_SDS3 = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                {
                }
            //=========Stop the stopwatch to indicate the amount of time which has elapsed========================//
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                total_processing_time = total_processing_time + elapsedMs;
                TimeSpan t = TimeSpan.FromMilliseconds(total_processing_time);
                string display_total_processing_time = String.Format(@"{0:mm\:ss\.f} s", t);
                string display_in_min = display_total_processing_time.Substring(0, 2);
                //======Convert minutes into seconds=======
                double minutes = double.Parse(display_in_min);
                double min_to_seconds = minutes * 60;
                //Get the seconds in decimal
                string display_in_sec = display_total_processing_time.Substring(3, 4);
                double seconds = double.Parse(display_in_sec);
                double total_seconds = seconds + min_to_seconds;
                double av_speed_per_image = total_seconds / 1;
                string display_in_total_seconds = Convert.ToString(total_seconds);
                display_av_speed_per_image = String.Format("{0:0.00}", av_speed_per_image);
                lblTotalProcessingTime.Text = display_total_processing_time;    
        }

        private void btnloadimagefromfolder_Click(object sender, EventArgs e)
        {
         //=================Check if I have selected some image or not===========================//
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
         //========Get the file name without extension and place to indicate the name of the image==//
                //string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                //lblImgName.Text = fileName;
                Image InputImg = Image.FromFile(openFileDialog.FileName);
                string fileName = Path.GetFileName(openFileDialog.FileName);
                //var match = fileName.IndexOfAny("_0123456789.".ToCharArray()) != -1;
                int index = fileName.IndexOfAny("_0123456789.".ToCharArray());
                string extracted_training_label = fileName.Substring(0, index);
                txtImageFileName.Text = fileName;
                if (index > 0)
                {
                    txtRecognizerName.Text = extracted_training_label;
                    lblTestingImageName.Text = extracted_training_label;
                }
                else
                {
                    txtRecognizerName.Text = fileName;
                    lblTestingImageName.Text = fileName;
                }
                try
                {
                    if (InputImg == null)
                    {
                        throw new Exception("Please select an image");
                    }
                    picTestingImage.Image = InputImg;                    
                    ImageFrame = new Image<Bgr, Byte>(new Bitmap(picTestingImage.Image));
                    CamImageBox.Image = ImageFrame;
                    DetectFaces();
                   //TestingImage();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btnAddTestingImageToDatabase.Enabled = true;
        }      
        //==========The image needs to be converted from the PictureBox form to be placed into the ImageBox==============//
        void convert()
        {   
            NamePersons.Add("");
            //Reset the face number to 0
            faceNo = 0;
            //Check if I have selected some image or not
            Image ThisInputImg = picTestingImage.Image;
            ImageFrame = new Image<Bgr, Byte>(new Bitmap(ThisInputImg));
            ImageFrame = ImageFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            CamImageBox.Image = ImageFrame;
        }       
       
        //===================Conduct experiment module=====================================//
        void AutoNext()
        {

            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                try
                {
                    Image image_from_file = Image.FromFile(images_SDS[counter_SDS]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS[counter_SDS]);
                    int index = Image_File_Name.IndexOfAny("_0123456789.".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                    DetectFaces();
                    TestingImage();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS < images_SDS.Length - 1)
                    {
                        counter_SDS = counter_SDS + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS);
                    }
                    else
                    {
                        counter_SDS = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                try
                {
                    Image image_from_file = Image.FromFile(images_SDS2[counter_SDS2]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS2[counter_SDS2]);
                    int index = Image_File_Name.IndexOfAny("_0123456789.".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                    DetectFaces();
                    TestingImage();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS2 < images_SDS2.Length - 1)
                    {
                        counter_SDS2 = counter_SDS2 + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS2);
                    }
                    else
                    {
                        counter_SDS2 = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                try
                {
                    Image image_from_file = Image.FromFile(images_SDS3[counter_SDS3]);
                    ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                    CamImageBox.Image = ImageFrame;
                    Image_File_Name = Path.GetFileName(images_SDS3[counter_SDS3]);
                    int index = Image_File_Name.IndexOfAny("_0123456789.".ToCharArray());
                    string extracted_training_label = Image_File_Name.Substring(0, index);
                    if (index > 0)
                    {
                        txtRecognizerName.Text = extracted_training_label;
                        lblTestingImageName.Text = extracted_training_label;
                    }
                    DetectFaces();
                    TestingImage();
                    /* Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                     picTestingImage.Image = (Image)BmpImgFrame2;*/
                    if (counter_SDS3 < images_SDS3.Length - 1)
                    {
                        counter_SDS3 = counter_SDS3 + 1;
                        lblTestingImgNo.Text = Convert.ToString(counter_SDS3);
                    }
                    else
                    {
                        counter_SDS3 = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
            }
        }
        void Store_Wrongly_Recognized_Images()
        {
           
            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                string wrongly_recognized_images_SDS = Application.StartupPath + "/Wrongly Recognized Images for SDS/";
                if (!Directory.Exists(wrongly_recognized_images_SDS))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_SDS);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for SDS\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                string wrongly_recognized_images_SDS2 = Application.StartupPath + "/Wrongly Recognized Images for SDS2/";
                if (!Directory.Exists(wrongly_recognized_images_SDS2))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_SDS2);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for SDS2\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                string wrongly_recognized_images_SDS3 = Application.StartupPath + "/Wrongly Recognized Images for SDS3/";
                if (!Directory.Exists(wrongly_recognized_images_SDS3))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_SDS3);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for SDS3\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 1")
            {
                string wrongly_recognized_images_CDS1 = Application.StartupPath + "/Wrongly Recognized Images for CDS1/";
                if (!Directory.Exists(wrongly_recognized_images_CDS1))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_CDS1);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for CDS1\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 2")
            {
                string wrongly_recognized_images_CDS2 = Application.StartupPath + "/Wrongly Recognized Images for CDS2/";
                if (!Directory.Exists(wrongly_recognized_images_CDS2))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_CDS2);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for CDS2\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 3")
            {
                string wrongly_recognized_images_CDS3 = Application.StartupPath + "/Wrongly Recognized Images for CDS3/";
                if (!Directory.Exists(wrongly_recognized_images_CDS3))
                {
                    Directory.CreateDirectory(wrongly_recognized_images_CDS3);
                }
                try
                {
                    if (ImageFrame != null)
                    {
                        ImageFrame.Save(Application.StartupPath + "\\Wrongly Recognized Images for CDS3\\" + Image_File_Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }
        private void TestingImage()
        {
            //============The actual recognized name of the testing image is the name of the testing image==============//
            lblCorrectRecognition.Text = lblTestingImageName.Text;
            if(lblActualRecognition.Text == "UNKNOWN")
            {
                unknown_faces++;
                Store_Wrongly_Recognized_Images();
            }
            else
            {
                //lblthe_unknown_faces.Text = "None";
            }
            //lblthe_unknown_faces.Text = Convert.ToString(unknown_faces);
            if (lblActualRecognition.Text == lblCorrectRecognition.Text)
            {
                lblMatch.Text = "Yes";
                lblTestingImgNo.ForeColor = Color.Black;
                lblTotalTested.ForeColor = Color.Black;
                lblMatch.ForeColor = Color.Black;
                lblActualRecognition.ForeColor = Color.Black;
                lblRight.ForeColor = Color.Black;
                lblWrong.ForeColor = Color.Black;
                matched = true;
            }
            else if (lblCorrectRecognition.Text != lblActualRecognition.Text)
            {    
                lblMatch.Text = "No";
                lblTestingImgNo.ForeColor = Color.Red;
                lblTotalTested.ForeColor = Color.Red;
                lblActualRecognition.ForeColor = Color.Red;
                lblRight.ForeColor = Color.Red;
                lblMatch.ForeColor = Color.Red;
                lblWrong.ForeColor = Color.Red;
                matched = false;
                Store_Wrongly_Recognized_Images();
            }
            else
            {
            }
            if (matched == true)
            {
                correct_matches++;
            }
            else if (matched == false)
            {
                wrong_matches++;
            }
            else
            {
            }          
            total_number_of_tests = correct_matches + wrong_matches;
            percentageAccuracyOfResults = (correct_matches / total_number_of_tests) * 100;
            lblPercentageAccuracyOfResults.Text = string.Format("{0:0.0}", percentageAccuracyOfResults) + " %";
            percentageOfUnknownFaces = (unknown_faces / total_number_of_tests) * 100;
            Percent_unknown_faces = string.Format("{0:0}", percentageOfUnknownFaces) + " %";
            lblRight.Text = Convert.ToString(correct_matches);
            lblWrong.Text = Convert.ToString(wrong_matches);
            lblTotalTested.Text = Convert.ToString(total_number_of_tests) + "/" + Convert.ToString(total_number_of_testing_images);
          //  lbl_the_total_faces_detected_in_test.Text = Convert.ToString(total_faces_detected_in_test);
           // percentageOfUnknownFaces = (unknown_faces / total_number_of_tests) * 100;   
        }
       
        private void DetectFaces()
        {
            if (chkHighlightRecognizedFace.Checked == true)
            {
                is_recognized_face_highlighted = true;            
            }
            else if (chkHighlightRecognizedFace.Checked == false)
            {
                is_recognized_face_highlighted = false;      
            }
            else
            {
            }
            //=============================================================================//
            NamePersons.Add("");
            Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
            //Assign user-defined values to parameter variables
            MinNeighbors = int.Parse(lblMinNeighbors.Text);//The third parameter
            WindowSize = int.Parse(lblMinDetectionScale.Text); //The fifth parameter
            ScaleIncreaseRate = double.Parse(lblScaleIncreaseRate.Text); //The second parameter  
            CamImageBox.Image = ImageFrame;
            //Detect faces from the gray-scale image and store into an array of type "var"
            MCvAvgComp[][] facesDetected = grayframe.DetectHaarCascade(
            haar2,
            ScaleIncreaseRate,
            MinNeighbors,
            Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            new Size(WindowSize, WindowSize));            
            lbltotalfacesdetected.Text = facesDetected[0].Length.ToString();
            //========================================================================//
            Bitmap BmpInput = grayframe.ToBitmap();
            Bitmap ExtractedFace; //Empty
            Graphics FaceCanvas;
            ExtFaces = new Bitmap[facesDetected[0].Length];
            //========================================================================//
            if (facesDetected[0].Length > 0)
            {
                //Draw a green rectangle on each detected face in image
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    //============Get the width and height of the rectangle which highlights the extracted face================//
                    int face_width = Convert.ToInt32(f.rect.Width);
                    int face_height = Convert.ToInt32(f.rect.Height);
                    //============================================================================================//
                    total_faces_detected_in_test = total_faces_detected_in_test + 1;
                    //If face found, increment t
                    t = t + 1;
                    //Get the extracted face in Img<,> form
                    result = ImageFrame.Copy(facesDetected[0][(facesDetected[0].Length - 1)].rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    if (is_recognized_face_highlighted == true)
                    {
                       ImageFrame.Draw(facesDetected[0][(facesDetected[0].Length-1)].rect, new Bgr(Color.Green), 3);
                    }
                    else
                    {                      
                    }
                    //Set the size of the extracted face
                    //Now see the result by copying the detected face in a frame name as result                   
                 /*   ExtractedFace = new Bitmap(f.rect.Width,f.rect.Height);
                    //Set empty image as facecanvas for painting
                    FaceCanvas = Graphics.FromImage(ExtractedFace);
                    FaceCanvas.DrawImage(BmpInput, 0, 0, f.rect, GraphicsUnit.Pixel);
                    ExtFaces[faceNo] = ExtractedFace;
                    faceNo++;               */     
                        RecognizerValue = Int32.Parse(lblEigenDistanceThreshold.Text);
                        epsilon = Double.Parse(cmbEpsilonValue.Text);
                        if (TrainingImages.ToArray().Length != 0)
                        {
                            //termcriteria against each image to find a match with it to perform different iterations
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, epsilon);
                            //Call class by creating object and pass parameters 
                            EigenFaceRecognizer recognizer = new EigenFaceRecognizer(
                                 TrainingImages.ToArray(),
                                 labels.ToArray(),
                                 RecognizerValue,
                                 ref termCrit
                                 );
                            //100 - needs to be in the same orientation but increasing it to 2000 or 3000 is otherwise
                            //Next step is to name find for recognized face
                            name = recognizer.Recognize(result);
                            the_average_face = new Bitmap(recognizer.AverageImage.Bitmap);                           
                            //Now show recognized person name so
                            //Initialize font for the name captured
                            if (string.IsNullOrEmpty(name) == true)
                            {
                                name = "UNKNOWN";
                            }                        
                            if (is_recognized_face_highlighted == true)
                            {
                                ImageFrame.Draw(name, ref font, new Point(facesDetected[0][(facesDetected[0].Length - 1)].rect.X - 2, facesDetected[0][(facesDetected[0].Length - 1)].rect.Y - 2), new Bgr(Color.Red));
                            }
                            else
                            {

                            }
                        }
                        //Now draw the rectangle on the detected image
                        /*NamePersons[t - 1] = name;
                        NamePersons.Add("");  */                                                                                          
                }                      
                //pbExtractedFaces.Image = ExtFaces[faceNo];       
            }
            lbltotalfacesdetected.Text = facesDetected[0].Length.ToString();
            NumberOfFacesDetected = facesDetected[0].Length;         
            t = 0;
            /*  for (int namelabel = 0; namelabel < facesDetected[0].Length; namelabel++)
              {
                  names = names + NamePersons[namelabel] + ",";
              }                      
              string names_without_comma_at_the_end = names.Remove(names.Length - 1);
              lblActualRecognition.Text  = names_without_comma_at_the_end.Substring(names_without_comma_at_the_end.LastIndexOf(',') + 1);
              names = "";
              NamePersons.Clear();*/
              //picTestingImage.Image = ImageFrame2.ToBitmap();
             // faceNo = 0;
            lblActualRecognition.Text = name;
            ImgDisplayFace.Image = result;
            Bitmap the_picturebox_image = new Bitmap(CamImageBox.Image.Bitmap);
            picTestingImage.Image = the_picturebox_image;
        }       
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        //--------------Buttons and Functions used to navigate and add face label pairs to database------------------//
        private void btnAddImageToTrainingSet_Click(object sender, EventArgs e)
        {
            /* ContTrain = ContTrain + 1;
             //Get a gray frame from capture device
             grayframe = ImageFrame2.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
             //Face Detector
             MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
             face,
             1.2,
             10,
             Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
             new Size(20, 20));

             //Action for each element detected
             foreach (MCvAvgComp f in facesDetected[0])
             {
                 TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                 break;
             }*/
            if(cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                //===========================Create TheFaces folder if it does not exist=======================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_2)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                //===========================Create TheFaces folder if it does not exist=======================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_2/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_2/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_2)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                //===========================Create TheFaces folder if it does not exist=======================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_3/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_3/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_3)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else if(cmb_Select_Data_Set.Text == "Celebrity Data Set 1")
            {
                //=====================Create TheFaces_Leo_DataSet_1 if it does not exist=====================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_1/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_1/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_Leo_DataSet_1)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else if(cmb_Select_Data_Set.Text == "Celebrity Data Set 2")
            {
                //===================Create TheFaces_Leo_DataSet_3 if it does not exist======================//
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_3/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_3/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_Leo_DataSet_3)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 3")
            {
                //===================Create TheFaces_Leo_DataSet_3 if it does not exist======================//
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_4/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                if (txtRecognizerName.Text == "")
                {
                    MessageBox.Show("Give a label to the training image!");
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImgDisplayFace.Image = TrainedFace;
                    TrainingImages.Add(TrainedFace);
                    //Array to store names
                    labels.Add(txtRecognizerName.Text);
                    //Write number of trained faces to list
                    //Add library to read/write to input file
                    //% is an end sign to differentiate between the number of training images and the stored images
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_4/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    MessageBox.Show("Image trained and successfully saved in the training set in the folder named (TheFaces_Leo_DataSet_4)");
                    string LabelsInfo2 = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt");
                    if (LabelsInfo2.Length > 4)
                    {
                        string Extracted_Characters = LabelsInfo2.Substring(0, 3);

                        lblNoOfRecognizedImages.Text = Extracted_Characters;
                    }
                    //Add training image to be stored in the database
                    Bitmap bitmap_extracted_training_image = new Bitmap(ImgDisplayFace.Image.Bitmap);
                    Image pic_box_extracted_training_image = (Image)bitmap_extracted_training_image;
                }
            }
            else
            {
                MessageBox.Show("Please select a Data Set!");
            }                   
        }
        private void btnAddTestingImageToDatabase_Click(object sender, EventArgs e)
        {
            images_SDS = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images\\");
            images_SDS2 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_2\\");
            images_SDS3 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_3\\");
            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                if (txtImageFileName.Text == "")
                {
                    MessageBox.Show("Please give the testing image a name!");
                }
                else
                {
                    try
                    {
                        if(ImageFrame!=null)
                        {
                            ImageFrame.Save(Application.StartupPath + "\\Student_Data_Set_Testing_Images\\"+txtImageFileName.Text);
                            MessageBox.Show(lblTestingImageName.Text+"'s image is being saved successfully");
                            lblTestingImgNo.Text = Convert.ToString((images_SDS.Length)+1);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                if (txtImageFileName.Text == "")
                {
                    MessageBox.Show("Please give the testing image a name!");
                }
                else
                {
                    try
                    {
                        if (ImageFrame != null)
                        {
                            ImageFrame.Save(Application.StartupPath + "\\Student_Data_Set_Testing_Images_2\\" + txtImageFileName.Text);
                            MessageBox.Show(lblTestingImageName.Text + "'s image is being saved successfully");
                            lblTestingImgNo.Text = Convert.ToString((images_SDS2.Length) + 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                if (txtImageFileName.Text == "")
                {
                    MessageBox.Show("Please give the testing image a name!");
                }
                else
                {
                    try
                    {
                        if (ImageFrame != null)
                        {
                            ImageFrame.Save(Application.StartupPath + "\\Student_Data_Set_Testing_Images_3\\" + txtImageFileName.Text);
                            MessageBox.Show(lblTestingImageName.Text + "'s image is being saved successfully");
                            lblTestingImgNo.Text = Convert.ToString((images_SDS3.Length) + 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
            }
        }   
        private void timer1_Tick(object sender, EventArgs e)
        {
            images_SDS = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images\\");
            images_SDS2 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_2\\");
            images_SDS3 = Directory.GetFiles(Application.StartupPath + "\\Student_Data_Set_Testing_Images_3\\");
            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                //================The total number of images is the number of images in the student data set=======//
                total_number_of_testing_images = images_SDS.Length;
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                //================The total number of images is the number of images in the student data set=======//
                total_number_of_testing_images = images_SDS2.Length;
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                //================The total number of images is the number of images in the student data set=======//
                total_number_of_testing_images = images_SDS3.Length;
            }
            else if(cmb_Select_Data_Set.Text =="Select a Data Set")
            {
                MessageBox.Show("Please select a data set");
            }
            else
            {

            }
            string the_message_1 = "Total Images Tested: " + lblTotalTested.Text + "\n" +
                                 "Number of correct matches: " + lblRight.Text + "\n" +
                                "Number of wrong matches: " + lblWrong.Text + "\n" +
                                "Face recognition accuracy (in %): " + lblPercentageAccuracyOfResults.Text + "\n" +  
                                "Total time taken to process all the images: " + lblTotalProcessingTime.Text + "\n"+
                                "Average time taken to process an image: " + display_av_speed_per_image +"s"+ "\n"+
                                "Percentage of faces being detected as UNKNOWN: " + Percent_unknown_faces + "\n";
            string results_caption = "Recognition results";
            string the_message_2 = "Total Images Tested: " + lblTotalTested.Text + "\n" +
                                 "Number of correct matches: " + lblRight.Text + "\n" +
                                "Number of wrong matches: " + lblWrong.Text + "\n" +
                                "Face Recognition Accuracy (in percentage): " + lblPercentageAccuracyOfResults.Text + "\n";
            string the_message_3 = "Percentage of unknown faces: " + Percent_unknown_faces + "\n"; 
            string the_message_4 = "Total time taken to process all the images: " + lblTotalProcessingTime.Text + "\n" +
                                   "Average time taken to process an image: " + display_av_speed_per_image +" s" + "\n";
            this.progressBar1.Maximum = total_number_of_testing_images;
            if (total_number_of_tests >= total_number_of_testing_images)
            {               
                timer1.Stop();
                for (int i = 0; i < 5; i++)
                {
                    //Beep 5 times when the test is completed
                    Console.Beep();
                    Thread.Sleep(20);
                }
                lblTestingImgNo.Text = Convert.ToString(total_number_of_tests);
                lblPercentageOfProgress.Text = "Experiment Completed";
                label23.Text = "";
                btnloadimagefromfolder.Enabled = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddTrainingImagesFromFolder.Enabled = true;
                txtImageFileName.Enabled = true;
                trkMinNeighbors.Enabled = true;
                trkEigenDistanceThreshold.Enabled = true;
                cmbEpsilonValue.Enabled = true;
                trkScaleIncreaseRate.Enabled = true;
                trkMinDetectionScale.Enabled = true;
                txtRecognizerName.Enabled = true;
                txtRecognizerName.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                btnAddTestingImageToDatabase.Enabled = true;
                MessageBox.Show(the_message_1, results_caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(the_message_2, results_caption, MessageBoxButtons.OK, MessageBoxIcon.Information);  
                //MessageBox.Show(the_message_3, results_caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(the_message_4, results_caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.progressBar1.Maximum = total_number_of_testing_images;
                this.progressBar1.Increment(1);
                double temp_store_total_number_of_testing_images = total_number_of_testing_images;
                process_complete = ((this.progressBar1.Value)/(temp_store_total_number_of_testing_images))*100;
                lblPercentageOfProgress.Text = string.Format("{0:0}", process_complete) +"%" +"  Complete";
                var watch = Stopwatch.StartNew();
                AutoNext();          
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;            
                total_processing_time = total_processing_time + elapsedMs;
                TimeSpan t = TimeSpan.FromMilliseconds(total_processing_time);
                string display_total_processing_time = String.Format(@"{0:mm\:ss\.f} s", t);
                string display_in_min = display_total_processing_time.Substring(0, 2);    
                //======Convert minutes into seconds=======
                double minutes = double.Parse(display_in_min);
                double min_to_seconds = minutes * 60;
                //Get the seconds in decimal
                string display_in_sec = display_total_processing_time.Substring(3, 4);
                double seconds = double.Parse(display_in_sec);
                double total_seconds = seconds + min_to_seconds;
                double av_speed_per_image = total_seconds / total_number_of_testing_images;
                string display_in_total_seconds = Convert.ToString(total_seconds);
                display_av_speed_per_image = String.Format("{0:0.00}", av_speed_per_image);
                lblTotalProcessingTime.Text = display_total_processing_time;              
               //lblTimeTakenPerImage.Text = display_av_speed_per_image + " s";
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            FrmEigenfacesExperiments NewForm = new FrmEigenfacesExperiments();
            NewForm.Show();
            this.Dispose(false);
        }
        private void label29_Click(object sender, EventArgs e)
        {

        }
        private void label30_Click(object sender, EventArgs e)
        {

        }
        private void trkEigenDistanceThreshold_Scroll(object sender, EventArgs e)
        {
            int x = trkEigenDistanceThreshold.Value * 200;
            lblEigenDistanceThreshold.Text = x.ToString();
        }

        private void trkScaleIncreaseRate_Scroll(object sender, EventArgs e)
        {
            double x2 = trkScaleIncreaseRate.Value * 0.02;
            lblScaleIncreaseRate.Text = x2.ToString();
        }

        private void trkMinNeighbors_Scroll(object sender, EventArgs e)
        {
            lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
        }

        private void trkMinDetectionScale_Scroll(object sender, EventArgs e)
        {
            int x3 = trkMinDetectionScale.Value * 5;
            lblMinDetectionScale.Text = x3.ToString();
        }

        private void trkChangeResolution_Scroll(object sender, EventArgs e)
        {
            resolution_scale_factor = trkChangeResolution.Value * 0.05;
            lblResolutionScaleFactor.Text = resolution_scale_factor.ToString();
            int original_width = picTestingImage.Width;
            int original_height = picTestingImage.Height;
            int new_width = (int)(original_width*resolution_scale_factor);
            int new_height = (int)(original_height*resolution_scale_factor);
            //lblImageResolutionDimensions.Text = new_width + "x" + new_height;
            Bitmap the_adjusted = new Bitmap(picTestingImage.Image, new_width, new_height);
            picTestingImage.Image = the_adjusted;
        }

        private void chkHighlightRecognizedFace_CheckedChanged(object sender, EventArgs e)
        {
            if (picTestingImage.Image != null)
            {
                if (chkHighlightRecognizedFace.Checked == true)
                {
                    is_recognized_face_highlighted = true;
                    DetectFaces();
                }
                else if (chkHighlightRecognizedFace.Checked == false)
                {
                    is_recognized_face_highlighted = false;
                    DetectFaces();
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void viewAverageFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAverageFace av_F_2 = new FrmAverageFace();
            av_F_2.Show();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf|JPG Image (.jpg)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                picTestingImage.Image.Save(f.FileName);
            }
        }
        private void cmb_Select_Data_Set_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                trkMinNeighbors.Value = 2;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item");
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                trkMinNeighbors.Value = 2;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_2/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item");
                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                trkMinNeighbors.Value = 2;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_3/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item");
                }
            }
            else if(cmb_Select_Data_Set.Text == "Celebrity Data Set 1")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = false;
                trkMinNeighbors.Value = 4;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_1/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item");
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 2")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = false;
                trkMinNeighbors.Value = 4;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_3/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item in celebrity Training Set 2");
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 3")
            {
                btnAddTestingImageToDatabase.Enabled = true;
                btnloadimagefromfolder.Enabled = true;
                btnLoadImageFromDatabase.Enabled = true;
                chkHighlightRecognizedFace.Checked = true;
                chkHighlightRecognizedFace.Enabled = true;
                btnAddImageToTrainingSet.Enabled = true;
                btnAddTrainingImagesFromFolder.Visible = false;
                trkMinNeighbors.Value = 4;
                lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_4/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Train an item if its the first time you are training an item for celebrity Training Set 3");
                }
            }
            else
            {
                btnAddTestingImageToDatabase.Enabled = false;
                btnLoadImageFromDatabase.Enabled = false;
                btnAddTrainingImagesFromFolder.Visible = false;
                btnloadimagefromfolder.Enabled = false;
                chkHighlightRecognizedFace.Enabled = false;
                btnAddImageToTrainingSet.Enabled = false;
                try
                {                   
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                   //MessageBox.Show("Train an item if its the first time you are training an item");
                }
            }
        }
        private void label21_Click(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void defaultSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trkScaleIncreaseRate.Value = 55;
            trkMinNeighbors.Value = 2;
            trkMinDetectionScale.Value = 4;
            trkEigenDistanceThreshold.Value = 30;
            trkChangeResolution.Value = 20;
            double x2 = trkScaleIncreaseRate.Value * 0.02;
            lblScaleIncreaseRate.Text = x2.ToString();
            lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
            int x3 = trkMinDetectionScale.Value * 5;
            lblMinDetectionScale.Text = x3.ToString();
            int x = trkEigenDistanceThreshold.Value * 200;
            lblEigenDistanceThreshold.Text = x.ToString();
            resolution_scale_factor = trkChangeResolution.Value * 0.05;
            epsilon = 0.01;
            cmbEpsilonValue.Text = "0.01";
            lblResolutionScaleFactor.Text = resolution_scale_factor.ToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmAdministratorMainPage FrmAM = new FrmAdministratorMainPage();
            FrmAM.Show();
            this.Hide();
        }
        private void FrmEigenfacesExperiments_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1800, 900);
            this.Location = new Point(0, 0);
            if (chkHighlightRecognizedFace.Checked == true)
            {
                is_recognized_face_highlighted = true;
            }
            else if (chkHighlightRecognizedFace.Checked == false)
            {
                is_recognized_face_highlighted = false;
            }
            else
            {
            }
            int y = trkEigenDistanceThreshold.Value * 200;
            lblEigenDistanceThreshold.Text = y.ToString();
            double y2 = trkScaleIncreaseRate.Value * 0.02;
            lblScaleIncreaseRate.Text = y2.ToString();
            lblMinNeighbors.Text = trkMinNeighbors.Value.ToString();
            int y3 = trkMinDetectionScale.Value * 5;
            lblMinDetectionScale.Text = y3.ToString();
        }

        private void FrmEigenfacesExperiments_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        string the_folder_path = "";
        private void deleteWronglyRecognizedImagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SDS_Path = Application.StartupPath + "\\Wrongly Recognized Images for SDS\\";
            string SDS2_Path = Application.StartupPath + "\\Wrongly Recognized Images for SDS2\\";
            string SDS3_Path = Application.StartupPath + "\\Wrongly Recognized Images for SDS3\\";
            string CDS1_Path = Application.StartupPath + "\\Wrongly Recognized Images for CDS1\\";
            string CDS2_Path = Application.StartupPath + "\\Wrongly Recognized Images for CDS2\\";
            string CDS3_Path = Application.StartupPath + "\\Wrongly Recognized Images for CDS3\\";
            try
            {
                if (Directory.Exists(SDS_Path) == true)
                {
                    var dir_SDS = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for SDS\\");
                    dir_SDS.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images for SDS) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (Directory.Exists(SDS2_Path) == true)
                {
                    var dir_SDS2 = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for SDS2\\");
                    dir_SDS2.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images for SDS2) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (Directory.Exists(SDS3_Path) == true)
                {
                    var dir_SDS3 = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for SDS3\\");
                    dir_SDS3.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images for SDS3) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (Directory.Exists(CDS1_Path) == true)
                {
                    var dir_CDS1 = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for CDS1\\");
                    dir_CDS1.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images for CDS1) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (Directory.Exists(CDS2_Path) == true)
                {
                    var dir_CDS2 = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for CDS2\\");
                    dir_CDS2.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images for CDS2) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (Directory.Exists(CDS3_Path) == true)
                {
                    var dir_CDS3 = new DirectoryInfo(Application.StartupPath + "\\Wrongly Recognized Images for CDS3\\");
                    dir_CDS3.Delete(true);
                    MessageBox.Show("(Wrongly Recognized Images from CDS3) folder is being deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddTrainingImagesFromFolder_Click(object sender, EventArgs e)
        {          
            //=============Depending on the data set (Student Data Set 1, Celebrity Data Set 1, Celebrity Data Set 2) from combo box selected, load the pre-trained images from the respective training sets=========//
            if (cmb_Select_Data_Set.Text == "Student Data Set 1")
            {
                //====================Create TheFaces folder if it does not exist===========================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {

                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
            {
                //====================Create TheFaces folder if it does not exist===========================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_2/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_2/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {

                }
            }
            else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
            {
                //====================Create TheFaces folder if it does not exist===========================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_3/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_3/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {

                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 1")
            {
                //==============Create TheFaces_Leo_DataSet_1 if it does not exist========================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_1/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_1/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {

                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 2")
            {
                //================Create TheFaces_Leo_DataSet_3 if it does not exist===========================//
                //File.WriteAllText(path_string,"Hello World");
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_3/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_3/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                }
            }
            else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 3")
            {
                //================Create TheFaces_Leo_DataSet_4 if it does not exist===========================//
                string folder_name = Application.StartupPath + "/TheFaces_Leo_DataSet_4/";
                if (!Directory.Exists(folder_name))
                {
                    Directory.CreateDirectory(folder_name);
                }
                string file_name = "TrainedLabel.txt";
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
                try
                {
                    //Load previous trained faces and labels for each image
                    string LabelsInfo = File.ReadAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt");
                    //Separate the labels by '%' sign
                    string[] Labels = LabelsInfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]); //Total no of faces present
                    ContTrain = NumLabels;//ContTrain will add new image to the previous one. i.e. If 3 are present and add new one which is 4
                    string LoadFaces;
                    for (int trainf = 1; trainf < NumLabels + 1; trainf++)
                    {
                        LoadFaces = "Face" + trainf + ".bmp";
                        TrainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TheFaces_Leo_DataSet_4/" + LoadFaces));
                        labels.Add(Labels[trainf]);
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a data set for the training images to be added!");
            }
            FolderBrowserDialog folder_selected = new FolderBrowserDialog();
            if (folder_selected.ShowDialog() == DialogResult.OK)
            {
                folder_selected.Description = "Select the folder which you want to load the training images";
                the_folder_path = folder_selected.SelectedPath;
            }
            else if (folder_selected.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {

            }
            //picTestingImage.Image = Image.FromFile(Application.StartupPath+ "\\Data Sets\\Training Set\\Training Set of Faces With Names\\Adam01.bmp");
            tmrRun.Start();
        }
        int counter = 0;
        private void tmrRun_Tick(object sender, EventArgs e)
        {
            try
            {
                //  string[] images = Directory.GetFiles(Application.StartupPath+ "\\Data Sets\\Training Set\\Training Set of Faces With Names", "*.bmp");
                string[] images = Directory.GetFiles(the_folder_path);
                Image image_from_file = Image.FromFile(images[counter]);
                ImageFrame = new Image<Bgr, byte>((Bitmap)image_from_file);
                CamImageBox.Image = ImageFrame;
                string ImageName = Path.GetFileName(images[counter]);
                int index = ImageName.IndexOfAny("_0123456789".ToCharArray());
                string extracted_training_label = ImageName.Substring(0, index);
                if (index > 0)
                {
                    txtRecognizerName.Text = extracted_training_label;
                }
                DetectFaces();
                // Bitmap BmpImgFrame2 = new Bitmap(ImageFrame2.Bitmap);
                // picTestingImage.Image = (Image)BmpImgFrame2;
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                ImgDisplayFace.Image = TrainedFace;
                TrainingImages.Add(TrainedFace);
                labels.Add(txtRecognizerName.Text);
                if (cmb_Select_Data_Set.Text == "Student Data Set 1")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }

                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces) successfully!");
                        counter = 0;
                    }
                }
                else if (cmb_Select_Data_Set.Text == "Student Data Set 2")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_2/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_2/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }

                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces_2) successfully!");
                        counter = 0;
                    }
                }
                else if (cmb_Select_Data_Set.Text == "Student Data Set 3")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_3/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_3/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }
                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces_3) successfully!");
                        counter = 0;
                    }
                }
                else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 1")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_1/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_1/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }

                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces_Leo_DataSet_1) successfully!");
                        counter = 0;
                    }
                }
                else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 2")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_3/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_3/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }

                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces_2) successfully!");
                        counter = 0;
                    }
                }
                else if (cmb_Select_Data_Set.Text == "Celebrity Data Set 3")
                {
                    File.WriteAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt", TrainingImages.ToArray().Length.ToString() + "%");
                    //Write label or data name to the file
                    for (int i = 1; i < TrainingImages.ToArray().Length + 1; i++)
                    {
                        //Save faces to folder with name face(i) is no. of face and .bmp extension of detected face image
                        TrainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TheFaces_Leo_DataSet_4/Face" + i + ".bmp");
                        //Save names to text file
                        File.AppendAllText(Application.StartupPath + "/TheFaces_Leo_DataSet_4/TrainedLabel.txt", labels.ToArray()[i - 1] + "%");

                    }

                    //btnAddImageToTrainingSet.PerformClick();         
                    //TestingImage();
                    if (counter < images.Length - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        tmrRun.Stop();
                        MessageBox.Show("All images were added to the training set folder (TheFaces_Leo_DataSet_4) successfully!");
                        counter = 0;
                    }
                }
            }
            catch(Exception)
            {
            }
        }
    }
}
