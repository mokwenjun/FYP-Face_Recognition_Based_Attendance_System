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
    public partial class FrmRegister : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tokyo\OneDrive\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter your user name.\n");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your password. \n");
            }
            else if (comboUserType.Text == "")
            {
                MessageBox.Show("Please select a user type. \n");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Login] VALUES('" + txtUserName.Text + "','" + txtPassword.Text + "','" + comboUserType.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully!");
                }
                catch
                {
                    MessageBox.Show("UserName has been registered before");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmlog = new FrmLogin();
            frmlog.Show();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
