namespace Improvement_Client
{
    partial class SupervisorViewReport
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtHeader;
        private TextBox txtText;
        private TextBox txtComment;
        private Button btnApply;
        private Button btnPhotos;
        private Button btnPrint;
        private TableLayoutPanel tableLayoutPanel;
        private CheckBox chkReportAccepted; // Новый чекбокс
        private CheckBox chkOrderAccepted; // Новый чекбокс

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
            txtComment = new TextBox();
            btnApply = new Button();
            btnPhotos = new Button();
            btnPrint = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            chkReportAccepted = new CheckBox();
            chkOrderAccepted = new CheckBox();
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
            txtHeader.ReadOnly = true;
            // 
            // txtText
            // 
            tableLayoutPanel.SetColumnSpan(txtText, 3);
            txtText.Dock = DockStyle.Fill;
            txtText.Font = new Font("Microsoft Sans Serif", 12F);
            txtText.Location = new Point(3, 53);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.ReadOnly = true;
            txtText.ScrollBars = ScrollBars.Vertical;
            txtText.Size = new Size(974, 443);
            txtText.TabIndex = 3;
            txtText.Text = "Содержание отчета";
            txtText.TextChanged += txtText_TextChanged;
            // 
            // txtComment
            // 
            tableLayoutPanel.SetColumnSpan(txtComment, 3);
            txtComment.Dock = DockStyle.Fill;
            txtComment.Font = new Font("Microsoft Sans Serif", 12F);
            txtComment.Location = new Point(3, 502);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Size = new Size(974, 143);
            txtComment.TabIndex = 4;
            txtComment.Text = "Комментарий руководителя";
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.None;
            btnApply.Font = new Font("Microsoft Sans Serif", 12F);
            btnApply.Location = new Point(637, 652);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(125, 62);
            btnApply.TabIndex = 5;
            btnApply.Text = "OK";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnPhotos
            // 
            btnPhotos.Anchor = AnchorStyles.None;
            btnPhotos.Font = new Font("Microsoft Sans Serif", 12F);
            btnPhotos.Location = new Point(217, 652);
            btnPhotos.Name = "btnPhotos";
            btnPhotos.Size = new Size(125, 62);
            btnPhotos.TabIndex = 6;
            btnPhotos.Text = "Фото";
            btnPhotos.UseVisualStyleBackColor = true;
            btnPhotos.Click += btnPhotos_Click;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.None;
            btnPrint.Font = new Font("Microsoft Sans Serif", 12F);
            btnPrint.Location = new Point(850, 652);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(125, 62);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // chkReportAccepted
            // 
            chkReportAccepted.Anchor = AnchorStyles.None;
            chkReportAccepted.AutoSize = true;
            chkReportAccepted.Font = new Font("Microsoft Sans Serif", 12F);
            chkReportAccepted.Location = new Point(580, 622);
            chkReportAccepted.Name = "chkReportAccepted";
            chkReportAccepted.Size = new Size(160, 29);
            chkReportAccepted.TabIndex = 8;
            chkReportAccepted.Text = "Принять отчет";
            chkReportAccepted.UseVisualStyleBackColor = true;
            chkReportAccepted.CheckedChanged += chkReportAccepted_CheckedChanged;
            // 
            // chkOrderAccepted
            // 
            chkOrderAccepted.Anchor = AnchorStyles.None;
            chkOrderAccepted.AutoSize = true;
            chkOrderAccepted.Font = new Font("Microsoft Sans Serif", 12F);
            chkOrderAccepted.Location = new Point(350, 622);
            chkOrderAccepted.Name = "chkOrderAccepted";
            chkOrderAccepted.Size = new Size(160, 29);
            chkOrderAccepted.TabIndex = 9;
            chkOrderAccepted.Text = "Принять поручение";
            chkOrderAccepted.UseVisualStyleBackColor = true;
            chkOrderAccepted.CheckedChanged += chkOrderAccepted_CheckedChanged;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.Controls.Add(txtHeader, 0, 0);
            tableLayoutPanel.Controls.Add(txtText, 0, 1);
            tableLayoutPanel.Controls.Add(txtComment, 0, 2);
            tableLayoutPanel.Controls.Add(btnPhotos, 0, 3);
            tableLayoutPanel.Controls.Add(btnApply, 1, 3);
            tableLayoutPanel.Controls.Add(btnPrint, 2, 3);
            tableLayoutPanel.Controls.Add(chkOrderAccepted, 1, 4); // Добавляем чекбокс "Принять поручение"
            tableLayoutPanel.Controls.Add(chkReportAccepted, 2, 4); // Добавляем чекбокс "Принять отчет"
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F)); // Новая строка для чекбоксов
            tableLayoutPanel.Size = new Size(980, 790); // Увеличиваем высоту для чекбоксов
            tableLayoutPanel.TabIndex = 0;
            // 
            // SupervisorViewReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 790); // Увеличиваем высоту формы для чекбоксов
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SupervisorViewReport";
            Text = "Просмотр отчета";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
