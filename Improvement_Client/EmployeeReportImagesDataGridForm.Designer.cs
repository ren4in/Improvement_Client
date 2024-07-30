namespace Improvement_Client
{
    partial class EmployeeReportImagesDataGridForm
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

        private DataGridView dataGridView;
        private Button btnLoad;
        private Button btnOK;
        private Button btnBack;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Employee Report Images";

            // Initialize components
            dataGridView = new DataGridView();
            btnLoad = new Button();
            btnOK = new Button();
            btnBack = new Button();

            // Set up btnLoad
            btnLoad.Text = "Загрузить";
            btnLoad.Click += new EventHandler(this.BtnLoad_Click);

            // Set up dataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);

            // Add columns to dataGridView
            dataGridView.Columns.Add(new DataGridViewImageColumn()
            {
                Name = "Image",
                HeaderText = "Изображение",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            dataGridView.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "View",
                HeaderText = "Посмотреть",
                Text = "Посмотреть",
                UseColumnTextForButtonValue = true
            });
            dataGridView.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Delete",
                HeaderText = "Удалить",
                Text = "Удалить",
                UseColumnTextForButtonValue = true
            });

            // Set up btnOK
            btnOK.Text = "OK";
            btnOK.Click += new EventHandler(this.BtnOK_Click);

            // Set up btnBack
            btnBack.Text = "Назад";
            btnBack.Click += new EventHandler(this.BtnBack_Click);

            // Add controls to the form
            this.Controls.Add(btnLoad);
            this.Controls.Add(dataGridView);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnBack);

            this.Load += new EventHandler(this.Form_Load);
            this.Resize += new EventHandler(this.Form_Resize);

            this.ResumeLayout(false);
        }
    }
}


        #endregion
    
