using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Speech;
using System.Speech.Synthesis;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
//====================Adding the OpenCV libraries================================
//Go to OpenCV file
//Add Emgu.CV.dll as a Reference
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
namespace MultiFaceRec
{
    public partial class FrmModifyAttendanceSheet : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        int count = 0;
        public FrmModifyAttendanceSheet()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
        private void FrmModifyAttendanceSheet_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 700);
            this.Location = new Point(0, 0);
            try
            {
                //============To View Attendance Records==============//
                sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                       FROM [dbo].[StudentAttendanceRecords]", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            count_number_of_students();
        }
        void count_number_of_students()
        {
            string number_of_rows = "SELECT COUNT(*) FROM [dbo].[StudentAttendanceRecords]";
            SqlCommand cmd = new SqlCommand(number_of_rows, con);
            con.Open();
            count = (int)cmd.ExecuteScalar();
            lblNoRows.Text = count.ToString();
            con.Close();
        }

        private void btnUpdateAttendanceSheet_Click(object sender, EventArgs e)
        {
            //======Update the attendance records after making amendments=======================//
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("Record(s) updated successfully!\n");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO [dbo].[StudentAttendanceRecords] (Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance) VALUES (@StudentRollNo,@Name,@ModuleCode,@Class,@Date,@Time,@Attendance)";
            SqlCommand mycommand = new SqlCommand(query,con);
            mycommand.Parameters.AddWithValue("@StudentRollNo", txtStudentRollNo.Text);
            mycommand.Parameters.AddWithValue("@Name", txtStudentName.Text);
            mycommand.Parameters.AddWithValue("@ModuleCode", "-");
            mycommand.Parameters.AddWithValue("@Class", "-");
            mycommand.Parameters.AddWithValue("@Date", "-");
            mycommand.Parameters.AddWithValue("@Time", "-");
            mycommand.Parameters.AddWithValue("@Attendance", "-");
            mycommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(txtStudentName.Text + "  Entry Inserted Successfully!");
            sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                     FROM [dbo].[StudentAttendanceRecords]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            count_number_of_students();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand mydelcommand = new SqlCommand("DELETE FROM [dbo].[StudentAttendanceRecords] WHERE Student_RollNo='" + txtStudentRollNo.Text + "'AND Name='" + txtStudentName.Text + "'", con);
                mydelcommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(txtStudentName.Text + "  Entry is Deleted Successfully!");
                sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                     FROM [dbo].[StudentAttendanceRecords]", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                count_number_of_students();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearAttendanceSheet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand mydelcommand = new SqlCommand("DELETE FROM [dbo].[StudentAttendanceRecords]", con);
            mydelcommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(txtStudentName.Text + "  All rows in the attendance sheet are deleted Successfully!");
            sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                     FROM [dbo].[StudentAttendanceRecords]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }
    }
}
