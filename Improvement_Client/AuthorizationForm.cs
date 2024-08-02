using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Improvement_Client
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginBox.Size = new System.Drawing.Size(200, 30);
            this.LoginBox.TabIndex = 0;
            // 
            // PasswrodBox
            // 
            this.PasswordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordBox.Size = new System.Drawing.Size(200, 30);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // JoinButton
            // 
            this.JoinButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JoinButton.BackColor = System.Drawing.Color.SteelBlue;
            this.JoinButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.JoinButton.ForeColor = System.Drawing.Color.White;
            this.JoinButton.AutoSize = true;
            this.JoinButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.JoinButton.TabIndex = 2;
            this.JoinButton.Text = "Войти";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += JoinButton_Click;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.LoginBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.PasswordBox, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.JoinButton, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(400, 300);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.Resize += new System.EventHandler(this.AuthorizationForm_Resize);
            this.ResumeLayout(false);

        }

        private async void AuthHandler()
        {
            try
            {
                if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
                {
                    throw new Exception("Введите логин и пароль!");
                }

                await Api.UserAuthAsync(LoginBox.Text, PasswordBox.Text);

                switch (Api.role)// определение роли при авторизации. Временно просто выводит название роли, потом будет направлять на соответсвующую страницу
                {
                    case ("Администратор"):
                                
                      ManagerChoiceForm form =  new ManagerChoiceForm();
 
                        form.Show();
                      this.Hide();
                       form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна


                        break;
                    case ("Пользователь"):
                        EmployeeChoiceForm form2 = new EmployeeChoiceForm();

                        form2.Show();
                        this.Hide();
                        form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна


                        break;
                 
                }
                //   return task;

            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                //   return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //    return null;
            }
        }


        private void AuthorizationForm_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 20F; // Adjust the divisor to control the font size scaling
            this.LoginBox.Font = new Font(this.LoginBox.Font.FontFamily, newSize);
            this.PasswordBox.Font = new Font(this.PasswordBox.Font.FontFamily, newSize);
            this.JoinButton.Font = new Font(this.JoinButton.Font.FontFamily, newSize, FontStyle.Bold);
            this.label1.Font = new Font(this.label1.Font.FontFamily, newSize);
            this.label2.Font = new Font(this.label2.Font.FontFamily, newSize);

            // Adjust TextBox sizes
            this.LoginBox.Size = new Size((int)(this.ClientSize.Width * 0.5), (int)(newSize * 2));
            this.PasswordBox.Size = new Size((int)(this.ClientSize.Width * 0.5), (int)(newSize * 2));
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            AuthHandler();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
