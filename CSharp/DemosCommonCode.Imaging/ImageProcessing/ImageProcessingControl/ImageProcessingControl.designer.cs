namespace DemosCommonCode
{
    partial class ImageProcessingControl
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
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings2 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.processedImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.executeCommandOnImageButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageProcessingCommandsEditor1 = new DemosCommonCode.ImageProcessingCommandSelectionControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(227, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceImageViewer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.processedImageViewer);
            this.splitContainer1.Size = new System.Drawing.Size(466, 539);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 7;
            // 
            // sourceImageViewer
            // 
            this.sourceImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceImageViewer.Clipboard = winFormsSystemClipboard1;
            this.sourceImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceImageViewer.ImageRenderingSettings = renderingSettings1;
            this.sourceImageViewer.ImageRotationAngle = 0;
            this.sourceImageViewer.Location = new System.Drawing.Point(0, 0);
            this.sourceImageViewer.Name = "sourceImageViewer";
            this.sourceImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.sourceImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.sourceImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.sourceImageViewer.Size = new System.Drawing.Size(231, 539);
            this.sourceImageViewer.TabIndex = 5;
            this.sourceImageViewer.Text = "imageViewer1";
            this.sourceImageViewer.ZoomChanged += new System.EventHandler<Vintasoft.Imaging.UI.ZoomChangedEventArgs>(this.sourceImageViewer_ZoomChanged);
            this.sourceImageViewer.FocusedIndexChanged += new System.EventHandler<Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs>(this.sourceImageViewer_FocusedIndexChanged);
            // 
            // processedImageViewer
            // 
            this.processedImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processedImageViewer.Clipboard = winFormsSystemClipboard1;
            this.processedImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedImageViewer.ImageRenderingSettings = renderingSettings2;
            this.processedImageViewer.ImageRotationAngle = 0;
            this.processedImageViewer.Location = new System.Drawing.Point(0, 0);
            this.processedImageViewer.Name = "processedImageViewer";
            this.processedImageViewer.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.processedImageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.processedImageViewer.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.processedImageViewer.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.processedImageViewer.Size = new System.Drawing.Size(231, 539);
            this.processedImageViewer.TabIndex = 4;
            this.processedImageViewer.Text = "imageViewer2";
            this.processedImageViewer.ZoomChanged += new System.EventHandler<Vintasoft.Imaging.UI.ZoomChangedEventArgs>(this.processedImageViewer_ZoomChanged);
            // 
            // executeCommandOnImageButton
            // 
            this.executeCommandOnImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executeCommandOnImageButton.Location = new System.Drawing.Point(12, 503);
            this.executeCommandOnImageButton.Name = "executeCommandOnImageButton";
            this.executeCommandOnImageButton.Size = new System.Drawing.Size(196, 33);
            this.executeCommandOnImageButton.TabIndex = 0;
            this.executeCommandOnImageButton.Text = "Execute commands on image";
            this.executeCommandOnImageButton.UseVisualStyleBackColor = true;
            this.executeCommandOnImageButton.Click += new System.EventHandler(this.executeCommandOnImageButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.imageProcessingCommandsEditor1);
            this.groupBox1.Controls.Add(this.executeCommandOnImageButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 542);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image processing commands";
            // 
            // imageProcessingCommandsEditor1
            // 
            this.imageProcessingCommandsEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageProcessingCommandsEditor1.AvailableProcessingCommands = null;
            this.imageProcessingCommandsEditor1.Location = new System.Drawing.Point(6, 19);
            this.imageProcessingCommandsEditor1.MinimumSize = new System.Drawing.Size(178, 283);
            this.imageProcessingCommandsEditor1.Name = "imageProcessingCommandsEditor1";
            this.imageProcessingCommandsEditor1.SelectedCommands = null;
            this.imageProcessingCommandsEditor1.Size = new System.Drawing.Size(206, 478);
            this.imageProcessingCommandsEditor1.TabIndex = 1;
            this.imageProcessingCommandsEditor1.ProcessingCommandsChanged += new System.EventHandler(this.imageProcessingCommandsEditor1_ProcessingCommandsChanged);
            // 
            // ImageProcessingControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(427, 361);
            this.Name = "ImageProcessingControl";
            this.Size = new System.Drawing.Size(696, 545);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Vintasoft.Imaging.UI.ImageViewer sourceImageViewer;
        private Vintasoft.Imaging.UI.ImageViewer processedImageViewer;
        private System.Windows.Forms.Button executeCommandOnImageButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private ImageProcessingCommandSelectionControl imageProcessingCommandsEditor1;
    }
}