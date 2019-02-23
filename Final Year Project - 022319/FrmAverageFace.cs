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
    public partial class FrmAverageFace : Form
    {
        public FrmAverageFace()
        {
            InitializeComponent();
        }


        private void FrmAverageFace_Load(object sender, EventArgs e)
        {
            Bitmap that_average_image = FrmEigenfacesExperiments.the_average_face;
            Image img_average_image = (Image)that_average_image;
            picAverageFace.Image = img_average_image;
        }
    }
}
