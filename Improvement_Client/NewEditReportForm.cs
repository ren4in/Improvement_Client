using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class NewEditReportForm : Form
    {
        public NewEditReportForm()
        {
            InitializeComponent();
        }
        private Report _currentReport = new Report();
        private Order _currentOrder;

        public NewEditReportForm(Report _selectedReport)
        {
            InitializeComponent();
            if (_selectedReport != null)
            {
                _currentReport = _selectedReport;
                txtHeader.Text = _currentReport.Header;
                txtText.Text = _currentReport.Text;


            }

        }
        public NewEditReportForm(Order _selectedOrder)
        {
            InitializeComponent();
            {
                _currentReport = new Report();
                _currentReport.id_Order = _selectedOrder.id_Order;
                _currentReport.Accepted = false;
                _currentOrder = _selectedOrder;

            }

        }
       


        private void btnBack_Click(object sender, EventArgs e)
        {
            EmployeeReportsForm form = new EmployeeReportsForm(_currentOrder);

            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

        }



        private async void btnApply_Click(object sender, EventArgs e)
        {
            _currentReport.Header = txtHeader.Text;

            // Получение времени из MaskedTextBox


            _currentReport.Text = txtText.Text;
            _currentReport.Date_Of_Writing = DateTime.Now;

            var reportJson = JsonConvert.SerializeObject(_currentReport);
            var content = new StringContent(reportJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            if (_currentReport.id_Report == null)
            {
                response = await Api.client.PostAsync(Api.APP_PATH + "/api/reports", content);
                if (response.IsSuccessStatusCode)
                {
                    Form form;
                    DialogResult result = MessageBox.Show("Добавить фотографии?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Проверяем выбранный пользователем ответ
                    if (result == DialogResult.Yes)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var createdReport = JsonConvert.DeserializeObject<Report>(responseContent);


                        form = new EmployeeReportImagesDataGridForm(createdReport);
                    }
                    else
                    {
                        form = new EmployeeReportsForm(_currentOrder);
                    }
                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

                }

                else
                {
                    MessageBox.Show("Ошибка!");
                }


            }

            else
            {


                response = await Api.client.PutAsync(Api.APP_PATH + "/api/reports/" + _currentReport.id_Report, content);
                if (response.IsSuccessStatusCode)
                    
                {
                    MessageBox.Show("Данные успешно изменены!");
                    //   EmployeeReportsForm  
                    Form form;
                    DialogResult result = MessageBox.Show("Просмотреть фотографии?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Проверяем выбранный пользователем ответ
                    if (result == DialogResult.Yes)
                    {

                          form = new EmployeeReportImagesDataGridForm(_currentReport);
                    } 
                    else
                    {
                        form = new EmployeeReportsForm(_currentReport.id_OrderNavigation);
                         }
                        form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна



                }
                else
                {
                    MessageBox.Show("Ошибка при изменении данных");
                }
            }

        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtText_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtText_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
