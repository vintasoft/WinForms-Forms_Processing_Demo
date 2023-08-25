namespace DemosCommonCode.Imaging
{
    partial class OcrLanguagesListBox
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

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.languagePanel = new System.Windows.Forms.Panel();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.removeAllLanguagesFromListButton = new System.Windows.Forms.Button();
            this.removeLanguageFromListButton = new System.Windows.Forms.Button();
            this.selectedLanguagesLabel = new System.Windows.Forms.Label();
            this.selectedLanguagesListBox = new System.Windows.Forms.ListBox();
            this.languagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // languagePanel
            // 
            this.languagePanel.Controls.Add(this.moveDownButton);
            this.languagePanel.Controls.Add(this.moveUpButton);
            this.languagePanel.Controls.Add(this.removeAllLanguagesFromListButton);
            this.languagePanel.Controls.Add(this.removeLanguageFromListButton);
            this.languagePanel.Controls.Add(this.selectedLanguagesLabel);
            this.languagePanel.Controls.Add(this.selectedLanguagesListBox);
            this.languagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languagePanel.Location = new System.Drawing.Point(0, 0);
            this.languagePanel.Name = "languagePanel";
            this.languagePanel.Size = new System.Drawing.Size(353, 240);
            this.languagePanel.TabIndex = 1;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(119, 213);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(99, 23);
            this.moveDownButton.TabIndex = 27;
            this.moveDownButton.Text = "Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(119, 184);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(99, 23);
            this.moveUpButton.TabIndex = 26;
            this.moveUpButton.Text = "Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // removeAllLanguagesFromListButton
            // 
            this.removeAllLanguagesFromListButton.Location = new System.Drawing.Point(3, 213);
            this.removeAllLanguagesFromListButton.Name = "removeAllLanguagesFromListButton";
            this.removeAllLanguagesFromListButton.Size = new System.Drawing.Size(110, 23);
            this.removeAllLanguagesFromListButton.TabIndex = 25;
            this.removeAllLanguagesFromListButton.Text = "Remove all";
            this.removeAllLanguagesFromListButton.UseVisualStyleBackColor = true;
            this.removeAllLanguagesFromListButton.Click += new System.EventHandler(this.removeAllLanguagesFromList_Click);
            // 
            // removeLanguageFromListButton
            // 
            this.removeLanguageFromListButton.Location = new System.Drawing.Point(3, 184);
            this.removeLanguageFromListButton.Name = "removeLanguageFromListButton";
            this.removeLanguageFromListButton.Size = new System.Drawing.Size(110, 23);
            this.removeLanguageFromListButton.TabIndex = 24;
            this.removeLanguageFromListButton.Text = "Remove selected";
            this.removeLanguageFromListButton.UseVisualStyleBackColor = true;
            this.removeLanguageFromListButton.Click += new System.EventHandler(this.removeLanguageFromList_Click);
            // 
            // selectedLanguagesLabel
            // 
            this.selectedLanguagesLabel.AutoSize = true;
            this.selectedLanguagesLabel.Location = new System.Drawing.Point(3, 2);
            this.selectedLanguagesLabel.Name = "selectedLanguagesLabel";
            this.selectedLanguagesLabel.Size = new System.Drawing.Size(108, 13);
            this.selectedLanguagesLabel.TabIndex = 23;
            this.selectedLanguagesLabel.Text = "Selected Languages:";
            // 
            // selectedLanguagesListBox
            // 
            this.selectedLanguagesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedLanguagesListBox.FormattingEnabled = true;
            this.selectedLanguagesListBox.Location = new System.Drawing.Point(3, 18);
            this.selectedLanguagesListBox.Name = "selectedLanguagesListBox";
            this.selectedLanguagesListBox.Size = new System.Drawing.Size(345, 160);
            this.selectedLanguagesListBox.TabIndex = 22;
            // 
            // OcrLanguagesListBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.languagePanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OcrLanguagesListBox";
            this.Size = new System.Drawing.Size(353, 240);
            this.languagePanel.ResumeLayout(false);
            this.languagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel languagePanel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button removeAllLanguagesFromListButton;
        private System.Windows.Forms.Button removeLanguageFromListButton;
        private System.Windows.Forms.Label selectedLanguagesLabel;
        private System.Windows.Forms.ListBox selectedLanguagesListBox;
    }
}