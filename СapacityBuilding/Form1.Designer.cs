namespace СapacityBuilding
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.а1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zA2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.o2A2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.channelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseDataToolStripMenuItem,
            this.averageToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // parseDataToolStripMenuItem
            // 
            this.parseDataToolStripMenuItem.Name = "parseDataToolStripMenuItem";
            this.parseDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parseDataToolStripMenuItem.Text = "ParseData";
            this.parseDataToolStripMenuItem.Click += new System.EventHandler(this.parseDataToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.averageToolStripMenuItem.Text = "Average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.averageToolStripMenuItem_Click);
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.а1ToolStripMenuItem,
            this.zA2ToolStripMenuItem,
            this.o2A2ToolStripMenuItem});
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.channelToolStripMenuItem.Text = "Channel";
            // 
            // а1ToolStripMenuItem
            // 
            this.а1ToolStripMenuItem.Name = "а1ToolStripMenuItem";
            this.а1ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.а1ToolStripMenuItem.Text = "O1А1";
            this.а1ToolStripMenuItem.Click += new System.EventHandler(this.а1ToolStripMenuItem_Click);
            // 
            // zA2ToolStripMenuItem
            // 
            this.zA2ToolStripMenuItem.Name = "zA2ToolStripMenuItem";
            this.zA2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.zA2ToolStripMenuItem.Text = "OzA2";
            this.zA2ToolStripMenuItem.Click += new System.EventHandler(this.zA2ToolStripMenuItem_Click);
            // 
            // o2A2ToolStripMenuItem
            // 
            this.o2A2ToolStripMenuItem.Name = "o2A2ToolStripMenuItem";
            this.o2A2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.o2A2ToolStripMenuItem.Text = "O2A2";
            this.o2A2ToolStripMenuItem.Click += new System.EventHandler(this.o2A2ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(0, 24);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Values";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(555, 322);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 336);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(555, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 346);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem channelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem а1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zA2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem o2A2ToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

