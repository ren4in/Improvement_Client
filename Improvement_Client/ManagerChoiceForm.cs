namespace Improvement_Client
{
    public partial class ManagerChoiceForm : Form
    {
        public ManagerChoiceForm()
        {
            InitializeComponent();
        }

        private void ManagerChoiceForm_Resize(object sender, EventArgs e)
        {
            AdjustButtonSizeAndFont();
        }

        private void AdjustButtonSizeAndFont()
        {
            // Adjust the size and font of the buttons based on the form's size
            int buttonWidth = Math.Max(200, ClientSize.Width / 2);
            int buttonHeight = Math.Max(50, ClientSize.Height / 8);

            float newSize = Math.Max(12, ClientSize.Width / 40); // Adjust this factor as needed

            btnTasks.Size = new Size(buttonWidth, buttonHeight);
            btnTasks.Font = new Font("Microsoft Sans Serif", newSize);

            btnMap.Size = new Size(buttonWidth, buttonHeight);
            btnMap.Font = new Font("Microsoft Sans Serif", newSize);

            btnSummaryReport.Size = new Size(buttonWidth, buttonHeight); // Настройка размера новой кнопки
            btnSummaryReport.Font = new Font("Microsoft Sans Serif", newSize); // Настройка шрифта новой кнопки
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            ReportsForm form2 = new ReportsForm();
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            Map form2 = new Map();
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            SummaryReportForm form2 = new SummaryReportForm(); // Создайте форму для итогового отчета
           form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна
        }
    }
}
