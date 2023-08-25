namespace FormsProcessingDemo
{
    partial class FieldTemplatesSelectionForm
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
            this.fieldTemplatesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(145, 330);
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
            this.btCancel.Location = new System.Drawing.Point(236, 330);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(85, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // fieldTemplatesCheckedListBox
            // 
            this.fieldTemplatesCheckedListBox.CheckOnClick = true;
            this.fieldTemplatesCheckedListBox.FormattingEnabled = true;
            this.fieldTemplatesCheckedListBox.Location = new System.Drawing.Point(4, 5);
            this.fieldTemplatesCheckedListBox.Name = "fieldTemplatesCheckedListBox";
            this.fieldTemplatesCheckedListBox.Size = new System.Drawing.Size(463, 319);
            this.fieldTemplatesCheckedListBox.TabIndex = 6;
            // 
            // FieldTemplatesSelectionForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(479, 363);
            this.Controls.Add(this.fieldTemplatesCheckedListBox);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldTemplatesSelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Form Field Templates";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckedListBox fieldTemplatesCheckedListBox;
	}
}