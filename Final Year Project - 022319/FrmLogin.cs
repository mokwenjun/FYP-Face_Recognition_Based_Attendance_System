using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MultiFaceRec
{
    public partial class FrmLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True;Connect Timeout=30");       
        public static string the_user_name;
        
        public FrmLogin()
        {
            InitializeComponent();
           
        }
        
        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
          
        }
       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            the_user_name = txtUserName.Text;
            //If the checkbox is ticked
            if (chkRememberMe.Checked)
            {
                Properties.Settings.Default.textbox = txtUserName.Text;
                Properties.Settings.Default.textbox2 = txtPassword.Text;
                Properties.Settings.Default.combobox = comboUserType.Text;
                Properties.Settings.Default.checkbox = chkRememberMe.Checked;
                Properties.Settings.Default.Save();
            } //If the checkbox is not ticked   
            else
            {
                Properties.Settings.Default.textbox = "";
                Properties.Settings.Default.textbox2 = "";
                Properties.Settings.Default.combobox = "";
                Properties.Settings.Default.checkbox = (chkRememberMe.Checked = false);
                Properties.Settings.Default.Save();
            }
            if (txtUserName.Text == "9999999999")
            {
                MessageBox.Show("Please key in your User Name", "User Name field is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPassword.Text == "9999999999")
            {
                MessageBox.Show("Please key in your Password", "Password field is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboUserType.Text == "Select User Type")
            {
                MessageBox.Show("Please select your User Type", "User Type is not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Sql Adapter to run the Sql Query
                //If it is correct, the count will be 1, otherwise the count will be 0
              /*SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From [dbo].[Login] Where UserName='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'and UserType='" + comboUserType.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);*/
             //   if (dt.Rows[0][0].ToString() == "1")
             //   {

                    if (comboUserType.Text == "Student")
                    {
                       
                       FrmMainForm frmp = new FrmMainForm();
                       frmp.Show();
                        
                        if (chkRememberMe.Checked == false)
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            comboUserType.Text = "";
                        }
                        this.Hide();
                      


                    }
                    else if (comboUserType.Text == "Teacher")
                    {

                        FrmAttendanceRecords frar = new FrmAttendanceRecords();
                        frar.Show();
                        if (chkRememberMe.Checked == false)
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            comboUserType.Text = "";
                        }
                        this.Hide();
                    }
                    else if (comboUserType.Text == "Admin")
                    {

                        FrmAdministratorMainPage FrmAdmin = new FrmAdministratorMainPage();
                        FrmAdmin.Show();
                        if (chkRememberMe.Checked == false)
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            comboUserType.Text = "";
                        }
                        this.Hide();
                    }
               // }
              /*  else
                {
                    MessageBox.Show("Please Check Your UserName and Password", "Invalid username or password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }*/
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.textbox != string.Empty)
            {
                chkRememberMe.Checked = Properties.Settings.Default.checkbox;
                txtUserName.Text = Properties.Settings.Default.textbox;
                txtPassword.Text = Properties.Settings.Default.textbox2;
                comboUserType.Text = Properties.Settings.Default.combobox;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegister frmreg = new FrmRegister();
            frmreg.Show();
        }

        private void comboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
