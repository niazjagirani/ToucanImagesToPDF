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
    public partial class flashScreen : Form
    {
        public flashScreen()
        {
            InitializeComponent();
        }

        private void flashScreen_Load(object sender, EventArgs e)
        {
          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

        private void flashScreen_Activated(object sender, EventArgs e)
        {
          
        }

        private void flashScreen_Enter(object sender, EventArgs e)
        {
        }
        Timer tmr;
        private void flashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();

            //set time interval 3 sec

            tmr.Interval = 3000;

            //starts the timer

            tmr.Start();

            tmr.Tick += tmr_Tick;


        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer

            tmr.Stop();

            //display mainform


            Form1 frm = new Form1();
            frm.Show();

            //hide this form

            this.Hide();
        }
    }
}
