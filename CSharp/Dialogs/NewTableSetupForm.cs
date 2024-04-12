using System;
using System.Windows.Forms;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to specify parameters of new OMR table.
    /// </summary>
    public partial class NewTableSetupForm : Form
    {

        public NewTableSetupForm(int initialRowCount, int initialColumnCount)
        {
            InitializeComponent();

            rowCountNumericUpDown.Value = Math.Min((decimal)initialRowCount, rowCountNumericUpDown.Maximum);
            columnCountNumericUpDown.Value = Math.Min((decimal)initialColumnCount, columnCountNumericUpDown.Maximum);
        }



        public int RowCount
        {
            get
            {
                return (int)rowCountNumericUpDown.Value;
            }
        }

        public int ColumnCount
        {
            get
            {
                return (int)columnCountNumericUpDown.Value;
            }
        }



        /// <summary>
        /// Handles the Click event of btOk object.
        /// </summary>
        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of btCancel object.
        /// </summary>
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
