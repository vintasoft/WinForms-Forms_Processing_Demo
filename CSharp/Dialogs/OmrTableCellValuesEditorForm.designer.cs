namespace FormsProcessingDemo
{
    partial class OmrTableCellValuesEditorForm
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
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cellValuesGridView = new System.Windows.Forms.DataGridView();
            this.horizontalRadioButton = new System.Windows.Forms.RadioButton();
            this.verticalRadioButton = new System.Windows.Forms.RadioButton();
            this.segmentOrientationGroupBox = new System.Windows.Forms.GroupBox();
            this.fillValuesAbcButton = new System.Windows.Forms.Button();
            this.fillValues123Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cellValuesGridView)).BeginInit();
            this.segmentOrientationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(610, 346);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(85, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(701, 346);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(85, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cellValuesGridView
            // 
            this.cellValuesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cellValuesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cellValuesGridView.Location = new System.Drawing.Point(12, 12);
            this.cellValuesGridView.Name = "cellValuesGridView";
            this.cellValuesGridView.Size = new System.Drawing.Size(582, 357);
            this.cellValuesGridView.TabIndex = 6;
            // 
            // horizontalRadioButton
            // 
            this.horizontalRadioButton.AutoSize = true;
            this.horizontalRadioButton.Checked = true;
            this.horizontalRadioButton.Location = new System.Drawing.Point(10, 19);
            this.horizontalRadioButton.Name = "horizontalRadioButton";
            this.horizontalRadioButton.Size = new System.Drawing.Size(72, 17);
            this.horizontalRadioButton.TabIndex = 7;
            this.horizontalRadioButton.TabStop = true;
            this.horizontalRadioButton.Text = "Horizontal";
            this.horizontalRadioButton.UseVisualStyleBackColor = true;
            // 
            // verticalRadioButton
            // 
            this.verticalRadioButton.AutoSize = true;
            this.verticalRadioButton.Location = new System.Drawing.Point(10, 42);
            this.verticalRadioButton.Name = "verticalRadioButton";
            this.verticalRadioButton.Size = new System.Drawing.Size(60, 17);
            this.verticalRadioButton.TabIndex = 8;
            this.verticalRadioButton.TabStop = true;
            this.verticalRadioButton.Text = "Vertical";
            this.verticalRadioButton.UseVisualStyleBackColor = true;
            // 
            // segmentOrientationGroupBox
            // 
            this.segmentOrientationGroupBox.Controls.Add(this.horizontalRadioButton);
            this.segmentOrientationGroupBox.Controls.Add(this.verticalRadioButton);
            this.segmentOrientationGroupBox.Location = new System.Drawing.Point(600, 12);
            this.segmentOrientationGroupBox.Name = "segmentOrientationGroupBox";
            this.segmentOrientationGroupBox.Size = new System.Drawing.Size(186, 74);
            this.segmentOrientationGroupBox.TabIndex = 9;
            this.segmentOrientationGroupBox.TabStop = false;
            this.segmentOrientationGroupBox.Text = "Orientation";
            // 
            // fillValuesAbcButton
            // 
            this.fillValuesAbcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fillValuesAbcButton.Location = new System.Drawing.Point(610, 92);
            this.fillValuesAbcButton.Name = "fillValuesAbcButton";
            this.fillValuesAbcButton.Size = new System.Drawing.Size(176, 23);
            this.fillValuesAbcButton.TabIndex = 10;
            this.fillValuesAbcButton.Text = "Fill values A, B, C...";
            this.fillValuesAbcButton.UseVisualStyleBackColor = true;
            this.fillValuesAbcButton.Click += new System.EventHandler(this.fillValuesAbcButton_Click);
            // 
            // fillValues123Button
            // 
            this.fillValues123Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fillValues123Button.Location = new System.Drawing.Point(610, 121);
            this.fillValues123Button.Name = "fillValues123Button";
            this.fillValues123Button.Size = new System.Drawing.Size(176, 23);
            this.fillValues123Button.TabIndex = 11;
            this.fillValues123Button.Text = "Fill values 0, 1, 2...";
            this.fillValues123Button.UseVisualStyleBackColor = true;
            this.fillValues123Button.Click += new System.EventHandler(this.fillValues123Button_Click);
            // 
            // OmrTableCellValuesEditorForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(798, 381);
            this.Controls.Add(this.fillValues123Button);
            this.Controls.Add(this.fillValuesAbcButton);
            this.Controls.Add(this.segmentOrientationGroupBox);
            this.Controls.Add(this.cellValuesGridView);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OmrTableCellValuesEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OMR Filled Mark Table Cell Value Editor";
            ((System.ComponentModel.ISupportInitialize)(this.cellValuesGridView)).EndInit();
            this.segmentOrientationGroupBox.ResumeLayout(false);
            this.segmentOrientationGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridView cellValuesGridView;
        private System.Windows.Forms.RadioButton horizontalRadioButton;
        private System.Windows.Forms.RadioButton verticalRadioButton;
        private System.Windows.Forms.GroupBox segmentOrientationGroupBox;
        private System.Windows.Forms.Button fillValuesAbcButton;
        private System.Windows.Forms.Button fillValues123Button;
	}
}