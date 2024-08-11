using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class SupervisorviewReportImages : Form
    {
        private List<Report_Image> allReportImages;
        private const int MaxImageWidth = 1000;  // Максимальная ширина изображения
        private const int MaxImageHeight = 1000; // Максимальная высота изображения

        public SupervisorviewReportImages(List<Report_Image> images)
        {
            InitializeComponent();
            allReportImages = images;
            LoadImages();
        }

        private void LoadImages()
        {
            imagePanel.Controls.Clear();  // Clear the panel of old images

            foreach (var reportImage in allReportImages)
            {
                Image img = ByteArrayToImage(reportImage.Image);
                if (img != null)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = img,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(10), // Add padding between images
                        Width = Math.Min(MaxImageWidth, imagePanel.ClientSize.Width - 40), // Устанавливаем ширину изображения
                        Height = Math.Min(MaxImageHeight, (MaxImageWidth * img.Height) / img.Width), // Устанавливаем высоту изображения
                        Anchor = AnchorStyles.Top // Центрируем по горизонтали
                    };

                    // Центрирование изображения
                    Panel wrapperPanel = new Panel
                    {
                        Width = imagePanel.ClientSize.Width,
                        Height = pictureBox.Height + 20, // Добавляем отступ
                        Margin = new Padding(0),
                        BackColor = Color.Transparent
                    };
                    pictureBox.Location = new Point((wrapperPanel.Width - pictureBox.Width) / 2, 10);
                    wrapperPanel.Controls.Add(pictureBox);

                    // Добавляем обёртку для изображения в панель
                    imagePanel.Controls.Add(wrapperPanel);
                }
                else
                {
                    Console.WriteLine("Image is null");
                }
            }

            AdjustLayout(); // Adjust layout after loading images
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupervisorviewReportImages_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            // Регулируем ширину и высоту каждого изображения при изменении размера окна
            foreach (Control control in imagePanel.Controls)
            {
                if (control is Panel wrapperPanel && wrapperPanel.Controls.Count > 0 && wrapperPanel.Controls[0] is PictureBox pictureBox)
                {
                    int newWidth = Math.Min(MaxImageWidth, imagePanel.ClientSize.Width - 40); // Ограничиваем ширину
                    int newHeight = Math.Min(MaxImageHeight, (newWidth * pictureBox.Image.Height) / pictureBox.Image.Width); // Ограничиваем высоту

                    pictureBox.Width = newWidth;
                    pictureBox.Height = newHeight;
                    wrapperPanel.Width = imagePanel.ClientSize.Width;
                    wrapperPanel.Height = newHeight + 20; // Добавляем отступ

                    pictureBox.Location = new Point((wrapperPanel.Width - pictureBox.Width) / 2, 10);
                }
            }

            // Центрируем кнопку OK
            btnOK.Font = new Font(btnOK.Font.FontFamily, Math.Max(10, this.ClientSize.Width / 50));
            btnOK.Width = Math.Max(100, this.ClientSize.Width / 5);
            btnOK.Height = Math.Max(40, this.ClientSize.Height / 8);
            btnOK.Location = new Point((okButtonPanel.Width - btnOK.Width) / 2, (okButtonPanel.Height - btnOK.Height) / 2);
        }
    }
}