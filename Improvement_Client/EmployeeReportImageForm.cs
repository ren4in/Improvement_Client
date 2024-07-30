using Microsoft.IdentityModel.Tokens;
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
    public partial class EmployeeReportImageForm : Form
    {
        private List<Report_Image> allReportImages = new List<Report_Image>();

        private Report currentReport;
        public EmployeeReportImageForm(Report _selectedReport)
        {
            currentReport = _selectedReport;
            InitializeComponent();
            LoadImages();

        }
        private void LoadImages()
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var reportImage in allReportImages)
            {
                var pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                using (var ms = new MemoryStream(reportImage.Image))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }

                var deleteButton = new Button();
                deleteButton.Text = "X";
                deleteButton.BackColor = Color.Red;
                deleteButton.ForeColor = Color.White;
                deleteButton.Click += (s, e) => DeleteImage(reportImage);

                var panel = new Panel();
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(deleteButton);
                panel.Dock = DockStyle.Fill;

                deleteButton.Location = new Point(pictureBox.Width - deleteButton.Width, 0);

                flowLayoutPanel.Controls.Add(panel);
                panel.Margin = new Padding(10); // Adds spacing between items

                panel.Resize += (s, e) =>
                {
                    pictureBox.Size = new Size(panel.ClientSize.Width - deleteButton.Width, panel.ClientSize.Height);
                    deleteButton.Location = new Point(panel.ClientSize.Width - deleteButton.Width, 0);
                };

            }
        }
            


                private void DeleteImage(Report_Image reportImage)
        {
            allReportImages.Remove(reportImage);
            LoadImages();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    var imageBytes = File.ReadAllBytes(fileName);
                    var newImage = new Report_Image
                    {
                        id_Report = currentReport.id_Report, // Set the report ID accordingly
                        RowGuid = Guid.NewGuid(),
                        Image = imageBytes
                    };
                    allReportImages.Add(newImage);
                    LayoutControls();
                }
                LoadImages();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Implement saving logic here
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Implement back logic here
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void LayoutControls()
        {
            int margin = 10;
            int buttonHeight = 40;

            btnLoad.Location = new Point(margin, margin);
            btnLoad.Size = new Size(ClientSize.Width - 2 * margin, buttonHeight);

            flowLayoutPanel.Location = new Point(margin, btnLoad.Bottom + margin);
            flowLayoutPanel.Size = new Size(ClientSize.Width - 2 * margin, ClientSize.Height - btnLoad.Bottom - 3 * margin - buttonHeight);

            btnBack.Location = new Point(margin, ClientSize.Height - margin - buttonHeight);
            btnBack.Size = new Size(100, buttonHeight);

            btnOK.Location = new Point(ClientSize.Width - margin - 100, ClientSize.Height - margin - buttonHeight);
            btnOK.Size = new Size(100, buttonHeight);

            // Adjust size of picture boxes in the flow layout panel
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is Panel panel)
                {
                    var pictureBox = panel.Controls[0] as PictureBox;
                    var deleteButton = panel.Controls[1] as Button;
                    pictureBox.Size = new Size(panel.ClientSize.Width - deleteButton.Width, panel.ClientSize.Height);
                    deleteButton.Location = new Point(panel.ClientSize.Width - deleteButton.Width, 0);
                }
            }
        }
    }
}

