using Improvement_Client.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class SummaryReportForm : Form
    {
        public SummaryReportForm()
        {
            InitializeComponent();
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
            // Print logic
        }
        private void SummaryReportForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            // Adjust the size and font of controls based on the form's size
            /*     float newSize = Math.Max(12, ClientSize.Width / 50); // Adjust this factor as needed

            // Update font sizes
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

