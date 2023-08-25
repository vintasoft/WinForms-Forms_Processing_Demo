using System;
using System.Windows.Forms;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to view and edit the barcode reader settings.
    /// </summary>
    public partial class BarcodeReaderSettingsForm : Form
    {

#if !REMOVE_BARCODE_SDK
        ReaderSettings _readerSettings; 
#endif



        public BarcodeReaderSettingsForm()
        {
            InitializeComponent();
        }

#if !REMOVE_BARCODE_SDK
        public BarcodeReaderSettingsForm(ReaderSettings readerSettings)
            : this()
        {
            _readerSettings = readerSettings;
            barcodeReaderSettingsControl1.RestoreSettings(readerSettings);
            barcodeReaderSettingsControl1.CanChangeExpectedBarcodes = false;
        } 
#endif



        /// <summary>
        /// Handles the Click event of BtOk object.
        /// </summary>
        private void btOk_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            barcodeReaderSettingsControl1.SetReaderSettings(_readerSettings); 
#endif
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of BtCancel object.
        /// </summary>
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
