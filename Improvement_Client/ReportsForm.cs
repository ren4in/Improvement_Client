using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            InitializeDataGridView_Users();
            LoadUsers();


        }
        public ReportsForm(User _selectedUser)
        {
            InitializeComponent();
            InitializeDataGridView_Orders();
            LoadOrders(_selectedUser.id_User);
            selectedUser = _selectedUser;


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
            usersToolStripMenuItem.Font = new Font("Segoe UI", newSize);
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
            // Обработка нажатия на кнопку "Пользователи"
            RegistrationForm form = new RegistrationForm(null);

            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

            // Здесь можно добавить код для открытия формы с пользователями или другую нужную логику
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Обработка нажатия на кнопку "Пользователи"
            InitializeDataGridView_Users();
            LoadUsers();
            // Здесь можно добавить код для открытия формы с пользователями или другую нужную логику
        }


        private void InitializeDataGridView_Users()
        {
            DataGridReports.CellFormatting -= DataGridReports_CellFormattingRole;
            DataGridReports.DataSource = null;

            DataGridReports.Columns.Clear();
            DataGridReports.Rows.Clear();

            //DataGridReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            DataGridReports.AutoGenerateColumns = false;

            // Создаем и добавляем столбцы с настраиваемыми заголовками
            DataGridViewTextBoxColumn LastNameColumn = new DataGridViewTextBoxColumn();



            LastNameColumn.Name = "UserLastName";
            LastNameColumn.HeaderText = "Фамилия";
            LastNameColumn.DataPropertyName = "Lastname";
            DataGridReports.Columns.Add(LastNameColumn);

            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();

            firstNameColumn.Name = "UserFirstName";
            firstNameColumn.HeaderText = "Имя";
            firstNameColumn.DataPropertyName = "Firstname";
            DataGridReports.Columns.Add(firstNameColumn);

            DataGridViewTextBoxColumn MiddleNameColumn = new DataGridViewTextBoxColumn();


            MiddleNameColumn.Name = "UserMiddleName";
            MiddleNameColumn.HeaderText = "Отчество";
            MiddleNameColumn.DataPropertyName = "Middlename";
            DataGridReports.Columns.Add(MiddleNameColumn);


            DataGridViewTextBoxColumn PhoneColumn = new DataGridViewTextBoxColumn();


            PhoneColumn.Name = "UserPhone";
            PhoneColumn.HeaderText = "Телефон";
            PhoneColumn.DataPropertyName = "Phone";
            DataGridReports.Columns.Add(PhoneColumn);




            DataGridViewTextBoxColumn LoginColumn = new DataGridViewTextBoxColumn();


            LoginColumn.Name = "UserLogin";
            LoginColumn.HeaderText = "Логин";
            LoginColumn.DataPropertyName = "Login";
            DataGridReports.Columns.Add(LoginColumn);

            DataGridViewTextBoxColumn RoleColumn = new DataGridViewTextBoxColumn();


            RoleColumn.Name = "UserRole";
            RoleColumn.HeaderText = "Роль";
            RoleColumn.DataPropertyName = "id_RoleNavigation.Name";
            DataGridReports.Columns.Add(RoleColumn);



            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "OrdersButton";
            buttonColumn1.HeaderText = "Поручения";
            buttonColumn1.Text = "Поручения";
            buttonColumn1.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            // Добавление второго DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "EditButton";
            buttonColumn2.HeaderText = "Редактировать";
            buttonColumn2.Text = "Редактировать";
            buttonColumn2.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.Name = "DelButton";
            buttonColumn3.HeaderText = "Удалить";
            buttonColumn3.Text = "Удалить";
            buttonColumn3.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridViewButtonColumn buttonColumn4 = new DataGridViewButtonColumn();
            buttonColumn4.Name = "NewOrderButton";
            buttonColumn4.HeaderText = "Новое поручение";
            buttonColumn4.Text = "Новое поручение";
            buttonColumn4.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк



            DataGridReports.Columns.Add(buttonColumn1);
            DataGridReports.Columns.Add(buttonColumn2);
            DataGridReports.Columns.Add(buttonColumn3);
            DataGridReports.Columns.Add(buttonColumn4);
            // DataGridReports.CellClick += DataGridView1_CellClick;
            DataGridReports.CellFormatting += DataGridReports_CellFormattingRole;

            CenterDataGrid();
        }


        private void InitializeDataGridView_Orders()
        {

            DataGridReports.CellFormatting -= DataGridReports_CellFormattingRole;
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
            acceptedColumn.ReadOnly = false;
            DataGridReports.Columns.Add(acceptedColumn);

            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "ReportsButton";
            buttonColumn1.HeaderText = "Отчеты";
            buttonColumn1.Text = "Отчеты";
            buttonColumn1.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            // Добавление второго DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "DeleteOrderButton";
            buttonColumn2.HeaderText = "Удалить";
            buttonColumn2.Text = "Удалить";
            buttonColumn2.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк


            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.Name = "EditOrderButton";
            buttonColumn3.HeaderText = "Редактировать";
            buttonColumn3.Text = "Редактировать";
            buttonColumn3.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridReports.Columns.Add(buttonColumn1);
            DataGridReports.Columns.Add(buttonColumn2);
            DataGridReports.Columns.Add(buttonColumn3);


            // DataGridReports.CellClick += DataGridView1_CellClick;
            DataGridReports.CellFormatting += DataGridReports_CellFormattingSupervisor;

            CenterDataGrid();
        }

        private List<Order> allOrders;
        public async void LoadOrders(int? thisUser)
        {
            HttpResponseMessage response = await   Api.client.GetAsync(Api.APP_PATH + "/api/Orders/user/" + thisUser);

            if (response.IsSuccessStatusCode)
            {
                var ordersJson = await response.Content.ReadAsStringAsync();
                allOrders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);
                DataGridReports.DataSource = allOrders;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }
        private void InitializeDataGridView_Reports()
        {

            DataGridReports.CellFormatting -= DataGridReports_CellFormattingRole;
            DataGridReports.DataSource = null;

            DataGridReports.Columns.Clear();
            DataGridReports.Rows.Clear();


            //DataGridReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            DataGridReports.AutoGenerateColumns = false;

            // Создаем и добавляем столбцы с настраиваемыми заголовками
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();



            idColumn.Name = "UserFirstName";
            idColumn.HeaderText = "Имя";
            idColumn.DataPropertyName = "IdUserNavigation.FirstName";
            DataGridReports.Columns.Add(idColumn);


            DataGridViewTextBoxColumn startDateColumn = new DataGridViewTextBoxColumn();


            startDateColumn.Name = "Start_date";
            startDateColumn.HeaderText = "Дата начала";
            startDateColumn.DataPropertyName = "Start_Date";
            DataGridReports.Columns.Add(startDateColumn);

            DataGridViewTextBoxColumn finalDateColumn = new DataGridViewTextBoxColumn();


            finalDateColumn.Name = "Final_date";
            finalDateColumn.HeaderText = "Дата конца";
            finalDateColumn.DataPropertyName = "Final_Date";
            DataGridReports.Columns.Add(finalDateColumn);

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
            acceptedColumn.Name = "Accepted";
            acceptedColumn.HeaderText = "Принят";
            acceptedColumn.DataPropertyName = "Accepted"; // Связь с полем данных
            acceptedColumn.ReadOnly = false;
            DataGridReports.Columns.Add(acceptedColumn);

            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "J";
            buttonColumn1.HeaderText = "placeholder";
            buttonColumn1.Text = "placeholder";
            buttonColumn1.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            // Добавление второго DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "ShowDate";
            buttonColumn2.HeaderText = "Show Date";
            buttonColumn2.Text = "Show Date";
            buttonColumn2.UseColumnTextForButtonValue = true; // Использовать текст кнопки для всех строк

            DataGridReports.Columns.Add(buttonColumn1);
            DataGridReports.Columns.Add(buttonColumn2);
            // DataGridReports.CellClick += DataGridView1_CellClick;
            DataGridReports.CellFormatting += DataGridReports_CellFormattingUser;

            CenterDataGrid();
        }

        private void DataGridReports_CellFormattingRole(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && allusers != null && allusers.Count > e.RowIndex)
            {
                var user = allusers[e.RowIndex];

                if (DataGridReports.Columns[e.ColumnIndex].Name == "UserRole")
                {
                    e.Value = user.id_RoleNavigation?.Name ?? string.Empty;
                }
            }
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


        private void DataGridReports_CellFormattingUser(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && allreports != null && allreports.Count > e.RowIndex)
            {
                var report = allreports[e.RowIndex];

                if (DataGridReports.Columns[e.ColumnIndex].Name == "UserFirstName")
                {
                    e.Value = report.id_OrderNavigation.id_ExecutorNavigation?.FirstName ?? string.Empty;
                }
                else if (DataGridReports.Columns[e.ColumnIndex].Name == "UserLastName")
                    e.Value = report.id_OrderNavigation.id_ExecutorNavigation?.LastName ?? string.Empty;
                {
                }
            }
        }

        private List<User> allusers;

        public async void LoadUsers()
        {

            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/Users");

            if (response.IsSuccessStatusCode)
            {
                var usersJson = await response.Content.ReadAsStringAsync();
                allusers = JsonConvert.DeserializeObject<List<User>>(usersJson);
                DataGridReports.DataSource = allusers;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }

        }

        private List<Report> allreports;


        public async void LoadReports(int thisUser)
        {

            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/Reports/user/" + thisUser);

            if (response.IsSuccessStatusCode)
            {
                var reportsJson = await response.Content.ReadAsStringAsync();
                allreports = JsonConvert.DeserializeObject<List<Report>>(reportsJson);
                DataGridReports.DataSource = allreports;

            }
            else
            {
                MessageBox.Show("Ошибка сервера!");
            }

        }

        User selectedUser;

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "OrdersButton")
                {
                    // Проверяем, что allusers не является null и e.RowIndex в пределах массива
                    if (allusers != null && e.RowIndex < allusers.Count)
                    {
                        selectedUser = allusers[e.RowIndex];
                        InitializeDataGridView_Orders();
                        LoadOrders((int)selectedUser.id_User);

                    }
                    else
                    {
                        MessageBox.Show("Ошибка загрузки поручений: данные о пользователе не найдены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    selectedUser = allusers[e.RowIndex];

                    RegistrationForm form = new RegistrationForm(selectedUser);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна





                }


                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "EditOrderButton")
                {
                Order    selectedOrder = allOrders[e.RowIndex];

                    OrderForm form = new OrderForm(selectedOrder);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна





                }


                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "DeleteOrderButton")
                {
                    DialogResult result = MessageBox.Show("Вы точно хотите удалить это поручение?", "Удаление поручения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Проверяем выбранный пользователем ответ
                    if (result == DialogResult.Yes)
                    {

                        Order selectedOrder = allOrders[e.RowIndex];

                        HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/orders/" + selectedOrder.id_Order);

                        if (response.IsSuccessStatusCode)
                        {
                            // Успешно удалено
                            MessageBox.Show("Поручение успешно удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //   InitializeDataGridView_Users();
                            LoadOrders(selectedUser.id_User);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении поручения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }


                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "NewOrderButton")
                {
                    User selectedUser = allusers[e.RowIndex];


                    OrderForm form = new OrderForm(selectedUser);

                    form.Show();
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна



                }



                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewButtonColumn && DataGridReports.Columns[e.ColumnIndex].Name == "DelButton")
                {
                    DialogResult result = MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Проверяем выбранный пользователем ответ
                    if (result == DialogResult.Yes)
                    {

                        selectedUser = allusers[e.RowIndex];

                        HttpResponseMessage response = await Api.client.DeleteAsync(Api.APP_PATH + "/api/Users/" + selectedUser.id_User);
                        if (response.IsSuccessStatusCode)
                        {
                            // Успешно удалено
                            MessageBox.Show("Пользователь успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //   InitializeDataGridView_Users();
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }


                else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && DataGridReports.Columns[e.ColumnIndex].Name == "AcceptedOrder")
                {
                    var cellAcceptOrder = DataGridReports.Rows[e.RowIndex].Cells["AcceptedOrder"] as DataGridViewCheckBoxCell;
                    if (cellAcceptOrder != null)
                    {
                        bool isChecked = (bool)cellAcceptOrder.Value;
                        Order selectedOrder = allOrders[e.RowIndex];

                        cellAcceptOrder.Value = !isChecked; // Изменяем состояние чекбокса на противоположное
                        HttpResponseMessage response = await Api.client.PostAsync(Api.APP_PATH + $"/api/Orders/ToggleAccepted/{selectedOrder.id_Order}", null);

                    }


                    else if (DataGridReports.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && DataGridReports.Columns[e.ColumnIndex].Name == "AcceptedReport")
                    {
                        var cellAcceptReport = DataGridReports.Rows[e.RowIndex].Cells["Accepted"] as DataGridViewCheckBoxCell;
                        if (cellAcceptReport != null)
                        {
                            bool isChecked = (bool)cellAcceptReport.Value;
                            Report selectedReport = allreports[e.RowIndex];

                            cellAcceptReport.Value = !isChecked; // Изменяем состояние чекбокса на противоположное
                            HttpResponseMessage response = await Api.client.PostAsync(Api.APP_PATH + $"/api/Reports/ToggleAccepted/{selectedReport.id_Report}", null);

                        }
                    }
                }
            }
        }
    }


}
