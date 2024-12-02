using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to edit form field view settings.
    /// </summary>
    public partial class FormFieldViewSettingsEditorForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FormFieldViewSettingsEditorForm"/> class.
        /// </summary>
        /// <param name="settings">Form field view settings.</param>
        public FormFieldViewSettingsEditorForm(FormFieldViewSettings settings)
        {
            InitializeComponent();

            _formFieldSettings = settings;

            // set OCR form field view settings
            confidenceThresholdTrackBar.Value = (int)(FormFieldSettings.OcrConfidenceThreshold * 100);
            if (FormFieldSettings.OcrCertainObjectsBrush is SolidBrush)
                certainObjectsBackgroundColorPanelControl.Color = ((SolidBrush)FormFieldSettings.OcrCertainObjectsBrush).Color;
            if (FormFieldSettings.OcrUncertainObjectsBrush is SolidBrush)
                uncertainObjectsBackgroundColorPanelControl.Color = ((SolidBrush)FormFieldSettings.OcrUncertainObjectsBrush).Color;
            certainObjectsBorderColorPanelControl.Color = FormFieldSettings.OcrCertainObjectsPen.Color;
            certainObjectsBorderWidthNumericUpDown.Value = (decimal)FormFieldSettings.OcrCertainObjectsPen.Width;
            uncertainObjectsBorderColorPanelControl.Color = FormFieldSettings.OcrUncertainObjectsPen.Color;
            uncertainObjectsBorderWidthNumericUpDown.Value = (decimal)FormFieldSettings.OcrUncertainObjectsPen.Width;

            // set OMR form field view settings
            if (FormFieldSettings.OmrFilledBrush is SolidBrush)
                filledObjectsBackgroundColorPanelControl.Color = ((SolidBrush)FormFieldSettings.OmrFilledBrush).Color;
            if (FormFieldSettings.OmrUnfilledBrush is SolidBrush)
                unfilledObjectsBackgroundColorPanelControl.Color = ((SolidBrush)FormFieldSettings.OmrUnfilledBrush).Color;
            if (FormFieldSettings.OmrUndefinedBrush is SolidBrush)
                undefinedObjectsBorderColorPanelControl.Color = ((SolidBrush)FormFieldSettings.OmrUndefinedBrush).Color;
            objectsBorderColorPanelControl.Color = FormFieldSettings.OmrPen.Color;
            objectsBorderWidthNumericUpDown.Value = (decimal)FormFieldSettings.OmrPen.Width;
        }

        #endregion



        #region Properties

        FormFieldViewSettings _formFieldSettings;
        /// <summary>
        /// Gets or sets form field view settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FormFieldViewSettings FormFieldSettings
        {
            get
            {
                return _formFieldSettings;
            }
            set
            {
                _formFieldSettings = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // set OCR form field view settings
            FormFieldSettings.OcrConfidenceThreshold = confidenceThresholdTrackBar.Value / 100.0f;
            FormFieldSettings.OcrCertainObjectsBrush = new SolidBrush(certainObjectsBackgroundColorPanelControl.Color);
            FormFieldSettings.OcrUncertainObjectsBrush = new SolidBrush(uncertainObjectsBackgroundColorPanelControl.Color);
            FormFieldSettings.OcrCertainObjectsPen = new Pen(
                certainObjectsBorderColorPanelControl.Color,
                (float)certainObjectsBorderWidthNumericUpDown.Value);
            FormFieldSettings.OcrUncertainObjectsPen = new Pen(
                uncertainObjectsBorderColorPanelControl.Color,
                (float)uncertainObjectsBorderWidthNumericUpDown.Value);

            // set OMR form field view settings
            FormFieldSettings.OmrFilledBrush = new SolidBrush(filledObjectsBackgroundColorPanelControl.Color);
            FormFieldSettings.OmrUnfilledBrush = new SolidBrush(unfilledObjectsBackgroundColorPanelControl.Color);
            FormFieldSettings.OmrUndefinedBrush = new SolidBrush(undefinedObjectsBorderColorPanelControl.Color);
            FormFieldSettings.OmrPen = new Pen(
                objectsBorderColorPanelControl.Color,
                (float)objectsBorderWidthNumericUpDown.Value);

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is clicked.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
