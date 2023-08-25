using System;
using System.Drawing;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif
using Vintasoft.Imaging.FormsProcessing.FormRecognition.UI;
using Vintasoft.Imaging;

namespace FormsProcessingDemo
{
    /// <summary>
    /// Determines how to display a recognized barcode field
    /// and how user can interact with it.
    /// </summary>
    public class BarcodeFieldView : FormFieldView
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeFieldView"/> class.
        /// </summary>
        /// <param name="field">The barcode field.</param>
        public BarcodeFieldView(BarcodeField field)
            : base(field)
        {
            BarcodeBrush = Brush;
            Brush = null;
        }

        #endregion



        #region Properties

        Brush _barcodeBrush;
        /// <summary>
        /// Gets or sets the background brush of the recognized barcode.
        /// </summary>
        /// <value>
        /// Default value is SolidBrush(Color.FromArgb(48, Color.Green)).
        /// </value>
        public Brush BarcodeBrush
        {
            get
            {
                return _barcodeBrush;
            }
            set
            {
                if (_barcodeBrush != value)
                {
                    _barcodeBrush = value;
                    OnStateChanged(EventArgs.Empty);
                }
            }
        }

        Pen _barcodePen = new Pen(Color.FromArgb(150, Color.Green), 1f);
        /// <summary>
        /// Gets or sets the border pen of the recognized barcode.
        /// </summary>
        /// <value>
        /// Default value is Pen(Color.FromArgb(192, Color.Green), 2f).
        /// </value>
        public Pen BarcodePen
        {
            get
            {
                return _barcodePen;
            }
            set
            {
                if (_barcodePen != value)
                {
                    _barcodePen = value;
                    OnStateChanged(EventArgs.Empty);
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Draws the barcode field on the <see cref="System.Drawing.Graphics"/>
        /// in the coordinate space of barcode field.
        /// </summary>
        /// <param name="g">The <see cref="System.Drawing.Graphics"/> to draw on.</param>
        protected override void DrawInContentSpace(Graphics g)
        {
            // the recognized barcode field
            BarcodeField field = Field as BarcodeField;
#if !REMOVE_BARCODE_SDK
            // the recognized barcode info
            IBarcodeInfo barcodeInfo = field.BarcodeInfo;
            // if barcode is recognized
            if (barcodeInfo != null)
            {
                // get barcode region points, in pixels
                Point[] regionPoints = Vintasoft.Imaging.GdiConverter.Convert(barcodeInfo.Region.GetPoints());
                // the resolution of the template image
                Resolution imageResolution = field.TemplateResolution;
                // get the location of the bounding box
                PointF fieldLocation = field.FieldTemplate.BoundingBox.Location;

                // array of points in the DIP space (device-independent pixels, 1/96 of inch)
                PointF[] regionPointsInDIP = new PointF[regionPoints.Length];
                for (int i = 0; i < regionPoints.Length; i++)
                {
                    // calculate the location of the point in the DIP space

                    Point pointInPixels = regionPoints[i];
                    regionPointsInDIP[i] = new PointF(
                        pointInPixels.X * (96 / (float)imageResolution.Horizontal) + fieldLocation.X,
                        pointInPixels.Y * (96 / (float)imageResolution.Vertical) + fieldLocation.Y);
                }

                // fill the barcode area
                if (BarcodeBrush != null)
                    g.FillPolygon(BarcodeBrush, regionPointsInDIP);
                // draw the outline of the barcode area
                if (BarcodePen != null)
                    g.DrawPolygon(BarcodePen, regionPointsInDIP);
            } 
#endif

            // draw the field area
            base.DrawInContentSpace(g);
        }

        #endregion

    }
}
