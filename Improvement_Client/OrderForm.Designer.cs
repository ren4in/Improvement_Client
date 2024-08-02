using System;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class OrderForm : Form
    {
        private TextBox txtHeader;
        private Label lblDeadline;
        private DateTimePicker dtpDeadline;
        private MaskedTextBox txtTime;
        private TextBox txtText;
        private Button btnApply;
        private Button btnCancel;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtHeader = new TextBox();
            lblDeadline = new Label();
            dtpDeadline = new DateTimePicker();
            txtTime = new MaskedTextBox();
            txtText = new TextBox();
            btnApply = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtHeader
            // 
            txtHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHeader.Font = new Font("Microsoft Sans Serif", 12F);
            txtHeader.Location = new Point(15, 19);
            txtHeader.Margin = new Padding(4, 5, 4, 5);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(949, 35);
            txtHeader.TabIndex = 0;
            txtHeader.Text = "Заголовок";
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Font = new Font("Microsoft Sans Serif", 12F);
            lblDeadline.Location = new Point(15, 86);
            lblDeadline.Margin = new Padding(4, 0, 4, 0);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(223, 29);
            lblDeadline.TabIndex = 1;
            lblDeadline.Text = "Срок выполнения";
            // 
            // dtpDeadline
            // 
            dtpDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDeadline.CustomFormat = "dd MMM yyyyг.";
            dtpDeadline.Font = new Font("Microsoft Sans Serif", 12F);
            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.Location = new Point(15, 130);
            dtpDeadline.Margin = new Padding(4, 5, 4, 5);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(949, 35);
            dtpDeadline.TabIndex = 2;
            dtpDeadline.ValueChanged += dtpDeadline_ValueChanged;
            // 
            // txtTime
            // 
            txtTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTime.Font = new Font("Microsoft Sans Serif", 12F);
            txtTime.Location = new Point(15, 180);
            txtTime.Margin = new Padding(4, 5, 4, 5);
            txtTime.Mask = "00:00";
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(949, 35);
            txtTime.TabIndex = 3;
            txtTime.Text = "0000";
            txtTime.ValidatingType = typeof(DateTime);
            // 
            // txtText
            // 
            txtText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtText.Font = new Font("Microsoft Sans Serif", 12F);
            txtText.Location = new Point(15, 235);
            txtText.Margin = new Padding(4, 5, 4, 5);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.ScrollBars = ScrollBars.Vertical;
            txtText.Size = new Size(949, 355);
            txtText.TabIndex = 4;
            txtText.Text = "Содержание поручения";
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApply.Font = new Font("Microsoft Sans Serif", 12F);
            btnApply.Location = new Point(840, 602);
            btnApply.Margin = new Padding(4, 5, 4, 5);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(125, 62);
            btnApply.TabIndex = 5;
            btnApply.Text = "OK";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancel.Location = new Point(15, 602);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 62);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 689);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(txtText);
            Controls.Add(txtTime);
            Controls.Add(dtpDeadline);
            Controls.Add(lblDeadline);
            Controls.Add(txtHeader);
            Margin = new Padding(4, 5, 4, 5);
            Name = "OrderForm";
            Text = "OrderForm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
