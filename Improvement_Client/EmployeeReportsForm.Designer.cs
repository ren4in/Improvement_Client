
namespace Improvement_Client
{
    partial class EmployeeReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem registrationToolStripMenuItem;
        private MenuStrip menuStrip1;
        private DataGridView DataGridReports;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.Text = "EmployeeReportsForm";
          
                this.components = new System.ComponentModel.Container();
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.DataGridReports = new System.Windows.Forms.DataGridView();
                ((System.ComponentModel.ISupportInitialize)(this.DataGridReports)).BeginInit();
                this.SuspendLayout();
                // 
                // menuStrip1
                // 
                this.menuStrip1.BackColor = System.Drawing.Color.Blue; // Цвет меню
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordersToolStripMenuItem,
            this.registrationToolStripMenuItem});
                this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                this.menuStrip1.Name = "menuStrip1";
                this.menuStrip1.Size = new System.Drawing.Size(1778, 40); // Высота меню
                this.menuStrip1.TabIndex = 0;
                this.menuStrip1.Text = "menuStrip1";
                // 
                // ordersToolStripMenuItem
                // 
                this.ordersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F); // Увеличение размера шрифта
                this.ordersToolStripMenuItem.ForeColor = System.Drawing.Color.White; // Цвет текста
                this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
                this.ordersToolStripMenuItem.Size = new System.Drawing.Size(180, 36); // Размер кнопки
                this.ordersToolStripMenuItem.Text = "Поручения";
                this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
                // 
                // registrationToolStripMenuItem

                this.registrationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F); // Увеличение размера шрифта
                this.registrationToolStripMenuItem.ForeColor = System.Drawing.Color.White; // Цвет текста
                this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
                this.registrationToolStripMenuItem.Size = new System.Drawing.Size(180, 36); // Размер кнопки
                this.registrationToolStripMenuItem.Text = "Регистрация";
                this.registrationToolStripMenuItem.Click += new System.EventHandler(this.registrationToolStripMenuItem_Click);
                // 
                // DataGridReports
                // 
                this.DataGridReports.AllowUserToAddRows = false;
                this.DataGridReports.AllowUserToDeleteRows = false;
                this.DataGridReports.AllowUserToResizeRows = false;
                this.DataGridReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.DataGridReports.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                this.DataGridReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.DataGridReports.Location = new System.Drawing.Point(20, 60); // Позиция и размер DataGridView
                this.DataGridReports.Name = "DataGridReports";
                this.DataGridReports.RowHeadersWidth = 62;
                this.DataGridReports.BackgroundColor = System.Drawing.Color.White; // Цвет фона DataGridView
                this.DataGridReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
                this.DataGridReports.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow; // Цвет ячеек
                this.DataGridReports.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F); // Увеличение размера шрифта в ячейках
                this.DataGridReports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); // Увеличение размера шрифта в заголовках столбцов
                this.DataGridReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewButtonColumn(),
                new System.Windows.Forms.DataGridViewButtonColumn()
            });
                this.DataGridReports.Dock = System.Windows.Forms.DockStyle.Fill; // Занимать всё доступное пространство
                this.DataGridReports.TabIndex = 1;
                this.DataGridReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                this.DataGridReports.ReadOnly = true; // Запрет редактирования ячеек
                this.DataGridReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Выделение всей строки
                                                                                                                   // 
                                                                                                                   // ReportsForm
                                                                                                                   // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1778, 904);
                this.Controls.Add(this.DataGridReports);
                this.Controls.Add(this.menuStrip1);

                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Resize += new System.EventHandler(this.ReportsForm_Resize); // Обработчик изменения размеров формы
                ((System.ComponentModel.ISupportInitialize)(this.DataGridReports)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

                this.menuStrip1.ResumeLayout(false);
                this.menuStrip1.PerformLayout();
            }

         

        #endregion
    }    }
