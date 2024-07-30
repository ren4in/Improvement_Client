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
    public partial class EmployeeReportsForm : Form
    {
        public EmployeeReportsForm()
        {

            InitializeComponent();
            InitializeDataGridView_Orders();
            LoadOrders(Api.userId);

        }
        public EmployeeReportsForm(Order _selectedOrder)
        {

            InitializeComponent();
            InitializeDataGridView_Reports();
            LoadReports(_selectedOrder.id_Order);
            selectedOrder = _selectedOrder;

        }
        private List<Order> allOrders;
        private List<Report> allReports;



        public async void LoadReports(int? thisOrder)
        {
            HttpResponseMessage response = await

                Api.client.GetAsync(Api.APP_PATH + "/api/Reports/order/" + thisOrder);

            if (response.IsSuccessStatusCode)
            {
                var reportsJson = await response.Content.ReadAsStringAsync();
                allReports = JsonConvert.DeserializeObject<List<Report>>(reportsJson);
                DataGridReports.DataSource = allReports;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }

        private void InitializeDataGridView_Reports()
        {

            DataGridReports.CellFormatting -= DataGridReports_CellFormattingSupervisor;

            DataGridReports.DataSource = null;

            DataGridReports.Columns.Clear();
            DataGridReports.Rows.Clear();


            //DataGridReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            DataGridReports.AutoGenerateColumns = false;

            // Создаем и добавляем столбцы с настраиваемыми заголовками
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();


            
            idColumn.Name = "idColiumn";
            idColumn.HeaderText = "Номер отчета";
            idColumn.DataPropertyName = "id_Report";
            DataGridReports.Columns.Add(idColumn);


            DataGridViewTextBoxColumn headerColumn = new DataGridViewTextBoxColumn();



            headerColumn.Name = "HeaderColumn";
            headerColumn.HeaderText = "Заголовок";
            headerColumn.DataPropertyName = "Header";

            DataGridReports.Columns.Add(headerColumn);
             


            DataGridViewTextBoxColumn dateOfWritingColumn = new DataGridViewTextBoxColumn();



            dateOfWritingColumn.Name = "DateOfWritingColumn";
            dateOfWritingColumn.HeaderText = "Дата написания";
            dateOfWritingColumn.DataPropertyName = "Date_of_Writing";

            DataGridReports.Columns.Add(dateOfWritingColumn);

            DataGridViewTextBoxColumn TextColumn = new DataGridViewTextBoxColumn();



            TextColumn.Name = "TextColumn";
            TextColumn.HeaderText = "Содержание";
            TextColumn.DataPropertyName = "Text";

            DataGridReports.Columns.Add(TextColumn);


            DataGridViewCheckBoxColumn acceptedColumn = new DataGridViewCheckBoxColumn();
            acceptedColumn.Name = "AcceptedReportColumn";
            acceptedColumn.HeaderText = "Принят";
            acceptedColumn.DataPropertyName = "Accepted"; // Связь с полем данных
            acceptedColumn.ReadOnly = true;
            DataGridReports.Columns.Add(acceptedColumn);

            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "EditReportButton";
            buttonColumn1.HeaderText = "Изменить";
            buttonColumn1.Text = "Изменить";
            buttonColumn1.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            // Добавление второго DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "DeleteReportButton";
            buttonColumn2.HeaderText = "Удалить";
            buttonColumn2.Text = "Удалить отчет";
            buttonColumn2.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк


            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.Name = "ImagesButton";
            buttonColumn3.HeaderText = "Посмотреть фото";
            buttonColumn3.Text = "Посмотреть фото";
            buttonColumn3.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridReports.Columns.Add(buttonColumn1);
            DataGridReports.Columns.Add(buttonColumn2);
            DataGridReports.Columns.Add(buttonColumn3);


            // DataGridReports.CellClick += DataGridView1_CellClick;
            DataGridReports.CellFormatting += DataGridReports_CellFormattingSupervisor;

            CenterDataGrid();


        }
            public async void LoadOrders(int? thisUser)
        {
            HttpResponseMessage response = await

                Api.client.GetAsync(Api.APP_PATH + "/api/Orders/user/" + thisUser);

            if (response.IsSuccessStatusCode)
            {
                var ordersJson = await response.Content.ReadAsStringAsync();
                allOrders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);
                DataGridReports.DataSource = allOrders
                    ;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }

        private void InitializeDataGridView_Orders()
        {

            DataGridReports.DataSource = null;

            DataGridReports.Columns.Clear();
            DataGridReports.Rows.Clear();


            //DataGridReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            DataGridReports.AutoGenerateColumns = false;

            // Создаем и добавляем столбцы с настраиваемыми заголовками
            DataGridViewTextBoxColumn supervisorFirstnameColumn = new DataGridViewTextBoxColumn();



            supervisorFirstnameColumn.Name = "SupervisorFirstName";
            supervisorFirstnameColumn.HeaderText = "Имя руководителя";
            supervisorFirstnameColumn.DataPropertyName = "id_SupervisorNavigation.FirstName";
            DataGridReports.Columns.Add(supervisorFirstnameColumn);


            DataGridViewTextBoxColumn supervisorMiddlenameColumn = new DataGridViewTextBoxColumn();



            supervisorMiddlenameColumn.Name = "SupervisorMiddleName";
            supervisorMiddlenameColumn.HeaderText = "Отчество руководителя";
            supervisorFirstnameColumn.DataPropertyName = "id_SupervisorNavigation.MiddleName";

            DataGridReports.Columns.Add(supervisorMiddlenameColumn);



            DataGridViewTextBoxColumn supervisorLastnameColumn = new DataGridViewTextBoxColumn();



            supervisorLastnameColumn.Name = "SupervisorLastName";
            supervisorLastnameColumn.HeaderText = "Фамилия руководителя";
            supervisorLastnameColumn.DataPropertyName = "id_SupervisorNavigation.LastName";

            DataGridReports.Columns.Add(supervisorLastnameColumn);

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();



            idColumn.Name = "id";
            idColumn.HeaderText = "Номер задания";
            idColumn.DataPropertyName = "id_Order";

            DataGridReports.Columns.Add(idColumn);

            DataGridViewTextBoxColumn dateOfIssueColumn = new DataGridViewTextBoxColumn();



            dateOfIssueColumn.Name = "DateOfOssue";
            dateOfIssueColumn.HeaderText = "Дата выдачи";
            dateOfIssueColumn.DataPropertyName = "Date_Of_Issue";

            DataGridReports.Columns.Add(dateOfIssueColumn);


            DataGridViewTextBoxColumn deadlineColumn = new DataGridViewTextBoxColumn();


            deadlineColumn.Name = "Deadline";
            deadlineColumn.HeaderText = "Срок выполнения";
            deadlineColumn.DataPropertyName = "Deadline";
            DataGridReports.Columns.Add(deadlineColumn);



            DataGridViewTextBoxColumn headerColumn = new DataGridViewTextBoxColumn();


            headerColumn.Name = "Header";
            headerColumn.HeaderText = "Заголовок";
            headerColumn.DataPropertyName = "Header";
            DataGridReports.Columns.Add(headerColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();


            textColumn.Name = "Text";
            textColumn.HeaderText = "Содержание";
            textColumn.DataPropertyName = "Text";
            DataGridReports.Columns.Add(textColumn);


            DataGridViewCheckBoxColumn acceptedColumn = new DataGridViewCheckBoxColumn();
            acceptedColumn.Name = "AcceptedOrder";
            acceptedColumn.HeaderText = "Принят";
            acceptedColumn.DataPropertyName = "Accepted"; // Связь с полем данных
            acceptedColumn.ReadOnly = true;
            DataGridReports.Columns.Add(acceptedColumn);

            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "ReportsButton";
            buttonColumn1.HeaderText = "Отчеты";
            buttonColumn1.Text = "Отчеты";
            buttonColumn1.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            // Добавление второго DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "NewReportButton";
            buttonColumn2.HeaderText = "Написать отчет";
            buttonColumn2.Text = "Написать отчет";
            buttonColumn2.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк


            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.Name = "ViewOrderButton";
            buttonColumn3.HeaderText = "Посмотреть";
            buttonColumn3.Text = "Посмотреть";
            buttonColumn3.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridReports.Columns.Add(buttonColumn1);
            DataGridReports.Columns.Add(buttonColumn2);
            DataGridReports.Columns.Add(buttonColumn3);


            // DataGridReports.CellClick += DataGridView1_CellClick;
            DataGridReports.CellFormatting += DataGridReports_CellFormattingSupervisor;

            CenterDataGrid();
        }

        private void DataGridReports_CellFormattingSupervisor(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && allOrders != null && allOrders.Count > e.RowIndex)
            {
                var order = allOrders[e.RowIndex];

                if (DataGridReports.Columns[e.ColumnIndex].Name == "SupervisorFirstName")
                {
                    e.Value = order.id_SupervisorNavigation?.FirstName ?? string.Empty;
                }

                if (DataGridReports.Columns[e.ColumnIndex].Name == "SupervisorMiddleName")
                {
                    e.Value = order.id_SupervisorNavigation?.MiddleName ?? string.Empty;
                }


                else if (DataGridReports.Columns[e.ColumnIndex].Name == "SupervisorLastName")
                    e.Value = order.id_SupervisorNavigation?.LastName ?? string.Empty;
                {
                }
            }
        }

        Order selectedOrder;

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)

            {
                if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "ViewOrderButton")
                {
                    Order selectedOrder = allOrders[e.RowIndex];

                    EmployeeOrdersForm form = new EmployeeOrdersForm(selectedOrder);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна




                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "NewReportButton")
                {
                    Order selectedOrder = allOrders[e.RowIndex];

                    NewEditReportForm form = new NewEditReportForm(selectedOrder);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна




                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "ReportsButton")
                {
                    InitializeDataGridView_Reports();
                    selectedOrder = allOrders[e.RowIndex];
                    LoadReports((int)selectedOrder.id_Order);





                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "EditReportButton")
                {
                    Report selectedReport = allReports[e.RowIndex];

                    NewEditReportForm form = new NewEditReportForm(selectedReport);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна





                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "ImagesButton")
                {
                    Report selectedReport = allReports[e.RowIndex];

                    EmployeeReportImagesDataGridForm form = new EmployeeReportImagesDataGridForm(selectedReport);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна





                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "DeleteReportButton")
                {
                    DialogResult result = MessageBox.Show("Вы точно хотите удалить этот отчет?", "Удаление отчета", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Проверяем выбранный пользователем ответ
                    if (result == DialogResult.Yes)
                    {

                        Report selectedReport = allReports[e.RowIndex];

                        HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/reports/" + selectedReport.id_Report);

                        if (response.IsSuccessStatusCode)
                        {
                            // Успешно удалено
                            MessageBox.Show("Отчет успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //   InitializeDataGridView_Users();
                            LoadReports(selectedOrder.id_Order);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении отчета.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }


            }
        }


        private void ReportsForm_Resize(object sender, EventArgs e)
        {
            // Вызываем метод для центрирования DataGridView при изменении размеров формы
            CenterDataGrid();
            AdjustMenuFontSize();
        }

        private void AdjustMenuFontSize()
        {
            // Адаптация размера шрифта в меню в зависимости от размеров формы
            float newSize = Math.Max(12, ClientSize.Width / 100); // Примерная формула для изменения размера шрифта
            ordersToolStripMenuItem.Font = new Font("Segoe UI", newSize);
        }
        private void CenterDataGrid()
        {
            // Вычисляем координаты для центрирования DataGridView
            DataGridReports.Location = new Point(
                (ClientSize.Width - DataGridReports.Width) / 2,
                (ClientSize.Height - DataGridReports.Height) / 2);
        }


        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeDataGridView_Orders();
            LoadOrders(Api.userId);
        }
    }
}
