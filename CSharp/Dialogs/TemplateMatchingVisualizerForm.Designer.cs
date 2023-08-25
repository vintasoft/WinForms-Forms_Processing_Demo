namespace FormsProcessingDemo
{
    partial class TemplateMatchingVisualizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateMatchingVisualizerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilledImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageScaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignFilledImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showImprintsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeTemplateMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imprintPreprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.templateImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filledImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.transparencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.keyZoneLocationDeviationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nonMatchedColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.matchedColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.zoomTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyZoneLocationDeviationNumericUpDown)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.templateMatchingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTemplateImageToolStripMenuItem,
            this.openFilledImageToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTemplateImageToolStripMenuItem
            // 
            this.openTemplateImageToolStripMenuItem.Name = "openTemplateImageToolStripMenuItem";
            this.openTemplateImageToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openTemplateImageToolStripMenuItem.Text = "Open Template Image...";
            this.openTemplateImageToolStripMenuItem.Click += new System.EventHandler(this.openTemplateImageToolStripMenuItem_Click);
            // 
            // openFilledImageToolStripMenuItem
            // 
            this.openFilledImageToolStripMenuItem.Name = "openFilledImageToolStripMenuItem";
            this.openFilledImageToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openFilledImageToolStripMenuItem.Text = "Open Filled Image...";
            this.openFilledImageToolStripMenuItem.Click += new System.EventHandler(this.openFilledImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageScaleModeToolStripMenuItem,
            this.alignFilledImageToolStripMenuItem,
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // imageScaleModeToolStripMenuItem
            // 
            this.imageScaleModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalImageToolStripMenuItem,
            this.bestFitToolStripMenuItem,
            this.fitToWidthToolStripMenuItem,
            this.fitToHeightToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.pixelToPixelToolStripMenuItem,
            this.toolStripSeparator2,
            this.scale25ToolStripMenuItem,
            this.scale50ToolStripMenuItem,
            this.scale100ToolStripMenuItem,
            this.scale200ToolStripMenuItem,
            this.scale400ToolStripMenuItem});
            this.imageScaleModeToolStripMenuItem.Name = "imageScaleModeToolStripMenuItem";
            this.imageScaleModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageScaleModeToolStripMenuItem.Text = "Image Scale Mode";
            // 
            // normalImageToolStripMenuItem
            // 
            this.normalImageToolStripMenuItem.Name = "normalImageToolStripMenuItem";
            this.normalImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.normalImageToolStripMenuItem.Text = "Normal";
            this.normalImageToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // bestFitToolStripMenuItem
            // 
            this.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem";
            this.bestFitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.bestFitToolStripMenuItem.Text = "Best fit";
            this.bestFitToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // fitToWidthToolStripMenuItem
            // 
            this.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem";
            this.fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // fitToHeightToolStripMenuItem
            // 
            this.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem";
            this.fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // pixelToPixelToolStripMenuItem
            // 
            this.pixelToPixelToolStripMenuItem.Name = "pixelToPixelToolStripMenuItem";
            this.pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pixelToPixelToolStripMenuItem.Text = "Pixel to pixel";
            this.pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // scale25ToolStripMenuItem
            // 
            this.scale25ToolStripMenuItem.Name = "scale25ToolStripMenuItem";
            this.scale25ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale25ToolStripMenuItem.Text = "25%";
            this.scale25ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale50ToolStripMenuItem
            // 
            this.scale50ToolStripMenuItem.Name = "scale50ToolStripMenuItem";
            this.scale50ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale50ToolStripMenuItem.Text = "50%";
            this.scale50ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale100ToolStripMenuItem
            // 
            this.scale100ToolStripMenuItem.Name = "scale100ToolStripMenuItem";
            this.scale100ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale100ToolStripMenuItem.Text = "100%";
            this.scale100ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale200ToolStripMenuItem
            // 
            this.scale200ToolStripMenuItem.Name = "scale200ToolStripMenuItem";
            this.scale200ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale200ToolStripMenuItem.Text = "200%";
            this.scale200ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale400ToolStripMenuItem
            // 
            this.scale400ToolStripMenuItem.Name = "scale400ToolStripMenuItem";
            this.scale400ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale400ToolStripMenuItem.Text = "400%";
            this.scale400ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // alignFilledImageToolStripMenuItem
            // 
            this.alignFilledImageToolStripMenuItem.Checked = true;
            this.alignFilledImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alignFilledImageToolStripMenuItem.Name = "alignFilledImageToolStripMenuItem";
            this.alignFilledImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alignFilledImageToolStripMenuItem.Text = "Align Filled Image";
            this.alignFilledImageToolStripMenuItem.Click += new System.EventHandler(this.alignFilledImageToolStripMenuItem_Click);
            // 
            // showKeyZoneRecognierPreprocessingToolStripMenuItem
            // 
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.Checked = true;
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.Name = "showKeyZoneRecognierPreprocessingToolStripMenuItem";
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.Text = "Show Preprocessing";
            this.showKeyZoneRecognierPreprocessingToolStripMenuItem.Click += new System.EventHandler(this.showKeyZoneRecognierPreprocessingToolStripMenuItem_Click);
            // 
            // templateMatchingToolStripMenuItem
            // 
            this.templateMatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showImprintsToolStripMenuItem,
            this.executeTemplateMatchingToolStripMenuItem,
            this.toolStripSeparator1,
            this.imprintPreprocessingToolStripMenuItem});
            this.templateMatchingToolStripMenuItem.Name = "templateMatchingToolStripMenuItem";
            this.templateMatchingToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.templateMatchingToolStripMenuItem.Text = "Template Matching";
            // 
            // showImprintsToolStripMenuItem
            // 
            this.showImprintsToolStripMenuItem.Name = "showImprintsToolStripMenuItem";
            this.showImprintsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.showImprintsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.showImprintsToolStripMenuItem.Text = "Show Imprints...";
            this.showImprintsToolStripMenuItem.Click += new System.EventHandler(this.showImprintsToolStripMenuItem_Click);
            // 
            // executeTemplateMatchingToolStripMenuItem
            // 
            this.executeTemplateMatchingToolStripMenuItem.Name = "executeTemplateMatchingToolStripMenuItem";
            this.executeTemplateMatchingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.executeTemplateMatchingToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.executeTemplateMatchingToolStripMenuItem.Text = "Execute Template Matching...";
            this.executeTemplateMatchingToolStripMenuItem.Click += new System.EventHandler(this.executeTemplateMatchingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // imprintPreprocessingToolStripMenuItem
            // 
            this.imprintPreprocessingToolStripMenuItem.Name = "imprintPreprocessingToolStripMenuItem";
            this.imprintPreprocessingToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.imprintPreprocessingToolStripMenuItem.Text = "Preprocessing...";
            this.imprintPreprocessingToolStripMenuItem.Click += new System.EventHandler(this.imageImprintGeneratorPreprocessingToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(884, 377);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.templateImageViewer);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template Image";
            // 
            // templateImageViewer
            // 
            this.templateImageViewer.AutoScroll = true;
            this.templateImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateImageViewer.Location = new System.Drawing.Point(3, 16);
            this.templateImageViewer.Name = "templateImageViewer";
            this.templateImageViewer.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.templateImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.templateImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.templateImageViewer.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.templateImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.templateImageViewer.Size = new System.Drawing.Size(428, 350);
            this.templateImageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.templateImageViewer.TabIndex = 0;
            this.templateImageViewer.Text = "imageViewer1";
            this.templateImageViewer.ZoomChanged += new System.EventHandler<Vintasoft.Imaging.UI.ZoomChangedEventArgs>(this.imageViewer_ZoomChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.filledImageViewer);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 369);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filled Image";
            // 
            // filledImageViewer
            // 
            this.filledImageViewer.AutoScroll = true;
            this.filledImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filledImageViewer.Location = new System.Drawing.Point(3, 16);
            this.filledImageViewer.Name = "filledImageViewer";
            this.filledImageViewer.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.Size = new System.Drawing.Size(424, 350);
            this.filledImageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.filledImageViewer.TabIndex = 0;
            this.filledImageViewer.Text = "imageViewer1";
            this.filledImageViewer.ZoomChanged += new System.EventHandler<Vintasoft.Imaging.UI.ZoomChangedEventArgs>(this.imageViewer_ZoomChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 52);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2MinSize = 60;
            this.splitContainer2.Size = new System.Drawing.Size(884, 460);
            this.splitContainer2.SplitterDistance = 377;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.transparencyNumericUpDown);
            this.groupBox3.Controls.Add(this.keyZoneLocationDeviationNumericUpDown);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nonMatchedColorPanelControl);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.matchedColorPanelControl);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.sourceColorPanelControl);
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(876, 74);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View Settings";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Key Zone Transparency";
            // 
            // transparencyNumericUpDown
            // 
            this.transparencyNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.transparencyNumericUpDown.Location = new System.Drawing.Point(751, 42);
            this.transparencyNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.transparencyNumericUpDown.Name = "transparencyNumericUpDown";
            this.transparencyNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.transparencyNumericUpDown.TabIndex = 9;
            this.transparencyNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.transparencyNumericUpDown.ValueChanged += new System.EventHandler(this.alphaColorsNumericUpDown_ValueChanged);
            // 
            // keyZoneLocationDeviationNumericUpDown
            // 
            this.keyZoneLocationDeviationNumericUpDown.Location = new System.Drawing.Point(383, 42);
            this.keyZoneLocationDeviationNumericUpDown.Name = "keyZoneLocationDeviationNumericUpDown";
            this.keyZoneLocationDeviationNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.keyZoneLocationDeviationNumericUpDown.TabIndex = 8;
            this.keyZoneLocationDeviationNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.keyZoneLocationDeviationNumericUpDown.ValueChanged += new System.EventHandler(this.keyZoneLocationDeviationNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Key Zone Matching Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 5;
            this.label3.Tag = "";
            this.label3.Text = "Non-Matched Key Zones";
            // 
            // nonMatchedColorPanelControl
            // 
            this.nonMatchedColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.nonMatchedColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.nonMatchedColorPanelControl.CanEditAlphaChannel = false;
            this.nonMatchedColorPanelControl.Location = new System.Drawing.Point(243, 40);
            this.nonMatchedColorPanelControl.Name = "nonMatchedColorPanelControl";
            this.nonMatchedColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.nonMatchedColorPanelControl.TabIndex = 4;
            this.nonMatchedColorPanelControl.ColorChanged += new System.EventHandler(this.filledImageColorPanel_ColorChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matched Key Zones";
            // 
            // matchedColorPanelControl
            // 
            this.matchedColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.matchedColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.matchedColorPanelControl.CanEditAlphaChannel = false;
            this.matchedColorPanelControl.Location = new System.Drawing.Point(125, 40);
            this.matchedColorPanelControl.Name = "matchedColorPanelControl";
            this.matchedColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.matchedColorPanelControl.TabIndex = 2;
            this.matchedColorPanelControl.Tag = "";
            this.matchedColorPanelControl.ColorChanged += new System.EventHandler(this.filledImageColorPanel_ColorChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Key Zones";
            // 
            // sourceColorPanelControl
            // 
            this.sourceColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.sourceColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.sourceColorPanelControl.CanEditAlphaChannel = false;
            this.sourceColorPanelControl.Location = new System.Drawing.Point(9, 40);
            this.sourceColorPanelControl.Name = "sourceColorPanelControl";
            this.sourceColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.sourceColorPanelControl.TabIndex = 0;
            this.sourceColorPanelControl.ColorChanged += new System.EventHandler(this.sourceColorPanelControl_ColorChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomOutButton,
            this.zoomTextBox,
            this.zoomInButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Enabled = false;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutButton.Text = "toolStripButton1";
            this.zoomOutButton.ToolTipText = "Zoom Out";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomTextBox
            // 
            this.zoomTextBox.Enabled = false;
            this.zoomTextBox.Name = "zoomTextBox";
            this.zoomTextBox.Size = new System.Drawing.Size(40, 25);
            this.zoomTextBox.Text = "100%";
            this.zoomTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoomTextBox_KeyPress);
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Enabled = false;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInButton.Text = "toolStripButton2";
            this.zoomInButton.ToolTipText = "Zoom In";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // TemplateMatchingVisualizerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "TemplateMatchingVisualizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template Matching Visualizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TemplateMatchingVisualizerForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyZoneLocationDeviationNumericUpDown)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTemplateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilledImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageScaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale400ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignFilledImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeTemplateMatchingToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Vintasoft.Imaging.UI.ImageViewer templateImageViewer;
        private Vintasoft.Imaging.UI.ImageViewer filledImageViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem showImprintsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl nonMatchedColorPanelControl;
        private System.Windows.Forms.Label label2;
        private DemosCommonCode.CustomControls.ColorPanelControl matchedColorPanelControl;
        private System.Windows.Forms.Label label1;
        private DemosCommonCode.CustomControls.ColorPanelControl sourceColorPanelControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown keyZoneLocationDeviationNumericUpDown;
        private System.Windows.Forms.ToolStripMenuItem showKeyZoneRecognierPreprocessingToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown transparencyNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem imprintPreprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripTextBox zoomTextBox;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}