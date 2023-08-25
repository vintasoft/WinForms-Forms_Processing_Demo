using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;


namespace DemosCommonCode
{
    /// <summary>
    /// A form that allows to:
    /// <ul>
    /// <li>view and select the image processing commands</li>
    /// <li>view source image</li>
    /// <li>apply selected image processing command to the source image and view the processed image</li>
    /// </ul>
    /// </summary>
    public partial class ImageProcessingForm : Form
    {

        #region Fields

        /// <summary>
        /// The source image for processing.
        /// </summary>
        VintasoftImage _sourceImage;

        /// <summary>
        /// The current image in viewer.
        /// </summary>
        VintasoftImage _currentImage;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingForm"/> class.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="availableImageProcessingCommands">The available processing commands.</param>
        /// <param name="selectedImageProcessingCommands">The image processing commands,
        /// which must be applied to an image by default.</param>
        public ImageProcessingForm(
            VintasoftImage sourceImage,
            ProcessingCommandBase[] availableImageProcessingCommands,
            params ProcessingCommandBase[] selectedImageProcessingCommands)
            : this(sourceImage)
        {
            Dictionary<string, ProcessingCommandBase[]> availableProcessingCommandsDictionary =
                new Dictionary<string, ProcessingCommandBase[]>();
            availableProcessingCommandsDictionary.Add(string.Empty, availableImageProcessingCommands);

            imageProcessingCommandSelectionControl1.AvailableProcessingCommands = availableProcessingCommandsDictionary;
            imageProcessingCommandSelectionControl1.SelectedCommands = selectedImageProcessingCommands;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingForm"/> class.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="availableImageProcessingCommands">The available processing commands.</param>
        /// <param name="selectedImageProcessingCommands">The image processing commands,
        /// which must be applied to an image by default.</param>
        public ImageProcessingForm(
            VintasoftImage sourceImage,
            Dictionary<string, ProcessingCommandBase[]> availableImageProcessingCommands,
            params ProcessingCommandBase[] selectedImageProcessingCommands)
            : this(sourceImage)
        {
            imageProcessingCommandSelectionControl1.AvailableProcessingCommands = availableImageProcessingCommands;
            imageProcessingCommandSelectionControl1.SelectedCommands = selectedImageProcessingCommands;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingForm"/> class.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        private ImageProcessingForm(VintasoftImage sourceImage)
        {
            InitializeComponent();

            _sourceImage = sourceImage;
            imageViewer1.Image = sourceImage;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the selected commands.
        /// </summary>
        public ProcessingCommandBase[] SelectedCommands
        {
            get
            {
                if (enableImageProcessingCheckBox.Checked)
                    return imageProcessingCommandSelectionControl1.SelectedCommands;
                else
                    return null;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raizes the <see cref="E:System.Windows.Forms.Form.Shown" /> event.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (imageProcessingCommandSelectionControl1.SelectedCommands != null &&
                imageProcessingCommandSelectionControl1.SelectedCommands.Length > 0)
                enableImageProcessingCheckBox.Checked = true;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the CheckedChanged event of EnableImageProcessingCheckBox object.
        /// </summary>
        private void enableImageProcessingCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            // if image must be processed
            if (enableImageProcessingCheckBox.Checked)
                imageProcessingCommandSelectionControl1.Enabled = true;
            else
                imageProcessingCommandSelectionControl1.Enabled = false;

            ProcessImage();
        }

        /// <summary>
        /// Handles the ProcessingCommandsChanged event of ImageProcessingCommandsEditor1 object.
        /// </summary>
        private void imageProcessingCommandsEditor1_ProcessingCommandsChanged(
            object sender,
            System.EventArgs e)
        {
            // process the image
            ProcessImage();
        }


        /// <summary>
        /// Processes the image.
        /// </summary>
        private void ProcessImage()
        {
            if (SelectedCommands == null ||
                SelectedCommands.Length == 0)
            {
                UpdateImage(_sourceImage);
            }
            else
            {
                CompositeCommand processingCommand = new CompositeCommand(SelectedCommands);

                imageProcessingCommandSelectionControl1.Enabled = false;
                try
                {
                    processingCommand.Started += new EventHandler<ImageProcessingEventArgs>(processingCommand_Started);
                    processingCommand.Progress += new EventHandler<ImageProcessingProgressEventArgs>(processingCommand_Progress);
                    processingCommand.Finished += new EventHandler<ImageProcessedEventArgs>(processingCommand_Finished);

                    VintasoftImage processedImage;
                    try
                    {
                        processedImage = processingCommand.Execute(_sourceImage);
                    }
                    finally
                    {
                        processingCommand.Started -= processingCommand_Started;
                        processingCommand.Progress -= processingCommand_Progress;
                        processingCommand.Finished -= processingCommand_Finished;
                    }

                    UpdateImage(processedImage);
                }
                catch (Exception exc)
                {
                    DemosTools.ShowErrorMessage(exc);
                    return;
                }
                finally
                {
                    imageProcessingCommandSelectionControl1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// The processing command is started.
        /// </summary>
        private void processingCommand_Started(object sender, ImageProcessingEventArgs e)
        {
            processImageProgressBar.Value = 0;
            processImageProgressBar.Visible = true;
            imageProcessingCommandSelectionControl1.Enabled = false;
            enableImageProcessingCheckBox.Enabled = false;
        }

        /// <summary>
        /// The progress, of processing command, is changed.
        /// </summary>
        private void processingCommand_Progress(object sender, ImageProcessingProgressEventArgs e)
        {
            processImageProgressBar.Value = e.Progress;
            statusStrip1.Update();
        }

        /// <summary>
        /// The processing command is finished.
        /// </summary>
        private void processingCommand_Finished(object sender, ImageProcessedEventArgs e)
        {
            processImageProgressBar.Visible = false;
            imageProcessingCommandSelectionControl1.Enabled = true;
            enableImageProcessingCheckBox.Enabled = true;
        }

        /// <summary>
        /// Updates the image in image viewer.
        /// </summary>
        /// <param name="image">The image.</param>
        private void UpdateImage(VintasoftImage image)
        {
            imageViewer1.LoadTemporaryImage(image, true);

            if (_currentImage != null)
            {
                _currentImage.Dispose();
                _currentImage = null;
            }

            if (image != _sourceImage)
                _currentImage = image;
        }

        #endregion

        #endregion

    }
}
