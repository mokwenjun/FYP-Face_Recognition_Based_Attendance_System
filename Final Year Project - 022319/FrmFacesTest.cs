using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace MultiFaceRec
{
    public partial class FrmFacesTest : Form
    {
        private Capture capture3;
        private bool captureInProgress;
        public FrmFacesTest()
        {
            InitializeComponent();
        }
        Image<Bgr, Byte> ImageFrame3;
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> ImageFrame3 = capture3.QueryFrame();
            ImgCameraVideoBox.Image = ImageFrame3;
            picbox3.Image = ImageFrame3.ToBitmap();
        }
        private void btnstartvideo_Click(object sender, EventArgs e)
        {
            if(capture3 == null)
            {
                try
                {
                    capture3 = new Capture();
                }
                catch(NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if(capture3 != null)
            {
                if(captureInProgress)
                {
                    btnstartvideo.Text = "Start";
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture 
                    btnstartvideo.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }
                captureInProgress = !captureInProgress;
            }

        }
        private void ReleaseData()
        {
            if(capture3!=null)
            {
                capture3.Dispose();
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            ImageFrame3.Save(@"C:\Users\Tokyo\OneDrive\Desktop\Janet\test.jpg");
        }
    }
}
