namespace FormsProcessingDemo
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption1 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings2 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFilledImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilledImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageScaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorZoomModes = new System.Windows.Forms.ToolStripSeparator();
            this.scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.formFieldViewSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oMRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeAllPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignImagesByTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.maxThreadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateMatchingConfidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.imageImprintGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineRecognizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternRecognizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineAndPatternRecognizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lineRecognizerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternRecognizerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageImprintGeneratorPreprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.templateMatchingVisualizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.recognitionProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.sourceThumbnailViewer = new Vintasoft.Imaging.UI.ThumbnailViewer();
            this.filledImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.filledImageTabPage = new System.Windows.Forms.TabPage();
            this.filledImageFilenameLabel = new System.Windows.Forms.Label();
            this.recognizedImageTabPage = new System.Windows.Forms.TabPage();
            this.matchingTemplateNameLabel = new System.Windows.Forms.Label();
            this.recognizedImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.recognitionResultTabPage = new System.Windows.Forms.TabPage();
            this.recognitionResultLabel = new System.Windows.Forms.Label();
            this.recognitionResultTextBox = new System.Windows.Forms.TextBox();
            this.recognitionLogTabPage = new System.Windows.Forms.TabPage();
            this.recognitionLogTextBox = new System.Windows.Forms.TextBox();
            this.filledImageViewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.filledImageTabPage.SuspendLayout();
            this.recognizedImageTabPage.SuspendLayout();
            this.recognitionResultTabPage.SuspendLayout();
            this.recognitionLogTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.oMRToolStripMenuItem,
            this.templateMatchingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTemplateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openFilledImagesToolStripMenuItem,
            this.addFilledImagesToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTemplateToolStripMenuItem
            // 
            this.openTemplateToolStripMenuItem.Name = "openTemplateToolStripMenuItem";
            this.openTemplateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.openTemplateToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.openTemplateToolStripMenuItem.Text = "Manage Templates...";
            this.openTemplateToolStripMenuItem.Click += new System.EventHandler(this.openTemplateEditorFormToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(249, 6);
            // 
            // openFilledImagesToolStripMenuItem
            // 
            this.openFilledImagesToolStripMenuItem.Name = "openFilledImagesToolStripMenuItem";
            this.openFilledImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFilledImagesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.openFilledImagesToolStripMenuItem.Text = "Open Filled Images...";
            this.openFilledImagesToolStripMenuItem.Click += new System.EventHandler(this.openFilledImagesToolStripMenuItem_Click);
            // 
            // addFilledImagesToolStripMenuItem
            // 
            this.addFilledImagesToolStripMenuItem.Name = "addFilledImagesToolStripMenuItem";
            this.addFilledImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addFilledImagesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.addFilledImagesToolStripMenuItem.Text = "Add Filled Images...";
            this.addFilledImagesToolStripMenuItem.Click += new System.EventHandler(this.addFilledImagesToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageViewerSettingsToolStripMenuItem,
            this.imageScaleModeToolStripMenuItem,
            this.rotateViewToolStripMenuItem,
            this.toolStripSeparator5,
            this.formFieldViewSettingsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // imageViewerSettingsToolStripMenuItem
            // 
            this.imageViewerSettingsToolStripMenuItem.Name = "imageViewerSettingsToolStripMenuItem";
            this.imageViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.imageViewerSettingsToolStripMenuItem.Text = "Image Viewer Settings...";
            this.imageViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.imageViewerSettingsToolStripMenuItem_Click);
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
            this.toolStripSeparatorZoomModes,
            this.scale25ToolStripMenuItem,
            this.scale50ToolStripMenuItem,
            this.scale100ToolStripMenuItem,
            this.scale200ToolStripMenuItem,
            this.scale400ToolStripMenuItem});
            this.imageScaleModeToolStripMenuItem.Name = "imageScaleModeToolStripMenuItem";
            this.imageScaleModeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.imageScaleModeToolStripMenuItem.Text = "Image Scale Mode";
            // 
            // normalImageToolStripMenuItem
            // 
            this.normalImageToolStripMenuItem.Name = "normalImageToolStripMenuItem";
            this.normalImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.normalImageToolStripMenuItem.Text = "Normal";
            this.normalImageToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // bestFitToolStripMenuItem
            // 
            this.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem";
            this.bestFitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.bestFitToolStripMenuItem.Text = "Best fit";
            this.bestFitToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // fitToWidthToolStripMenuItem
            // 
            this.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem";
            this.fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // fitToHeightToolStripMenuItem
            // 
            this.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem";
            this.fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // pixelToPixelToolStripMenuItem
            // 
            this.pixelToPixelToolStripMenuItem.Name = "pixelToPixelToolStripMenuItem";
            this.pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.pixelToPixelToolStripMenuItem.Text = "Pixel to pixel";
            this.pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // toolStripSeparatorZoomModes
            // 
            this.toolStripSeparatorZoomModes.Name = "toolStripSeparatorZoomModes";
            this.toolStripSeparatorZoomModes.Size = new System.Drawing.Size(138, 6);
            // 
            // scale25ToolStripMenuItem
            // 
            this.scale25ToolStripMenuItem.Name = "scale25ToolStripMenuItem";
            this.scale25ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale25ToolStripMenuItem.Text = "25%";
            this.scale25ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // scale50ToolStripMenuItem
            // 
            this.scale50ToolStripMenuItem.Name = "scale50ToolStripMenuItem";
            this.scale50ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale50ToolStripMenuItem.Text = "50%";
            this.scale50ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // scale100ToolStripMenuItem
            // 
            this.scale100ToolStripMenuItem.Name = "scale100ToolStripMenuItem";
            this.scale100ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale100ToolStripMenuItem.Text = "100%";
            this.scale100ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // scale200ToolStripMenuItem
            // 
            this.scale200ToolStripMenuItem.Name = "scale200ToolStripMenuItem";
            this.scale200ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale200ToolStripMenuItem.Text = "200%";
            this.scale200ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // scale400ToolStripMenuItem
            // 
            this.scale400ToolStripMenuItem.Name = "scale400ToolStripMenuItem";
            this.scale400ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale400ToolStripMenuItem.Text = "400%";
            this.scale400ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // rotateViewToolStripMenuItem
            // 
            this.rotateViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateClockwiseToolStripMenuItem,
            this.counterclockwiseToolStripMenuItem});
            this.rotateViewToolStripMenuItem.Name = "rotateViewToolStripMenuItem";
            this.rotateViewToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.rotateViewToolStripMenuItem.Text = "Rotate View";
            // 
            // rotateClockwiseToolStripMenuItem
            // 
            this.rotateClockwiseToolStripMenuItem.Name = "rotateClockwiseToolStripMenuItem";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Plus";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Oemplus)));
            this.rotateClockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rotateClockwiseToolStripMenuItem.Text = "Clockwise";
            this.rotateClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateClockwiseToolStripMenuItem_Click);
            // 
            // counterclockwiseToolStripMenuItem
            // 
            this.counterclockwiseToolStripMenuItem.Name = "counterclockwiseToolStripMenuItem";
            this.counterclockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Minus";
            this.counterclockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.OemMinus)));
            this.counterclockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.counterclockwiseToolStripMenuItem.Text = "Counterclockwise";
            this.counterclockwiseToolStripMenuItem.Click += new System.EventHandler(this.counterclockwiseToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(209, 6);
            // 
            // formFieldViewSettingsToolStripMenuItem
            // 
            this.formFieldViewSettingsToolStripMenuItem.Name = "formFieldViewSettingsToolStripMenuItem";
            this.formFieldViewSettingsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.formFieldViewSettingsToolStripMenuItem.Text = "Form Field View Settings...";
            this.formFieldViewSettingsToolStripMenuItem.Click += new System.EventHandler(this.formFieldViewSettingsToolStripMenuItem_Click);
            // 
            // oMRToolStripMenuItem
            // 
            this.oMRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recognizeCurrentPageToolStripMenuItem,
            this.recognizeAllPagesToolStripMenuItem,
            this.alignImagesByTemplateToolStripMenuItem,
            this.toolStripSeparator1,
            this.maxThreadsToolStripMenuItem});
            this.oMRToolStripMenuItem.Name = "oMRToolStripMenuItem";
            this.oMRToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.oMRToolStripMenuItem.Text = "Forms Recognition";
            // 
            // recognizeCurrentPageToolStripMenuItem
            // 
            this.recognizeCurrentPageToolStripMenuItem.Name = "recognizeCurrentPageToolStripMenuItem";
            this.recognizeCurrentPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.recognizeCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.recognizeCurrentPageToolStripMenuItem.Text = "Recognize Current Page";
            this.recognizeCurrentPageToolStripMenuItem.Click += new System.EventHandler(this.recognizeCurrentPageToolStripMenuItem_Click);
            // 
            // recognizeAllPagesToolStripMenuItem
            // 
            this.recognizeAllPagesToolStripMenuItem.Name = "recognizeAllPagesToolStripMenuItem";
            this.recognizeAllPagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.recognizeAllPagesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.recognizeAllPagesToolStripMenuItem.Text = "Recognize All Pages";
            this.recognizeAllPagesToolStripMenuItem.Click += new System.EventHandler(this.recognizeAllPagesToolStripMenuItem_Click);
            // 
            // alignImagesByTemplateToolStripMenuItem
            // 
            this.alignImagesByTemplateToolStripMenuItem.CheckOnClick = true;
            this.alignImagesByTemplateToolStripMenuItem.Name = "alignImagesByTemplateToolStripMenuItem";
            this.alignImagesByTemplateToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.alignImagesByTemplateToolStripMenuItem.Text = "Align Recognized Images";
            this.alignImagesByTemplateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.alignImagesByTemplateToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // maxThreadsToolStripMenuItem
            // 
            this.maxThreadsToolStripMenuItem.Name = "maxThreadsToolStripMenuItem";
            this.maxThreadsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.maxThreadsToolStripMenuItem.Text = "Max Threads...";
            this.maxThreadsToolStripMenuItem.Click += new System.EventHandler(this.maxThreadsToolStripMenuItem_Click);
            // 
            // templateMatchingToolStripMenuItem
            // 
            this.templateMatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateMatchingConfidenceToolStripMenuItem,
            this.toolStripSeparator4,
            this.imageImprintGeneratorToolStripMenuItem,
            this.imageImprintGeneratorPreprocessingToolStripMenuItem,
            this.toolStripSeparator2,
            this.templateMatchingVisualizerToolStripMenuItem});
            this.templateMatchingToolStripMenuItem.Name = "templateMatchingToolStripMenuItem";
            this.templateMatchingToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.templateMatchingToolStripMenuItem.Text = "Template Matching";
            // 
            // templateMatchingConfidenceToolStripMenuItem
            // 
            this.templateMatchingConfidenceToolStripMenuItem.Name = "templateMatchingConfidenceToolStripMenuItem";
            this.templateMatchingConfidenceToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.templateMatchingConfidenceToolStripMenuItem.Text = "Template Matching Confidence...";
            this.templateMatchingConfidenceToolStripMenuItem.Click += new System.EventHandler(this.templateMatchingConfidenceToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(287, 6);
            // 
            // imageImprintGeneratorToolStripMenuItem
            // 
            this.imageImprintGeneratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineRecognizerToolStripMenuItem,
            this.patternRecognizerToolStripMenuItem,
            this.lineAndPatternRecognizerToolStripMenuItem,
            this.toolStripSeparator3,
            this.lineRecognizerSettingsToolStripMenuItem,
            this.patternRecognizerSettingsToolStripMenuItem});
            this.imageImprintGeneratorToolStripMenuItem.Name = "imageImprintGeneratorToolStripMenuItem";
            this.imageImprintGeneratorToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.imageImprintGeneratorToolStripMenuItem.Text = "Image Imprint Generator";
            // 
            // lineRecognizerToolStripMenuItem
            // 
            this.lineRecognizerToolStripMenuItem.Checked = true;
            this.lineRecognizerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineRecognizerToolStripMenuItem.Name = "lineRecognizerToolStripMenuItem";
            this.lineRecognizerToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.lineRecognizerToolStripMenuItem.Text = "Line Recognizer";
            this.lineRecognizerToolStripMenuItem.Click += new System.EventHandler(this.recognizerToolStripMenuItem_Click);
            // 
            // patternRecognizerToolStripMenuItem
            // 
            this.patternRecognizerToolStripMenuItem.Name = "patternRecognizerToolStripMenuItem";
            this.patternRecognizerToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.patternRecognizerToolStripMenuItem.Text = "\'L\' Pattern Recognizer";
            this.patternRecognizerToolStripMenuItem.Click += new System.EventHandler(this.recognizerToolStripMenuItem_Click);
            // 
            // lineAndPatternRecognizerToolStripMenuItem
            // 
            this.lineAndPatternRecognizerToolStripMenuItem.Name = "lineAndPatternRecognizerToolStripMenuItem";
            this.lineAndPatternRecognizerToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.lineAndPatternRecognizerToolStripMenuItem.Text = "Line and \'L\' Pattern Recognizer";
            this.lineAndPatternRecognizerToolStripMenuItem.Click += new System.EventHandler(this.recognizerToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(239, 6);
            // 
            // lineRecognizerSettingsToolStripMenuItem
            // 
            this.lineRecognizerSettingsToolStripMenuItem.Name = "lineRecognizerSettingsToolStripMenuItem";
            this.lineRecognizerSettingsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.lineRecognizerSettingsToolStripMenuItem.Text = "Line Recognizer Settings...";
            this.lineRecognizerSettingsToolStripMenuItem.Click += new System.EventHandler(this.lineRecognizerSettingsToolStripMenuItem_Click);
            // 
            // patternRecognizerSettingsToolStripMenuItem
            // 
            this.patternRecognizerSettingsToolStripMenuItem.Name = "patternRecognizerSettingsToolStripMenuItem";
            this.patternRecognizerSettingsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.patternRecognizerSettingsToolStripMenuItem.Text = "\'L\' Pattern Recognizer Settings...";
            this.patternRecognizerSettingsToolStripMenuItem.Click += new System.EventHandler(this.patternRecognizerSettingsToolStripMenuItem_Click);
            // 
            // imageImprintGeneratorPreprocessingToolStripMenuItem
            // 
            this.imageImprintGeneratorPreprocessingToolStripMenuItem.Name = "imageImprintGeneratorPreprocessingToolStripMenuItem";
            this.imageImprintGeneratorPreprocessingToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.imageImprintGeneratorPreprocessingToolStripMenuItem.Text = "Image Imprint Generator Preprocessing...";
            this.imageImprintGeneratorPreprocessingToolStripMenuItem.Click += new System.EventHandler(this.imageImprintGeneratorPreprocessingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(287, 6);
            // 
            // templateMatchingVisualizerToolStripMenuItem
            // 
            this.templateMatchingVisualizerToolStripMenuItem.Name = "templateMatchingVisualizerToolStripMenuItem";
            this.templateMatchingVisualizerToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.templateMatchingVisualizerToolStripMenuItem.Text = "Template Matching Visualizer...";
            this.templateMatchingVisualizerToolStripMenuItem.Click += new System.EventHandler(this.templateMatchingVisualizerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recognitionProgressBar,
            this.imageInfoLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // recognitionProgressBar
            // 
            this.recognitionProgressBar.Name = "recognitionProgressBar";
            this.recognitionProgressBar.Size = new System.Drawing.Size(100, 16);
            this.recognitionProgressBar.Visible = false;
            // 
            // imageInfoLabel
            // 
            this.imageInfoLabel.Name = "imageInfoLabel";
            this.imageInfoLabel.Size = new System.Drawing.Size(869, 17);
            this.imageInfoLabel.Spring = true;
            this.imageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 52);
            this.splitContainerLeft.Name = "splitContainerLeft";
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.sourceThumbnailViewer);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.tabControl1);
            this.splitContainerLeft.Size = new System.Drawing.Size(884, 535);
            this.splitContainerLeft.SplitterDistance = 254;
            this.splitContainerLeft.TabIndex = 3;
            // 
            // sourceThumbnailViewer
            // 
            this.sourceThumbnailViewer.AllowDrop = true;
            this.sourceThumbnailViewer.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.sourceThumbnailViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceThumbnailViewer.Clipboard = winFormsSystemClipboard1;
            this.sourceThumbnailViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.sourceThumbnailViewer.FocusedThumbnailAppearance = thumbnailAppearance1;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.sourceThumbnailViewer.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.sourceThumbnailViewer.ImageRotationAngle = 0;
            this.sourceThumbnailViewer.Location = new System.Drawing.Point(0, 0);
            this.sourceThumbnailViewer.MasterViewer = this.filledImageViewer;
            this.sourceThumbnailViewer.Name = "sourceThumbnailViewer";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.sourceThumbnailViewer.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.sourceThumbnailViewer.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.sourceThumbnailViewer.Size = new System.Drawing.Size(254, 535);
            this.sourceThumbnailViewer.TabIndex = 0;
            this.sourceThumbnailViewer.Text = "thumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.sourceThumbnailViewer.ThumbnailAppearance = thumbnailAppearance5;
            thumbnailCaption1.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption1.TextColor = System.Drawing.Color.Black;
            this.sourceThumbnailViewer.ThumbnailCaption = thumbnailCaption1;
            this.sourceThumbnailViewer.ThumbnailControlPadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.sourceThumbnailViewer.ThumbnailFlowStyle = Vintasoft.Imaging.UI.ThumbnailFlowStyle.WrappedRows;
            this.sourceThumbnailViewer.ThumbnailImagePadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.sourceThumbnailViewer.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.sourceThumbnailViewer.ThumbnailRenderingThreadCount = 4;
            this.sourceThumbnailViewer.ThumbnailSize = new System.Drawing.Size(100, 100);
            // 
            // filledImageViewer
            // 
            this.filledImageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filledImageViewer.BackColor = System.Drawing.SystemColors.Control;
            this.filledImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filledImageViewer.Clipboard = winFormsSystemClipboard1;
            this.filledImageViewer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filledImageViewer.ImageRenderingSettings = renderingSettings1;
            this.filledImageViewer.ImageRotationAngle = 0;
            this.filledImageViewer.Location = new System.Drawing.Point(3, 46);
            this.filledImageViewer.Name = "filledImageViewer";
            this.filledImageViewer.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.filledImageViewer.Size = new System.Drawing.Size(606, 442);
            this.filledImageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.filledImageViewer.TabIndex = 1;
            this.filledImageViewer.Text = "imageViewer1";
            this.filledImageViewer.ZoomChanged += new System.EventHandler<Vintasoft.Imaging.UI.ZoomChangedEventArgs>(this.filledImageViewer_ZoomChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.filledImageTabPage);
            this.tabControl1.Controls.Add(this.recognizedImageTabPage);
            this.tabControl1.Controls.Add(this.recognitionResultTabPage);
            this.tabControl1.Controls.Add(this.recognitionLogTabPage);
            this.tabControl1.ItemSize = new System.Drawing.Size(67, 30);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 529);
            this.tabControl1.TabIndex = 0;
            // 
            // filledImageTabPage
            // 
            this.filledImageTabPage.Controls.Add(this.filledImageFilenameLabel);
            this.filledImageTabPage.Controls.Add(this.filledImageViewer);
            this.filledImageTabPage.Location = new System.Drawing.Point(4, 34);
            this.filledImageTabPage.Name = "filledImageTabPage";
            this.filledImageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filledImageTabPage.Size = new System.Drawing.Size(612, 491);
            this.filledImageTabPage.TabIndex = 0;
            this.filledImageTabPage.Text = "Filled Image";
            this.filledImageTabPage.UseVisualStyleBackColor = true;
            // 
            // filledImageFilenameLabel
            // 
            this.filledImageFilenameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filledImageFilenameLabel.Location = new System.Drawing.Point(6, 12);
            this.filledImageFilenameLabel.Name = "filledImageFilenameLabel";
            this.filledImageFilenameLabel.Size = new System.Drawing.Size(600, 20);
            this.filledImageFilenameLabel.TabIndex = 3;
            this.filledImageFilenameLabel.Text = "Filled image: <filled image>";
            this.filledImageFilenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recognizedImageTabPage
            // 
            this.recognizedImageTabPage.Controls.Add(this.matchingTemplateNameLabel);
            this.recognizedImageTabPage.Controls.Add(this.recognizedImageViewer);
            this.recognizedImageTabPage.Location = new System.Drawing.Point(4, 34);
            this.recognizedImageTabPage.Name = "recognizedImageTabPage";
            this.recognizedImageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.recognizedImageTabPage.Size = new System.Drawing.Size(612, 491);
            this.recognizedImageTabPage.TabIndex = 1;
            this.recognizedImageTabPage.Text = "Recognized Image";
            this.recognizedImageTabPage.UseVisualStyleBackColor = true;
            // 
            // matchingTemplateNameLabel
            // 
            this.matchingTemplateNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchingTemplateNameLabel.Location = new System.Drawing.Point(6, 12);
            this.matchingTemplateNameLabel.Name = "matchingTemplateNameLabel";
            this.matchingTemplateNameLabel.Size = new System.Drawing.Size(500, 20);
            this.matchingTemplateNameLabel.TabIndex = 4;
            this.matchingTemplateNameLabel.Text = "Matching template\'s name: <matching template\'s name>";
            this.matchingTemplateNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recognizedImageViewer
            // 
            this.recognizedImageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognizedImageViewer.BackColor = System.Drawing.SystemColors.Control;
            this.recognizedImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recognizedImageViewer.Clipboard = winFormsSystemClipboard1;
            this.recognizedImageViewer.ImageRenderingSettings = renderingSettings2;
            this.recognizedImageViewer.ImageRotationAngle = 0;
            this.recognizedImageViewer.Location = new System.Drawing.Point(3, 46);
            this.recognizedImageViewer.Name = "recognizedImageViewer";
            this.recognizedImageViewer.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.recognizedImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.recognizedImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.recognizedImageViewer.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.recognizedImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.recognizedImageViewer.Size = new System.Drawing.Size(606, 442);
            this.recognizedImageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.recognizedImageViewer.TabIndex = 1;
            this.recognizedImageViewer.Text = "imageViewer3";
            // 
            // recognitionResultTabPage
            // 
            this.recognitionResultTabPage.Controls.Add(this.recognitionResultLabel);
            this.recognitionResultTabPage.Controls.Add(this.recognitionResultTextBox);
            this.recognitionResultTabPage.Location = new System.Drawing.Point(4, 34);
            this.recognitionResultTabPage.Name = "recognitionResultTabPage";
            this.recognitionResultTabPage.Size = new System.Drawing.Size(612, 491);
            this.recognitionResultTabPage.TabIndex = 2;
            this.recognitionResultTabPage.Text = "Recognition Result";
            this.recognitionResultTabPage.UseVisualStyleBackColor = true;
            // 
            // recognitionResultLabel
            // 
            this.recognitionResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognitionResultLabel.Location = new System.Drawing.Point(6, 12);
            this.recognitionResultLabel.Name = "recognitionResultLabel";
            this.recognitionResultLabel.Size = new System.Drawing.Size(500, 20);
            this.recognitionResultLabel.TabIndex = 4;
            this.recognitionResultLabel.Text = "Matching template\'s name: <matching template\'s name>";
            this.recognitionResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recognitionResultTextBox
            // 
            this.recognitionResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognitionResultTextBox.Location = new System.Drawing.Point(3, 46);
            this.recognitionResultTextBox.Multiline = true;
            this.recognitionResultTextBox.Name = "recognitionResultTextBox";
            this.recognitionResultTextBox.ReadOnly = true;
            this.recognitionResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recognitionResultTextBox.Size = new System.Drawing.Size(604, 442);
            this.recognitionResultTextBox.TabIndex = 0;
            // 
            // recognitionLogTabPage
            // 
            this.recognitionLogTabPage.Controls.Add(this.recognitionLogTextBox);
            this.recognitionLogTabPage.Location = new System.Drawing.Point(4, 34);
            this.recognitionLogTabPage.Name = "recognitionLogTabPage";
            this.recognitionLogTabPage.Size = new System.Drawing.Size(612, 491);
            this.recognitionLogTabPage.TabIndex = 3;
            this.recognitionLogTabPage.Text = "Recognition Log";
            this.recognitionLogTabPage.UseVisualStyleBackColor = true;
            // 
            // recognitionLogTextBox
            // 
            this.recognitionLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognitionLogTextBox.Location = new System.Drawing.Point(3, 3);
            this.recognitionLogTextBox.Multiline = true;
            this.recognitionLogTextBox.Name = "recognitionLogTextBox";
            this.recognitionLogTextBox.ReadOnly = true;
            this.recognitionLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recognitionLogTextBox.Size = new System.Drawing.Size(604, 485);
            this.recognitionLogTextBox.TabIndex = 1;
            // 
            // filledImageViewerToolStrip
            // 
            this.filledImageViewerToolStrip.AssociatedZoomTrackBar = null;
            this.filledImageViewerToolStrip.CanPrint = false;
            this.filledImageViewerToolStrip.CanSaveFile = false;
            this.filledImageViewerToolStrip.CaptureFromCameraButtonEnabled = true;
            this.filledImageViewerToolStrip.ImageViewer = this.filledImageViewer;
            this.filledImageViewerToolStrip.Location = new System.Drawing.Point(0, 24);
            this.filledImageViewerToolStrip.Name = "filledImageViewerToolStrip";
            this.filledImageViewerToolStrip.PageCount = 0;
            this.filledImageViewerToolStrip.PrintButtonEnabled = true;
            this.filledImageViewerToolStrip.ScanButtonEnabled = true;
            this.filledImageViewerToolStrip.Size = new System.Drawing.Size(884, 25);
            this.filledImageViewerToolStrip.TabIndex = 0;
            this.filledImageViewerToolStrip.Text = "imageViewerToolStrip1";
            this.filledImageViewerToolStrip.UseImageViewerImages = true;
            this.filledImageViewerToolStrip.OpenFile += new System.EventHandler(this.openFilledImagesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.filledImageViewerToolStrip);
            this.Controls.Add(this.splitContainerLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            this.splitContainerLeft.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.filledImageTabPage.ResumeLayout(false);
            this.recognizedImageTabPage.ResumeLayout(false);
            this.recognitionResultTabPage.ResumeLayout(false);
            this.recognitionResultTabPage.PerformLayout();
            this.recognitionLogTabPage.ResumeLayout(false);
            this.recognitionLogTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTemplateToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Vintasoft.Imaging.UI.ThumbnailViewer sourceThumbnailViewer;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private DemosCommonCode.Imaging.ImageViewerToolStrip filledImageViewerToolStrip;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel imageInfoLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openFilledImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilledImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oMRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recognizeAllPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recognizeCurrentPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignImagesByTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageScaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorZoomModes;
        private System.Windows.Forms.ToolStripMenuItem scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale400ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem counterclockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private Vintasoft.Imaging.UI.ImageViewer filledImageViewer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage filledImageTabPage;
        private System.Windows.Forms.TabPage recognizedImageTabPage;
        private Vintasoft.Imaging.UI.ImageViewer recognizedImageViewer;
        private System.Windows.Forms.TabPage recognitionResultTabPage;
        private System.Windows.Forms.Label filledImageFilenameLabel;
        private System.Windows.Forms.Label matchingTemplateNameLabel;
        private System.Windows.Forms.TextBox recognitionResultTextBox;
        private System.Windows.Forms.Label recognitionResultLabel;
        private System.Windows.Forms.TabPage recognitionLogTabPage;
        private System.Windows.Forms.TextBox recognitionLogTextBox;
        private System.Windows.Forms.ToolStripProgressBar recognitionProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem maxThreadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageImprintGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineRecognizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternRecognizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineAndPatternRecognizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem lineRecognizerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternRecognizerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageImprintGeneratorPreprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateMatchingConfidenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateMatchingVisualizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem formFieldViewSettingsToolStripMenuItem;
    }
}