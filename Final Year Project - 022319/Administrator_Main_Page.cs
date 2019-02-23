using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmAdministratorMainPage : Form
    {
        public FrmAdministratorMainPage()
        {
            InitializeComponent();
        }

        private void btnTakeStudentsAttendance_Click(object sender, EventArgs e)
        {
            FrmTrainFaces Frm_tf = new FrmTrainFaces();
            Frm_tf.Show();
            this.Hide();
        }

        private void btnConductFaceRecognitionExperiments_Click(object sender, EventArgs e)
        {
            FrmEigenfacesExperiments detectf = new FrmEigenfacesExperiments();
            detectf.Show();
            this.Hide();
        }
        private void FrmAdministratorMainPage_Load(object sender, EventArgs e)
        {
        }
        private void btnRunIntegratedCode_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frmLog = new FrmLogin();
            frmLog.Show();
            this.Hide();
        }
    }
}
