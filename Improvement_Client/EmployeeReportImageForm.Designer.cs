using System.Windows.Forms;

namespace Improvement_Client
{
    partial class EmployeeReportImageForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private FlowLayoutPanel flowLayoutPanel;

        private Button btnLoad;
        private Button btnOK;
        private Button btnBack;

        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            btnLoad = new Button();
            btnOK = new Button();
            btnBack = new Button();

            // Set up form
            this.SuspendLayout();
            this.Text = "Employee Report Images";
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Load += new EventHandler(this.Form_Load);
            this.Resize += new EventHandler(this.Form_Resize);

            // Set up btnLoad
            btnLoad.Text = "Загрузить";
            btnLoad.Click += new EventHandler(this.BtnLoad_Click);

            // Set up flowLayoutPanel
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.WrapContents = false;

            // Set up btnOK
            btnOK.Text = "OK";
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Click += new EventHandler(this.BtnOK_Click);

            // Set up btnBack
            btnBack.Text = "Назад";
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.Click += new EventHandler(this.BtnBack_Click);

            // Add controls to the form
            this.Controls.Add(btnLoad);
            this.Controls.Add(flowLayoutPanel);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnBack);

            this.ResumeLayout(false);
        }
    }

        #endregion
    }