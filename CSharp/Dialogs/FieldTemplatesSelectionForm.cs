using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.FormsProcessing.FormRecognition;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to select the form field template.
    /// </summary>
    public partial class FieldTemplatesSelectionForm : Form
    {

        #region Fields

        /// <summary>
        /// The field templates.
        /// </summary>
        IList<FormFieldTemplate> _fieldTemplates;

        #endregion



        #region Constructors

        private FieldTemplatesSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldTemplatesSelectionForm"/> class.
        /// </summary>
        /// <param name="fieldTemplates">The field templates.</param>
        public FieldTemplatesSelectionForm(IList<FormFieldTemplate> fieldTemplates)
            : this()
        {
            _fieldTemplates = fieldTemplates;
            for (int i = 0; i < fieldTemplates.Count; i++)
            {
                FormFieldTemplate fieldTemplate = fieldTemplates[i];
                string text;
                if (string.IsNullOrEmpty(fieldTemplate.Name))
                    text = string.Format("{0}, {1}", fieldTemplate.GetType().Name, fieldTemplate.BoundingBox);
                else
                    text = string.Format("{0}, {1}", fieldTemplate.Name, fieldTemplate.BoundingBox);
                fieldTemplatesCheckedListBox.Items.Add(text);
            }
        }

        #endregion



        #region Properties

        IList<FormFieldTemplate> _selectedFieldTemplates;
        /// <summary>
        /// Gets the selected field templates.
        /// </summary>
        public IList<FormFieldTemplate> SelectedFieldTemplates
        {
            get
            {
                return _selectedFieldTemplates;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of the OK button.
        /// </summary>
        private void btOk_Click(object sender, EventArgs e)
        {
            _selectedFieldTemplates = new List<FormFieldTemplate>();

            for (int i = 0; i < _fieldTemplates.Count; i++)
            {
                if (fieldTemplatesCheckedListBox.GetItemChecked(i))
                    _selectedFieldTemplates.Add(_fieldTemplates[i]);
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the Cancel button.
        /// </summary>
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}