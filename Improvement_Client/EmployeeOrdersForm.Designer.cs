namespace Improvement_Client
{
    partial class EmployeeOrdersForm
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
        private TextBox txtHeader;
        private Label lblDeadline;
        private TextBox dtpDeadline;
        private TextBox txtText;
        private Button btnReport;
        private Button btnBack;
        private void InitializeComponent()
        {
            this.txtHeader = new TextBox();
            this.lblDeadline = new Label();
            this.dtpDeadline = new TextBox();
            this.txtText = new TextBox();
            this.btnReport = new Button();
            this.btnBack = new Button();
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
            this.txtHeader.ReadOnly = true;
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
            this.dtpDeadline.ReadOnly = true;

            // 
            // txtText
            // 
            this.txtText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtText.Location = new System.Drawing.Point(15, 202);
            this.txtText.Margin = new Padding(4, 5, 4, 5);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(949, 388);
            this.txtText.TabIndex = 3;
            this.txtText.Text = "Содержание поручения";
            this.txtText.ReadOnly = true;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnReport.Location = new System.Drawing.Point(840, 602);
            this.btnReport.Margin = new Padding(4, 5, 4, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 62);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "OK";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new EventHandler(this.btnReport_Click);

            // 
            // btnBack
            // 
            this.btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBack.Location = new System.Drawing.Point(15, 602);
            this.btnBack.Margin = new Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 62);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 689);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.txtHeader);
            this.Margin = new Padding(4, 5, 4, 5);
            this.Name = "EmployeeOrdersForm";
            this.Text = "EmployeeOrdersForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    
    }
}

