namespace DemosCommonCode.Imaging
{
    partial class OcrSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageBinarizationModeComboBox = new System.Windows.Forms.ComboBox();
            this.useCustomDictionariesCheckBox = new System.Windows.Forms.CheckBox();
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.charsWhitelistLabel = new System.Windows.Forms.Label();
            this.charsWhiteListTextBox = new System.Windows.Forms.TextBox();
            this.maxBlobOverlapsLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxBlobOverlapsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recognitionRegionTypeLabel = new System.Windows.Forms.Label();
            this.recognitionRegionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.recognitionModeComboBox = new System.Windows.Forms.ComboBox();
            this.recognitionModeLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxWordSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxRegionHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxRegionWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.useMultithreadingGroupBox = new System.Windows.Forms.GroupBox();
            this.resetMaxThreadsButton = new System.Windows.Forms.Button();
            this.maxThreadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxThreadsTrackBar = new System.Windows.Forms.TrackBar();
            this.useMultithreadingCheckBox = new System.Windows.Forms.CheckBox();
            this.selectLanguagesButton = new System.Windows.Forms.Button();
            this.useSymbolRegionsCorrectionCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlobOverlapsNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxWordSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRegionHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRegionWidthNumericUpDown)).BeginInit();
            this.useMultithreadingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Binarization";
            // 
            // imageBinarizationModeComboBox
            // 
            this.imageBinarizationModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBinarizationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageBinarizationModeComboBox.FormattingEnabled = true;
            this.imageBinarizationModeComboBox.Location = new System.Drawing.Point(153, 103);
            this.imageBinarizationModeComboBox.Name = "imageBinarizationModeComboBox";
            this.imageBinarizationModeComboBox.Size = new System.Drawing.Size(358, 21);
            this.imageBinarizationModeComboBox.TabIndex = 3;
            // 
            // useCustomDictionariesCheckBox
            // 
            this.useCustomDictionariesCheckBox.AutoSize = true;
            this.useCustomDictionariesCheckBox.Location = new System.Drawing.Point(15, 132);
            this.useCustomDictionariesCheckBox.Name = "useCustomDictionariesCheckBox";
            this.useCustomDictionariesCheckBox.Size = new System.Drawing.Size(138, 17);
            this.useCustomDictionariesCheckBox.TabIndex = 4;
            this.useCustomDictionariesCheckBox.Text = "Use custom dictionaries";
            this.useCustomDictionariesCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightLowConfidenceWordsAfterRecognitionCheckBox
            // 
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.AutoSize = true;
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.Location = new System.Drawing.Point(12, 457);
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.Name = "highlightLowConfidenceWordsAfterRecognitionCheckBox";
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.Size = new System.Drawing.Size(323, 17);
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.TabIndex = 5;
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.Text = "Select low-confidence words after recognition (\"Select\" button)";
            this.highlightLowConfidenceWordsAfterRecognitionCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(184, 489);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(265, 489);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // charsWhitelistLabel
            // 
            this.charsWhitelistLabel.AutoSize = true;
            this.charsWhitelistLabel.Location = new System.Drawing.Point(6, 22);
            this.charsWhitelistLabel.Name = "charsWhitelistLabel";
            this.charsWhitelistLabel.Size = new System.Drawing.Size(74, 13);
            this.charsWhitelistLabel.TabIndex = 8;
            this.charsWhitelistLabel.Text = "Chars whitelist";
            // 
            // charsWhiteListTextBox
            // 
            this.charsWhiteListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charsWhiteListTextBox.Location = new System.Drawing.Point(140, 19);
            this.charsWhiteListTextBox.Name = "charsWhiteListTextBox";
            this.charsWhiteListTextBox.Size = new System.Drawing.Size(348, 20);
            this.charsWhiteListTextBox.TabIndex = 9;
            // 
            // maxBlobOverlapsLabel
            // 
            this.maxBlobOverlapsLabel.AutoSize = true;
            this.maxBlobOverlapsLabel.Location = new System.Drawing.Point(6, 52);
            this.maxBlobOverlapsLabel.Name = "maxBlobOverlapsLabel";
            this.maxBlobOverlapsLabel.Size = new System.Drawing.Size(93, 13);
            this.maxBlobOverlapsLabel.TabIndex = 10;
            this.maxBlobOverlapsLabel.Text = "Max blob overlaps";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.maxBlobOverlapsNumericUpDown);
            this.groupBox1.Controls.Add(this.charsWhiteListTextBox);
            this.groupBox1.Controls.Add(this.maxBlobOverlapsLabel);
            this.groupBox1.Controls.Add(this.charsWhitelistLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tesseract OCR variables";
            // 
            // maxBlobOverlapsNumericUpDown
            // 
            this.maxBlobOverlapsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBlobOverlapsNumericUpDown.Location = new System.Drawing.Point(140, 50);
            this.maxBlobOverlapsNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxBlobOverlapsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxBlobOverlapsNumericUpDown.Name = "maxBlobOverlapsNumericUpDown";
            this.maxBlobOverlapsNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.maxBlobOverlapsNumericUpDown.TabIndex = 11;
            this.maxBlobOverlapsNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // recognitionRegionTypeLabel
            // 
            this.recognitionRegionTypeLabel.AutoSize = true;
            this.recognitionRegionTypeLabel.Location = new System.Drawing.Point(13, 77);
            this.recognitionRegionTypeLabel.Name = "recognitionRegionTypeLabel";
            this.recognitionRegionTypeLabel.Size = new System.Drawing.Size(119, 13);
            this.recognitionRegionTypeLabel.TabIndex = 13;
            this.recognitionRegionTypeLabel.Text = "Recognition region type";
            // 
            // recognitionRegionTypeComboBox
            // 
            this.recognitionRegionTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognitionRegionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recognitionRegionTypeComboBox.FormattingEnabled = true;
            this.recognitionRegionTypeComboBox.Location = new System.Drawing.Point(153, 74);
            this.recognitionRegionTypeComboBox.Name = "recognitionRegionTypeComboBox";
            this.recognitionRegionTypeComboBox.Size = new System.Drawing.Size(358, 21);
            this.recognitionRegionTypeComboBox.TabIndex = 14;
            // 
            // recognitionModeComboBox
            // 
            this.recognitionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognitionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recognitionModeComboBox.FormattingEnabled = true;
            this.recognitionModeComboBox.Location = new System.Drawing.Point(153, 45);
            this.recognitionModeComboBox.Name = "recognitionModeComboBox";
            this.recognitionModeComboBox.Size = new System.Drawing.Size(358, 21);
            this.recognitionModeComboBox.TabIndex = 16;
            // 
            // recognitionModeLabel
            // 
            this.recognitionModeLabel.AutoSize = true;
            this.recognitionModeLabel.Location = new System.Drawing.Point(13, 48);
            this.recognitionModeLabel.Name = "recognitionModeLabel";
            this.recognitionModeLabel.Size = new System.Drawing.Size(93, 13);
            this.recognitionModeLabel.TabIndex = 15;
            this.recognitionModeLabel.Text = "Recognition mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.maxWordSizeNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.maxRegionHeightNumericUpDown);
            this.groupBox2.Controls.Add(this.maxRegionWidthNumericUpDown);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 101);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Splitting Settings";
            // 
            // maxWordSizeNumericUpDown
            // 
            this.maxWordSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxWordSizeNumericUpDown.Location = new System.Drawing.Point(140, 71);
            this.maxWordSizeNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.maxWordSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxWordSizeNumericUpDown.Name = "maxWordSizeNumericUpDown";
            this.maxWordSizeNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.maxWordSizeNumericUpDown.TabIndex = 5;
            this.maxWordSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Max word size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max region height";
            // 
            // maxRegionHeightNumericUpDown
            // 
            this.maxRegionHeightNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxRegionHeightNumericUpDown.Location = new System.Drawing.Point(140, 45);
            this.maxRegionHeightNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.maxRegionHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRegionHeightNumericUpDown.Name = "maxRegionHeightNumericUpDown";
            this.maxRegionHeightNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.maxRegionHeightNumericUpDown.TabIndex = 2;
            this.maxRegionHeightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxRegionWidthNumericUpDown
            // 
            this.maxRegionWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxRegionWidthNumericUpDown.Location = new System.Drawing.Point(140, 19);
            this.maxRegionWidthNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.maxRegionWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRegionWidthNumericUpDown.Name = "maxRegionWidthNumericUpDown";
            this.maxRegionWidthNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.maxRegionWidthNumericUpDown.TabIndex = 1;
            this.maxRegionWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max region width";
            // 
            // useMultithreadingGroupBox
            // 
            this.useMultithreadingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useMultithreadingGroupBox.Controls.Add(this.resetMaxThreadsButton);
            this.useMultithreadingGroupBox.Controls.Add(this.maxThreadsNumericUpDown);
            this.useMultithreadingGroupBox.Controls.Add(this.useMultithreadingCheckBox);
            this.useMultithreadingGroupBox.Controls.Add(this.maxThreadsTrackBar);
            this.useMultithreadingGroupBox.Location = new System.Drawing.Point(15, 377);
            this.useMultithreadingGroupBox.Name = "useMultithreadingGroupBox";
            this.useMultithreadingGroupBox.Size = new System.Drawing.Size(497, 74);
            this.useMultithreadingGroupBox.TabIndex = 18;
            this.useMultithreadingGroupBox.TabStop = false;
            // 
            // resetMaxThreadsButton
            // 
            this.resetMaxThreadsButton.Location = new System.Drawing.Point(408, 42);
            this.resetMaxThreadsButton.Name = "resetMaxThreadsButton";
            this.resetMaxThreadsButton.Size = new System.Drawing.Size(75, 23);
            this.resetMaxThreadsButton.TabIndex = 2;
            this.resetMaxThreadsButton.Text = "Reset";
            this.resetMaxThreadsButton.UseVisualStyleBackColor = true;
            this.resetMaxThreadsButton.Click += new System.EventHandler(this.resetMaxThreadsButton_Click);
            // 
            // maxThreadsNumericUpDown
            // 
            this.maxThreadsNumericUpDown.Location = new System.Drawing.Point(408, 16);
            this.maxThreadsNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Name = "maxThreadsNumericUpDown";
            this.maxThreadsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.maxThreadsNumericUpDown.TabIndex = 1;
            this.maxThreadsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.ValueChanged += new System.EventHandler(this.maxThreadsNumericUpDown_ValueChanged);
            // 
            // maxThreadsTrackBar
            // 
            this.maxThreadsTrackBar.LargeChange = 2;
            this.maxThreadsTrackBar.Location = new System.Drawing.Point(6, 19);
            this.maxThreadsTrackBar.Maximum = 32;
            this.maxThreadsTrackBar.Minimum = 1;
            this.maxThreadsTrackBar.Name = "maxThreadsTrackBar";
            this.maxThreadsTrackBar.Size = new System.Drawing.Size(396, 45);
            this.maxThreadsTrackBar.TabIndex = 0;
            this.maxThreadsTrackBar.TickFrequency = 2;
            this.maxThreadsTrackBar.Value = 1;
            this.maxThreadsTrackBar.ValueChanged += new System.EventHandler(this.maxThreadsTrackBar_ValueChanged);
            // 
            // useMultithreadingCheckBox
            // 
            this.useMultithreadingCheckBox.AutoSize = true;
            this.useMultithreadingCheckBox.Location = new System.Drawing.Point(9, 0);
            this.useMultithreadingCheckBox.Name = "useMultithreadingCheckBox";
            this.useMultithreadingCheckBox.Size = new System.Drawing.Size(114, 17);
            this.useMultithreadingCheckBox.TabIndex = 3;
            this.useMultithreadingCheckBox.Text = "Use Multithreading";
            this.useMultithreadingCheckBox.UseVisualStyleBackColor = true;
            this.useMultithreadingCheckBox.CheckedChanged += new System.EventHandler(this.useMultithreadingCheckBox_CheckedChanged);
            // 
            // selectLanguagesButton
            // 
            this.selectLanguagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLanguagesButton.Location = new System.Drawing.Point(153, 16);
            this.selectLanguagesButton.Name = "selectLanguagesButton";
            this.selectLanguagesButton.Size = new System.Drawing.Size(358, 23);
            this.selectLanguagesButton.TabIndex = 19;
            this.selectLanguagesButton.Text = "Select Languages";
            this.selectLanguagesButton.UseVisualStyleBackColor = true;
            this.selectLanguagesButton.Click += new System.EventHandler(this.selectLanguagesButton_Click);
            // 
            // useSymbolRegionsCorrectionCheckBox
            // 
            this.useSymbolRegionsCorrectionCheckBox.AutoSize = true;
            this.useSymbolRegionsCorrectionCheckBox.Location = new System.Drawing.Point(15, 155);
            this.useSymbolRegionsCorrectionCheckBox.Name = "useSymbolRegionsCorrectionCheckBox";
            this.useSymbolRegionsCorrectionCheckBox.Size = new System.Drawing.Size(167, 17);
            this.useSymbolRegionsCorrectionCheckBox.TabIndex = 20;
            this.useSymbolRegionsCorrectionCheckBox.Text = "Use symbol regions correction";
            this.useSymbolRegionsCorrectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // OcrSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(523, 524);
            this.Controls.Add(this.useSymbolRegionsCorrectionCheckBox);
            this.Controls.Add(this.selectLanguagesButton);
            this.Controls.Add(this.useMultithreadingGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.recognitionModeComboBox);
            this.Controls.Add(this.recognitionModeLabel);
            this.Controls.Add(this.recognitionRegionTypeComboBox);
            this.Controls.Add(this.recognitionRegionTypeLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.highlightLowConfidenceWordsAfterRecognitionCheckBox);
            this.Controls.Add(this.useCustomDictionariesCheckBox);
            this.Controls.Add(this.imageBinarizationModeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 471);
            this.Name = "OcrSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCR Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlobOverlapsNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxWordSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRegionHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRegionWidthNumericUpDown)).EndInit();
            this.useMultithreadingGroupBox.ResumeLayout(false);
            this.useMultithreadingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox imageBinarizationModeComboBox;
        private System.Windows.Forms.CheckBox useCustomDictionariesCheckBox;
        private System.Windows.Forms.CheckBox highlightLowConfidenceWordsAfterRecognitionCheckBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label charsWhitelistLabel;
        private System.Windows.Forms.TextBox charsWhiteListTextBox;
        private System.Windows.Forms.Label maxBlobOverlapsLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown maxBlobOverlapsNumericUpDown;
        private System.Windows.Forms.Label recognitionRegionTypeLabel;
        private System.Windows.Forms.ComboBox recognitionRegionTypeComboBox;
        private System.Windows.Forms.ComboBox recognitionModeComboBox;
        private System.Windows.Forms.Label recognitionModeLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxRegionHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxRegionWidthNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxWordSizeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox useMultithreadingGroupBox;
        private System.Windows.Forms.NumericUpDown maxThreadsNumericUpDown;
        private System.Windows.Forms.TrackBar maxThreadsTrackBar;
        private System.Windows.Forms.Button resetMaxThreadsButton;
        private System.Windows.Forms.CheckBox useMultithreadingCheckBox;
        private System.Windows.Forms.Button selectLanguagesButton;
        private System.Windows.Forms.CheckBox useSymbolRegionsCorrectionCheckBox;
    }
}