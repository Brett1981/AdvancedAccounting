using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinListView;
using Re_useable_Classes.Converters;

namespace Advanced_Accounting.Forms
{
    public partial class FrmPricture : Form
    {
        public FrmPricture(string selectedFilePath)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = selectedFilePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public FrmPricture(UltraListView selectedFilePath)
        {
            InitializeComponent();
            if (selectedFilePath.SelectedItems.First.Tag != null)
            {
                byte[] item = ImageConverter.GetBytes(selectedFilePath.SelectedItems.First.Tag.ToString());
                string image = Convert.ToBase64String(item);
                pictureBox1.Image = ImageConverter.Base64ToImage(image);
            }
            else
            {
                pictureBox1.ImageLocation = selectedFilePath.SelectedItems.First.Key;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            Size = pictureBox1.Size;
        }

        private void pictureBox1_BackgroundImageChanged
            (
            object sender,
            EventArgs e)
        {
            Size = pictureBox1.Size;
        }

        private void pictureBox1_Validated
            (
            object sender,
            EventArgs e)
        {
            Size = pictureBox1.Size;
        }

        private void toolStripButton1_Click
            (
            object sender,
            EventArgs eventArgs)
        {
            printDocument.OriginAtMargins = true;
            printDocument.DocumentName = "Attachment: Date printed: " + DateTime.Now;

            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage
            (
            object sender,
            PrintPageEventArgs e)
        {
            e.Graphics.DrawImage
                (
                    pictureBox1.Image,
                    0,
                    0);
        }
    }
}
