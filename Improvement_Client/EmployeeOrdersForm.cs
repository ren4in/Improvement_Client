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
    public partial class EmployeeOrdersForm : Form
    {
        Order _currentOrder;
        public EmployeeOrdersForm(Order _selectedOrder)
        {
            InitializeComponent();
            if (_selectedOrder != null)
            {
                _currentOrder = _selectedOrder;
                txtHeader.Text = _currentOrder.Header;
                dtpDeadline.Text = Convert.ToString(_currentOrder.Deadline);
                txtText.Text = _currentOrder.Text;


            }
        }



            private void btnReport_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EmployeeReportsForm form = new EmployeeReportsForm();

            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close(); // Закрываем текущее окно после закрытия нового окна

        }

    }
}
