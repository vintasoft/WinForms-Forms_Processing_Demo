namespace FormsProcessingDemo
{
	partial class NewTableSetupForm
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
            this.labelText1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.rowCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.rowCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText1
            // 
            this.labelText1.Location = new System.Drawing.Point(35, 19);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(76, 23);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "Row count:";
            this.labelText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelText2
            // 
            this.labelText2.Location = new System.Drawing.Point(35, 47);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(76, 20);
            this.labelText2.TabIndex = 2;
            this.labelText2.Text = "Column count:";
            this.labelText2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(38, 106);
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
            this.btCancel.Location = new System.Drawing.Point(129, 106);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(85, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // rowCountNumericUpDown
            // 
            this.rowCountNumericUpDown.Location = new System.Drawing.Point(129, 22);
            this.rowCountNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.rowCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowCountNumericUpDown.Name = "rowCountNumericUpDown";
            this.rowCountNumericUpDown.Size = new System.Drawing.Size(101, 20);
            this.rowCountNumericUpDown.TabIndex = 6;
            this.rowCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // columnCountNumericUpDown
            // 
            this.columnCountNumericUpDown.Location = new System.Drawing.Point(129, 49);
            this.columnCountNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.columnCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnCountNumericUpDown.Name = "columnCountNumericUpDown";
            this.columnCountNumericUpDown.Size = new System.Drawing.Size(101, 20);
            this.columnCountNumericUpDown.TabIndex = 7;
            this.columnCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OmrMarkGridSetupForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(242, 141);
            this.Controls.Add(this.columnCountNumericUpDown);
            this.Controls.Add(this.rowCountNumericUpDown);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OmrMarkGridSetupForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New OMR Mark Table";
            ((System.ComponentModel.ISupportInitialize)(this.rowCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelText1;
		private System.Windows.Forms.Label labelText2;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.NumericUpDown rowCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown columnCountNumericUpDown;
	}
}