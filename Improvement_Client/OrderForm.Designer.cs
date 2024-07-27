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
            this.txtHeader = new TextBox();
            this.lblDeadline = new Label();
            this.dtpDeadline = new DateTimePicker();
            this.txtTime = new MaskedTextBox();
            this.txtText = new TextBox();
            this.btnApply = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // 
            // txtHeader
            // 
            this.txtHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHeader.Location = new System.Drawing.Point(15, 19);
            this.txtHeader.Margin = new Padding(4, 5, 4, 5);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(949, 35);
            this.txtHeader.TabIndex = 0;
            this.txtHeader.Text = "Заголовок";

            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDeadline.Location = new System.Drawing.Point(15, 86);
            this.lblDeadline.Margin = new Padding(4, 0, 4, 0);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(223, 29);
            this.lblDeadline.TabIndex = 1;
            this.lblDeadline.Text = "Срок выполнения";

            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dtpDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDeadline.Location = new System.Drawing.Point(15, 130);
            this.dtpDeadline.Margin = new Padding(4, 5, 4, 5);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(949, 35);
            this.dtpDeadline.TabIndex = 2;
            this.dtpDeadline.CustomFormat = "dd MMM yyyyг."; // Установка формата с датой
            this.dtpDeadline.Format = DateTimePickerFormat.Custom;

            //
            // txtTime
            //
            this.txtTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTime.Font = new Font("Microsoft Sans Serif", 12F);
            this.txtTime.Location = new Point(15, 180);
            this.txtTime.Margin = new Padding(4, 5, 4, 5);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new Size(949, 35);
            this.txtTime.TabIndex = 3;
            this.txtTime.Mask = "00:00"; // Маска для ввода времени
            this.txtTime.ValidatingType = typeof(DateTime); // Указывает тип данных для валидации
            this.txtTime.Text = "00:00"; // Начальное значение

            // 
            // txtText
            // 
            this.txtText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtText.Location = new System.Drawing.Point(15, 235);
            this.txtText.Margin = new Padding(4, 5, 4, 5);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(949, 355);
            this.txtText.TabIndex = 4;
            this.txtText.Text = "Содержание поручения";

            // 
            // btnApply
            // 
            this.btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnApply.Location = new System.Drawing.Point(840, 602);
            this.btnApply.Margin = new Padding(4, 5, 4, 5);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(125, 62);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "OK";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new EventHandler(this.btnApply_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(15, 602);
            this.btnCancel.Margin = new Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 62);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 689);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.txtHeader);
            this.Margin = new Padding(4, 5, 4, 5);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

   
    }
}
