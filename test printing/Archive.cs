using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_printing
{
    public partial class Archive : UserControl
    {
        public Archive()
        {
            InitializeComponent();
        }

        private void Archive_Load(object sender, EventArgs e)
        {
           
            LoadTable();
           Single.Visible = false;
            Single.FillColor = Color.FromArgb(128,Color.Black);
            Single.UseTransparentBackground = true;
        }
        private Image ScaleImage(Image image, int width, int height)
        {
            Bitmap scaledImage = new Bitmap(880, 750);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.DrawImage(image, 0, 0, 880, 750);
                //  scaledImage.SetResolution(100, 100);
            }
            return scaledImage;
        }
        public void LoadTable()
        {
            Image image = ScaleImage(new bill().CaptureScreenshot(), 300, 340);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    // Create a PictureBox
                    Guna2PictureBox pictureBox = new Guna2PictureBox
                    {
                        // Set PictureBox properties as needed
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = image,
                        Dock = DockStyle.Fill,
                        Name=col.ToString()+" "+ row.ToString(),
                        Cursor = Cursors.Hand,
                        
                        // BorderStyle = BorderStyle.FixedSingle, // Optional: Add a border

                    };
                    pictureBox.Click += PictureBox_Click;

                    // Add PictureBox to the TableLayoutPanel
                    ArchiveTable.Controls.Add(pictureBox, col, row);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                ArchiveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 4));
            }

            // Set the space between rows
            for (int i = 0; i < 3; i++)
            {
                ArchiveTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 3));
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Single.Visible = true;
            Single.BringToFront();
            Image image = ScaleImage(new bill().CaptureScreenshot(), 300, 340);
            billSwitch.Image = image;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Single.Visible=false;
            Single.SendToBack();

        }

        private void back_Click(object sender, EventArgs e)
        {
            Home home = (Home)this.ParentForm;
            home.archive1.SendToBack();
        }
    }
}
