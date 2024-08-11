using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class SupervisorViewReport : Form
    {
        private Report _currentReport = new Report();
        private Order _currentOrder;
        private List<Report_Image> allReportImages = new List<Report_Image>();
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private PrintDialog printDialog = new PrintDialog();
        private int currentImageIndex = 0;

        public SupervisorViewReport(Report selectedReport)
        {
            InitializeComponent();
            if (selectedReport != null)
            {
                _currentReport = selectedReport;
                txtHeader.Text = _currentReport.Header;
                txtText.Text = _currentReport.Text;
                txtComment.Text = _currentReport.Manager_Comment;
                _currentOrder = _currentReport.id_OrderNavigation;
                chkReportAccepted.Checked = _currentReport.Accepted;
                chkOrderAccepted.Checked = (bool)_currentReport.id_OrderNavigation.Accepted;
                printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

                printPreviewDialog.Document = printDocument;
                printPreviewDialog.Width = 800;
                printPreviewDialog.Height = 600;

                LoadImages();
            }
        }

        private async void LoadImages()
        {
            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/Report_Image/report/" + _currentReport.id_Report);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                allReportImages = JsonConvert.DeserializeObject<List<Report_Image>>(responseContent);
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

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            SupervisorviewReportImages form = new SupervisorviewReportImages(allReportImages);
            form.Show();
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            _currentReport.Manager_Comment = txtComment.Text;

            var reportJson = JsonConvert.SerializeObject(_currentReport);
            var content = new StringContent(reportJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Api.client.PutAsync(Api.APP_PATH + "/api/reports/" + _currentReport.id_Report, content);
              response = await Api.client.PostAsync(Api.APP_PATH + $"/api/Orders/ToggleAccepted/{_currentReport.id_Order}", null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Данные успешно изменены!");
                Form form;
                DialogResult result = MessageBox.Show("Просмотреть фотографии?", "Изменение отчета", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    form = new EmployeeReportImagesDataGridForm(_currentReport);
                }
                else
                {
                    form = new ReportsForm(_currentReport.id_OrderNavigation);
                }

                form.Show();
                this.Hide();
                form.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при изменении данных");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);
            int yPos = 100;
            int leftMargin = e.MarginBounds.Left;
            int rightMargin = e.MarginBounds.Right;

            if (currentImageIndex == 0)
            {
                string header = txtHeader.Text;
                SizeF headerSize = g.MeasureString(header, headerFont);
                g.DrawString(header, headerFont, Brushes.Black, (rightMargin + leftMargin - headerSize.Width) / 2, yPos);
                yPos += (int)headerSize.Height + 20;

                string executorName = $"Исполнитель: {_currentOrder.id_ExecutorNavigation.FirstName} {_currentOrder.id_ExecutorNavigation.MiddleName} {_currentOrder.id_ExecutorNavigation.LastName}";
                g.DrawString(executorName, regularFont, Brushes.Black, leftMargin, yPos);
                yPos += (int)regularFont.GetHeight(g) + 10;

                string reportDate = $"Дата создания отчета: {_currentReport.Date_Of_Writing.ToShortDateString()}";
                g.DrawString(reportDate, regularFont, Brushes.Black, leftMargin, yPos);
                yPos += (int)regularFont.GetHeight(g) + 20;

                string reportText = txtText.Text;
                g.DrawString(reportText, regularFont, Brushes.Black, new RectangleF(leftMargin, yPos, rightMargin - leftMargin, e.MarginBounds.Height - yPos));
                yPos += (int)g.MeasureString(reportText, regularFont, e.MarginBounds.Width).Height + 20;
            }

            while (currentImageIndex < allReportImages.Count)
            {
                var image = allReportImages[currentImageIndex];
                Image img = ByteArrayToImage(image.Image);
                float aspectRatio = (float)img.Width / img.Height;
                int imgWidth = e.MarginBounds.Width;
                int imgHeight = (int)(imgWidth / aspectRatio);

                if (yPos + imgHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                g.DrawImage(img, leftMargin, yPos, imgWidth, imgHeight);
                yPos += imgHeight + 20;
                currentImageIndex++;
            }

            e.HasMorePages = false;
            currentImageIndex = 0;
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
        }

        private void chkReportAccepted_CheckedChanged(object sender, EventArgs e)
        {
            _currentReport.Accepted = chkReportAccepted.Checked;
        }

        private void chkOrderAccepted_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentOrder != null)
            {
                _currentOrder.Accepted = chkOrderAccepted.Checked;
            }
        }
    }
}
