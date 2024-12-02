#if REMOVE_OCR_PLUGIN
#error Remove OcrLanguagesListBox from the project.
#endif

using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Ocr;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to manage list of selected OCR languages.
    /// </summary>
    public partial class OcrLanguagesListBox : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrLanguagesListBox"/> class.
        /// </summary>
        public OcrLanguagesListBox()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the selected languages.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OcrLanguage[] SelectedLanguages
        {
            get
            {
                OcrLanguage[] languages = new OcrLanguage[selectedLanguagesListBox.Items.Count];
                for (int i = 0; i < selectedLanguagesListBox.Items.Count; i++)
                {
                    languages[i] = (OcrLanguage)selectedLanguagesListBox.Items[i];
                }
                return languages;
            }
            set
            {
                selectedLanguagesListBox.Items.Clear();

                if (value != null)
                {
                    foreach (OcrLanguage language in value)
                    {
                        selectedLanguagesListBox.Items.Add(language);
                    }
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Adds language to the ListBox with selected languages.
        /// </summary>
        /// <param name="language">Language that should be added.</param>
        public void AddLanguage(OcrLanguage language)
        {
            if (!selectedLanguagesListBox.Items.Contains(language))
                selectedLanguagesListBox.Items.Add(language);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:SelectedLanguagesChanged" /> event.
        /// </summary>
        protected virtual void OnSelectedLanguagesChanged(EventArgs e)
        {
            if (SelectedLanguagesChanged != null)
                SelectedLanguagesChanged(this, e);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Click event of removeLanguageFromList object.
        /// </summary>
        private void removeLanguageFromList_Click(object sender, EventArgs e)
        {
            // if language is selected
            if (selectedLanguagesListBox.SelectedIndex > -1)
            {
                selectedLanguagesListBox.Items.RemoveAt(selectedLanguagesListBox.SelectedIndex);

                OnSelectedLanguagesChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the Click event of removeAllLanguagesFromList object.
        /// </summary>
        private void removeAllLanguagesFromList_Click(object sender, EventArgs e)
        {
            // if language list is not empty
            if (selectedLanguagesListBox.Items.Count > 0)
            {
                selectedLanguagesListBox.Items.Clear();

                OnSelectedLanguagesChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the Click event of moveUpButton object.
        /// </summary>
        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = selectedLanguagesListBox.SelectedIndex;
            if (index > 0)
            {
                selectedLanguagesListBox.Items.Insert(index - 1, selectedLanguagesListBox.Items[index]);
                selectedLanguagesListBox.Items.RemoveAt(index + 1);
                selectedLanguagesListBox.SelectedIndex = index - 1;

                OnSelectedLanguagesChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the Click event of moveDownButton object.
        /// </summary>
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = selectedLanguagesListBox.SelectedIndex;
            if (index > -1 && index < selectedLanguagesListBox.Items.Count - 1)
            {
                selectedLanguagesListBox.Items.Insert(index + 2, selectedLanguagesListBox.Items[index]);
                selectedLanguagesListBox.Items.RemoveAt(index);
                selectedLanguagesListBox.SelectedIndex = index + 1;

                OnSelectedLanguagesChanged(EventArgs.Empty);
            }
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the selected languages are changed.
        /// </summary>
        public event EventHandler SelectedLanguagesChanged;

        #endregion

    }
}
