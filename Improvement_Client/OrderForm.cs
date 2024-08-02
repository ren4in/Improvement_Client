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
    public partial class OrderForm : Form
    {
        private Order _currentOrder = new Order();
        private User selectedUser;
        public OrderForm(Order _selectedOrder)
        {
            InitializeComponent();
            if (_selectedOrder != null)
            {
                _currentOrder = _selectedOrder;
                txtHeader.Text = _currentOrder.Header;
                txtText.Text = _currentOrder.Text;
                dtpDeadline.Value = (DateTime)_currentOrder.Deadline;

            }

        }
        public OrderForm(User _selectedUser)
        {
            InitializeComponent();
            {
                _currentOrder = new Order();
                _currentOrder.id_Executor = _selectedUser.id_User;
                _currentOrder.id_Supervisor = Api.userId;
                _currentOrder.Accepted = false;
                _currentOrder.Date_of_Issue = DateTime.Now;
                selectedUser = _selectedUser;
            }

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ReportsForm form = new ReportsForm();

            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна
        }
        private async void btnApply_Click(object sender, EventArgs e)
        {
            _currentOrder.Header = txtHeader.Text;

            // Получение времени из MaskedTextBox
            DateTime selectedDate = dtpDeadline.Value.Date;

            // Получение времени из MaskedTextBox
            TimeSpan selectedTime;
            if (TimeSpan.TryParse(txtTime.Text, out selectedTime))
            {
                // Объединение даты и времени
                DateTime deadline = selectedDate.Add(selectedTime);
                _currentOrder.Deadline = deadline;
            }
            else
            {
                MessageBox.Show("Неверный формат времени. Пожалуйста, введите время в формате ЧЧ:ММ.");
                return;
            }

            

            _currentOrder.Text = txtText.Text;

            var orderJson = JsonConvert.SerializeObject(_currentOrder);
            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            if (_currentOrder.id_Order == null)
            {
                response = await Api.client.PostAsync(Api.APP_PATH + "/api/orders", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Поручение успешно добавлено");
                    ReportsForm form = new ReportsForm(selectedUser);

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


                response = await Api.client.PutAsync(Api.APP_PATH + "/api/orders/" + _currentOrder.id_Order, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Данные успешно изменены!");
                    ReportsForm form = new ReportsForm(_currentOrder.id_ExecutorNavigation);

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

        private void dtpDeadline_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}