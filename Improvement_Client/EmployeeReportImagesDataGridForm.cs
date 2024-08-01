using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class EmployeeReportImagesDataGridForm : Form
    {
        private List<Report_Image> allReportImages = new List<Report_Image>();
        private Report _currentReport;

        public EmployeeReportImagesDataGridForm(Report _selectedReport)
        {
            _currentReport = _selectedReport;
            InitializeComponent();
            LoadImages();
        }
    
        
        private async void LoadImages()
        {
            dataGridView.Rows.Clear();
            HttpResponseMessage response = await

                 Api.client.GetAsync(Api.APP_PATH + "/api/Report_Image/report/" + _currentReport.id_Report);

            if (response.IsSuccessStatusCode)
            {
                var imagesJson = await response.Content.ReadAsStringAsync();
                allReportImages = JsonConvert.DeserializeObject<List<Report_Image>>(imagesJson);
                foreach (var reportImage in allReportImages)
                {
                    var image = ByteArrayToImage(reportImage.Image);
                    var resizedImage = ResizeImage(image);

                    var row = new DataGridViewRow();
                    //   row.Height = ClientSize.Height - 3 * margin - buttonHeight * 2; ; // Adjust row height
                    row.Cells.Add(new DataGridViewImageCell() { Value = resizedImage });
                    row.Cells.Add(new DataGridViewButtonCell() { Value = "Посмотреть" });
                    row.Cells.Add(new DataGridViewButtonCell() { Value = "Удалить" });

                    dataGridView.Rows.Add(row);
                }

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }
            
        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private Image ResizeImage(Image image)
        {
            var maxWidth = dataGridView.Columns["Image"].Width;
            var maxHeight = 300; // Row height

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private async void BtnLoad_Click(object sender, EventArgs e)
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
                    id_Report = _currentReport.id_Report, // Set the report ID accordingly
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

                 LoadImages();
            }
        }
    
        

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Implement saving logic here
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)

        { 
        EmployeeReportsForm form = new EmployeeReportsForm(_currentReport.id_OrderNavigation);      
        form.Show();
        this.Hide();
        form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

    }

    private void Form_Load(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            LayoutControls();
            //   LoadImages(); // Reload images to apply new size
            ResizeImages();
        }
        private void ResizeImages()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Image"] is DataGridViewImageCell imageCell && imageCell.Value is Image image)
                {
                    imageCell.Value = ResizeImage(image);
                }
            }
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Image" && e.Value is Image image)
            {
                e.Value = ResizeImage(image);
            }
        }
        private void     LayoutControls()
        {
            int margin = 10;
            float buttonHeightRatio = 0.07f; // 6% of the form height
            float buttonWidthRatio = 0.15f; // 15% of the form width
            int buttonHeight = (int)(ClientSize.Height * buttonHeightRatio);
            int buttonWidth = (int)(ClientSize.Width * buttonWidthRatio);
            int gridWidth = ClientSize.Width - 2 * margin;
            int gridHeight = ClientSize.Height - 4 * margin - 2 * buttonHeight;

            // Расположение и размер кнопок
            btnLoad.Location = new Point(margin, margin);
            btnLoad.Size = new Size(gridWidth, buttonHeight);

            dataGridView.Location = new Point(margin, btnLoad.Bottom + margin);
            dataGridView.Size = new Size(gridWidth, gridHeight);

            btnBack.Location = new Point(margin, dataGridView.Bottom + margin);
            btnBack.Size = new Size(buttonWidth, buttonHeight);

            btnOK.Location = new Point(ClientSize.Width - margin - buttonWidth, dataGridView.Bottom + margin);
            btnOK.Size = new Size(buttonWidth, buttonHeight);

            // Настройка размера шрифта
            float newFontSize = Math.Min(ClientSize.Width, ClientSize.Height) / 50f; // Пропорциональный размер шрифта
            btnLoad.Font = new Font(btnLoad.Font.FontFamily, newFontSize);
            btnOK.Font = new Font(btnOK.Font.FontFamily, newFontSize);
            btnBack.Font = new Font(btnBack.Font.FontFamily, newFontSize);
            dataGridView.DefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, newFontSize);

            // Настройка высоты строк
            dataGridView.RowTemplate.Height = 80; // Уменьшена высота строки
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Убедитесь, что высота строк обновляется автоматически
        }
        private async void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridView.Columns["View"].Index)
                {
                    // Implement view logic here
                    var reportImage = allReportImages[e.RowIndex];
                    EmployeeReportImageForm form = new EmployeeReportImageForm(reportImage, allReportImages, _currentReport);
                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

                }
                else if (e.ColumnIndex == dataGridView.Columns["Delete"].Index)
                {
                    // Implement delete logic here
                    var reportImage = allReportImages[e.RowIndex];
                    HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/Report_Image/" + reportImage.id_Report_Image);
                    if (response.IsSuccessStatusCode)
                    {
                        // Успешно удалено
                        //   InitializeDataGridView_Users();
                        dataGridView.Rows.RemoveAt(e.RowIndex);
                        allReportImages.Remove(reportImage);
                        // LoadImages();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении фотографии.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
 
                }
            }
        }


    }
 
