namespace Improvement_Client
{
    partial class SummaryReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;
        private Button btnBack;
        private Button btnPrint;
        private TableLayoutPanel tableLayoutPanelTop;
        private TableLayoutPanel tableLayoutPanelBottom;

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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // dataGridView
            // 
            this.dataGridView.Dock = DockStyle.Fill;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F);
            this.dataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Номер сотрудника", DataPropertyName = "UserId" },
                new DataGridViewTextBoxColumn { HeaderText = "ФИО сотрудника", DataPropertyName = "FullName" },
                new DataGridViewTextBoxColumn { HeaderText = "Всего поручений", DataPropertyName = "TotalOrders" },
                new DataGridViewTextBoxColumn { HeaderText = "Выполненных поручений", DataPropertyName = "CompletedOrders" },
                new DataGridViewTextBoxColumn { HeaderText = "Невыполненных поручений", DataPropertyName = "UncompletedOrders" },
                new DataGridViewTextBoxColumn { HeaderText = "Просроченных поручений", DataPropertyName = "OverdueOrders" },
                new DataGridViewButtonColumn { HeaderText = "Посмотреть", Text = "Посмотреть", UseColumnTextForButtonValue = true },
                new DataGridViewButtonColumn { HeaderText = "Печать", Text = "Печать", UseColumnTextForButtonValue = true }
            });
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 300);
            this.dataGridView.TabIndex = 0;

            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.dtpStartDate.Font = new Font("Microsoft Sans Serif", 12F);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(3, 3);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(314, 30);
            this.dtpStartDate.TabIndex = 1;

            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.dtpEndDate.Font = new Font("Microsoft Sans Serif", 12F);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(323, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(314, 30);
            this.dtpEndDate.TabIndex = 2;

            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = AnchorStyles.Right;
            this.btnGenerate.Font = new Font("Microsoft Sans Serif", 10F);
            this.btnGenerate.Location = new System.Drawing.Point(643, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(154, 34);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Сформировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);

            // 
            // btnBack
            // 
            this.btnBack.Anchor = AnchorStyles.Left;
            this.btnBack.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(103, 34);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);

            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = AnchorStyles.Right;
            this.btnPrint.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnPrint.Location = new System.Drawing.Point(694, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 34);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);

            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tableLayoutPanelTop.Controls.Add(this.dtpStartDate, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.dtpEndDate, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnGenerate, 2, 0);
            this.tableLayoutPanelTop.Dock = DockStyle.Top;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(800, 40);
            this.tableLayoutPanelTop.TabIndex = 6;

            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.ColumnCount = 2;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnPrint, 1, 0);
            this.tableLayoutPanelBottom.Dock = DockStyle.Bottom;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(800, 40);
            this.tableLayoutPanelBottom.TabIndex = 7;

            // 
            // SummaryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tableLayoutPanelBottom);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Name = "SummaryReportForm";
            this.Text = "Сводный отчет";
            this.Resize += new System.EventHandler(this.SummaryReportForm_Resize);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

    }
}
