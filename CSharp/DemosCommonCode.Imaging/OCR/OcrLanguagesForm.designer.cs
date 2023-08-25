namespace DemosCommonCode.Imaging
{
    partial class OcrLanguagesForm
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
            this.downloadAdditionalLanguageDictionariesButton = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.supportedLanguagesListBox = new System.Windows.Forms.ListBox();
            this.supportedLanguagesLabel = new System.Windows.Forms.Label();
            this.addLanguage = new System.Windows.Forms.Button();
            this.ocrLanguagesListBox1 = new DemosCommonCode.Imaging.OcrLanguagesListBox();
            this.SuspendLayout();
            // 
            // downloadAdditionalLanguageDictionariesButton
            // 
            this.downloadAdditionalLanguageDictionariesButton.Location = new System.Drawing.Point(133, 191);
            this.downloadAdditionalLanguageDictionariesButton.Name = "downloadAdditionalLanguageDictionariesButton";
            this.downloadAdditionalLanguageDictionariesButton.Size = new System.Drawing.Size(232, 23);
            this.downloadAdditionalLanguageDictionariesButton.TabIndex = 1;
            this.downloadAdditionalLanguageDictionariesButton.Text = "Download additional language dictionaries...";
            this.downloadAdditionalLanguageDictionariesButton.UseVisualStyleBackColor = true;
            this.downloadAdditionalLanguageDictionariesButton.Click += new System.EventHandler(this.downloadAdditionalLanguageDictionariesButton_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(216, 490);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(297, 490);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // supportedLanguagesListBox
            // 
            this.supportedLanguagesListBox.FormattingEnabled = true;
            this.supportedLanguagesListBox.Location = new System.Drawing.Point(12, 25);
            this.supportedLanguagesListBox.Name = "supportedLanguagesListBox";
            this.supportedLanguagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.supportedLanguagesListBox.Size = new System.Drawing.Size(360, 160);
            this.supportedLanguagesListBox.Sorted = true;
            this.supportedLanguagesListBox.TabIndex = 14;
            this.supportedLanguagesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.supportedLanguagesListBox_MouseDoubleClick);
            // 
            // supportedLanguagesLabel
            // 
            this.supportedLanguagesLabel.AutoSize = true;
            this.supportedLanguagesLabel.Location = new System.Drawing.Point(12, 9);
            this.supportedLanguagesLabel.Name = "supportedLanguagesLabel";
            this.supportedLanguagesLabel.Size = new System.Drawing.Size(115, 13);
            this.supportedLanguagesLabel.TabIndex = 13;
            this.supportedLanguagesLabel.Text = "Supported Languages:";
            // 
            // addLanguage
            // 
            this.addLanguage.Location = new System.Drawing.Point(12, 191);
            this.addLanguage.Name = "addLanguage";
            this.addLanguage.Size = new System.Drawing.Size(115, 23);
            this.addLanguage.TabIndex = 15;
            this.addLanguage.Text = "Add language";
            this.addLanguage.UseVisualStyleBackColor = true;
            this.addLanguage.Click += new System.EventHandler(this.addLanguage_Click);
            // 
            // ocrLanguagesListBox1
            // 
            this.ocrLanguagesListBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ocrLanguagesListBox1.Location = new System.Drawing.Point(12, 231);
            this.ocrLanguagesListBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ocrLanguagesListBox1.Name = "ocrLanguagesListBox1";
            this.ocrLanguagesListBox1.SelectedLanguages = new Vintasoft.Imaging.Ocr.OcrLanguage[0];
            this.ocrLanguagesListBox1.Size = new System.Drawing.Size(353, 256);
            this.ocrLanguagesListBox1.TabIndex = 16;
            // 
            // OcrLanguagesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 522);
            this.Controls.Add(this.ocrLanguagesListBox1);
            this.Controls.Add(this.addLanguage);
            this.Controls.Add(this.supportedLanguagesListBox);
            this.Controls.Add(this.supportedLanguagesLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.downloadAdditionalLanguageDictionariesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(270, 160);
            this.Name = "OcrLanguagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCR Languages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadAdditionalLanguageDictionariesButton;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox supportedLanguagesListBox;
        private System.Windows.Forms.Label supportedLanguagesLabel;
        private System.Windows.Forms.Button addLanguage;
        private OcrLanguagesListBox ocrLanguagesListBox1;
    }
}