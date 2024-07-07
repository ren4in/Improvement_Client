namespace Improvement_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridReports = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridReports).BeginInit();
            SuspendLayout();
            // 
            // DataGridReports
            // 
            DataGridReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridReports.Location = new Point(194, 0);
            DataGridReports.Name = "DataGridReports";
            DataGridReports.RowHeadersWidth = 62;
            DataGridReports.Size = new Size(1648, 450);
            DataGridReports.TabIndex = 0;
            DataGridReports.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 904);
            Controls.Add(DataGridReports);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            SizeChanged += YourForm_Resize;
            ((System.ComponentModel.ISupportInitialize)DataGridReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridReports;
    }
}
