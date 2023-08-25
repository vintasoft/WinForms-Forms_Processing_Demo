namespace DemosCommonCode
{
    partial class ImageProcessingForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enableImageProcessingCheckBox = new System.Windows.Forms.CheckBox();
            this.imageProcessingCommandSelectionControl1 = new DemosCommonCode.ImageProcessingCommandSelectionControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.processImageProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageViewerToolStrip1 = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(583, 501);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(664, 501);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // imageViewer1
            // 
            this.imageViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Clipboard = winFormsSystemClipboard1;
            this.imageViewer1.ImageRenderingSettings = renderingSettings1;
            this.imageViewer1.Location = new System.Drawing.Point(255, 37);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(484, 458);
            this.imageViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.PixelToPixel;
            this.imageViewer1.TabIndex = 6;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.enableImageProcessingCheckBox);
            this.groupBox1.Controls.Add(this.imageProcessingCommandSelectionControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 458);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // enableImageProcessingCheckBox
            // 
            this.enableImageProcessingCheckBox.AutoSize = true;
            this.enableImageProcessingCheckBox.Location = new System.Drawing.Point(6, 0);
            this.enableImageProcessingCheckBox.Name = "enableImageProcessingCheckBox";
            this.enableImageProcessingCheckBox.Size = new System.Drawing.Size(146, 17);
            this.enableImageProcessingCheckBox.TabIndex = 9;
            this.enableImageProcessingCheckBox.Text = "Enable Image Processing";
            this.enableImageProcessingCheckBox.UseVisualStyleBackColor = true;
            this.enableImageProcessingCheckBox.CheckedChanged += new System.EventHandler(this.enableImageProcessingCheckBox_CheckedChanged);
            // 
            // imageProcessingCommandSelectionControl1
            // 
            this.imageProcessingCommandSelectionControl1.AvailableProcessingCommands = null;
            this.imageProcessingCommandSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageProcessingCommandSelectionControl1.Enabled = false;
            this.imageProcessingCommandSelectionControl1.Location = new System.Drawing.Point(3, 16);
            this.imageProcessingCommandSelectionControl1.MinimumSize = new System.Drawing.Size(178, 283);
            this.imageProcessingCommandSelectionControl1.Name = "imageProcessingCommandSelectionControl1";
            this.imageProcessingCommandSelectionControl1.SelectedCommands = null;
            this.imageProcessingCommandSelectionControl1.Size = new System.Drawing.Size(231, 439);
            this.imageProcessingCommandSelectionControl1.TabIndex = 5;
            this.imageProcessingCommandSelectionControl1.ProcessingCommandsChanged += new System.EventHandler(this.imageProcessingCommandsEditor1_ProcessingCommandsChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processImageProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // processImageProgressBar
            // 
            this.processImageProgressBar.Name = "processImageProgressBar";
            this.processImageProgressBar.Size = new System.Drawing.Size(100, 16);
            this.processImageProgressBar.Visible = false;
            // 
            // imageViewerToolStrip1
            // 
            this.imageViewerToolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewerToolStrip1.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.imageViewerToolStrip1.CanNavigate = false;
            this.imageViewerToolStrip1.CanOpenFile = false;
            this.imageViewerToolStrip1.CanPrint = false;
            this.imageViewerToolStrip1.CanSaveFile = false;
            this.imageViewerToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.imageViewerToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.imageViewerToolStrip1.ImageViewer = this.imageViewer1;
            this.imageViewerToolStrip1.ScanButtonEnabled = true;
            this.imageViewerToolStrip1.Location = new System.Drawing.Point(632, 9);
            this.imageViewerToolStrip1.Name = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.PageCount = 0;
            this.imageViewerToolStrip1.PrintButtonEnabled = true;
            this.imageViewerToolStrip1.SaveButtonEnabled = true;
            this.imageViewerToolStrip1.Size = new System.Drawing.Size(107, 25);
            this.imageViewerToolStrip1.TabIndex = 0;
            this.imageViewerToolStrip1.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.UseImageViewerImages = true;
            // 
            // ImageProcessingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.imageViewerToolStrip1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.MinimumSize = new System.Drawing.Size(438, 434);
            this.Name = "ImageProcessingForm";
            this.Text = "Image Processing Command";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private Imaging.ImageViewerToolStrip imageViewerToolStrip1;
        private ImageProcessingCommandSelectionControl imageProcessingCommandSelectionControl1;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar processImageProgressBar;
        private System.Windows.Forms.CheckBox enableImageProcessingCheckBox;
    }
}