using Vintasoft.Imaging.FormsProcessing.FormRecognition.UI;

namespace FormsProcessingDemo
{
    /// <summary>
    /// Determines how to display a barcode field template
    /// and how user can interact with it.
    /// </summary>
    public class BarcodeFieldTemplateView : FormFieldTemplateView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeFieldTemplateView"/> class.
        /// </summary>
        /// <param name="fieldTemplate">Barcode field template.</param>
        public BarcodeFieldTemplateView(BarcodeFieldTemplate fieldTemplate)
            : base(fieldTemplate)
        {
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new BarcodeFieldTemplateView((BarcodeFieldTemplate)FieldTemplate.Clone());
        }
    }
}
