namespace Improvement_Client
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelFirstName;
        private TextBox textBoxFirstName;
        private Label labelMiddleName;
        private TextBox textBoxMiddleName;
        private Label labelPhoneNumber;
        private TextBox textBoxPhoneNumber;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private CheckBox checkBoxAdminRights;
        private Button buttonRegister;

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
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelMiddleName = new Label();
            textBoxMiddleName = new TextBox();
            labelPhoneNumber = new Label();
            textBoxPhoneNumber = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            checkBoxAdminRights = new CheckBox();
            buttonRegister = new Button();
            SuspendLayout();
            // 
            // labelLastName
            // 
            labelLastName.Location = new Point(0, 0);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(100, 23);
            labelLastName.TabIndex = 13;
            labelLastName.Text = "Фамилия:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(0, 0);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(100, 31);
            textBoxLastName.TabIndex = 12;
            // 
            // labelFirstName
            // 
            labelFirstName.Location = new Point(0, 0);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(100, 23);
            labelFirstName.TabIndex = 11;
            labelFirstName.Text = "Имя:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(0, 0);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(100, 31);
            textBoxFirstName.TabIndex = 10;
            // 
            // labelMiddleName
            // 
            labelMiddleName.Location = new Point(0, 0);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(100, 23);
            labelMiddleName.TabIndex = 9;
            labelMiddleName.Text = "Отчество:";
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(0, 0);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(100, 31);
            textBoxMiddleName.TabIndex = 8;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.Location = new Point(0, 0);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(100, 23);
            labelPhoneNumber.TabIndex = 7;
            labelPhoneNumber.Text = "Номер Телефона:";
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Location = new Point(0, 0);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(100, 31);
            textBoxPhoneNumber.TabIndex = 6;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(0, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "E-Mail:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(0, 0);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 31);
            textBoxEmail.TabIndex = 4;
            // 
            // labelPassword
            // 
            labelPassword.Location = new Point(0, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 23);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(0, 0);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(100, 31);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // checkBoxAdminRights
            // 
            checkBoxAdminRights.Location = new Point(0, 0);
            checkBoxAdminRights.Name = "checkBoxAdminRights";
            checkBoxAdminRights.Size = new Size(104, 24);
            checkBoxAdminRights.TabIndex = 1;
            checkBoxAdminRights.Text = "Права администратора";
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(0, 0);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(75, 23);
            buttonRegister.TabIndex = 0;
            buttonRegister.Text = "Регистрация";
            buttonRegister.Click += buttonRegister_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRegister);
            Controls.Add(checkBoxAdminRights);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(labelPhoneNumber);
            Controls.Add(textBoxMiddleName);
            Controls.Add(labelMiddleName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxLastName);
            Controls.Add(labelLastName);
            Name = "RegistrationForm";
            Text = "Форма Регистрации";
            WindowState = FormWindowState.Maximized;
            Load += RegistrationForm_Load;
            Resize += RegistrationForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}