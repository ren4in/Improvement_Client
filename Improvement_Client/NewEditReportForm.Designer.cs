namespace Improvement_Client
{
    partial class NewEditReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtHeader;
        private TextBox txtText;
        private Button btnApply;
        private Button btnBack;
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
            txtHeader = new TextBox();
            txtText = new TextBox();
            btnApply = new Button();
            btnBack = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtHeader
            // 
            tableLayoutPanel.SetColumnSpan(txtHeader, 3);
            txtHeader.Dock = DockStyle.Fill;
            txtHeader.Font = new Font("Microsoft Sans Serif", 12F);
            txtHeader.Location = new Point(3, 3);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(974, 35);
            txtHeader.TabIndex = 0;
            txtHeader.Text = "Заголовок";
            // 
            // txtText
            // 
            tableLayoutPanel.SetColumnSpan(txtText, 3);
            txtText.Dock = DockStyle.Fill;
            txtText.Font = new Font("Microsoft Sans Serif", 12F);
            txtText.Location = new Point(3, 53);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.ScrollBars = ScrollBars.Vertical;
            txtText.Size = new Size(974, 563);
            txtText.TabIndex = 3;
            txtText.Text = "Содержание отчета";
            txtText.TextChanged += txtText_TextChanged_2;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.None;
            btnApply.Font = new Font("Microsoft Sans Serif", 12F);
            btnApply.Location = new Point(753, 623);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(125, 62);
            btnApply.TabIndex = 4;
            btnApply.Text = "OK";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.None;
            btnBack.Font = new Font("Microsoft Sans Serif", 12F);
            btnBack.Location = new Point(100, 623);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(125, 62);
            btnBack.TabIndex = 5;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
           
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.Controls.Add(txtHeader, 0, 0);
            tableLayoutPanel.Controls.Add(txtText, 0, 1);
            tableLayoutPanel.Controls.Add(btnBack, 0, 2);
            tableLayoutPanel.Controls.Add(btnApply, 2, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.Size = new Size(980, 689);
            tableLayoutPanel.TabIndex = 0;
            // 
            // NewEditReportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 689);
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "NewEditReportForm";
            Text = "EmployeeOrdersForm";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
