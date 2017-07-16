using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace Face_Detector
{
    public partial class Form1 : Form
    {
        private Bitmap _inputImage; //make a global variable to be accessable to all the loops

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            var openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                _inputImage = (Bitmap)System.Drawing.Image.FromFile(openfileDialog.FileName);
                pictureBoxInput.Image = _inputImage;

            }
        }

        private void process_button_Click(object sender, EventArgs e)
        {
            //changes are made here

            ////////YCbCr COLOUR PIXEL FILTERING

            var yCbCrFilter = new YCbCrFiltering();
            yCbCrFilter.Cb = new AForge.Range(-0.6f, 0);//horizon //segment the red colour
            yCbCrFilter.Cr = new AForge.Range(0, 0.2f);//vertical
            var yCbCrFilterOuptut = yCbCrFilter.Apply(_inputImage);
            pictureBoxOutput.Image = yCbCrFilterOuptut;
        }
    }
}
