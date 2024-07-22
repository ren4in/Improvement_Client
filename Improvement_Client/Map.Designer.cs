namespace Improvement_Client
{
    partial class Map
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.greenLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notClearedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearedHouseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearedEntranceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearedHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearedEntranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.None;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 44);
            this.gmap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1924, 1009);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gmap_OnMarkerEnter);
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSalmon;
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greenLineToolStripMenuItem,
            this.redLineToolStripMenuItem,
            this.notClearedToolStripMenuItem,
            this.clearedToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 44);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // greenLineToolStripMenuItem
            // 
            this.greenLineToolStripMenuItem.Name = "greenLineToolStripMenuItem";
            this.greenLineToolStripMenuItem.Size = new System.Drawing.Size(348, 40);
            this.greenLineToolStripMenuItem.Text = "Поставить зеленую линию";
            this.greenLineToolStripMenuItem.Click += new System.EventHandler(this.greenLineToolStripMenuItem_Click);
            // 
            // redLineToolStripMenuItem
            // 
            this.redLineToolStripMenuItem.Name = "redLineToolStripMenuItem";
            this.redLineToolStripMenuItem.Size = new System.Drawing.Size(344, 40);
            this.redLineToolStripMenuItem.Text = "Поставить красную линию";
            this.redLineToolStripMenuItem.Click += new System.EventHandler(this.redLineToolStripMenuItem_Click);
            // 
            // notClearedToolStripMenuItem
            // 
            this.notClearedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearedHouseToolStripMenuItem1,
            this.clearedEntranceToolStripMenuItem1});
            this.notClearedToolStripMenuItem.Name = "notClearedToolStripMenuItem";
            this.notClearedToolStripMenuItem.Size = new System.Drawing.Size(378, 40);
            this.notClearedToolStripMenuItem.Text = "Поставить метку \"Не чищено\"";
            // 
            // clearedHouseToolStripMenuItem1
            // 
            this.clearedHouseToolStripMenuItem1.Name = "clearedHouseToolStripMenuItem1";
            this.clearedHouseToolStripMenuItem1.Size = new System.Drawing.Size(223, 42);
            this.clearedHouseToolStripMenuItem1.Text = "Дом";
            this.clearedHouseToolStripMenuItem1.Click += new System.EventHandler(this.clearedHouseToolStripMenuItem1_Click);
            // 
            // clearedEntranceToolStripMenuItem1
            // 
            this.clearedEntranceToolStripMenuItem1.Name = "clearedEntranceToolStripMenuItem1";
            this.clearedEntranceToolStripMenuItem1.Size = new System.Drawing.Size(223, 42);
            this.clearedEntranceToolStripMenuItem1.Text = "Подъезд";
            this.clearedEntranceToolStripMenuItem1.Click += new System.EventHandler(this.clearedEntranceToolStripMenuItem1_Click);
            // 
            // clearedToolStripMenuItem
            // 
            this.clearedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearedHouseToolStripMenuItem,
            this.clearedEntranceToolStripMenuItem});
            this.clearedToolStripMenuItem.Name = "clearedToolStripMenuItem";
            this.clearedToolStripMenuItem.Size = new System.Drawing.Size(359, 40);
            this.clearedToolStripMenuItem.Text = "Поставить метку \"Очищено\"";
             // 
            // clearedHouseToolStripMenuItem
            // 
            this.clearedHouseToolStripMenuItem.Name = "clearedHouseToolStripMenuItem";
            this.clearedHouseToolStripMenuItem.Size = new System.Drawing.Size(223, 42);
            this.clearedHouseToolStripMenuItem.Text = "Дом";
            this.clearedHouseToolStripMenuItem.Click += new System.EventHandler(this.clearedHouseToolStripMenuItem_Click);
            // 
            // clearedEntranceToolStripMenuItem
            // 
            this.clearedEntranceToolStripMenuItem.Name = "clearedEntranceToolStripMenuItem";
            this.clearedEntranceToolStripMenuItem.Size = new System.Drawing.Size(223, 42);
            this.clearedEntranceToolStripMenuItem.Text = "Подъезд";
            this.clearedEntranceToolStripMenuItem.Click += new System.EventHandler(this.clearedEntranceToolStripMenuItem_Click);
            // 
            // кругУТочкиToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "ClearlStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(139, 40);
            this.clearToolStripMenuItem.Text = "Очистить";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click); 
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сСервераToolStripMenuItem,
            this.наСерверToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 40);
            this.toolStripMenuItem1.Text = "Загрузить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // сСервераToolStripMenuItem
            // 
            this.сСервераToolStripMenuItem.Name = "сСервераToolStripMenuItem";
            this.сСервераToolStripMenuItem.Size = new System.Drawing.Size(233, 42);
            this.сСервераToolStripMenuItem.Text = "С сервера";
            this.сСервераToolStripMenuItem.Click += new System.EventHandler(this.сСервераToolStripMenuItem_Click);
            // 
            // наСерверToolStripMenuItem
            // 
            this.наСерверToolStripMenuItem.Name = "наСерверToolStripMenuItem";
            this.наСерверToolStripMenuItem.Size = new System.Drawing.Size(233, 42);
            this.наСерверToolStripMenuItem.Text = "На сервер";
       //     this.наСерверToolStripMenuItem.Click += new System.EventHandler(this.наСерверToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 1053);
            this.trackBar1.BackColor= System.Drawing.Color.White;
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1924, 69);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(650, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(500, 41);
            this.button5.TabIndex = 11;
            this.button5.Text = "Вернуться в Выхино-Жулебино";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1924, 1122);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Map";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Map_Load);
            this.Resize += new System.EventHandler(this.Map_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem greenLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notClearedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearedHouseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearedEntranceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearedHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearedEntranceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сСервераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наСерверToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button5;
    }
}