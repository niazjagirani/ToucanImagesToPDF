using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ConvertImagesToPDF
{
    public partial class Form1 : Form
    {
        // private List<string> images;
        private int index;
        Document myDocument = new Document(PageSize.A4, 10, 10, 10, 10);
        public Form1()
        {
            //Thread t = new Thread(new ThreadStart(splash));
            //t.Start();
           

            InitializeComponent();

          

        //t.Abort();
         
        }
        public void splash()
        {
            Application.Run(new flashScreen());
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = documents + @"\\";
                openFileDialog1.Multiselect = true;
                openFileDialog1.Title = "Browse Image Files";
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.DefaultExt = "jpg";
                openFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                foreach (String file in openFileDialog1.FileNames)
                {
                    i += 1;

                    if (i > 10)
                    {

                    }
                    else
                    {
                        listBox1.Items.Add(file);
                    }

                }
                label1.Text = "Total Images: " + listBox1.Items.Count;
                pictureBox1.Image = null;
                pictureBox1.ImageLocation = listBox1.Items[0].ToString();
                label2.Text = "Current Image No: " + 1;
            }
            catch (Exception ex)
            {

            }

        }

        private void btnConvert_Click(object sender, EventArgs e)

        {
            try { 
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = documents + @"\\";
            Document myDocument = new Document(PageSize.A4,10,10,10,10);

            PdfWriter.GetInstance(myDocument, new FileStream(path + pdfFileNameMy.Text.ToString() + ".pdf", FileMode.Create));

            // step 3:  Open the document now using
             myDocument.Open();
            foreach (var image in listBox1.Items)
            {
               
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(image.ToString());
                pic.CompressionLevel = PdfStream.BEST_COMPRESSION;
                pic.CompressionLevel = PdfStream.BEST_SPEED;

                if (pic.Height > pic.Width)
                {
                  
                    //Maximum height is 800 pixels.
                    float percentage = 0.0f;
                    if (textBox2.Text == "")
                    {
                        percentage = 800 / pic.Height;
                    }
                    else
                        {
                        percentage = int.Parse(textBox2.Text) / pic.Height;
                        }
                    pic.ScalePercent(percentage * 100);
                }
                else
                {
                  //  MessageBox.Show("Width: " + pic.Width + "Height: " + pic.Height);
                  //  pic.RotationDegrees = 90; //RotateFlipType.
                   
                    //Maximum width is 600 pixels.
                    float percentage = 0.0f;
                    if (textBox1.Text == "")
                    {
                        percentage = 550 / pic.Width;
                    }
                    else
                    {
                        percentage = int.Parse(textBox1.Text)/ pic.Width;
                    }
                    pic.ScalePercent(percentage * 100);
                }

                pic.Border = iTextSharp.text.Rectangle.BOX;
                pic.BorderColor = iTextSharp.text.BaseColor.BLACK;
                pic.BorderWidth = 3f;
               
                
                myDocument.NewPage();
               
                myDocument.Add(pic);

                    // listBox2.Items.Add(pic.GetImageRotation());
              


        }
            myDocument.Close();
            MessageBox.Show("pdf file is created.");
            }
            catch
            {
                MessageBox.Show("Please load images.");
            }
        }
             
      

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Refresh();
                pictureBox1.Image.Save(listBox1.Items[index].ToString());
            }
            catch { }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            { 
            index += 1;
            if (index > listBox1.Items.Count-1 )
            {
                index = 0;
            }
            pictureBox1.ImageLocation = listBox1.Items[index].ToString();
            label2.Text = "Current Image No: " + (index + 1);
            }
            catch { }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           try
            { 
            index -= 1; 
            pictureBox1.ImageLocation = listBox1.Items[index].ToString();

            label2.Text = "Current Image No: " + (index + 1);
            if (index == 0)
            {
                index = listBox1.Items.Count;
            }
            }
            catch { }

        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            register r = new register();
            r.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //        myDocument.Close();
        //        MessageBox.Show("Creation of pdf is completed.");

        //}
    }
}
