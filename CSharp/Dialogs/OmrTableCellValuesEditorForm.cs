using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using DemosCommonCode;

using Vintasoft.Imaging.FormsProcessing.FormRecognition.Omr;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to edit OMR table cell values.
    /// </summary>
    public partial class OmrTableCellValuesEditorForm : Form
    {

        #region Fields

        /// <summary>
        /// Row count in a table.
        /// </summary>
        int _rowCount;

        /// <summary>
        /// Column count in a table.
        /// </summary>
        int _columnCount;

        /// <summary>
        /// Two dimensional source array of values.
        /// </summary>
        string[,] _cellValues;

        /// <summary>
        /// Intermediate data table as a source for DataGridView.
        /// </summary>
        DataTable _dataTable;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OmrTableCellValuesEditorForm"/> class.
        /// </summary>
        public OmrTableCellValuesEditorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OmrTableCellValuesEditorForm"/> class.
        /// </summary>
        /// <param name="cellValues">Two dimensional source array of values.</param>
        /// <param name="orientation">Orientation of OMR table.</param>
        public OmrTableCellValuesEditorForm(string[,] cellValues, OmrTableOrientation orientation)
            : this()
        {
            _rowCount = cellValues.GetLength(0);
            _columnCount = cellValues.GetLength(1);
            _cellValues = cellValues;
            Orientation = orientation;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets orientation of OMR table.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OmrTableOrientation Orientation
        {
            get
            {
                if (horizontalRadioButton.Checked)
                    return OmrTableOrientation.Horizontal;
	        return OmrTableOrientation.Vertical;
            }
            set
            {
                if (value == OmrTableOrientation.Horizontal)
                {
                    horizontalRadioButton.Checked = true;
                    verticalRadioButton.Checked = false;
                }
                else
                {
                    horizontalRadioButton.Checked = false;
                    verticalRadioButton.Checked = true;
                }
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Fills the cells with current values from source.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _dataTable = new DataTable();

            for (int col = 0; col < _columnCount; col++)
                _dataTable.Columns.Add(string.Format("Col.{0}", col + 1));

            for (int row = 0; row < _rowCount; row++)
            {
                DataRow dataRow = _dataTable.NewRow();
                for (int col = 0; col < _columnCount; col++)
                    dataRow[col] = _cellValues[row, col];
                _dataTable.Rows.Add(dataRow);
            }

            _dataTable.DefaultView.AllowDelete = false;
            _dataTable.DefaultView.AllowNew = false;
            
            cellValuesGridView.DataSource = _dataTable;
            for (int col = 0; col < _columnCount; col++)
                cellValuesGridView.Columns[col].Width = 50;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Fills cells with capital letters of Roman alphabet along the rows or columns.
        /// </summary>
        private void fillValuesAbcButton_Click(object sender, EventArgs e)
        {
            int letterCount;
            byte aLetterCode = (byte)'A';
            if (Orientation == OmrTableOrientation.Horizontal)
            {
                letterCount = Math.Min(_columnCount, 26);
                for (int r = 0; r < _rowCount; r++)
                {
                    DataRow row = _dataTable.Rows[r];
                    for (int c = 0; c < letterCount; c++)
                    {
                        row[c] = Convert.ToChar((byte)(aLetterCode + c)).ToString();
                    }
                }

                if (_columnCount > 26)
                {
                    for (int r = 0; r < _rowCount; r++)
                    {
                        DataRow row = _dataTable.Rows[r];
                        for (int c = 26; c < _columnCount; c++)
                        {
                            row[c] = "";
                        }
                    }

                    DemosTools.ShowWarningMessage("Column count exceeds number of capital letters." +
                        " Remaining columns are unfilled.");
                }
            }
            else
            {
                letterCount = Math.Min(_rowCount, 26);
                for (int r = 0; r < letterCount; r++)
                {
                    DataRow row = _dataTable.Rows[r];
                    string rowValue = Convert.ToChar((byte)(aLetterCode + r)).ToString();
                    for (int c = 0; c < _columnCount; c++)
                    {
                        row[c] = rowValue;
                    }
                }

                if (_rowCount > 26)
                {
                    for (int r = 26; r < _rowCount; r++)
                    {
                        DataRow row = _dataTable.Rows[r];
                        for (int c = 0; c < _columnCount; c++)
                        {
                            row[c] = "";
                        }
                    }

                    DemosTools.ShowWarningMessage("Row count exceeds number of capital letters." +
                        " Remaining rows are unfilled.");
                }
            }
        }

        /// <summary>
        /// Fills cells with numbers starting from zero along the rows or columns.
        /// </summary>
        private void fillValues123Button_Click(object sender, EventArgs e)
        {
            if (Orientation == OmrTableOrientation.Horizontal)
            {
                for (int r = 0; r < _rowCount; r++)
                {
                    DataRow row = _dataTable.Rows[r];
                    for (int c = 0; c < _columnCount; c++)
                    {
                        row[c] = c.ToString();
                    }
                }
            }
            else
            {
                for (int r = 0; r < _rowCount; r++)
                {
                    DataRow row = _dataTable.Rows[r];
                    string rowValue = r.ToString();
                    for (int c = 0; c < _columnCount; c++)
                    {
                        row[c] = rowValue;
                    }
                }
            }
        }

        /// <summary>
        /// Copies actual values of cells to source array and closes form.
        /// </summary>
        private void btOk_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _columnCount; col++)
                {
                    _cellValues[row, col] = cellValuesGridView[col, row].Value.ToString();
                }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Closes form without copying cell values.
        /// </summary>
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #endregion

    }
}