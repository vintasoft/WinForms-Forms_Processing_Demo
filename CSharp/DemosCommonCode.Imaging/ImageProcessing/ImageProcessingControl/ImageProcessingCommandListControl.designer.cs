namespace DemosCommonCode
{
    partial class ImageProcessingCommandListControl
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
            this.commandTypesLabel = new System.Windows.Forms.Label();
            this.commandTypeComboBox = new System.Windows.Forms.ComboBox();
            this.commandListBox = new System.Windows.Forms.ListBox();
            this.commandsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.commandsPanel = new System.Windows.Forms.Panel();
            this.commandTypesPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.commandsPanel.SuspendLayout();
            this.commandTypesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandTypesLabel
            // 
            this.commandTypesLabel.AutoSize = true;
            this.commandTypesLabel.Location = new System.Drawing.Point(0, 0);
            this.commandTypesLabel.Name = "commandTypesLabel";
            this.commandTypesLabel.Size = new System.Drawing.Size(85, 13);
            this.commandTypesLabel.TabIndex = 8;
            this.commandTypesLabel.Text = "Command types:";
            // 
            // commandTypeComboBox
            // 
            this.commandTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commandTypeComboBox.FormattingEnabled = true;
            this.commandTypeComboBox.Items.AddRange(new object[] {
            "All",
            "Base",
            "Info",
            "Transforms",
            "Color",
            "Filters",
            "Document Cleanup, Info",
            "Document Cleanup",
            "Effects",
            "Forms Processing"});
            this.commandTypeComboBox.Location = new System.Drawing.Point(0, 16);
            this.commandTypeComboBox.Name = "commandTypeComboBox";
            this.commandTypeComboBox.Size = new System.Drawing.Size(212, 21);
            this.commandTypeComboBox.TabIndex = 7;
            this.commandTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.commandTypeComboBox_SelectedIndexChanged);
            // 
            // commandListBox
            // 
            this.commandListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandListBox.FormattingEnabled = true;
            this.commandListBox.Location = new System.Drawing.Point(0, 16);
            this.commandListBox.Name = "commandListBox";
            this.commandListBox.Size = new System.Drawing.Size(212, 95);
            this.commandListBox.Sorted = true;
            this.commandListBox.TabIndex = 10;
            this.commandListBox.SelectedIndexChanged += new System.EventHandler(this.commandListBox_SelectedIndexChanged);
            this.commandListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.commandListBox_MouseDoubleClick);
            // 
            // commandsLabel
            // 
            this.commandsLabel.AutoSize = true;
            this.commandsLabel.Location = new System.Drawing.Point(0, 0);
            this.commandsLabel.Name = "commandsLabel";
            this.commandsLabel.Size = new System.Drawing.Size(62, 13);
            this.commandsLabel.TabIndex = 9;
            this.commandsLabel.Text = "Commands:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.commandsPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.commandTypesPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 150);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // commandsPanel
            // 
            this.commandsPanel.Controls.Add(this.commandListBox);
            this.commandsPanel.Controls.Add(this.commandsLabel);
            this.commandsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsPanel.Location = new System.Drawing.Point(0, 39);
            this.commandsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.commandsPanel.Name = "commandsPanel";
            this.commandsPanel.Size = new System.Drawing.Size(212, 111);
            this.commandsPanel.TabIndex = 12;
            // 
            // commandTypesPanel
            // 
            this.commandTypesPanel.Controls.Add(this.commandTypeComboBox);
            this.commandTypesPanel.Controls.Add(this.commandTypesLabel);
            this.commandTypesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandTypesPanel.Location = new System.Drawing.Point(0, 0);
            this.commandTypesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.commandTypesPanel.Name = "commandTypesPanel";
            this.commandTypesPanel.Size = new System.Drawing.Size(212, 39);
            this.commandTypesPanel.TabIndex = 12;
            // 
            // ImageProcessingCommandListControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(103, 101);
            this.Name = "ImageProcessingCommandListControl";
            this.Size = new System.Drawing.Size(212, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.commandsPanel.ResumeLayout(false);
            this.commandsPanel.PerformLayout();
            this.commandTypesPanel.ResumeLayout(false);
            this.commandTypesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label commandTypesLabel;
        private System.Windows.Forms.ComboBox commandTypeComboBox;
        private System.Windows.Forms.ListBox commandListBox;
        private System.Windows.Forms.Label commandsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel commandsPanel;
        private System.Windows.Forms.Panel commandTypesPanel;
    }
}