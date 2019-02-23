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
using System.Speech;
using System.Speech.Synthesis;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing.Drawing2D;

namespace MultiFaceRec
{
    public partial class FrmMainForm : Form
    {
        private OleDbConnection theConnection = new OleDbConnection();
        Image<Bgr, byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;    
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        //===============Create a list of labels without knowing the size of the labels========//
        List<string> labels= new List<string>();
        //================Create a list of names without knowing the size of the list of names ==========//
        List<string> NamePersons = new List<string>();
        IList<string> list_of_names = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        private bool captureInProgress;
        Color color_of_rectangle = Color.Red;
        Color color_of_name_above_recognized_face = Color.LightGreen;
        private bool detect_both_face_and_eyes = false;
        private Image<Bgr, byte> ImageFrame;
        SpeechSynthesizer reader = new SpeechSynthesizer();       
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentData.mdf;Integrated Security = True; Connect Timeout = 30");
        private bool is_camera_on = false;
        int NumberOfFacesDetected = 0;
        bool is_12HR_format = false;
        bool is_in_grayscale = false;
        string name_one, name_two, name_three, name_four, name_five, name_six, name_seven = "";
        public FrmMainForm()
        {
            InitializeComponent();
            theConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=StudentAttendanceRecords.mdb";
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            eye = new HaarCascade("haarcascade_eye.xml");        
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
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There are no faces in the training set yet.\n" +
                                "Please add at least a face to the training set \n" +
                                "You can add a face by training the face by typing in the name of the trained face in the textbox and then click  the (Add Face) Button.\n", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnStartTheCamera_Click(object sender, EventArgs e)
        {
            is_camera_on = true;
            if (grabber == null)
            {
                try
                {
                    grabber = new Capture(0);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if (grabber != null)
            {
                if (captureInProgress)
                {
                    //If camera is getting frames then pause the capture and set button text to "Resume" for resuming capture               
                    btnStartTheCamera.Text = "Resume Camera";
                    Application.Idle -= FrameGrabber;
                }
                else
                {
                    //If camera is not getting frames then start the capture and set button Text to "Pause" for pausing capture
                    btnStartTheCamera.Text = "Pause Camera";
                    Application.Idle += FrameGrabber;
                }
                captureInProgress = !captureInProgress;
            }
        }
        private void btnStopCamera_Click(object sender, EventArgs e)
        {       
            is_camera_on = false;
            lblName.Text = "";
            names = "";
            NamePersons.Clear();
            if (grabber != null)
            {
                if (captureInProgress)
                {
                    btnStartTheCamera.Text = "Start Camera";
                    Application.Idle -= FrameGrabber;
                    ReleaseData();
                    grabber = null;
                    imageBoxFrameGrabber.Image = null;
                }
                else
                {               
                    ReleaseData();
                    grabber = null;
                    imageBoxFrameGrabber.Image = null;
                }
                captureInProgress = !captureInProgress;
            }
            btnStopCamera.Text = "Turn Off Camera";
            imageBoxFrameGrabber.Image = null;
            NumberOfFacesDetected = 0;
            label3.Text = "0";
        }
        private void ReleaseData()
        {
            if(grabber!=null)
            {
                grabber.Dispose();
            }
        }
        void FrameGrabber(object sender, EventArgs e)
        {
            if (is_camera_on == true)
            {
                try
                {
                    label3.Text = "0";
                    NumberOfFacesDetected = 0;
                    //=========We use NamePersons as a list of names since we do not know the size of NamePersons====//
                    NamePersons.Add("");
                    //Get the current frame form capture device
                    currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    if (currentFrame != null)
                    {
                        //Convert the current frame captured to Grayscale
                        gray = currentFrame.Convert<Gray, Byte>();
                        MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                              face,
                              1.2,
                              8,
                              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                              new Size(20, 20));
                        MCvAvgComp[][] EyesDetected = gray.DetectHaarCascade(
                           eye,
                           1.2,
                           8,
                           Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                           new Size(20, 20));
                        //=================If at least one face has been detected==================//
                        if (facesDetected[0].Length > 0)
                        {
                            //====================================================================//
                            foreach (MCvAvgComp f in facesDetected[0])
                            {                               
                                //Increase the number of training images by 1
                                t = t + 1;
                                if (detect_both_face_and_eyes == true)
                                {
                                    foreach (MCvAvgComp ey in EyesDetected[0])
                                    {
                                        currentFrame.Draw(ey.rect, new Bgr(Color.Yellow), 2);
                                        //Set the size of the empty box(Extracted face) which will later contain the extracted faces
                                       
                                    }
                                }
                                else
                                {
                                }
                                currentFrame.Draw(f.rect, new Bgr(color_of_rectangle), 3);
                                //==============================================================
                                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                                //The face detected in channel 0 (grey) is drawn with a red rectangle of thickness 3
                                btnSubmitAttendance.Enabled = true;
                                if (trainingImages.ToArray().Length != 0)
                                {
                                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                                    //Eigen face recognizer
                                    EigenFaceRecognizer recognizer = new EigenFaceRecognizer(
                                       trainingImages.ToArray(),
                                       labels.ToArray(),
                                       5000,
                                       ref termCrit);
                                    name = recognizer.Recognize(result);
                                    if (string.IsNullOrEmpty(name) == true)
                                    {
                                        name = "UNKNOWN";
                                    }
                                    //Draw the label for each face detected and recognized
                                    currentFrame.Draw(name, ref font, new Point(f.rect.X + 10, f.rect.Y - 2), new Bgr(color_of_name_above_recognized_face));
                                }
                                NamePersons[t - 1] = name;
                                NamePersons.Add("");
                                //Set the number of faces detected on the scene                               
                            }
                        }
                        label3.Text = facesDetected[0].Length.ToString();
                        NumberOfFacesDetected = facesDetected[0].Length;
                        t = 0;
                        if (name == "UNKNOWN")
                        {
                            btnSubmitAttendance.Enabled = false;
                        }
                        if (facesDetected[0].Length < 1)
                        {
                            names = "";
                            NamePersons.Clear();
                            lblName.Text = "";
                        }
                        else if (facesDetected[0].Length >= 1)
                        {
                            for (int namelabel = 0; namelabel < facesDetected[0].Length; namelabel++)
                            {
                                names = names + NamePersons[namelabel] + ",";
                            }
                            foreach(var en in NamePersons)
                            {
                                lblName.Text = en.ToString();
                            }
                            //Show the faces processed and recognized                           
                            string names_without_comma_at_the_end = names.Remove(names.Length - 1);
                            lblName.Text = names_without_comma_at_the_end;
                            names = "";
                            NamePersons.Clear();
                        }
                        else
                        {
                        }
                        if (is_in_grayscale == true)
                        {
                            Image<Gray, Byte> grayImage = currentFrame.Convert<Gray, Byte>();
                            imageBoxFrameGrabber.Image = grayImage;
                        }
                        else
                        {
                            imageBoxFrameGrabber.Image = currentFrame;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }       
        public void Load_the_default_settings()
        {
            this.Size = new Size(900, 700);
            this.Location = new Point(0, 0);
            if (Properties.Settings.Default.themodule != string.Empty)
            {
                cmbModule.Text = Properties.Settings.Default.themodule;
            }
            if (Properties.Settings.Default.theclass != string.Empty)
            {
                cmbClass.Text = Properties.Settings.Default.theclass;
            }          
            is_12HR_format = Properties.Settings.Default.in12HrFormat;
            try
            {
                theConnection.Open();
                theConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Declare the date and time
            DateTime dt = DateTime.Now;
            lbldate.Text = dt.ToShortDateString();
            lbltime.Text = dt.ToString("HH:mm:ss");
            timer1.Start();
        }
        
        void submit_the_attendance()
        {
            string sub_attendance_message;
            if (lblName.Text == "")
            {
                reader.Dispose();
                sub_attendance_message = "No face detected. Try Again.";
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(sub_attendance_message);
                MessageBox.Show("No face detected. Try Again", "No face detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbClass.Text == "")
            {
                reader.Dispose();
                sub_attendance_message = "You need to input the class. Try Again.";
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(sub_attendance_message);
                MessageBox.Show("You need to input the class. Try Again.", "Class field is empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);          
            }
            else if (cmbModule.Text == "")
            {
                reader.Dispose();
                sub_attendance_message = "You need to input the module. Try Again.";
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(sub_attendance_message);
                MessageBox.Show("You need to input the module. Try Again.", "Module field is empty", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else if (lblName.Text.Contains("UNKNOWN")==true)
            {
                reader.Dispose();
                sub_attendance_message = "Unknown face detected! Student is not recognized";
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(sub_attendance_message);
                MessageBox.Show("Unknown face detected! Student is not recognized ", "Unknown face detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DateTime current_date = DateTime.Now;
                int total_people_present_in_scene = Int32.Parse(label3.Text);
                string namestring = lblName.Text;
                try
                    {
                    if (total_people_present_in_scene == 1)
                    {
                        con.Open();
                        SqlDataAdapter sdb = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + namestring + "'", con);
                        sdb.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(namestring + "'s attendance is submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string folder_name = Application.StartupPath + "/Student Attendance Log/Attendance Log";
                        if (!Directory.Exists(folder_name))
                        {
                            Directory.CreateDirectory(folder_name);
                        }
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy")+" Student Attendance Records Log"+".txt",true);
                        file.WriteLine(namestring + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();
                    }
                    else if (total_people_present_in_scene == 2)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                         con.Open();
                         SqlDataAdapter sdb = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                         sdb.SelectCommand.ExecuteNonQuery();
                         con.Close();
                         con.Open();
                         SqlDataAdapter sdc = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                         sdc.SelectCommand.ExecuteNonQuery();
                         con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + " and " + name_two + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + " and " + name_two + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();                 
                    }
                    else if (total_people_present_in_scene == 3)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                        name_three = list_of_names[2].ToString();
                         con.Open();
                         SqlDataAdapter sdd = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                         sdd.SelectCommand.ExecuteNonQuery();
                         con.Close();
                         con.Open();
                         SqlDataAdapter sde = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                         sde.SelectCommand.ExecuteNonQuery();
                         con.Close();
                         con.Open();
                         SqlDataAdapter sdf = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_three + "'", con);
                         sdf.SelectCommand.ExecuteNonQuery();
                         con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + ", " + name_two + " and " + name_three + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + ", " + name_two + " and " + name_three + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();                      
                    }
                    else if (total_people_present_in_scene == 4)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                        name_three = list_of_names[2].ToString();
                        name_four = list_of_names[3].ToString();
                        con.Open();
                        SqlDataAdapter sdd = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                        sdd.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sde = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                        sde.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdf = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_three + "'", con);
                        sdf.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdg = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_four + "'", con);
                        sdg.SelectCommand.ExecuteNonQuery();
                        con.Close();        
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + ", " + name_two + ", " + name_three + " and " + name_four + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + ", " + name_two + " and " + name_three + " and " + name_four + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();
                    }
                    else if (total_people_present_in_scene == 5)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                        name_three =list_of_names[2].ToString();
                        name_four = list_of_names[3].ToString();
                        name_five = list_of_names[4].ToString();
                        con.Open();
                        SqlDataAdapter sdd = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                        sdd.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sde = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                        sde.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdf = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_three + "'", con);
                        sdf.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdg = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_four + "'", con);
                        sdg.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdh = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_five + "'", con);
                        sdh.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();
                    }
                    else if (total_people_present_in_scene == 6)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                        name_three = list_of_names[2].ToString();
                        name_four = list_of_names[3].ToString();
                        name_five = list_of_names[4].ToString();
                        name_six = list_of_names[5].ToString();
                        con.Open();
                        SqlDataAdapter sdd = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                        sdd.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sde = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                        sde.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdf = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_three + "'", con);
                        sdf.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdg = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_four + "'", con);
                        sdg.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdh = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_five + "'", con);
                        sdh.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        SqlDataAdapter sdi = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_six + "'", con);
                        sdi.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + name_six + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + name_six + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();
                    }
                    else if (total_people_present_in_scene == 7)
                    {
                        list_of_names = namestring.Split(',');
                        name_one = list_of_names[0].ToString();
                        name_two = list_of_names[1].ToString();
                        name_three = list_of_names[2].ToString();
                        name_four = list_of_names[3].ToString();
                        name_five = list_of_names[4].ToString();
                        name_six = list_of_names[5].ToString();
                        name_seven = list_of_names[6].ToString();
                        con.Open();
                        SqlDataAdapter sdd = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_one + "'", con);
                        sdd.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sde = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_two + "'", con);
                        sde.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdf = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_three + "'", con);
                        sdf.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdg = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_four + "'", con);
                        sdg.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlDataAdapter sdh = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_five + "'", con);
                        sdh.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        SqlDataAdapter sdi = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_six + "'", con);
                        sdi.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        SqlDataAdapter sdj = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + cmbModule.Text + "',Class='" + cmbClass.Text + "',Date='" + lbldate.Text + "',Time='" + lbltime.Text + "',Attendance='" + "Present" + "'WHERE Name='" + name_seven + "'", con);
                        sdj.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        reader.Dispose();
                        sub_attendance_message = "Attendance submitted successfully";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + name_six + name_seven + "'s attendance are submitted successfully!", "Submission successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StreamWriter file = new StreamWriter(Application.StartupPath + "\\Student Attendance Log\\" + "\\Attendance Log\\" + current_date.ToString("dd-MM-yyyy") + " Student Attendance Records Log" + ".txt", true);
                        file.WriteLine(name_one + ", " + name_two + ", " + name_three + ", " + name_four + " and " + name_five + name_six + name_seven + " attendance is taken on " + current_date.ToString("dd/MM/yyyy HH:mm:ss"));
                        file.Close();
                    }
                    else if(total_people_present_in_scene==0)
                    {
                        reader.Dispose();
                        sub_attendance_message = "No face detected! Try Again";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show("No face detected. Try Again", "No face detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(total_people_present_in_scene>7)
                    {
                        reader.Dispose();
                        sub_attendance_message = "Too many people present in the scene. Please ensure that only 1 to 5 people are facing the camera.";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync(sub_attendance_message);
                        MessageBox.Show("Too many people present in the scene. Please ensure that only 1 to 7 people are facing the camera.", "Too many people present", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                    }                    
                    }
                    catch
                    {
                        MessageBox.Show("There were issues capturing the attendance! Try again.");
                    }
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void clearStudentDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + "-" + "',Class='" + "-" + "',Date='" + "-" + "',Time='" + "-" + "',Attendance='" + "-" + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Attendance Records Cleared");
            }
            catch
            {
                MessageBox.Show("Error Clearing the student database");
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            btnStopCamera.PerformClick();
            FrmLogin frmlog = new FrmLogin();
            frmlog.Show();
            this.Hide();
        }  

        private void btnSubmitAttendance_Click(object sender, EventArgs e)
        {          
            Properties.Settings.Default.theclass = cmbClass.Text;
            Properties.Settings.Default.themodule = cmbModule.Text;
            Properties.Settings.Default.Save();
            submit_the_attendance();
        }
        private void browse_image()
        {
            NamePersons.Add("");
            NumberOfFacesDetected = 0;
            label3.Text = "0";
            //=================Check if I have selected some image or not===========================//
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.bmp";
            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                Image InputImg = Image.FromFile(open_file_dialog.FileName);
                try
                {
                    if (InputImg == null)
                    {
                        throw new Exception("Please select an image");
                    }
                    ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                    DetectFaces();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }     
        private void DetectFaces()
        {
            NamePersons.Add("");
            Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
            MCvAvgComp[][] facesDetected = grayframe.DetectHaarCascade(
            face,
            1.2,
            4,
            Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            new Size(20, 20));
            label3.Text = facesDetected[0].Length.ToString();
            if (facesDetected[0].Length > 0)
            {
                foreach (MCvAvgComp f in facesDetected[0])
                {              
                    t = t + 1;                 
                    result = ImageFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    ImageFrame.Draw(f.rect, new Bgr(Color.Green), 3);
                    if (trainingImages.ToArray().Length != 0)
                        {
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.01);
                            EigenFaceRecognizer recognizer = new EigenFaceRecognizer(
                                 trainingImages.ToArray(),
                                 labels.ToArray(),
                                 5000,
                                 ref termCrit
                                 );
                            name = recognizer.Recognize(result);
                            //Show recognized person's name
                            if (string.IsNullOrEmpty(name) == true)
                            {
                                name = "UNKNOWN";
                            }
                            ImageFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));
                        }
                        NamePersons[t - 1] = name;
                        NamePersons.Add("");
                    }
                }
            label3.Text = facesDetected[0].Length.ToString();
            NumberOfFacesDetected = facesDetected[0].Length;
            t = 0;                  
            for (int namelabel = 0; namelabel < facesDetected[0].Length; namelabel++)
            {
                names = names + NamePersons[namelabel] + ",";
            }
            if (is_in_grayscale == true)
            {                
                Image<Gray, byte> displayed_image_in_grayscale = ImageFrame.Convert<Gray, byte>();
                imageBoxFrameGrabber.Image = displayed_image_in_grayscale;
            }
            else if(is_in_grayscale == false)
            {
                imageBoxFrameGrabber.Image = ImageFrame;
            }
            else
            {
            }
            string names_without_comma_at_the_end = names.Remove(names.Length - 1);
            lblName.Text = names_without_comma_at_the_end;
            names = "";
            NamePersons.Clear();
        }
        private void detectFaceOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detect_both_face_and_eyes = false;
        }
        private void detectFaceAndEyesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detect_both_face_and_eyes = true;
        }
        private void btnAddTrainingImage_Click(object sender, EventArgs e)
        {
            if (is_camera_on == true)
            {
                btnStopCamera.PerformClick();
            }
            else
            {

            }
            FrmTrainFaces frm_tf = new FrmTrainFaces();
            frm_tf.Show();
            this.Hide();
        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            Load_the_default_settings();
        }
        private void browseImageToRecognizeFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_camera_on == true)
            {
                btnStopCamera.PerformClick();
            }
            else
            {

            }
            if (is_camera_on == false)
            {
                browse_image();
            }
            else
            {
                MessageBox.Show("Turn off the camera first!");
            }
        }

        private void convertToGrayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_in_grayscale = true;
            if (is_camera_on == false)
            {
                if (is_in_grayscale == true)
                {
                    Image<Bgr, byte> the_displayed_image = new Image<Bgr, byte>(new Bitmap(imageBoxFrameGrabber.Image.Bitmap));
                    Image<Gray, byte> the_displayed_image_in_grayscale = the_displayed_image.Convert<Gray, byte>();
                    imageBoxFrameGrabber.Image = the_displayed_image_in_grayscale;
                }
            }
        }
        private void hourFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_12HR_format = true;
            Properties.Settings.Default.in12HrFormat = is_12HR_format;
            Properties.Settings.Default.Save();
        }
        private void hourFormatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            is_12HR_format = false;
            Properties.Settings.Default.in12HrFormat = is_12HR_format;
            Properties.Settings.Default.Save();
        }      
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime1 = DateTime.Now;
            lbldate.Text = datetime1.ToShortDateString();
            if (is_12HR_format == true)
            {
                lbltime.Text = datetime1.ToString("hh:mm:ss tt");
            }
            else if (is_12HR_format == false)
            {
                lbltime.Text = datetime1.ToString("HH:mm:ss");
            }
        }
    }
}