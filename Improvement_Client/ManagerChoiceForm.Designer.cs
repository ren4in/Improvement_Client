namespace Improvement_Client
{
    partial class ManagerChoiceForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTasks;
        private Button btnMap;
        private Button btnSummaryReport; // Новая кнопка
        private TableLayoutPanel tableLayoutPanel;

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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnSummaryReport = new System.Windows.Forms.Button(); // Инициализация новой кнопки
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.btnTasks, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnSummaryReport, 0, 1); // Добавление новой кнопки
            this.tableLayoutPanel.Controls.Add(this.btnMap, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnTasks
            // 
            this.btnTasks.Anchor = AnchorStyles.None;
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTasks.Location = new System.Drawing.Point(200, 30);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(400, 50);
            this.btnTasks.TabIndex = 0;
            this.btnTasks.Text = "Поручения";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnSummaryReport
            // 
            this.btnSummaryReport.Anchor = AnchorStyles.None;
            this.btnSummaryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSummaryReport.Location = new System.Drawing.Point(200, 180); // Позиция по вертикали для новой кнопки
            this.btnSummaryReport.Name = "btnSummaryReport";
            this.btnSummaryReport.Size = new System.Drawing.Size(400, 50);
            this.btnSummaryReport.TabIndex = 2;
            this.btnSummaryReport.Text = "Итоговый отчет";
            this.btnSummaryReport.UseVisualStyleBackColor = true;
            this.btnSummaryReport.Click += new System.EventHandler(this.btnSummaryReport_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = AnchorStyles.None;
            this.btnMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMap.Location = new System.Drawing.Point(200, 330);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(400, 50);
            this.btnMap.TabIndex = 1;
            this.btnMap.Text = "Карта";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // ManagerChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ManagerChoiceForm";
            this.Text = "ManagerChoiceForm";
            this.Resize += new System.EventHandler(this.ManagerChoiceForm_Resize);
            this.ResumeLayout(false);

        }
    }
}
