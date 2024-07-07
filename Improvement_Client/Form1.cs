using Improvement_API.db;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadReports();


        }


        private void YourForm_Resize(object sender, EventArgs e)
        {
            // Вызываем метод для центрирования DataGridView при изменении размеров формы
            CenterDataGrid();
        }

        private void CenterDataGrid()
        {
            // Вычисляем координаты для центрирования DataGridView
            DataGridReports.Location = new Point(
                (ClientSize.Width - DataGridReports.Width) / 2,
                (ClientSize.Height - DataGridReports.Height) / 2);
        }

        private void InitializeDataGridView()
        {

 
            //DataGridReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            DataGridReports.AutoGenerateColumns = false;

            // Создаем и добавляем столбцы с настраиваемыми заголовками
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();

         
             
            idColumn.Name = "UserFirstName";
            idColumn.HeaderText = "Имя";
          //  idColumn.DataPropertyName = "IdUserNavigation.FirstName";
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
            textColumn.HeaderText = "Содержане";
            textColumn.DataPropertyName = "Text";
            DataGridReports.Columns.Add(textColumn);


            DataGridViewCheckBoxColumn acceptedColumn = new DataGridViewCheckBoxColumn();
            acceptedColumn.Name = "Accepted";
            acceptedColumn.HeaderText = "Принят";
            acceptedColumn.DataPropertyName = "Accepted"; // Связь с полем данных
            DataGridReports.Columns.Add(acceptedColumn);

            // Добавление первого DataGridViewButtonColumn
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "ShowName";
            buttonColumn1.HeaderText = "Show Name";
            buttonColumn1.Text = "Show Name";
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
            DataGridReports.CellFormatting += DataGridReports_CellFormatting;

           CenterDataGrid();
        }

       

        private void DataGridReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && allreports != null && allreports.Count > e.RowIndex)
            {
                var report = allreports[e.RowIndex];

                if (DataGridReports.Columns[e.ColumnIndex].Name == "UserFirstName")
                {
                    e.Value = report.id_UserNavigation?.FirstName ?? string.Empty;
                }
                else if (DataGridReports.Columns[e.ColumnIndex].Name == "UserLastName")
                    e.Value = report.id_UserNavigation?.LastName ?? string.Empty;
                {
                }
            }
        }   

        private List<Report> allreports;
        public async void LoadReports()
        {

            HttpResponseMessage response = await Api.client.GetAsync(Api.APP_PATH + "/api/Reports");

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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Проверка, что клик был по кнопке и строка валидная
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == DataGridReports.Columns["ShowName"].Index)
                {
                    // Получение значения поля Name из текущей строки
                    Report selectedReport = allreports[e.RowIndex];
                    MessageBox.Show(selectedReport.id_Report + "Report Name", "жопа",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.ColumnIndex == DataGridReports.Columns["ShowDate"].Index)
                {
                    // Получение значения поля Date из текущей строки
                    var date = DataGridReports.Rows[e.RowIndex].Cells["Accepted"].Value.ToString();
                    MessageBox.Show(date, "Report Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}



