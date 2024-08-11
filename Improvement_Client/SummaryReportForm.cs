using Improvement_Client.db;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class SummaryReportForm : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintDialog printDialog = new PrintDialog(); // Добавляем диалог печати
        private int currentRowIndex = 0;
        private int totalWidth;
        private List<int> columnWidths = new List<int>();

        public SummaryReportForm()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private async void BtnGenerate_Click(object sender, EventArgs e)
                
        {
            var startDate = dtpStartDate.Value.Date;
            var endDate = dtpEndDate.Value.Date;
            var url = Api.APP_PATH + $"/api/ReportsSummary/SummaryReport?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

            try
            {
                var summaryReports = await Api.client.GetFromJsonAsync<List<SummaryReport>>(url);
                dataGridView.DataSource = summaryReports;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            currentRowIndex = 0; // Сброс индекса строки
            columnWidths.Clear();
            totalWidth = 0;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!(column is DataGridViewButtonColumn))
                {
                    columnWidths.Add(column.Width);
                    totalWidth += column.Width;
                }
            }

            // Открываем диалог выбора принтера
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); // Отправляем документ на печать
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDataGridView(e);
        }

        private void PrintDataGridView(PrintPageEventArgs e)
        {
            int headerHeight = 50;
            int rowHeight = 40;
            int cellPadding = 5;
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top + headerHeight;
            int rightMargin = e.MarginBounds.Right;

            // Отрисовка заголовка отчета
            string reportTitle = $"Отчет за период с {dtpStartDate.Value:dd.MM.yyyy} по {dtpEndDate.Value:dd.MM.yyyy}";
            e.Graphics.DrawString(reportTitle, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, leftMargin, e.MarginBounds.Top);

            // Отрисовка заголовков колонок
            leftMargin = e.MarginBounds.Left;
            int columnIndex = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!(column is DataGridViewButtonColumn))
                {
                    e.Graphics.FillRectangle(Brushes.LightBlue, new Rectangle(leftMargin, topMargin, columnWidths[columnIndex], headerHeight));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(leftMargin, topMargin, columnWidths[columnIndex], headerHeight));
                    e.Graphics.DrawString(column.HeaderText, dataGridView.Font, Brushes.Black, new RectangleF(leftMargin + cellPadding, topMargin + cellPadding, columnWidths[columnIndex] - 2 * cellPadding, headerHeight - 2 * cellPadding), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    leftMargin += columnWidths[columnIndex];
                    columnIndex++;
                }
            }

            // Отрисовка строк данных
            leftMargin = e.MarginBounds.Left;
            topMargin += headerHeight;
            while (currentRowIndex < dataGridView.Rows.Count)
            {
                columnIndex = 0;
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    if (!(dataGridView.Columns[col] is DataGridViewButtonColumn))
                    {
                        if (dataGridView.Rows[currentRowIndex].Cells[col].Value != null)
                        {
                            e.Graphics.DrawString(dataGridView.Rows[currentRowIndex].Cells[col].Value.ToString(), dataGridView.Font, Brushes.Black, new RectangleF(leftMargin + cellPadding, topMargin + cellPadding, columnWidths[columnIndex] - 2 * cellPadding, rowHeight - 2 * cellPadding), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        }
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(leftMargin, topMargin, columnWidths[columnIndex], rowHeight));
                        leftMargin += columnWidths[columnIndex];
                        columnIndex++;
                    }
                }
                topMargin += rowHeight;
                leftMargin = e.MarginBounds.Left;
                currentRowIndex++;

                if (topMargin > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void SummaryReportForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            // Корректировка размера и шрифта элементов управления в зависимости от размера формы
            /*     float newSize = Math.Max(12, ClientSize.Width / 50); // При необходимости настройте этот коэффициент

            // Обновление размеров шрифтов
            dataGridView.Font = new Font("Microsoft Sans Serif", newSize);
            dtpStartDate.Font = new Font("Microsoft Sans Serif", newSize);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", newSize);
            btnGenerate.Font = new Font("Microsoft Sans Serif", newSize);
            btnBack.Font = new Font("Microsoft Sans Serif", newSize);
            btnPrint.Font = new Font("Microsoft Sans Serif", newSize);
            */
        }
    }
}
