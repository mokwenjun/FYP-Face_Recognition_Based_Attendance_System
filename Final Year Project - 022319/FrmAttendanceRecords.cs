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
using System.Data;

namespace MultiFaceRec
{
    public partial class FrmAttendanceRecords : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public FrmAttendanceRecords()
        {
            InitializeComponent();          
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
        private void btninsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + txtModule2.Text + "',Class='" + txtClass2.Text + "',Date='" + txtDate2.Text + "',Time='" + txtTime2.Text + "',Attendance='" + cmbAttendance.Text + "'WHERE Name='" + txtName2.Text + "'", con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(txtName2.Text + "  Entry Inserted Successfully!");
            sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                     FROM [dbo].[StudentAttendanceRecords]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmAttendanceRecords_Load(object sender, EventArgs e)
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
                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            //======Update the attendance records after making amendments=======================//
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("Record(s) updated successfully!\n");
        }
        private void btnclearalldata_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("UPDATE [dbo].[StudentAttendanceRecords] SET Module_Code='" + "-" + "',Class='" + "-" + "',Date='" + "-" + "',Time='" + "-" + "',Attendance='" + "-" + "'", con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("All student attendance records are cleared! ");
            sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                       FROM [dbo].[StudentAttendanceRecords]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sda.Update(dt);
            txtName2.Text = "";
            txtModule2.Text = "";
            txtClass2.Text = "";
            txtName2.Text = "";
            txtDate2.Text = "";
            txtTime2.Text = "";
            cmbAttendance.Text = "";
        }      
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtName2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtModule2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtClass2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtDate2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtTime2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            cmbAttendance.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin frmlog = new FrmLogin();
            frmlog.Show();
            this.Hide();
        }
        private void btnExportAttendanceRecordsToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime the_date = DateTime.Now;
                sda = new SqlDataAdapter(@"SELECT Student_RollNo,Name,Module_Code,Class,Date,Time,Attendance
                                       FROM [dbo].[StudentAttendanceRecords]", con);
                dt = new DataTable();      
                //  sda.Update(dt);
                DataSet ds = new DataSet("New_Dataset");
                ds.Locale = Thread.CurrentThread.CurrentCulture;
                sda.Fill(dt);
                ds.Tables.Add(dt);
                dataGridView1.DataSource = dt;
                ExcelLibrary.DataSetHelper.CreateWorkbook("Attendance_Records " + the_date.ToString("dd-MM-yyyy HHmm")+"-hrs" + ".xls", ds);
                MessageBox.Show("Attendance Records are being exported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmlog = new FrmLogin();
            frmlog.Show();
            this.Hide();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAttendanceRecords FrmAR = new FrmAttendanceRecords();
            FrmAR.Show();
            this.Dispose(false);
        }

        private void modifyAttendanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModifyAttendanceSheet FrmMAS = new FrmModifyAttendanceSheet();
            FrmMAS.Show();
            this.Hide();
        }
    }
}
