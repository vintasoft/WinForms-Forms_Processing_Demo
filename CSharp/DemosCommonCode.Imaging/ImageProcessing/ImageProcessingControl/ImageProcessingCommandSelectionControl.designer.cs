namespace DemosCommonCode
{
    partial class ImageProcessingCommandSelectionControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addCommandToListButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.commandsToProcessListBox = new System.Windows.Forms.ListBox();
            this.removeAllCommandsFromList = new System.Windows.Forms.Button();
            this.setCommandPropertiesButton = new System.Windows.Forms.Button();
            this.removeCommandFromListButton = new System.Windows.Forms.Button();
            this.imageProcessingCommandsViewer1 = new DemosCommonCode.ImageProcessingCommandListControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageProcessingCommandsViewer1);
            this.splitContainer1.Panel1.Controls.Add(this.addCommandToListButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.moveDownButton);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.moveUpButton);
            this.splitContainer1.Panel2.Controls.Add(this.commandsToProcessListBox);
            this.splitContainer1.Panel2.Controls.Add(this.removeAllCommandsFromList);
            this.splitContainer1.Panel2.Controls.Add(this.setCommandPropertiesButton);
            this.splitContainer1.Panel2.Controls.Add(this.removeCommandFromListButton);
            this.splitContainer1.Size = new System.Drawing.Size(224, 345);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // addCommandToListButton
            // 
            this.addCommandToListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addCommandToListButton.Location = new System.Drawing.Point(6, 134);
            this.addCommandToListButton.Name = "addCommandToListButton";
            this.addCommandToListButton.Size = new System.Drawing.Size(215, 23);
            this.addCommandToListButton.TabIndex = 0;
            this.addCommandToListButton.Text = "Add command to list";
            this.addCommandToListButton.UseVisualStyleBackColor = true;
            this.addCommandToListButton.Click += new System.EventHandler(this.addCommandToListButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Location = new System.Drawing.Point(122, 120);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(99, 23);
            this.moveDownButton.TabIndex = 8;
            this.moveDownButton.Text = "Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Commands to process the image:";
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Location = new System.Drawing.Point(122, 91);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(99, 23);
            this.moveUpButton.TabIndex = 7;
            this.moveUpButton.Text = "Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // commandsToProcessListBox
            // 
            this.commandsToProcessListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsToProcessListBox.FormattingEnabled = true;
            this.commandsToProcessListBox.Location = new System.Drawing.Point(6, 16);
            this.commandsToProcessListBox.Name = "commandsToProcessListBox";
            this.commandsToProcessListBox.Size = new System.Drawing.Size(215, 69);
            this.commandsToProcessListBox.TabIndex = 0;
            this.commandsToProcessListBox.SelectedIndexChanged += new System.EventHandler(this.commandsToProcessListBox_SelectedIndexChanged);
            this.commandsToProcessListBox.DoubleClick += new System.EventHandler(this.commandsToProcessListBox_DoubleClick);
            // 
            // removeAllCommandsFromList
            // 
            this.removeAllCommandsFromList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAllCommandsFromList.Location = new System.Drawing.Point(6, 120);
            this.removeAllCommandsFromList.Name = "removeAllCommandsFromList";
            this.removeAllCommandsFromList.Size = new System.Drawing.Size(110, 23);
            this.removeAllCommandsFromList.TabIndex = 5;
            this.removeAllCommandsFromList.Text = "Remove all";
            this.removeAllCommandsFromList.UseVisualStyleBackColor = true;
            this.removeAllCommandsFromList.Click += new System.EventHandler(this.removeAllCommandsFromList_Click);
            // 
            // setCommandPropertiesButton
            // 
            this.setCommandPropertiesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.setCommandPropertiesButton.Location = new System.Drawing.Point(6, 155);
            this.setCommandPropertiesButton.Name = "setCommandPropertiesButton";
            this.setCommandPropertiesButton.Size = new System.Drawing.Size(215, 23);
            this.setCommandPropertiesButton.TabIndex = 4;
            this.setCommandPropertiesButton.Text = "Set command parameters";
            this.setCommandPropertiesButton.UseVisualStyleBackColor = true;
            this.setCommandPropertiesButton.Click += new System.EventHandler(this.setCommandPropertiesButton_Click);
            // 
            // removeCommandFromListButton
            // 
            this.removeCommandFromListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.removeCommandFromListButton.Location = new System.Drawing.Point(6, 91);
            this.removeCommandFromListButton.Name = "removeCommandFromListButton";
            this.removeCommandFromListButton.Size = new System.Drawing.Size(110, 23);
            this.removeCommandFromListButton.TabIndex = 3;
            this.removeCommandFromListButton.Text = "Remove selected";
            this.removeCommandFromListButton.UseVisualStyleBackColor = true;
            this.removeCommandFromListButton.Click += new System.EventHandler(this.removeCommandFromListButton_Click);
            // 
            // imageProcessingCommandsViewer1
            // 
            this.imageProcessingCommandsViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageProcessingCommandsViewer1.Location = new System.Drawing.Point(6, 4);
            this.imageProcessingCommandsViewer1.MinimumSize = new System.Drawing.Size(103, 101);
            this.imageProcessingCommandsViewer1.Name = "imageProcessingCommandsViewer1";
            this.imageProcessingCommandsViewer1.AvailableProcessingCommands = null;
            this.imageProcessingCommandsViewer1.Size = new System.Drawing.Size(215, 124);
            this.imageProcessingCommandsViewer1.TabIndex = 1;
            this.imageProcessingCommandsViewer1.SelectedProcessingCommandChanged += new System.EventHandler(this.imageProcessingCommandsViewer1_SelectedProcessingCommandChanged);
            this.imageProcessingCommandsViewer1.MouseDoubleClickOnSelectedProcessingCommand += new System.EventHandler(this.imageProcessingCommandsViewer1_MouseDoubleClickOnSelectedProcessingCommand);
            // 
            // ImageProcessingCommandsEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(178, 283);
            this.Name = "ImageProcessingCommandsEditor";
            this.Size = new System.Drawing.Size(224, 345);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ImageProcessingCommandListControl imageProcessingCommandsViewer1;
        private System.Windows.Forms.Button addCommandToListButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.ListBox commandsToProcessListBox;
        private System.Windows.Forms.Button removeAllCommandsFromList;
        private System.Windows.Forms.Button setCommandPropertiesButton;
        private System.Windows.Forms.Button removeCommandFromListButton;
    }
}