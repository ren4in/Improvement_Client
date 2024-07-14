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
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelMiddleName = new System.Windows.Forms.Label();
            this.textBoxMiddleName = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxAdminRights = new System.Windows.Forms.CheckBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLastName
            // 
            this.labelLastName.Text = "Фамилия:";
            // 
            // textBoxLastName
            // 
            // 
            // labelFirstName
            // 
            this.labelFirstName.Text = "Имя:";
            // 
            // textBoxFirstName
            // 
            // 
            // labelMiddleName
            // 
            this.labelMiddleName.Text = "Отчество:";
            // 
            // textBoxMiddleName
            // 
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.Text = "Номер Телефона:";
            // 
            // textBoxPhoneNumber
            // 
            // 
            // labelEmail
            // 
            this.labelEmail.Text = "E-Mail:";
            // 
            // textBoxEmail
            // 
            // 
            // labelPassword
            // 
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            this.textBoxPassword.UseSystemPasswordChar = true;

            // 
            // 
            // checkBoxAdminRights
            // 
            this.checkBoxAdminRights.Text = "Права администратора";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.checkBoxAdminRights);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.textBoxMiddleName);
            this.Controls.Add(this.labelMiddleName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Name = "RegistrationForm";
            this.Text = "Форма Регистрации";
            this.Resize += new System.EventHandler(this.RegistrationForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();
            buttonRegister.Click += buttonRegister_Click;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}