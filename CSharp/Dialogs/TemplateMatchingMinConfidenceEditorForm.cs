using System;
using System.Windows.Forms;

using Vintasoft.Imaging.FormsProcessing.TemplateMatching;

namespace FormsProcessingDemo
{
    /// <summary> 
    /// A form that allow to change MinConfidence value of template matching command.
    /// </summary>
    public partial class TemplateMatchingMinConfidenceEditorForm : Form
    {

        #region Fields

        /// <summary>
        /// The template matching command.
        /// </summary>
        TemplateMatchingCommand _templateMatching;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateMatchingMinConfidenceEditorForm"/> class.
        /// </summary>
        public TemplateMatchingMinConfidenceEditorForm(TemplateMatchingCommand command)
        {
            InitializeComponent();

            _templateMatching = command;
            minConfidenceTrackBar.Value = (int)(_templateMatching.MinConfidence * 100);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Changes MinConfidence value of template matching command.
        /// </summary>
        private void minConfidenceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            minConfidenceValueLabel.Text = minConfidenceTrackBar.Value.ToString() + "%";
        }

        /// <summary>
        /// Sets MinConfidence value to the template matching command
        /// and closes form with DialogResult "OK".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _templateMatching.MinConfidence = (minConfidenceTrackBar.Value) / 100f;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Closes form with DialogResult "Cancel".
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
