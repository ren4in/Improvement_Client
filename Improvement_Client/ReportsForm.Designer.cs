namespace Improvement_Client
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem registrationToolStripMenuItem;
        private MenuStrip menuStrip1;
        private DataGridView DataGridReports;
        private ToolStripTextBox searchTextBox;
        private ToolStripButton searchButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            usersToolStripMenuItem = new ToolStripMenuItem();
            registrationToolStripMenuItem = new ToolStripMenuItem();
            searchTextBox = new ToolStripTextBox();
            searchButton = new ToolStripButton();
            DataGridReports = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridReports).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Blue;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { usersToolStripMenuItem, registrationToolStripMenuItem,   });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1778, 51);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            usersToolStripMenuItem.ForeColor = Color.White;
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(212, 47);
            usersToolStripMenuItem.Text = "Пользователи";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // registrationToolStripMenuItem
            // 
            registrationToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            registrationToolStripMenuItem.ForeColor = Color.White;
            registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            registrationToolStripMenuItem.Size = new Size(192, 47);
            registrationToolStripMenuItem.Text = "Регистрация";
            registrationToolStripMenuItem.Click += registrationToolStripMenuItem_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Alignment = ToolStripItemAlignment.Right;
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(200, 47);
            searchTextBox.Visible = false;
            searchTextBox.KeyDown += SearchTextBox_KeyDown;
            searchTextBox.Click += searchTextBox_Click;
            // 
            // searchButton
            // 
            searchButton.Alignment = ToolStripItemAlignment.Right;
            searchButton.BackColor = Color.White;
            searchButton.Font = new Font("Segoe UI", 14F);
            searchButton.ForeColor = Color.Black;
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(100, 42);
            searchButton.Text = "Поиск";
            searchButton.Click += OnSearchButtonClick;
            // 
            // DataGridReports
            // 
            DataGridReports.AllowUserToAddRows = false;
            DataGridReports.AllowUserToDeleteRows = false;
            DataGridReports.AllowUserToResizeRows = false;
            DataGridReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridReports.BackgroundColor = Color.White;
            DataGridReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightCyan;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGridReports.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridReports.Dock = DockStyle.Fill;
            DataGridReports.Location = new Point(0, 51);
            DataGridReports.Name = "DataGridReports";
            DataGridReports.ReadOnly = true;
            DataGridReports.RowHeadersWidth = 62;
            DataGridReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridReports.Size = new Size(1778, 853);
            DataGridReports.TabIndex = 1;
            DataGridReports.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 904);
            Controls.Add(DataGridReports);
            Controls.Add(menuStrip1);
            Name = "ReportsForm";
            Text = "Отчеты";
            WindowState = FormWindowState.Maximized;
            Resize += ReportsForm_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
