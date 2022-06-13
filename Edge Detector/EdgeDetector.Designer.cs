namespace Edge_Detector
{
    partial class EdgeDetector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdgeDetector));
            this.InputImagePB = new System.Windows.Forms.PictureBox();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SobelRadioButton = new System.Windows.Forms.RadioButton();
            this.CannyRadioButton = new System.Windows.Forms.RadioButton();
            this.DoButton = new System.Windows.Forms.Button();
            this.ResultImagePB = new System.Windows.Forms.PictureBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HighTreshold = new System.Windows.Forms.NumericUpDown();
            this.LowTreshold = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.InputImagePB)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultImagePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowTreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // InputImagePB
            // 
            this.InputImagePB.Location = new System.Drawing.Point(12, 81);
            this.InputImagePB.Name = "InputImagePB";
            this.InputImagePB.Size = new System.Drawing.Size(369, 354);
            this.InputImagePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InputImagePB.TabIndex = 1;
            this.InputImagePB.TabStop = false;
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.Size = new System.Drawing.Size(128, 26);
            this.OpenFileMenuItem.Text = "Open";
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(128, 26);
            this.SaveFileMenuItem.Text = "Save";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem,
            this.SaveFileMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(46, 28);
            this.FileMenuItem.Text = "File";
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(782, 28);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripItem,
            this.toolStripSeparator,
            this.SaveToolStripItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // OpenToolStripItem
            // 
            this.OpenToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripItem.Image")));
            this.OpenToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripItem.Name = "OpenToolStripItem";
            this.OpenToolStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripItem.Size = new System.Drawing.Size(203, 26);
            this.OpenToolStripItem.Text = "&Открыть";
            this.OpenToolStripItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(200, 6);
            // 
            // SaveToolStripItem
            // 
            this.SaveToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputSaveItem,
            this.ResultSaveItem});
            this.SaveToolStripItem.Enabled = false;
            this.SaveToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripItem.Image")));
            this.SaveToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripItem.Name = "SaveToolStripItem";
            this.SaveToolStripItem.Size = new System.Drawing.Size(203, 26);
            this.SaveToolStripItem.Text = "&Сохранить";
            // 
            // InputSaveItem
            // 
            this.InputSaveItem.Enabled = false;
            this.InputSaveItem.Name = "InputSaveItem";
            this.InputSaveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.InputSaveItem.Size = new System.Drawing.Size(346, 26);
            this.InputSaveItem.Text = "Исходное изображение";
            this.InputSaveItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // ResultSaveItem
            // 
            this.ResultSaveItem.Enabled = false;
            this.ResultSaveItem.Name = "ResultSaveItem";
            this.ResultSaveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.ResultSaveItem.Size = new System.Drawing.Size(346, 26);
            this.ResultSaveItem.Text = "Обработанное изображение";
            this.ResultSaveItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.опрограммеToolStripMenuItem_Click);
            // 
            // SobelRadioButton
            // 
            this.SobelRadioButton.AutoSize = true;
            this.SobelRadioButton.Checked = true;
            this.SobelRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SobelRadioButton.Location = new System.Drawing.Point(12, 34);
            this.SobelRadioButton.Name = "SobelRadioButton";
            this.SobelRadioButton.Size = new System.Drawing.Size(179, 24);
            this.SobelRadioButton.TabIndex = 3;
            this.SobelRadioButton.TabStop = true;
            this.SobelRadioButton.Text = "Детектор Собеля";
            this.SobelRadioButton.UseVisualStyleBackColor = true;
            this.SobelRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // CannyRadioButton
            // 
            this.CannyRadioButton.AutoSize = true;
            this.CannyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CannyRadioButton.Location = new System.Drawing.Point(201, 34);
            this.CannyRadioButton.Name = "CannyRadioButton";
            this.CannyRadioButton.Size = new System.Drawing.Size(168, 24);
            this.CannyRadioButton.TabIndex = 4;
            this.CannyRadioButton.Text = "Детектор Канни";
            this.CannyRadioButton.UseVisualStyleBackColor = true;
            this.CannyRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // DoButton
            // 
            this.DoButton.Enabled = false;
            this.DoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoButton.Location = new System.Drawing.Point(632, 34);
            this.DoButton.Name = "DoButton";
            this.DoButton.Size = new System.Drawing.Size(138, 31);
            this.DoButton.TabIndex = 5;
            this.DoButton.Text = "Обработать";
            this.DoButton.UseVisualStyleBackColor = true;
            this.DoButton.Click += new System.EventHandler(this.DetectEdges);
            // 
            // ResultImagePB
            // 
            this.ResultImagePB.Location = new System.Drawing.Point(402, 81);
            this.ResultImagePB.Name = "ResultImagePB";
            this.ResultImagePB.Size = new System.Drawing.Size(368, 354);
            this.ResultImagePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ResultImagePB.TabIndex = 6;
            this.ResultImagePB.TabStop = false;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Верх. граница";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ниж. граница";
            // 
            // HighTreshold
            // 
            this.HighTreshold.DecimalPlaces = 2;
            this.HighTreshold.Enabled = false;
            this.HighTreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HighTreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.HighTreshold.Location = new System.Drawing.Point(378, 53);
            this.HighTreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HighTreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HighTreshold.Name = "HighTreshold";
            this.HighTreshold.Size = new System.Drawing.Size(80, 26);
            this.HighTreshold.TabIndex = 11;
            this.HighTreshold.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.HighTreshold.ValueChanged += new System.EventHandler(this.HighTreshold_ValueChanged);
            // 
            // LowTreshold
            // 
            this.LowTreshold.DecimalPlaces = 2;
            this.LowTreshold.Enabled = false;
            this.LowTreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LowTreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.LowTreshold.Location = new System.Drawing.Point(511, 53);
            this.LowTreshold.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.LowTreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowTreshold.Name = "LowTreshold";
            this.LowTreshold.Size = new System.Drawing.Size(80, 26);
            this.LowTreshold.TabIndex = 12;
            this.LowTreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowTreshold.ValueChanged += new System.EventHandler(this.LowTreshold_ValueChanged);
            // 
            // EdgeDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.LowTreshold);
            this.Controls.Add(this.HighTreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultImagePB);
            this.Controls.Add(this.DoButton);
            this.Controls.Add(this.CannyRadioButton);
            this.Controls.Add(this.SobelRadioButton);
            this.Controls.Add(this.InputImagePB);
            this.Controls.Add(this.Menu);
            this.Name = "EdgeDetector";
            this.Text = "Edge detector";
            ((System.ComponentModel.ISupportInitialize)(this.InputImagePB)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultImagePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowTreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox InputImagePB;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.RadioButton SobelRadioButton;
        private System.Windows.Forms.RadioButton CannyRadioButton;
        private System.Windows.Forms.Button DoButton;
        private System.Windows.Forms.PictureBox ResultImagePB;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem InputSaveItem;
        private System.Windows.Forms.ToolStripMenuItem ResultSaveItem;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown HighTreshold;
        private System.Windows.Forms.NumericUpDown LowTreshold;
    }
}

