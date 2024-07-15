using Improvement_API.db;
using MebelMag;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Improvement_Client
{
    

    public partial class RegistrationForm : Form
    {
        private User _currentuser = new User();
        public RegistrationForm(User _selectedUser)
        {
            InitializeComponent();
            if (_selectedUser != null)
            {
                _currentuser = _selectedUser;
              textBoxFirstName.Text= _currentuser.FirstName;
              textBoxLastName.Text= _currentuser.LastName;
                textBoxMiddleName.Text = _currentuser.MiddleName;
                textBoxPhoneNumber.Text = _currentuser.Phone;
                textBoxEmail.Text = _currentuser.Login;
                if (_currentuser.id_Role == 1)
                    checkBoxAdminRights.Checked = true;
                else
                    checkBoxAdminRights.Checked = false;

            }
            

            }

            private void RegistrationForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }
        StringBuilder errors = new StringBuilder();

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
                errors.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
                errors.AppendLine("Введите фамилию!");
            if (string.IsNullOrWhiteSpace(textBoxMiddleName.Text))
                errors.AppendLine("Введите отчество!");
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                errors.AppendLine("Введите E-Mail!");
            if (string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text))
                errors.AppendLine("Введите номер телефона!");
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text) && _currentuser.id_User == null)
                errors.AppendLine("Введите пароль!");
            if (Check.CheckEmail(textBoxEmail.Text) == false)
                errors.AppendLine("Адрес электронной почты не соответствует формату!");
            if (Check.CheckPhone(textBoxPhoneNumber.Text) == false)
                errors.AppendLine("Номер телефона не соответствует формату!");
            if(!string.IsNullOrWhiteSpace(textBoxPassword.Text))
            if (Check.CheckPassword(textBoxPassword.Text) == false && _currentuser.id_User==null )
                errors.AppendLine("Пароль должен состоять минимум из 8 латинских букв и цифр, из них как минимум одна прописная и одна строчная буква и одна цифра.  ");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание");

                return;

            }
            else
            {
                
                _currentuser.FirstName = textBoxFirstName.Text;
                _currentuser.MiddleName = textBoxMiddleName.Text;
                _currentuser.LastName = textBoxLastName.Text;
                _currentuser.Phone = textBoxPhoneNumber.Text;
                _currentuser.Login = textBoxEmail.Text;
                if (!string.IsNullOrWhiteSpace(textBoxPassword.Text)) 
                _currentuser.Password = textBoxPassword.Text;
                if (checkBoxAdminRights.Checked)
                    _currentuser.id_Role = 1;
                else
                    _currentuser.id_Role = 2;
                var userJson = JsonConvert.SerializeObject(_currentuser);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                if (_currentuser.id_User == null)
                {
                     response = await Api.client.PostAsync(Api.APP_PATH + "/api/users", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Пользователь успешно добавлен");
                        ReportsForm form = new ReportsForm();

                        form.Show();
                        this.Hide();
                        form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна
                    }
                   
                }
                else
                {
                    response = await Api.client.PutAsync(Api.APP_PATH + "/api/users/" + _currentuser.id_User, content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Данные успешно изменены!");
                        ReportsForm form = new ReportsForm();

                        form.Show();
                        this.Hide();
                        form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна


                    }
                    else
                    {
                        MessageBox.Show("Ошибка при изменении данных");
                    }
                }
            }
        }




                    


                
           
        private void AdjustLayout()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int controlWidth = formWidth / 2;
            int controlHeight = formHeight / 15;

            int spacing = controlHeight / 4;
            int labelWidth = controlWidth / 3;

            int currentY = formHeight / 10;

            AdjustControl(labelLastName, textBoxLastName, labelWidth, controlWidth, controlHeight, spacing, ref currentY);
            AdjustControl(labelFirstName, textBoxFirstName, labelWidth, controlWidth, controlHeight, spacing, ref currentY);
            AdjustControl(labelMiddleName, textBoxMiddleName, labelWidth, controlWidth, controlHeight, spacing, ref currentY);
            AdjustControl(labelPhoneNumber, textBoxPhoneNumber, labelWidth, controlWidth, controlHeight, spacing, ref currentY);
            AdjustControl(labelEmail, textBoxEmail, labelWidth, controlWidth, controlHeight, spacing, ref currentY);
            AdjustControl(labelPassword, textBoxPassword, labelWidth, controlWidth, controlHeight, spacing, ref currentY);

            checkBoxAdminRights.Location = new System.Drawing.Point((formWidth - controlWidth) / 2, currentY);
            checkBoxAdminRights.Size = new System.Drawing.Size(controlWidth, controlHeight);
            checkBoxAdminRights.Font = new System.Drawing.Font("Segoe UI", controlHeight / 3);

            currentY += controlHeight + spacing;

            buttonRegister.Location = new System.Drawing.Point((formWidth - controlWidth) / 2, currentY);
            buttonRegister.Size = new System.Drawing.Size(controlWidth, controlHeight);
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", controlHeight / 3);
        }

        private void AdjustControl(Label label, TextBox textBox, int labelWidth, int controlWidth, int controlHeight, int spacing, ref int currentY)
        {
            int formWidth = this.ClientSize.Width;

            label.Location = new System.Drawing.Point((formWidth - controlWidth) / 2, currentY);
            label.Size = new System.Drawing.Size(labelWidth, controlHeight);
            label.Font = new System.Drawing.Font("Segoe UI", controlHeight / 3);

            textBox.Location = new System.Drawing.Point((formWidth - controlWidth) / 2 + labelWidth, currentY);
            textBox.Size = new System.Drawing.Size(controlWidth - labelWidth, controlHeight);
            textBox.Font = new System.Drawing.Font("Segoe UI", controlHeight / 3);

            currentY += controlHeight + spacing;
        }
    }

}
