namespace FormsProcessingDemo
{
    partial class ImageBinarizationForm
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
            this.applyButton = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.applyToAllButton = new System.Windows.Forms.Button();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.binarizationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.renderingSettingsButton = new System.Windows.Forms.Button();
            this.imageViewerToolStrip1 = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applyButton.Location = new System.Drawing.Point(257, 451);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(85, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(439, 451);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(85, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // applyToAllButton
            // 
            this.applyToAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applyToAllButton.Location = new System.Drawing.Point(348, 451);
            this.applyToAllButton.Name = "applyToAllButton";
            this.applyToAllButton.Size = new System.Drawing.Size(85, 23);
            this.applyToAllButton.TabIndex = 8;
            this.applyToAllButton.Text = "Apply to All";
            this.applyToAllButton.UseVisualStyleBackColor = true;
            this.applyToAllButton.Click += new System.EventHandler(this.applyToAllButton_Click);
            // 
            // imageViewer1
            // 
            this.imageViewer1.AutoScroll = true;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Location = new System.Drawing.Point(12, 49);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(512, 322);
            this.imageViewer1.TabIndex = 9;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // binarizationTypeComboBox
            // 
            this.binarizationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.binarizationTypeComboBox.FormattingEnabled = true;
            this.binarizationTypeComboBox.Location = new System.Drawing.Point(117, 394);
            this.binarizationTypeComboBox.Name = "binarizationTypeComboBox";
            this.binarizationTypeComboBox.Size = new System.Drawing.Size(142, 23);
            this.binarizationTypeComboBox.TabIndex = 10;
            this.binarizationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.binarizationTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Binarization Type:";
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsButton.Location = new System.Drawing.Point(265, 392);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(101, 23);
            this.settingsButton.TabIndex = 12;
            this.settingsButton.Text = "Settings...";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // renderingSettingsButton
            // 
            this.renderingSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renderingSettingsButton.Location = new System.Drawing.Point(372, 392);
            this.renderingSettingsButton.Name = "renderingSettingsButton";
            this.renderingSettingsButton.Size = new System.Drawing.Size(152, 23);
            this.renderingSettingsButton.TabIndex = 13;
            this.renderingSettingsButton.Text = "Rendering Settings...";
            this.renderingSettingsButton.UseVisualStyleBackColor = true;
            this.renderingSettingsButton.Click += new System.EventHandler(this.renderingSettingsButton_Click);
            // 
            // imageViewerToolStrip1
            // 
            this.imageViewerToolStrip1.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip1.CanNavigate = false;
            this.imageViewerToolStrip1.CanOpenFile = false;
            this.imageViewerToolStrip1.CanPrint = false;
            this.imageViewerToolStrip1.CanSaveFile = false;
            this.imageViewerToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.imageViewerToolStrip1.ImageViewer = this.imageViewer1;
            this.imageViewerToolStrip1.ScanButtonEnabled = true;
            this.imageViewerToolStrip1.Location = new System.Drawing.Point(12, 9);
            this.imageViewerToolStrip1.Name = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.PageCount = 0;
            this.imageViewerToolStrip1.PrintButtonEnabled = true;
            this.imageViewerToolStrip1.SaveButtonEnabled = true;
            this.imageViewerToolStrip1.Size = new System.Drawing.Size(116, 25);
            this.imageViewerToolStrip1.TabIndex = 14;
            this.imageViewerToolStrip1.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.UseImageViewerImages = true;
            // 
            // ImageBinarizationForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(536, 486);
            this.Controls.Add(this.imageViewerToolStrip1);
            this.Controls.Add(this.renderingSettingsButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.binarizationTypeComboBox);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.applyToAllButton);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.applyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageBinarizationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Binarization";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button applyToAllButton;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.ComboBox binarizationTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button renderingSettingsButton;
        private DemosCommonCode.Imaging.ImageViewerToolStrip imageViewerToolStrip1;
	}
}