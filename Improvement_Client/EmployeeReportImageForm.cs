using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class EmployeeReportImageForm : Form
    {
        private List<Report_Image> allReportImages;
        private int currentIndex;
        private Report currentReport;
        public EmployeeReportImageForm(Report_Image _selectedImage, List<Report_Image> _allReportImages, Report _selectedReport)
        {
            allReportImages = _allReportImages;
            currentReport = _selectedReport;
            currentIndex = allReportImages.IndexOf(_selectedImage);
            InitializeComponent();
            LoadCurrentImage();
        }

        private void LoadCurrentImage()
        {
            if (currentIndex >= 0 && currentIndex < allReportImages.Count)
            {
                var currentImage = allReportImages[currentIndex];
                using (var ms = new MemoryStream(currentImage.Image))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % allReportImages.Count;
            LoadCurrentImage();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + allReportImages.Count) % allReportImages.Count;
            LoadCurrentImage();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < allReportImages.Count)
            {
                HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/Report_Image/" + allReportImages[currentIndex].id_Report_Image);

                allReportImages.RemoveAt(currentIndex);
                if (allReportImages.Count == 0)
                {
                    pictureBox.Image = null;
                    return;
                }
                currentIndex = currentIndex % allReportImages.Count;
                LoadCurrentImage();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            EmployeeReportImagesDataGridForm form = new EmployeeReportImagesDataGridForm(currentReport);
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false; // Изменено на false, чтобы выбрать только одно изображение
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName; // Получаем только первый выбранный файл
                var imageBytes = File.ReadAllBytes(fileName);
                var newImage = new Report_Image
                {
                    id_Report_Image = null,
                    id_Report = currentReport.id_Report, // Set the report ID accordingly
                    RowGuid = Guid.NewGuid(),
                    Image = imageBytes
                };

                allReportImages.Add(newImage);
                var imageJson = JsonConvert.SerializeObject(newImage);
                var content = new StringContent(imageJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await Api.client.PostAsync(Api.APP_PATH + "/api/Report_Image", content);
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
                allReportImages.Add(newImage);
                currentIndex = allReportImages.Count - 1;
                LoadCurrentImage();

            }
        }



        private void Form_Load(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }
        private void LayoutControls()
        {
            int margin = 10;
            int buttonHeight = ClientSize.Height / 6; // Высота кнопок
            int buttonWidth = ClientSize.Width / 7;  // Увеличенная ширина кнопок
            int bottomButtonWidth = ClientSize.Width / 4; // Увеличенная ширина нижних кнопок

            btnPrevious.Location = new Point(margin, ClientSize.Height / 2 - buttonHeight / 2);
            btnPrevious.Size = new Size(buttonWidth, buttonHeight);

            btnNext.Location = new Point(ClientSize.Width - buttonWidth - margin, ClientSize.Height / 2 - buttonHeight / 2);
            btnNext.Size = new Size(buttonWidth, buttonHeight);

            int pictureBoxHeight = ClientSize.Height - 2 * buttonHeight - 3 * margin; // Увеличенное пространство для картинки
            pictureBox.Location = new Point(btnPrevious.Right + margin, margin);
            pictureBox.Size = new Size(ClientSize.Width - 2 * buttonWidth - 3 * margin, pictureBoxHeight);

            btnBack.Location = new Point(margin, ClientSize.Height - buttonHeight - margin);
            btnBack.Size = new Size(bottomButtonWidth, buttonHeight);

            btnDelete.Location = new Point((ClientSize.Width - bottomButtonWidth) / 2, ClientSize.Height - buttonHeight - margin);
            btnDelete.Size = new Size(bottomButtonWidth, buttonHeight);

            btnLoad.Location = new Point(ClientSize.Width - bottomButtonWidth - margin, ClientSize.Height - buttonHeight - margin);
            btnLoad.Size = new Size(bottomButtonWidth, buttonHeight);

            float newFontSize = ClientSize.Width / 45f; // Увеличенный размер шрифта
            btnPrevious.Font = new Font(btnPrevious.Font.FontFamily, newFontSize);
            btnNext.Font = new Font(btnNext.Font.FontFamily, newFontSize);
            btnDelete.Font = new Font(btnDelete.Font.FontFamily, newFontSize);
            btnBack.Font = new Font(btnBack.Font.FontFamily, newFontSize);
            btnLoad.Font = new Font(btnLoad.Font.FontFamily, newFontSize);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click_1(object sender, EventArgs e)
        {

        }
    }
}