using System.Windows.Forms;

namespace Improvement_Client
{
    partial class EmployeeReportImageForm
    {
        private PictureBox pictureBox;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnDelete;
        private Button btnBack;
        private Button btnLoad;

        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            btnPrevious = new Button();
            btnNext = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(100, 50);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click_1;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(0, 0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "<";
            btnPrevious.Click += BtnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(0, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = ">";
            btnNext.Click += BtnNext_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 4;
            btnBack.Text = "Назад";
            btnBack.Click += BtnBack_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(0, 0);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Добавить";
            btnLoad.Click += btnLoad_Click;
            // 
            // EmployeeReportImageForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(pictureBox);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Controls.Add(btnLoad);
            Name = "EmployeeReportImageForm";
            Text = "Employee Report Images";
            Load += Form_Load;
            Resize += Form_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }
    }   
}
     