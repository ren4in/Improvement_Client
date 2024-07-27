using System;
using System.Drawing;
using System.Windows.Forms;

namespace Improvement_Client
{
    partial class EmployeeChoiceForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTasks;
        private Button btnMap;
        private TableLayoutPanel tableLayoutPanel;

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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.btnTasks, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnMap, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnTasks
            // 
            this.btnTasks.Anchor = AnchorStyles.None;
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTasks.Location = new System.Drawing.Point(200, 75);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(400, 50);
            this.btnTasks.TabIndex = 0;
            this.btnTasks.Text = "Поручения";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = AnchorStyles.None;
            this.btnMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMap.Location = new System.Drawing.Point(200, 325);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(400, 50);
            this.btnMap.TabIndex = 1;
            this.btnMap.Text = "Карта";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // EmployeeChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "EmployeeChoiceForm";
            this.Text = "EmployeeChoiceForm";
            this.Resize += new System.EventHandler(this.EmployeeChoiceForm_Resize);
            this.ResumeLayout(false);

        }
         


    }
}
