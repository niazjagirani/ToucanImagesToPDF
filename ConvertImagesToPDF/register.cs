using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertImagesToPDF
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please communicate with vendor, Key is not registered");
        }
    }
}
