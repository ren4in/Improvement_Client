namespace Improvement_Client
{
    partial class SupervisorviewReportImages
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayoutPanel;
        private FlowLayoutPanel imagePanel;
        private Panel okButtonPanel;
        private Button btnOK;
        private Panel separatorPanel;

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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.separatorPanel = new System.Windows.Forms.Panel();
            this.okButtonPanel = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F)); // Разделительная линия
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainLayoutPanel.Controls.Add(this.imagePanel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.separatorPanel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.okButtonPanel, 0, 2);
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // imagePanel
            // 
            this.imagePanel.AutoScroll = true;
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.imagePanel.WrapContents = false;
            this.imagePanel.AutoSize = true;
            this.imagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagePanel.Margin = new Padding(0);
            this.imagePanel.Padding = new Padding(0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(794, 344);
            this.imagePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.imagePanel.Location = new Point(0, 0);
            // 
            // separatorPanel
            // 
            this.separatorPanel.BackColor = Color.Gray;
            this.separatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separatorPanel.Location = new System.Drawing.Point(3, 353);
            this.separatorPanel.Name = "separatorPanel";
            this.separatorPanel.Size = new System.Drawing.Size(794, 4);
            this.separatorPanel.TabIndex = 1;
            // 
            // okButtonPanel
            // 
            this.okButtonPanel.Controls.Add(this.btnOK);
            this.okButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButtonPanel.Location = new System.Drawing.Point(3, 363);
            this.okButtonPanel.Name = "okButtonPanel";
            this.okButtonPanel.Size = new System.Drawing.Size(794, 84);
            this.okButtonPanel.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(347, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SupervisorviewReportImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayoutPanel);
            this.Name = "SupervisorviewReportImages";
            this.Text = "Просмотр изображений";
            this.Resize += new System.EventHandler(this.SupervisorviewReportImages_Resize);
            this.ResumeLayout(false);
        }

    }
}