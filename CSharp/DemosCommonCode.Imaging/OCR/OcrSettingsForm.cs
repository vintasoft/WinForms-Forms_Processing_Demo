#if REMOVE_OCR_PLUGIN
#error Remove OcrSettingsForm from the project.
#endif

using System;
using System.Diagnostics;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.Ocr;
using Vintasoft.Imaging.Ocr.Tesseract;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the settings of OCR engine manager.
    /// </summary>
    public partial class OcrSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The maximum count of threads, which can be used for text recognition.
        /// </summary>
        int _maxThreads = 0;

        /// <summary>
        /// The selected languages.
        /// </summary>
        OcrLanguage[] _selectedLanguages;

        /// <summary>
        /// The supported languages.
        /// </summary>
        OcrLanguage[] _supportedLanguages;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrSettingsForm"/> class.
        /// </summary>
        public OcrSettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrSettingsForm"/> class.
        /// </summary>
        /// <param name="tesseractOcrSettings">The settings of Tesseract OCR engine.</param>
        /// <param name="supportedLanguages">The languages,
        /// which are supported by Tesseract OCR engine.</param>
        /// <param name="imageBinarizationMode">The image binarization mode
        /// of Tesseract OCR engine.</param>
        /// <param name="highlightLowConfidenceWordsAfterRecognition">
        /// Indicates that words with low confidence must be highlighted.
        /// </param>
        public OcrSettingsForm(
            TesseractOcrSettings tesseractOcrSettings,
            OcrLanguage[] supportedLanguages,
            OcrBinarizationMode imageBinarizationMode,
            bool highlightLowConfidenceWordsAfterRecognition)
            : this(tesseractOcrSettings,
            supportedLanguages,
            imageBinarizationMode,
            highlightLowConfidenceWordsAfterRecognition,
            null,
            false,
            Environment.ProcessorCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrSettingsForm"/> class.
        /// </summary>
        /// <param name="tesseractOcrSettings">The settings of Tesseract OCR engine.</param>
        /// <param name="supportedLanguages">The languages,
        /// which are supported by Tesseract OCR engine.</param>
        /// <param name="imageBinarizationMode">The image binarization mode
        /// of Tesseract OCR engine.</param>
        /// <param name="highlightLowConfidenceWordsAfterRecognition">
        /// Indicates that words with low confidence must be highlighted after text recognition.
        /// </param>
        /// <param name="useMultithreading">Indicates that text recognition must be
        /// executed in multiple threads.</param>
        /// <param name="maxThreads">The maximum count of threads,
        /// which can be used for text recognition.</param>
        public OcrSettingsForm(
            TesseractOcrSettings tesseractOcrSettings,
            OcrLanguage[] supportedLanguages,
            OcrBinarizationMode imageBinarizationMode,
            bool highlightLowConfidenceWordsAfterRecognition,
            bool useMultithreading,
            int maxThreads)
            : this(tesseractOcrSettings,
            supportedLanguages,
            imageBinarizationMode,
            highlightLowConfidenceWordsAfterRecognition,
            null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrSettingsForm"/> class.
        /// </summary>
        /// <param name="tesseractOcrSettings">The settings of Tesseract OCR engine.</param>
        /// <param name="supportedLanguages">The languages,
        /// which are supported by Tesseract OCR engine.</param>
        /// <param name="imageBinarizationMode">The image binarization mode
        /// of Tesseract OCR engine.</param>
        /// <param name="highlightLowConfidenceWordsAfterRecognition">
        /// Indicates that words with low confidence must be highlighted.
        /// </param>
        /// <param name="ocrRecognitionRegionSplittingSettings">The OCR recognition region
        /// splitting settings.</param>
        public OcrSettingsForm(
            TesseractOcrSettings tesseractOcrSettings,
            OcrLanguage[] supportedLanguages,
            OcrBinarizationMode imageBinarizationMode,
            bool highlightLowConfidenceWordsAfterRecognition,
            OcrRecognitionRegionSplittingSettings ocrRecognitionRegionSplittingSettings)
            : this(tesseractOcrSettings, supportedLanguages,
            imageBinarizationMode,
            highlightLowConfidenceWordsAfterRecognition,
            ocrRecognitionRegionSplittingSettings,
            false,
            Environment.ProcessorCount)
        {
            useMultithreadingCheckBox.Checked = false;
            useMultithreadingGroupBox.Enabled = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrSettingsForm"/> class.
        /// </summary>
        /// <param name="tesseractOcrSettings">The settings of Tesseract OCR engine.</param>
        /// <param name="supportedLanguages">The languages,
        /// which are supported by Tesseract OCR engine.</param>
        /// <param name="imageBinarizationMode">The image binarization mode
        /// of Tesseract OCR engine.</param>
        /// <param name="highlightLowConfidenceWordsAfterRecognition">
        /// Indicates that words with low confidence must be highlighted after text recognition.
        /// </param>
        /// <param name="ocrRecognitionRegionSplittingSettings">The OCR recognition region
        /// splitting settings.</param>
        /// <param name="useMultithreading">Indicates that text recognition must be
        /// executed in multiple threads.</param>
        /// <param name="maxThreads">The maximum count of threads,
        /// which can be used for text recognition.</param>
        public OcrSettingsForm(
            TesseractOcrSettings tesseractOcrSettings,
            OcrLanguage[] supportedLanguages,
            OcrBinarizationMode imageBinarizationMode,
            bool highlightLowConfidenceWordsAfterRecognition,
            OcrRecognitionRegionSplittingSettings ocrRecognitionRegionSplittingSettings,
            bool useMultithreading,
            int maxThreads)
            : this()
        {
            _tesseractOcrSettings = tesseractOcrSettings;

            if (ocrRecognitionRegionSplittingSettings == OcrRecognitionRegionSplittingSettings.Default)
            {
                ocrRecognitionRegionSplittingSettings =
                    (OcrRecognitionRegionSplittingSettings)OcrRecognitionRegionSplittingSettings.Default.Clone();
            }
            _ocrRecognitionRegionSplittingSettings = ocrRecognitionRegionSplittingSettings;
            if (ocrRecognitionRegionSplittingSettings == null)
                ocrRecognitionRegionSplittingSettings = OcrRecognitionRegionSplittingSettings.Default;

            _supportedLanguages = supportedLanguages;
            _selectedLanguages = tesseractOcrSettings.Languages;

            recognitionModeComboBox.Items.Add(TesseractOcrRecognitionMode.Quality);
            recognitionModeComboBox.Items.Add(TesseractOcrRecognitionMode.Speed);

            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizePageWithPageSegmentationAndOrientationDetection);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizePageWithPageSegmentation);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleColumn);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleBlockOfVertText);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleBlock);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleLine);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleWord);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeCircleWord);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSingleChar);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSparseTextWithPageOrientationDetection);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeSparseText);
            recognitionRegionTypeComboBox.Items.Add(RecognitionRegionType.RecognizeRawLine);

            imageBinarizationModeComboBox.Items.Add(OcrBinarizationMode.None);
            imageBinarizationModeComboBox.Items.Add(OcrBinarizationMode.Adaptive);
            imageBinarizationModeComboBox.Items.Add(OcrBinarizationMode.Global);

            recognitionModeComboBox.SelectedItem = _tesseractOcrSettings.RecognitionMode;
            recognitionRegionTypeComboBox.SelectedItem = _tesseractOcrSettings.RecognitionRegionType;
            imageBinarizationModeComboBox.SelectedItem = imageBinarizationMode;
            useCustomDictionariesCheckBox.Checked = _tesseractOcrSettings.UseCustomDictionaries;
            charsWhiteListTextBox.Text = _tesseractOcrSettings.CharWhiteList;
            maxBlobOverlapsNumericUpDown.Value = _tesseractOcrSettings.MaxBlobOverlaps;
            highlightLowConfidenceWordsAfterRecognitionCheckBox.Checked = highlightLowConfidenceWordsAfterRecognition;

            useSymbolRegionsCorrectionCheckBox.Checked = _tesseractOcrSettings.UseSymbolRegionsCorrection;

            maxRegionHeightNumericUpDown.Value = ocrRecognitionRegionSplittingSettings.MaxRegionHeight;
            maxRegionWidthNumericUpDown.Value = ocrRecognitionRegionSplittingSettings.MaxRegionWidth;
            maxWordSizeNumericUpDown.Value = ocrRecognitionRegionSplittingSettings.MaxWordSize;

            useMultithreadingCheckBox.Checked = useMultithreading;
            useMultithreadingGroupBox.Enabled = useMultithreading;
            _maxThreads = maxThreads;
            maxThreadsNumericUpDown.Value = maxThreads;
        }

        #endregion



        #region Properties

        TesseractOcrSettings _tesseractOcrSettings;
        /// <summary>
        /// Gets the settings of Tesseract OCR engine.
        /// </summary>
        public TesseractOcrSettings TesseractOcrSettings
        {
            get
            {
                return _tesseractOcrSettings;
            }
        }

        OcrRecognitionRegionSplittingSettings _ocrRecognitionRegionSplittingSettings;
        /// <summary>
        /// Gets the OCR recognition region splitting settings.
        /// </summary>
        public OcrRecognitionRegionSplittingSettings OcrRecognitionRegionSplittingSettings
        {
            get
            {
                return _ocrRecognitionRegionSplittingSettings;
            }
        }

        /// <summary>
        /// Gets the binarization mode of image.
        /// </summary>
        public OcrBinarizationMode ImageBinarizationMode
        {
            get
            {
                return (OcrBinarizationMode)imageBinarizationModeComboBox.SelectedItem;
            }
        }

        /// <summary>
        /// Gets a value indicating whether words with low confidence must be
        /// highlighted after text recognition.
        /// </summary>
        public bool HighlightLowConfidenceWordsAfterRecognition
        {
            get
            {
                return highlightLowConfidenceWordsAfterRecognitionCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the highlightLowConfidenceWordsAfterRecognitionCheckBox control must be visible.
        /// </summary>
        public bool ShowHighlightLowConfidenceWordsCheckBox
        {
            get
            {
                return highlightLowConfidenceWordsAfterRecognitionCheckBox.Visible;
            }
            set
            {
                highlightLowConfidenceWordsAfterRecognitionCheckBox.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image binarization mode can be changed.
        /// </summary>
        public bool CanChooseBinarization
        {
            get
            {
                return imageBinarizationModeComboBox.Enabled;
            }
            set
            {
                imageBinarizationModeComboBox.Enabled = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether multithreading can be used.
        /// </summary>
        public bool UseMultithreading
        {
            get
            {
                return useMultithreadingCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets the maximum count of threads, which can be used for text recognition.
        /// </summary>
        public int MaxThreads
        {
            get
            {
                return (int)maxThreadsNumericUpDown.Value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of buttonOK object.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // update OCR settings

            _tesseractOcrSettings.Languages = _selectedLanguages;

            if (recognitionModeComboBox.SelectedItem != null)
                _tesseractOcrSettings.RecognitionMode = (TesseractOcrRecognitionMode)recognitionModeComboBox.SelectedItem;

            if (recognitionRegionTypeComboBox.SelectedItem != null)
                _tesseractOcrSettings.RecognitionRegionType = (RecognitionRegionType)recognitionRegionTypeComboBox.SelectedItem;

            _tesseractOcrSettings.UseCustomDictionaries = useCustomDictionariesCheckBox.Checked;
            _tesseractOcrSettings.CharWhiteList = charsWhiteListTextBox.Text;
            _tesseractOcrSettings.MaxBlobOverlaps = (int)maxBlobOverlapsNumericUpDown.Value;
            _tesseractOcrSettings.UseSymbolRegionsCorrection = useSymbolRegionsCorrectionCheckBox.Checked;

            if (_ocrRecognitionRegionSplittingSettings == null)
            {
                _ocrRecognitionRegionSplittingSettings = new OcrRecognitionRegionSplittingSettings(
                    (int)maxRegionWidthNumericUpDown.Value,
                    (int)maxRegionHeightNumericUpDown.Value,
                    (int)maxWordSizeNumericUpDown.Value);
            }
            else
            {
                _ocrRecognitionRegionSplittingSettings.MaxRegionWidth = (int)maxRegionWidthNumericUpDown.Value;
                _ocrRecognitionRegionSplittingSettings.MaxRegionHeight = (int)maxRegionHeightNumericUpDown.Value;
                _ocrRecognitionRegionSplittingSettings.MaxWordSize = (int)maxWordSizeNumericUpDown.Value;
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of selectLanguagesButton object.
        /// </summary>
        private void selectLanguagesButton_Click(object sender, EventArgs e)
        {
            // create OCR language form
            using (OcrLanguagesForm dialog = new OcrLanguagesForm(_selectedLanguages, _supportedLanguages))
            {
                dialog.Owner = this;

                // if selected languages must be changed
                if (dialog.ShowDialog() == DialogResult.OK)
                    // update selected languages
                    _selectedLanguages = dialog.SelectedLanguages;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of maxThreadsNumericUpDown object.
        /// </summary>
        private void maxThreadsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if maximum threads for recognition must be changed
            if (maxThreadsTrackBar.Value != maxThreadsNumericUpDown.Value)
                // update maximum thread for recognition
                maxThreadsTrackBar.Value = (int)maxThreadsNumericUpDown.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of maxThreadsTrackBar object.
        /// </summary>
        private void maxThreadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // if maximum threads for recognition must be changed
            if (maxThreadsTrackBar.Value != maxThreadsNumericUpDown.Value)
                // update maximum thread for recognition
                maxThreadsNumericUpDown.Value = maxThreadsTrackBar.Value;
        }

        /// <summary>
        /// Handles the Click event of resetMaxThreadsButton object.
        /// </summary>
        private void resetMaxThreadsButton_Click(object sender, EventArgs e)
        {
            // reset maximum threads for recognition
            maxThreadsNumericUpDown.Value = _maxThreads;
        }

        /// <summary>
        /// Handles the CheckedChanged event of useMultithreadingCheckBox object.
        /// </summary>
        private void useMultithreadingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if multithread recognition must be used
            if (useMultithreadingCheckBox.Checked)
                useMultithreadingGroupBox.Enabled = true;
            else
                useMultithreadingGroupBox.Enabled = false;
        }

        #endregion

    }
}
