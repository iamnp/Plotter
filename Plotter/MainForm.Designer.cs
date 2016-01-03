namespace Plotter
{
    partial class MainForm
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xMinLabel = new System.Windows.Forms.Label();
            this.xMaxLabel = new System.Windows.Forms.Label();
            this.dxLabel = new System.Windows.Forms.Label();
            this.plotFuncButton = new System.Windows.Forms.Button();
            this.plotIntegralButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.smoothCheckBox = new System.Windows.Forms.CheckBox();
            this.dxPerSecLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.plotFuncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotIntegralMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketingThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monochromeThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.plotFuncToolItem = new System.Windows.Forms.ToolStripButton();
            this.plotIntegralToolItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smoothToolItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolItem = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.oneToOneYScaleRadioButton = new System.Windows.Forms.RadioButton();
            this.autoYScaleRadioButton = new System.Windows.Forms.RadioButton();
            this.dxPerSecInputBox = new Plotter.DoubleInputBox();
            this.zTrackBar = new Plotter.MyTrackBar();
            this.yTrackBar = new Plotter.MyTrackBar();
            this.plotterControl1 = new Plotter.PlotterControl();
            this.dxInputBox = new Plotter.DoubleInputBox();
            this.xMaxInputBox = new Plotter.DoubleInputBox();
            this.xMinInputBox = new Plotter.DoubleInputBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotterControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // xMinLabel
            // 
            this.xMinLabel.AutoSize = true;
            this.xMinLabel.Location = new System.Drawing.Point(12, 55);
            this.xMinLabel.Name = "xMinLabel";
            this.xMinLabel.Size = new System.Drawing.Size(33, 13);
            this.xMinLabel.TabIndex = 0;
            this.xMinLabel.Text = "Xmin:";
            // 
            // xMaxLabel
            // 
            this.xMaxLabel.AutoSize = true;
            this.xMaxLabel.Location = new System.Drawing.Point(9, 87);
            this.xMaxLabel.Name = "xMaxLabel";
            this.xMaxLabel.Size = new System.Drawing.Size(36, 13);
            this.xMaxLabel.TabIndex = 1;
            this.xMaxLabel.Text = "Xmax:";
            // 
            // dxLabel
            // 
            this.dxLabel.AutoSize = true;
            this.dxLabel.Location = new System.Drawing.Point(23, 135);
            this.dxLabel.Name = "dxLabel";
            this.dxLabel.Size = new System.Drawing.Size(22, 13);
            this.dxLabel.TabIndex = 2;
            this.dxLabel.Text = "∆x:";
            // 
            // plotFuncButton
            // 
            this.plotFuncButton.Location = new System.Drawing.Point(12, 222);
            this.plotFuncButton.Name = "plotFuncButton";
            this.plotFuncButton.Size = new System.Drawing.Size(131, 47);
            this.plotFuncButton.TabIndex = 4;
            this.plotFuncButton.Text = "Построить график функции";
            this.plotFuncButton.UseVisualStyleBackColor = true;
            this.plotFuncButton.Click += new System.EventHandler(this.plotFuncButton_Click);
            // 
            // plotIntegralButton
            // 
            this.plotIntegralButton.Location = new System.Drawing.Point(12, 297);
            this.plotIntegralButton.Name = "plotIntegralButton";
            this.plotIntegralButton.Size = new System.Drawing.Size(131, 54);
            this.plotIntegralButton.TabIndex = 5;
            this.plotIntegralButton.Text = "Построить график интеграла с анимацией";
            this.plotIntegralButton.UseVisualStyleBackColor = true;
            this.plotIntegralButton.Click += new System.EventHandler(this.plotIntegralButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Параметр Y:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Параметр Z:";
            // 
            // smoothCheckBox
            // 
            this.smoothCheckBox.AutoSize = true;
            this.smoothCheckBox.Checked = true;
            this.smoothCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smoothCheckBox.Location = new System.Drawing.Point(12, 181);
            this.smoothCheckBox.Name = "smoothCheckBox";
            this.smoothCheckBox.Size = new System.Drawing.Size(94, 17);
            this.smoothCheckBox.TabIndex = 3;
            this.smoothCheckBox.Text = "Сглаживание";
            this.smoothCheckBox.UseVisualStyleBackColor = true;
            this.smoothCheckBox.CheckedChanged += new System.EventHandler(this.smoothCheckBox_CheckedChanged);
            // 
            // dxPerSecLabel
            // 
            this.dxPerSecLabel.AutoSize = true;
            this.dxPerSecLabel.Location = new System.Drawing.Point(15, 378);
            this.dxPerSecLabel.Name = "dxPerSecLabel";
            this.dxPerSecLabel.Size = new System.Drawing.Size(50, 13);
            this.dxPerSecLabel.TabIndex = 14;
            this.dxPerSecLabel.Text = "∆x / sec:";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewMenuItem,
            this.settingsMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotFuncMenuItem,
            this.plotIntegralMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem1.Text = "Действия";
            // 
            // plotFuncMenuItem
            // 
            this.plotFuncMenuItem.Name = "plotFuncMenuItem";
            this.plotFuncMenuItem.Size = new System.Drawing.Size(309, 22);
            this.plotFuncMenuItem.Text = "Построить график функции";
            this.plotFuncMenuItem.Click += new System.EventHandler(this.plotFuncButton_Click);
            // 
            // plotIntegralMenuItem
            // 
            this.plotIntegralMenuItem.Name = "plotIntegralMenuItem";
            this.plotIntegralMenuItem.Size = new System.Drawing.Size(309, 22);
            this.plotIntegralMenuItem.Text = "Построить график интеграла с анимацией";
            this.plotIntegralMenuItem.Click += new System.EventHandler(this.plotIntegralButton_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewMenuItem.Text = "Вид";
            // 
            // themeMenuItem
            // 
            this.themeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultThemeMenuItem,
            this.minimalThemeMenuItem,
            this.businessThemeMenuItem,
            this.marketingThemeMenuItem,
            this.monochromeThemeMenuItem});
            this.themeMenuItem.Name = "themeMenuItem";
            this.themeMenuItem.Size = new System.Drawing.Size(102, 22);
            this.themeMenuItem.Text = "Тема";
            // 
            // defaultThemeMenuItem
            // 
            this.defaultThemeMenuItem.Checked = true;
            this.defaultThemeMenuItem.CheckOnClick = true;
            this.defaultThemeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultThemeMenuItem.Name = "defaultThemeMenuItem";
            this.defaultThemeMenuItem.Size = new System.Drawing.Size(179, 22);
            this.defaultThemeMenuItem.Text = "Стандартная";
            this.defaultThemeMenuItem.Click += new System.EventHandler(this.themeChanged_Click);
            // 
            // minimalThemeMenuItem
            // 
            this.minimalThemeMenuItem.CheckOnClick = true;
            this.minimalThemeMenuItem.Name = "minimalThemeMenuItem";
            this.minimalThemeMenuItem.Size = new System.Drawing.Size(179, 22);
            this.minimalThemeMenuItem.Text = "Минималистичная";
            this.minimalThemeMenuItem.Click += new System.EventHandler(this.themeChanged_Click);
            // 
            // businessThemeMenuItem
            // 
            this.businessThemeMenuItem.CheckOnClick = true;
            this.businessThemeMenuItem.Name = "businessThemeMenuItem";
            this.businessThemeMenuItem.Size = new System.Drawing.Size(179, 22);
            this.businessThemeMenuItem.Text = "Бизнес";
            this.businessThemeMenuItem.Click += new System.EventHandler(this.themeChanged_Click);
            // 
            // marketingThemeMenuItem
            // 
            this.marketingThemeMenuItem.CheckOnClick = true;
            this.marketingThemeMenuItem.Name = "marketingThemeMenuItem";
            this.marketingThemeMenuItem.Size = new System.Drawing.Size(179, 22);
            this.marketingThemeMenuItem.Text = "Маркетинг";
            this.marketingThemeMenuItem.Click += new System.EventHandler(this.themeChanged_Click);
            // 
            // monochromeThemeMenuItem
            // 
            this.monochromeThemeMenuItem.CheckOnClick = true;
            this.monochromeThemeMenuItem.Name = "monochromeThemeMenuItem";
            this.monochromeThemeMenuItem.Size = new System.Drawing.Size(179, 22);
            this.monochromeThemeMenuItem.Text = "Черно-белая";
            this.monochromeThemeMenuItem.Click += new System.EventHandler(this.themeChanged_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsMenuItem.Text = "Настройки";
            // 
            // smoothMenuItem
            // 
            this.smoothMenuItem.Checked = true;
            this.smoothMenuItem.CheckOnClick = true;
            this.smoothMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smoothMenuItem.Name = "smoothMenuItem";
            this.smoothMenuItem.Size = new System.Drawing.Size(148, 22);
            this.smoothMenuItem.Text = "Сглаживание";
            this.smoothMenuItem.CheckedChanged += new System.EventHandler(this.smoothCheckBox_CheckedChanged);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpMenuItem.Text = "Помощь";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutMenuItem.Text = "О программе";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotFuncToolItem,
            this.plotIntegralToolItem,
            this.toolStripSeparator1,
            this.smoothToolItem,
            this.toolStripSeparator2,
            this.aboutToolItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // plotFuncToolItem
            // 
            this.plotFuncToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plotFuncToolItem.Image = global::Plotter.Properties.Resources.func_icon;
            this.plotFuncToolItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotFuncToolItem.Name = "plotFuncToolItem";
            this.plotFuncToolItem.Size = new System.Drawing.Size(23, 22);
            this.plotFuncToolItem.Text = "Построить график функции";
            this.plotFuncToolItem.Click += new System.EventHandler(this.plotFuncButton_Click);
            // 
            // plotIntegralToolItem
            // 
            this.plotIntegralToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plotIntegralToolItem.Image = global::Plotter.Properties.Resources.integral_icon;
            this.plotIntegralToolItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotIntegralToolItem.Name = "plotIntegralToolItem";
            this.plotIntegralToolItem.Size = new System.Drawing.Size(23, 22);
            this.plotIntegralToolItem.Text = "Построить график интеграла с анимацией";
            this.plotIntegralToolItem.Click += new System.EventHandler(this.plotIntegralButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // smoothToolItem
            // 
            this.smoothToolItem.Checked = true;
            this.smoothToolItem.CheckOnClick = true;
            this.smoothToolItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smoothToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.smoothToolItem.Image = global::Plotter.Properties.Resources.smoothing_icon;
            this.smoothToolItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.smoothToolItem.Name = "smoothToolItem";
            this.smoothToolItem.Size = new System.Drawing.Size(23, 22);
            this.smoothToolItem.Text = "Сглаживание";
            this.smoothToolItem.CheckedChanged += new System.EventHandler(this.smoothCheckBox_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutToolItem
            // 
            this.aboutToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolItem.Image = global::Plotter.Properties.Resources.about_icon;
            this.aboutToolItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolItem.Name = "aboutToolItem";
            this.aboutToolItem.Size = new System.Drawing.Size(23, 22);
            this.aboutToolItem.Text = "toolStripButton1";
            this.aboutToolItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.oneToOneYScaleRadioButton);
            this.groupBox1.Controls.Add(this.autoYScaleRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 417);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 105);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Масштаб по оси Y";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "или используйте колесо мыши для изменения масштаба";
            // 
            // oneToOneYScaleRadioButton
            // 
            this.oneToOneYScaleRadioButton.AutoSize = true;
            this.oneToOneYScaleRadioButton.Location = new System.Drawing.Point(14, 42);
            this.oneToOneYScaleRadioButton.Name = "oneToOneYScaleRadioButton";
            this.oneToOneYScaleRadioButton.Size = new System.Drawing.Size(40, 17);
            this.oneToOneYScaleRadioButton.TabIndex = 1;
            this.oneToOneYScaleRadioButton.Text = "1:1";
            this.oneToOneYScaleRadioButton.UseVisualStyleBackColor = true;
            this.oneToOneYScaleRadioButton.CheckedChanged += new System.EventHandler(this.oneToOneYScaleRadioButton_CheckedChanged);
            // 
            // autoYScaleRadioButton
            // 
            this.autoYScaleRadioButton.AutoSize = true;
            this.autoYScaleRadioButton.Checked = true;
            this.autoYScaleRadioButton.Location = new System.Drawing.Point(14, 19);
            this.autoYScaleRadioButton.Name = "autoYScaleRadioButton";
            this.autoYScaleRadioButton.Size = new System.Drawing.Size(103, 17);
            this.autoYScaleRadioButton.TabIndex = 0;
            this.autoYScaleRadioButton.TabStop = true;
            this.autoYScaleRadioButton.Text = "Автоматически";
            this.autoYScaleRadioButton.UseVisualStyleBackColor = true;
            this.autoYScaleRadioButton.CheckedChanged += new System.EventHandler(this.autoYScaleRadioButton_CheckedChanged);
            // 
            // dxPerSecInputBox
            // 
            this.dxPerSecInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(190)))));
            this.dxPerSecInputBox.Location = new System.Drawing.Point(71, 375);
            this.dxPerSecInputBox.Name = "dxPerSecInputBox";
            this.dxPerSecInputBox.Size = new System.Drawing.Size(72, 20);
            this.dxPerSecInputBox.TabIndex = 6;
            this.dxPerSecInputBox.Text = "2";
            // 
            // zTrackBar
            // 
            this.zTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zTrackBar.Divisor = 20D;
            this.zTrackBar.Location = new System.Drawing.Point(226, 460);
            this.zTrackBar.Maximum = 63;
            this.zTrackBar.Minimum = 0;
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(746, 62);
            this.zTrackBar.TabIndex = 9;
            this.zTrackBar.Value = 0D;
            // 
            // yTrackBar
            // 
            this.yTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yTrackBar.Divisor = 20D;
            this.yTrackBar.Location = new System.Drawing.Point(226, 388);
            this.yTrackBar.Maximum = 40;
            this.yTrackBar.Minimum = 0;
            this.yTrackBar.Name = "yTrackBar";
            this.yTrackBar.Size = new System.Drawing.Size(746, 62);
            this.yTrackBar.TabIndex = 8;
            this.yTrackBar.Value = 0.05D;
            // 
            // plotterControl1
            // 
            this.plotterControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterControl1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.plotterControl1.Location = new System.Drawing.Point(149, 52);
            this.plotterControl1.Name = "plotterControl1";
            this.plotterControl1.Size = new System.Drawing.Size(823, 330);
            this.plotterControl1.TabIndex = 7;
            this.plotterControl1.TabStop = false;
            this.plotterControl1.MouseEnter += new System.EventHandler(this.plotterControl1_MouseEnter);
            // 
            // dxInputBox
            // 
            this.dxInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(190)))));
            this.dxInputBox.Location = new System.Drawing.Point(51, 132);
            this.dxInputBox.Name = "dxInputBox";
            this.dxInputBox.Size = new System.Drawing.Size(92, 20);
            this.dxInputBox.TabIndex = 2;
            this.dxInputBox.Text = "0.005";
            // 
            // xMaxInputBox
            // 
            this.xMaxInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(190)))));
            this.xMaxInputBox.Location = new System.Drawing.Point(51, 92);
            this.xMaxInputBox.Name = "xMaxInputBox";
            this.xMaxInputBox.Size = new System.Drawing.Size(92, 20);
            this.xMaxInputBox.TabIndex = 1;
            this.xMaxInputBox.Text = "10.0";
            // 
            // xMinInputBox
            // 
            this.xMinInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(190)))));
            this.xMinInputBox.Location = new System.Drawing.Point(51, 52);
            this.xMinInputBox.Name = "xMinInputBox";
            this.xMinInputBox.Size = new System.Drawing.Size(92, 20);
            this.xMinInputBox.TabIndex = 0;
            this.xMinInputBox.Text = "0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dxPerSecInputBox);
            this.Controls.Add(this.dxPerSecLabel);
            this.Controls.Add(this.smoothCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.zTrackBar);
            this.Controls.Add(this.yTrackBar);
            this.Controls.Add(this.plotIntegralButton);
            this.Controls.Add(this.plotterControl1);
            this.Controls.Add(this.plotFuncButton);
            this.Controls.Add(this.dxInputBox);
            this.Controls.Add(this.xMaxInputBox);
            this.Controls.Add(this.xMinInputBox);
            this.Controls.Add(this.dxLabel);
            this.Controls.Add(this.xMaxLabel);
            this.Controls.Add(this.xMinLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 573);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графопостроитель";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotterControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xMinLabel;
        private System.Windows.Forms.Label xMaxLabel;
        private System.Windows.Forms.Label dxLabel;
        private DoubleInputBox xMinInputBox;
        private DoubleInputBox xMaxInputBox;
        private DoubleInputBox dxInputBox;
        private System.Windows.Forms.Button plotFuncButton;
        private PlotterControl plotterControl1;
        private System.Windows.Forms.Button plotIntegralButton;
        private MyTrackBar yTrackBar;
        private MyTrackBar zTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox smoothCheckBox;
        private System.Windows.Forms.Label dxPerSecLabel;
        private DoubleInputBox dxPerSecInputBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem plotFuncMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotIntegralMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton plotFuncToolItem;
        private System.Windows.Forms.ToolStripButton plotIntegralToolItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripButton smoothToolItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothMenuItem;
        private System.Windows.Forms.ToolStripButton aboutToolItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton autoYScaleRadioButton;
        private System.Windows.Forms.RadioButton oneToOneYScaleRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketingThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monochromeThemeMenuItem;
    }
}

