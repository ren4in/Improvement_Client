using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Improvement_Client
{
    public partial class EmployeeChoiceForm : Form
    {
        public EmployeeChoiceForm()
        {
            InitializeComponent();
        }

        private void EmployeeChoiceForm_Resize(object sender, EventArgs e)
        {
            AdjustButtonSizeAndFont();
        }

        private void AdjustButtonSizeAndFont()
        {
            // Adjust the size and font of the buttons based on the form's size
            int buttonWidth = Math.Max(200, ClientSize.Width / 2);
            int buttonHeight = Math.Max(50, ClientSize.Height / 8);

            float newSize = Math.Max(12, ClientSize.Width / 40); // Adjust this factor as needed

            btnTasks.Size = new Size(buttonWidth, buttonHeight);
            btnTasks.Font = new Font("Microsoft Sans Serif", newSize);

            btnMap.Size = new Size(buttonWidth, buttonHeight);
            btnMap.Font = new Font("Microsoft Sans Serif", newSize);
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            EmployeeReportsForm form2 = new EmployeeReportsForm();

            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна


        }

        private void btnMap_Click(object sender, EventArgs e)
        {
 
                Map form2 = new Map();

                form2.Show();
                this.Hide();
                form2.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна


             }
        }
}
