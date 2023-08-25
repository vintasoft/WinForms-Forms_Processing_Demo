#if REMOVE_OCR_PLUGIN
#error Remove OcrLanguagesForm from the project.
#endif

using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Ocr;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the language settings of OCR engine manager.
    /// </summary>
    public partial class OcrLanguagesForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrLanguagesForm"/> class.
        /// </summary>
        /// <param name="selectedLanguages">The selected languages.</param>
        /// <param name="supportedLanguages">The languages,
        /// which are supported by Tesseract OCR engine.</param>
        public OcrLanguagesForm(
            OcrLanguage[] selectedLanguages,
            OcrLanguage[] supportedLanguages)
        {
            InitializeComponent();

            // add supported languages in listBox
            foreach (OcrLanguage language in supportedLanguages)
                supportedLanguagesListBox.Items.Add(language);

            // add selected languages in listBox
            ocrLanguagesListBox1.SelectedLanguages = selectedLanguages;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the selected languages.
        /// </summary>
        public OcrLanguage[] SelectedLanguages
        {
            get
            {
                return ocrLanguagesListBox1.SelectedLanguages;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of ButtonOK object.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // if language is not selected
            if (SelectedLanguages.Length == 0)
            {
                MessageBox.Show(
                    "The language is not selected.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Handles the Click event of AddLanguage object.
        /// </summary>
        private void addLanguage_Click(object sender, EventArgs e)
        {
            // add supported languages to the selected languages

            foreach (OcrLanguage supportedLanguage in supportedLanguagesListBox.SelectedItems)
            {
                ocrLanguagesListBox1.AddLanguage(supportedLanguage);
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of SupportedLanguagesListBox object.
        /// </summary>
        private void supportedLanguagesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ocrLanguagesListBox1.AddLanguage((OcrLanguage)supportedLanguagesListBox.SelectedItem);
        }

        /// <summary>
        /// Handles the Click event of DownloadAdditionalLanguageDictionariesButton object.
        /// </summary>
        private void downloadAdditionalLanguageDictionariesButton_Click(object sender, EventArgs e)
        {
            // open the OCR documentation web page
            DemosTools.OpenBrowser("https://www.vintasoft.com/docs/vsimaging-dotnet/Programming-Ocr-Prepare_OCR_engine_for_text_recognition.html");
        }

        #endregion

    }
}
