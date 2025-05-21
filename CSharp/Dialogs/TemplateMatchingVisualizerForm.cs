using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.FormsProcessing.TemplateMatching;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.GraphicObjects;

using DemosCommonCode;
using DemosCommonCode.Imaging.Codecs;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to visualize the result of template matching command.
    /// </summary>
    public partial class TemplateMatchingVisualizerForm : Form
    {

        #region Fields

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleSelectedMenuItem;

        /// <summary>
        /// Available zoom values.
        /// </summary>
        int[] _zoomValues = new int[] { 1, 5, 10, 25, 50, 75, 100, 125, 150, 200, 400, 600, 800, 1000 };

        /// <summary>
        /// A value indicating whether the filled form image must be aligned to the template form image.
        /// </summary>
        bool _alignFilledImage;

        /// <summary>
        /// A value indicating whether image viewers must display processed images.
        /// </summary>
        bool _displayProcessedImages;

        /// <summary>
        /// A value indicating whether template matching is executed.
        /// </summary>
        bool _isTemplateMatchingExecuted = false;

        /// <summary>
        /// The template form image.
        /// </summary>
        VintasoftImage _templateFormImage;

        /// <summary>
        /// The filled form image.
        /// </summary>
        VintasoftImage _filledFormImage;

        /// <summary>
        /// The processed template form image.
        /// </summary>
        VintasoftImage _processedTemplateFormImage;

        /// <summary>
        /// The processed filled form image.
        /// </summary>
        VintasoftImage _processedFilledFormImage;

        /// <summary>
        /// The transformation matrix from the filled form image into the template form image.
        /// </summary>
        AffineMatrix _transformationMatrix = null;

        /// <summary>
        /// Key zone recognizers.
        /// </summary>
        KeyZoneRecognizerCommand[] _keyZoneRecognizerCommands;

        /// <summary>
        /// Key zones of template form image.
        /// </summary>
        KeyZone[] _templateZones;

        /// <summary>
        /// Key zones of filled form image.
        /// </summary>
        KeyZone[] _filledZones;

        /// <summary>
        /// The visual tool, which displays key zones on template form image.
        /// </summary>
        GraphicObjectTool _templateVisualTool;

        /// <summary>
        /// The visual tool, which displays key zones on filled form image.
        /// </summary>
        GraphicObjectTool _filledVisualTool;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TemplateMatchingVisualizerForm"/> class.
        /// </summary>
        /// <param name="command">The template matching command.</param>
        /// <param name="preprocessing">The preprocessing command.</param>
        /// <param name="keyZoneRecognizerCommands">The key zone recognizer.</param>
        public TemplateMatchingVisualizerForm(
            TemplateMatchingCommand command,
            ProcessingCommandBase preprocessing,
            KeyZoneRecognizerCommand[] keyZoneRecognizerCommands)
        {
            InitializeComponent();

            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog1);

            _matchingCommand = command;
            _keyZoneRecognizerPreprocessing = preprocessing;
            _keyZoneRecognizerCommands = keyZoneRecognizerCommands;

            // init "View => Image Scale Mode" menu
            normalImageToolStripMenuItem.Tag = ImageSizeMode.Normal;
            bestFitToolStripMenuItem.Tag = ImageSizeMode.BestFit;
            fitToWidthToolStripMenuItem.Tag = ImageSizeMode.FitToWidth;
            fitToHeightToolStripMenuItem.Tag = ImageSizeMode.FitToHeight;
            pixelToPixelToolStripMenuItem.Tag = ImageSizeMode.PixelToPixel;
            scaleToolStripMenuItem.Tag = ImageSizeMode.Zoom;
            scale25ToolStripMenuItem.Tag = 25;
            scale50ToolStripMenuItem.Tag = 50;
            scale100ToolStripMenuItem.Tag = 100;
            scale200ToolStripMenuItem.Tag = 200;
            scale400ToolStripMenuItem.Tag = 400;
            _imageScaleSelectedMenuItem = bestFitToolStripMenuItem;
            _imageScaleSelectedMenuItem.Checked = true;

            _alignFilledImage = alignFilledImageToolStripMenuItem.Checked;
            _displayProcessedImages = showKeyZoneRecognierPreprocessingToolStripMenuItem.Checked;

            // init visual tools
            _templateVisualTool = new GraphicObjectTool();
            _filledVisualTool = new GraphicObjectTool();
            templateImageViewer.VisualTool = _templateVisualTool;
            filledImageViewer.VisualTool = _filledVisualTool;

            // init colors
            sourceColorPanelControl.Color = Color.Blue;
            matchedColorPanelControl.Color = Color.Green;
            nonMatchedColorPanelControl.Color = Color.Red;

            sourceColorPanelControl.ColorChanged += new EventHandler(filledImageColorPanel_ColorChanged);
            openFileDialog1.Multiselect = false;

            UpdateUI();
        }

        #endregion



        #region Properties

        TemplateMatchingCommand _matchingCommand;
        /// <summary>
        /// Gets TemplateMatchingCommand used in form processing manager.
        /// </summary>
        private TemplateMatchingCommand MatchingCommand
        {
            get
            {
                return _matchingCommand;
            }
        }

        ProcessingCommandBase _keyZoneRecognizerPreprocessing;
        /// <summary>
        /// Gets Preprocessing commands used in form processing manager.
        /// </summary>
        private ProcessingCommandBase KeyZoneRecognizerPreprocessing
        {
            get
            {
                return _keyZoneRecognizerPreprocessing;
            }
        }

        #endregion



        #region Methods

        #region Main form

        /// <summary>
        /// Form is closed.
        /// </summary>
        private void TemplateMatchingVisualizerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // clear the image collection of the image viewers
            templateImageViewer.Images.ClearAndDisposeItems();
            filledImageViewer.Images.ClearAndDisposeItems();

            // dispose images
            if (_filledFormImage != null)
            {
                _filledFormImage.Dispose();
                _processedFilledFormImage.Dispose();
            }
            if (_templateFormImage != null)
            {
                _templateFormImage.Dispose();
                _processedTemplateFormImage.Dispose();
            }

            // dispose visual tools
            _templateVisualTool.Dispose();
            _filledVisualTool.Dispose();
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates user interface.
        /// </summary>
        private void UpdateUI()
        {
            // indicates whether template image is loaded
            bool isTemplateImageLoaded = templateImageViewer.Image != null;
            // indicates whether filled image is loaded
            bool isFilledImageLoaded = filledImageViewer.Image != null;

            showImprintsToolStripMenuItem.Enabled = isTemplateImageLoaded || isFilledImageLoaded;
            executeTemplateMatchingToolStripMenuItem.Enabled = isTemplateImageLoaded && isFilledImageLoaded;
            imprintPreprocessingToolStripMenuItem.Enabled = isTemplateImageLoaded && isFilledImageLoaded;

            zoomInButton.Enabled = isTemplateImageLoaded || isFilledImageLoaded;
            zoomTextBox.Enabled = isTemplateImageLoaded || isFilledImageLoaded;
            zoomOutButton.Enabled = isTemplateImageLoaded || isFilledImageLoaded;

            UpdateViewers();
        }

        /// <summary>
        /// Updates image viewers.
        /// </summary>
        private void UpdateViewers()
        {
            // if image viewer must display processed images
            if (_displayProcessedImages)
            {
                // if template image viewer is not empty
                if (templateImageViewer.Image != null)
                    // set processed template image to the template image viewer
                    templateImageViewer.Image = _processedTemplateFormImage;

                // if filled image viewer is not empty
                if (filledImageViewer.Image != null)
                {
                    VintasoftImage filledProcessImage;
                    // if transformation matrix is not empty,
                    // template matching is executed and
                    // filled form image must be aligned to the template form image
                    if (_transformationMatrix != null && _isTemplateMatchingExecuted && _alignFilledImage)
                    {
                        MatrixTransformCommand command = new MatrixTransformCommand();
                        command.Matrix = _transformationMatrix;
                        command.CropRect = new RectangleF(0, 0, _processedTemplateFormImage.Width, _processedTemplateFormImage.Height);
                        // transform processed filled form image
                        filledProcessImage = command.Execute(_processedFilledFormImage);
                    }
                    else
                    {
                        filledProcessImage = (VintasoftImage)_processedFilledFormImage.Clone();
                    }
                    // set processed filled form image to the image viewer
                    filledImageViewer.Image.SetImage(filledProcessImage);
                }
            }
            // if image viewer must display NOT processed (source) images
            else
            {
                // if template image viewer is not empty
                if (templateImageViewer.Image != null)
                    // set template image to the template image viewer
                    templateImageViewer.Image = _templateFormImage;

                // if filled image viewer is not empty
                if (filledImageViewer.Image != null)
                {
                    VintasoftImage filledImage;
                    // if transformation matrix is not empty,
                    // template matching is executed and
                    // filled form image must be aligned to the template form image
                    if (_transformationMatrix != null && _isTemplateMatchingExecuted && _alignFilledImage)
                    {
                        MatrixTransformCommand command = new MatrixTransformCommand();
                        command.Matrix = _transformationMatrix;
                        command.CropRect = new RectangleF(0, 0, _templateFormImage.Width, _templateFormImage.Height);
                        // transform filled form image
                        filledImage = command.Execute(_filledFormImage);
                    }
                    else
                    {
                        // copy filled form image
                        filledImage = (VintasoftImage)_filledFormImage.Clone();
                    }
                    // set filled form image to the image viewer
                    filledImageViewer.Image.SetImage(filledImage);
                }
            }

            // if template image viewer is not empty
            // and filled image viewer is not empty
            // and image size mode is zoom size mode
            if (templateImageViewer.Image != null &&
                filledImageViewer.Image != null &&
                templateImageViewer.SizeMode == ImageSizeMode.Zoom)
            {
                // set zoom value to filled image viewer
                filledImageViewer.Zoom = (int)GetImageZoom(
                    templateImageViewer.Image.Resolution,
                    filledImageViewer.Image.Resolution,
                    templateImageViewer.Zoom);
            }
        }

        /// <summary>
        /// Updates key zones on filled image viewer.
        /// </summary>
        private void UpdateKeyZonesOnFilledImageViewer()
        {
            // if filled image viewer is empty
            if (filledImageViewer.Image == null)
                return;

            RemoveZonesInVisualTool(_filledVisualTool);

            // get key zones of template form image
            int templateLength;
            if (_templateZones != null)
                templateLength = _templateZones.Length;
            else
                templateLength = 0;
            KeyZone[] templateZones = new KeyZone[templateLength];
            for (int i = 0; i < templateLength; i++)
                templateZones[i] = (KeyZone)_templateZones[i].Clone();

            // get key zones of filled form image
            int filledLength;
            if (_filledZones != null)
                filledLength = _filledZones.Length;
            else
                filledLength = 0;
            KeyZone[] filledZones = new KeyZone[filledLength];
            for (int i = 0; i < filledLength; i++)
                filledZones[i] = (KeyZone)_filledZones[i].Clone();

            // if template matching is executed
            if (_isTemplateMatchingExecuted)
            {
                // if filled form image must be aligned to the template form image
                if (_alignFilledImage)
                    // transform zones of filled form image
                    TransformZones(_transformationMatrix, filledZones, !_alignFilledImage);
                // if filled form image must NOT be aligned to the template form image
                else
                    // transform zones of template form image
                    TransformZones(_transformationMatrix, templateZones, !_alignFilledImage);
            }

            // show source zones
            ShowZones(filledZones, sourceColorPanelControl.Color, 10, _filledVisualTool);

            // if template matching is executed
            if (_isTemplateMatchingExecuted)
            {
                // get matched and non-matched zones
                KeyZone[] nonMatchingZones = null;
                KeyZone[] matchingZones = GetMatchingZones(templateZones, filledZones, (int)keyZoneLocationDeviationNumericUpDown.Value, out nonMatchingZones);

                // show matched and non-matched zones
                ShowZones(nonMatchingZones, nonMatchedColorPanelControl.Color, 10, _filledVisualTool);
                ShowZones(matchingZones, matchedColorPanelControl.Color, 10, _filledVisualTool);
            }
        }

        /// <summary>
        /// Updates key zones on template image viewer.
        /// </summary>
        private void UpdateKeyZonesOnTemplateImageViewer()
        {
            // if template image viewer is empty
            if (templateImageViewer.Image == null)
                return;

            // if template key zones is not found
            if (_templateZones == null)
                return;

            RemoveZonesInVisualTool(_templateVisualTool);

            // show source zones
            ShowZones(_templateZones, sourceColorPanelControl.Color, 10, _templateVisualTool);
        }

        #endregion


        #region 'File' menu

        /// <summary> 
        /// Opens a template form image file.
        /// </summary>
        private void openTemplateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if image file is selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // open image file
                    OpenFile(templateImageViewer, openFileDialog1.FileName);
                    // if image file is opened
                    if (templateImageViewer.Image != null)
                    {
                        _templateFormImage = (VintasoftImage)templateImageViewer.Image.Clone();

                        if (KeyZoneRecognizerPreprocessing != null)
                            _processedTemplateFormImage = KeyZoneRecognizerPreprocessing.Execute(_templateFormImage);
                        else
                            _processedTemplateFormImage = (VintasoftImage)_templateFormImage.Clone();
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    templateImageViewer.Images.ClearAndDisposeItems();
                }
            }

            UpdateUI();
        }

        /// <summary> 
        /// Opens a filled form image file.
        /// </summary>
        private void openFilledImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if image file is selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // open image file
                    OpenFile(filledImageViewer, openFileDialog1.FileName);
                    // if image file is opened
                    if (filledImageViewer.Image != null)
                    {
                        _filledFormImage = (VintasoftImage)filledImageViewer.Image.Clone();

                        if (KeyZoneRecognizerPreprocessing != null)
                            _processedFilledFormImage = KeyZoneRecognizerPreprocessing.Execute(_filledFormImage);
                        else
                            _processedFilledFormImage = (VintasoftImage)_filledFormImage.Clone();
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    filledImageViewer.Images.ClearAndDisposeItems();
                }
            }
            UpdateUI();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Changes image scale mode of image viewer.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            _imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if menu item is set to the ImageSizeMode
            if (_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                // set size mode 
                templateImageViewer.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                filledImageViewer.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                _imageScaleSelectedMenuItem.Checked = true;
            }
            // if menu item is set to the zoom mode
            else
            {
                // get zoom value
                int zoomValue = (int)_imageScaleSelectedMenuItem.Tag;
                // set ImageSizeMode to the Zoom
                templateImageViewer.SizeMode = ImageSizeMode.Zoom;
                filledImageViewer.SizeMode = ImageSizeMode.Zoom;
                // set zoom value
                templateImageViewer.Zoom = zoomValue;

                // if template form image viewer is not empty
                // and filled image viewer is not empty
                if (templateImageViewer.Image != null && filledImageViewer.Image != null)
                    filledImageViewer.Zoom = (int)GetImageZoom(templateImageViewer.Image.Resolution, filledImageViewer.Image.Resolution, zoomValue);
                else
                    filledImageViewer.Zoom = zoomValue;

                _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                _imageScaleSelectedMenuItem.Checked = true;
            }
        }

        /// <summary>
        /// Zoom of image viewer is changed.
        /// </summary>
        /// <remarks>
        /// Changes text in zoom combo box according to the current zoom.
        /// </remarks>
        private void imageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            if (templateImageViewer.Image == null)
            {
                templateImageViewer.Zoom = filledImageViewer.Zoom;
                zoomTextBox.Text = templateImageViewer.Zoom.ToString() + "%";
            }
            zoomTextBox.Text = templateImageViewer.Zoom.ToString() + "%";
        }

        /// <summary>
        /// Enables or disables aligning of filled form image.
        /// </summary>
        private void alignFilledImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if filled form image must be aligned to the template form image
            if (_alignFilledImage)
            {
                _alignFilledImage = false;
            }
            // if filled form image must NOT be aligned to the template form image
            else
            {
                _alignFilledImage = true;
            }
            alignFilledImageToolStripMenuItem.Checked = _alignFilledImage;

            UpdateViewers();
            UpdateKeyZonesOnFilledImageViewer();
        }

        /// <summary>
        /// Enables or disables showing key zone recognizer preprocessing.
        /// </summary>
        private void showKeyZoneRecognierPreprocessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if image viewers must display images, which are preprocessed by key zone recognizer
            if (_displayProcessedImages)
            {
                _displayProcessedImages = false;
            }
            // if image viewers must display images, which are NOT preprocessed by key zone recognizer
            else
            {
                _displayProcessedImages = true;
            }
            showKeyZoneRecognierPreprocessingToolStripMenuItem.Checked = _displayProcessedImages;

            UpdateViewers();
            UpdateKeyZonesOnFilledImageViewer();
        }

        #endregion


        #region 'Template Matching' menu

        /// <summary>
        /// Edits the properties of
        /// <see cref="Vintasoft.Imaging.FormsProcessing.TemplateMatching.KeyZoneRecognizerCommand"/>.
        /// </summary>
        private void imageImprintGeneratorPreprocessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessingCommandBase[] preprocessingCommands = null;

            // if imprint generator has preprocessing command
            if (_keyZoneRecognizerPreprocessing != null)
            {
                // if preprocessing command is composite command
                if (_keyZoneRecognizerPreprocessing is CompositeCommand)
                {
                    // get sub commands
                    CompositeCommand compositeCommand = (CompositeCommand)_keyZoneRecognizerPreprocessing;
                    preprocessingCommands = compositeCommand.GetCommands();
                }
                else
                {
                    // get command
                    preprocessingCommands = new ProcessingCommandBase[] {
                        _keyZoneRecognizerPreprocessing
                    };
                }
            }

#if REMOVE_DOCCLEANUP_PLUGIN
            ProcessingCommandBase[] availableProcessingCommands = new ProcessingCommandBase[] {
                    new DilateCommand(),
                    new ErodeCommand(),
            };
#else
            ProcessingCommandBase[] availableProcessingCommands = new ProcessingCommandBase[] {
                    new DespeckleCommand(),
                    new HalftoneRemovalCommand(),
                    new DilateCommand(),
                    new ErodeCommand(),
                    new BorderClearCommand(),
            };
#endif

            // create the image processing form
            using (ImageProcessingForm dlg = new ImageProcessingForm(
                    _filledFormImage,
                    availableProcessingCommands,
                    preprocessingCommands))
            {
                // set form title
                dlg.Text = "Preprocessing of image imprint generator";
                // set form start position
                dlg.StartPosition = FormStartPosition.CenterParent;
                // set owner
                dlg.Owner = this;
                // if dialog returns "OK"
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // get commands from the dialog
                    preprocessingCommands = dlg.SelectedCommands;

                    ProcessingCommandBase command = null;
                    // if there are some commands
                    if (preprocessingCommands != null)
                    {
                        // if there is only one command
                        if (preprocessingCommands.Length == 1)
                        {
                            // get this command
                            command = preprocessingCommands[0];
                        }
                        // if there are several commands
                        else
                        {
                            // create composite command
                            command = new CompositeCommand(preprocessingCommands);
                        }

                        // create processed images
                        _processedFilledFormImage.SetImage(command.Execute(_filledFormImage));
                        _processedTemplateFormImage.SetImage(command.Execute(_templateFormImage));
                    }
                    // if there is no any command
                    else
                    {
                        // copy not processed images
                        _processedFilledFormImage.SetImage((VintasoftImage)_filledFormImage.Clone());
                        _processedTemplateFormImage.SetImage((VintasoftImage)_templateFormImage.Clone());
                    }

                    _keyZoneRecognizerPreprocessing = command;

                    // create new imprint generator
                    MatchingCommand.ImageImprintGenerator =
                        CreateImageImprintGenerator(command);
                }
            }
            UpdateViewers();
        }

        /// <summary>
        /// Creates the
        /// <see cref="Vintasoft.Imaging.FormsProcessing.TemplateMatching.ImageImprintGeneratorCommand"/>.
        /// </summary>
        /// <param name="imagePreprocessing">The image preprocessing.</param>
        /// <returns>The image imprint generator command.</returns>
        private ImageImprintGeneratorCommand CreateImageImprintGenerator(
            ProcessingCommandBase imagePreprocessing)
        {
            // for each recognizer
            foreach (KeyZoneRecognizerCommand recognizerCommand in _keyZoneRecognizerCommands)
            {
                // set image preprocessing commands
                recognizerCommand.ImagePreprocessing = imagePreprocessing;
            }

            ImageImprintGeneratorCommand imprintGenerator = new ImageImprintGeneratorCommand(_keyZoneRecognizerCommands);

            // return generator
            return imprintGenerator;
        }

        /// <summary>
        /// Gets imprints of template form image and filled form image and
        /// displays key zones of imprints on images.
        /// </summary>
        private void showImprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isTemplateMatchingExecuted = false;

            string report = "";

            // if template image viewer is not empty
            if (templateImageViewer.Image != null)
            {
                RemoveZonesInVisualTool(_templateVisualTool);

                // create image imprint of template form image
                MatchingCommand.ImageImprintGenerator.Execute(_templateFormImage);

                // get zones on template form image
                _templateZones = MatchingCommand.ImageImprintGenerator.ImageImprint.KeyZones;

                // shows zones on template form image
                ShowZones(_templateZones, sourceColorPanelControl.Color, 10, _templateVisualTool);

                report += string.Format("Key zones on template image: {0}. \n", _templateZones.Length);
            }

            // if filled image viewer is not empty
            if (filledImageViewer.Image != null)
            {
                RemoveZonesInVisualTool(_filledVisualTool);

                VintasoftImage filledImage;
                // if image viewers must display images, which are preprocessed by key zone recognizer
                if (_displayProcessedImages)
                    // get processed filled form image
                    filledImage = (VintasoftImage)_processedFilledFormImage.Clone();
                // if image viewers must display images, which are NOT preprocessed by key zone recognizer
                else
                    // get filled form image
                    filledImage = (VintasoftImage)_filledFormImage.Clone();

                // create image imprint of filled form image
                MatchingCommand.ImageImprintGenerator.Execute(_filledFormImage);

                // get zones on filled form image
                _filledZones = MatchingCommand.ImageImprintGenerator.ImageImprint.KeyZones;

                filledImageViewer.Image.SetImage(filledImage);

                // shows zones on filled form image
                ShowZones(_filledZones, sourceColorPanelControl.Color, 10, _filledVisualTool);

                report += string.Format("Key zones on filled image: {0}. \n", _filledZones.Length);
            }

            MessageBox.Show(report, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Compares imprints of two images and
        /// shows found key zones on images.
        /// </summary>
        private void executeTemplateMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder report = new StringBuilder();
            Cursor = Cursors.WaitCursor;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // get imprint of template form image
                MatchingCommand.ImageImprintGenerator.Execute(_templateFormImage);
                ImageImprint imageImprint1 = MatchingCommand.ImageImprintGenerator.ImageImprint;

                // get imprint of filled form image
                MatchingCommand.ImageImprintGenerator.Execute(_filledFormImage);
                ImageImprint imageImprint2 = MatchingCommand.ImageImprintGenerator.ImageImprint;

                // get zones on template form image
                _templateZones = imageImprint1.KeyZones;
                // get zones on filled form image
                _filledZones = imageImprint2.KeyZones;

                RemoveZonesInVisualTool(_templateVisualTool);
                // shows zones on template form image
                ShowZones(_templateZones, sourceColorPanelControl.Color, 10, _templateVisualTool);

                // create imprint comparer
                ImageImprintComparer comparer = new ImageImprintComparer(imageImprint1);
                // compare two imprints
                ImageImprintCompareResult result = comparer.Compare(imageImprint2);

                VintasoftImage filledImage;
                if (_displayProcessedImages)
                    filledImage = (VintasoftImage)_processedFilledFormImage.Clone();
                else
                    filledImage = (VintasoftImage)_filledFormImage.Clone();

                _transformationMatrix = result.TransformMatrix;
                // if filled form image must be aligned to the template form image
                if (_alignFilledImage)
                {
                    // if transformation matrix is not empty
                    if (result.TransformMatrix != null)
                    {
                        MatrixTransformCommand command = new MatrixTransformCommand();
                        command.Matrix = _transformationMatrix;
                        command.CropRect = new RectangleF(0, 0, _templateFormImage.Width, _templateFormImage.Height);
                        // transform image
                        command.ExecuteInPlace(filledImage);
                    }
                }
                filledImageViewer.Image.SetImage(filledImage);

                _isTemplateMatchingExecuted = true;

                // show key zones on filled form image
                UpdateKeyZonesOnFilledImageViewer();

                // if comparison result is not reliable
                if (!result.IsReliable)
                {
                    icon = MessageBoxIcon.Warning;
                    report.AppendLine(string.Format("Template matching is not found (confidence {0:f2}%).", result.Confidence * 100));
                }
                else
                {
                    icon = MessageBoxIcon.Information;
                    report.AppendLine(string.Format("Template matching result is found with confidence {0:f2}%.", result.Confidence * 100));
                    report.AppendLine(string.Format("Transform Matrix: ({0:f3}; {1:f3}; {2:f3}; {3:f3}; {4:f3}; {5:f3}).",
                                            result.TransformMatrix.M11, result.TransformMatrix.M12,
                                            result.TransformMatrix.M21, result.TransformMatrix.M22,
                                            result.TransformMatrix.OffsetX, result.TransformMatrix.OffsetY));
                    report.AppendLine(string.Format("Average similarity: {0:f3}.", result.AvgSimilarity));
                    report.AppendLine(string.Format("Average location deviation: {0:f3} (X={1:f3}; Y={2:f3}).",
                                                result.AvgLocationDeviation,
                                                result.AvgLocationDeviationX,
                                                result.AvgLocationDeviationY));
                }

                report.AppendLine(string.Format("Key zones on template image: {0}.", _templateZones.Length));
                report.AppendLine(string.Format("Key zones on filled image: {0}.", _filledZones.Length));
                report.AppendLine(string.Format("Key zones matched: {0}.", result.CoincidentZoneCount));
                report.AppendLine(string.Format("Missing source zone count: {0}.", result.NotCoincidentSourceZoneCount));
                report.AppendLine(string.Format("Missing dest zone count: {0}.", result.NotCoincidentDestZoneCount));
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            MessageBox.Show(report.ToString(), "Info", MessageBoxButtons.OK, icon);
        }

        #endregion


        #region KeyZones manipulation

        /// <summary>
        /// Returns distance between two points.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>Distance between two points.</returns>
        private static double GetPointDistance(PointF point1, PointF point2)
        {
            return Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) +
                             (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

        /// <summary>
        /// Returns array with matching key zones.
        /// </summary>
        /// <param name="zones1">The first key zones.</param>
        /// <param name="zones2">The second key zones.</param>
        /// <param name="matchingThreshold">The matching threshold of two key zones.</param>
        /// <param name="nonMatchingZones">Non-matching zones.</param>
        /// <returns>Matching zones.</returns>
        private KeyZone[] GetMatchingZones(
            KeyZone[] zones1,
            KeyZone[] zones2,
            int matchingThreshold,
            out KeyZone[] nonMatchingZones)
        {
            List<KeyZone> matchingZonesList = new List<KeyZone>();
            List<KeyZone> nonMatchingZonesList = new List<KeyZone>();
            foreach (KeyZone zone1 in zones1)
            {
                // indicates if two zones are matched
                bool isMatched = false;
                foreach (KeyZone zone2 in zones2)
                {
                    if (GetPointDistance(zone1.Location, zone2.Location) < matchingThreshold)
                    {
                        matchingZonesList.Add(zone2);
                        isMatched = true;
                        break;
                    }
                }

                // if two zones are not matched
                if (!isMatched)
                    nonMatchingZonesList.Add(zone1);
            }
            nonMatchingZones = nonMatchingZonesList.ToArray();
            return matchingZonesList.ToArray();
        }

        /// <summary>
        /// Shows found key zones.
        /// </summary>
        /// <param name="zones">Found key zones.</param>
        /// <param name="penColor">The color of pen.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="visualTool">The visual tool.</param>
        private void ShowZones(KeyZone[] zones, Color penColor, int radius, GraphicObjectTool visualTool)
        {
            // set colors, pens, brush
            int alphaComponentOfLineAndBrush = (int)transparencyNumericUpDown.Value;
            int alphaComponentOfFigureContour = (int)transparencyNumericUpDown.Value + 128;
            if (alphaComponentOfFigureContour > 255)
                alphaComponentOfFigureContour = 255;
            Color colorOfLineAndBrush = Color.FromArgb(alphaComponentOfLineAndBrush, penColor);
            Color colorOfFigureContour = Color.FromArgb(alphaComponentOfFigureContour, penColor);
            Brush brush = new SolidBrush(colorOfLineAndBrush);
            Pen penOfLine = new Pen(colorOfLineAndBrush, 5);
            Pen penOfFigureContour = new Pen(colorOfFigureContour, 5);

            // for each zone
            for (int i = 0; i < zones.Length; i++)
            {
                // if zone is line
                if (zones[i] is KeyLineZone)
                {
                    // get line zone
                    KeyLineZone lineZone = (KeyLineZone)zones[i];
                    // get start and end points of zone
                    PointF[] pointsOfKeyZone = new PointF[]{
                        lineZone.FirstPoint,
                        lineZone.SecondPoint
                    };
                    // set types of points
                    byte[] typesOfPoints = new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line };
                    // create path
                    GraphicsPath path = new GraphicsPath(pointsOfKeyZone, typesOfPoints);
                    PathGraphicObject line = new PathGraphicObject(path, penOfLine, brush);
                    // set point transformation
                    line.PointTransform = new PixelsToImageViewerPointFTransform();
                    // add zone as line
                    visualTool.GraphicObjectCollection.Add(line);

                    // get coordinates of zone
                    PointF location = zones[i].Location;
                    // create circle - the center of line
                    RectangleF rect = new RectangleF(location.X - radius, location.Y - radius, 2 * radius, 2 * radius);
                    EllipticalGraphicObject circleObject = new EllipticalGraphicObject(rect, penOfFigureContour, brush);
                    // set point transformation
                    circleObject.PointTransform = new PixelsToImageViewerPointFTransform();
                    // add center of zone as circle
                    visualTool.GraphicObjectCollection.Add(circleObject);

                    // create circle - the start of line
                    rect = new RectangleF(pointsOfKeyZone[0].X - radius / 2, pointsOfKeyZone[0].Y - radius / 2, radius, radius);
                    circleObject = new EllipticalGraphicObject(rect, penOfFigureContour, brush);
                    // set point transformation
                    circleObject.PointTransform = new PixelsToImageViewerPointFTransform();
                    // add start of zone as circle
                    visualTool.GraphicObjectCollection.Add(circleObject);

                    // create circle - the end of line
                    rect = new RectangleF(pointsOfKeyZone[1].X - radius / 2, pointsOfKeyZone[1].Y - radius / 2, radius, radius);
                    circleObject = new EllipticalGraphicObject(rect, penOfFigureContour, brush);
                    // set point transformation
                    circleObject.PointTransform = new PixelsToImageViewerPointFTransform();
                    // add end of zone as circle
                    visualTool.GraphicObjectCollection.Add(circleObject);
                }
                else
                {
                    // get coordinates of zone
                    PointF location = zones[i].Location;
                    // create rectangle
                    RectangleF rect = new RectangleF(location.X - radius, location.Y - radius, 2 * radius, 2 * radius);
                    RectangularGraphicObject rectangularObject = new RectangularGraphicObject(rect, penOfFigureContour, brush);
                    // set point transformation
                    rectangularObject.PointTransform = new PixelsToImageViewerPointFTransform();
                    // add zone as rectangle
                    visualTool.GraphicObjectCollection.Add(rectangularObject);
                }
            }
        }

        /// <summary>
        /// Removes all zones in visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        private void RemoveZonesInVisualTool(GraphicObjectTool visualTool)
        {
            visualTool.GraphicObjectCollection.Clear();
        }

        /// <summary>
        /// Transforms key zones by transform matrix.
        /// </summary>
        /// <param name="transformMatrix">The transform matrix.</param>
        /// <param name="zones">The key zones.</param>
        /// <param name="applyInverseTransform">The direction of transformation.</param>
        private void TransformZones(AffineMatrix transformMatrix, KeyZone[] zones, bool applyInverseTransform)
        {
            // if direction is forward
            if (applyInverseTransform && transformMatrix != null)
                // get invert transform matrix
                transformMatrix = AffineMatrix.Invert(transformMatrix);
            // foreach key zone 
            foreach (KeyZone zone in zones)
                // transform key zone
                zone.Transform(transformMatrix);
        }

        #endregion


        #region 'Color Of Key Zones' groupBox

        /// <summary>
        /// Color of filled form image key zones is changed.
        /// </summary>
        private void filledImageColorPanel_ColorChanged(object sender, EventArgs e)
        {
            UpdateKeyZonesOnFilledImageViewer();
        }

        /// <summary>
        /// Color of template form image key zones is changed.
        /// </summary>
        private void sourceColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            UpdateKeyZonesOnTemplateImageViewer();
        }

        /// <summary>
        /// Key zone matching threshold value is changed.
        /// </summary>
        private void keyZoneLocationDeviationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if filled image viewer is empty
            if (filledImageViewer.Image == null)
                return;
            // if template matching is not executed
            if (!_isTemplateMatchingExecuted)
                return;

            // update key zones on filled image viewer
            UpdateKeyZonesOnFilledImageViewer();
        }

        /// <summary>
        /// Transparency value is changed.
        /// </summary>
        private void alphaColorsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update key zones on filled image viewer
            UpdateKeyZonesOnFilledImageViewer();
            // update key zones on template image viewer
            UpdateKeyZonesOnTemplateImageViewer();
        }

        #endregion


        #region ToolStrip

        /// <summary>
        /// Updates zoom value in text box.
        /// </summary>
        private void UpdateTextBoxZoom()
        {
            zoomTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0}%", templateImageViewer.Zoom);
        }

        /// <summary>
        /// Decreases zoom value.
        /// </summary>
        private void zoomOutButton_Click(object sender, System.EventArgs e)
        {
            // if zoom value is greater than minimum zoom value
            if (templateImageViewer.Zoom > _zoomValues[0])
            {
                int zoomValue = templateImageViewer.Zoom;
                // if template form image viewer is not empty
                if (templateImageViewer.Image == null)
                    zoomValue = filledImageViewer.Zoom;

                _imageScaleSelectedMenuItem.Checked = false;
                _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                _imageScaleSelectedMenuItem.Checked = true;

                // set ImageSizeMode to the Zoom
                templateImageViewer.SizeMode = ImageSizeMode.Zoom;
                filledImageViewer.SizeMode = ImageSizeMode.Zoom;

                int index = 0;
                // search current zoom value in array of available zoom values
                while (index < _zoomValues.Length && _zoomValues[index] < zoomValue)
                {
                    index++;
                }
                // set zoom value
                templateImageViewer.Zoom = _zoomValues[index - 1];

                // if template form image viewer is not empty and
                // filled image viewer is not empty
                if (templateImageViewer.Image != null && filledImageViewer.Image != null)
                    filledImageViewer.Zoom = (int)GetImageZoom(templateImageViewer.Image.Resolution, filledImageViewer.Image.Resolution, _zoomValues[index - 1]);
                else
                    filledImageViewer.Zoom = _zoomValues[index - 1];

                // update zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Increases zoom value.
        /// </summary>
        private void zoomInButton_Click(object sender, System.EventArgs e)
        {
            // if zoom value is greater than maximum zoom value
            if (templateImageViewer.Zoom < _zoomValues[_zoomValues.Length - 1])
            {
                int zoomValue = templateImageViewer.Zoom;
                // if template form image viewer is not empty
                if (templateImageViewer.Image == null)
                    zoomValue = filledImageViewer.Zoom;

                _imageScaleSelectedMenuItem.Checked = false;
                _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                _imageScaleSelectedMenuItem.Checked = true;

                // set ImageSizeMode to the Zoom
                templateImageViewer.SizeMode = ImageSizeMode.Zoom;
                filledImageViewer.SizeMode = ImageSizeMode.Zoom;

                int index = 0;
                // search current zoom value in array of available zoom values
                while (_zoomValues[index] <= zoomValue)
                {
                    index++;
                }
                // set zoom value
                templateImageViewer.Zoom = _zoomValues[index];

                // if template form image viewer is not empty
                // and filled image viewer is not empty
                if (templateImageViewer.Image != null && filledImageViewer.Image != null)
                    filledImageViewer.Zoom = (int)GetImageZoom(templateImageViewer.Image.Resolution, filledImageViewer.Image.Resolution, _zoomValues[index]);
                else
                    filledImageViewer.Zoom = _zoomValues[index];

                // update zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Key is pressed in zoom text box.
        /// </summary>
        /// <remarks>
        /// Changes zoom value according to the entered value.
        /// </remarks>
        private void zoomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if "Enter" is pressed
            if (e.KeyChar == '\r')
            {
                // get text from text box
                string sourceText = ((ToolStripTextBox)sender).Text.Replace("%", "");

                _imageScaleSelectedMenuItem.Checked = false;
                _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                _imageScaleSelectedMenuItem.Checked = true;

                // set ImageSizeMode to the Zoom
                templateImageViewer.SizeMode = ImageSizeMode.Zoom;
                filledImageViewer.SizeMode = ImageSizeMode.Zoom;

                int value;
                if (int.TryParse(sourceText, out value) && value > 0)
                {
                    // set zoom value
                    templateImageViewer.Zoom = value;

                    // if template form image viewer is not empty
                    // and filled image viewer is not empty
                    if (templateImageViewer.Image != null && filledImageViewer.Image != null)
                        filledImageViewer.Zoom = (int)GetImageZoom(templateImageViewer.Image.Resolution, filledImageViewer.Image.Resolution, value);
                    else
                        filledImageViewer.Zoom = value;
                }

                // update zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Returns zoom value for the image.
        /// </summary>
        /// <param name="resolution1">The first resolution.</param>
        /// <param name="resolution2">The second resolution.</param>
        /// <param name="zoomValue">The zoom value.</param>
        /// <returns>Modified zoom.</returns>
        private float GetImageZoom(Resolution resolution1, Resolution resolution2, int zoomValue)
        {
            float maxFirstResolutionComponent = Math.Max((float)resolution1.Horizontal, (float)resolution1.Vertical);
            float maxSecondResolutionComponent = Math.Max((float)resolution2.Horizontal, (float)resolution2.Vertical);

            return zoomValue * (maxSecondResolutionComponent / maxFirstResolutionComponent);
        }

        #endregion


        #region File manipulation

        /// <summary> 
        /// Opens image files and adds to the image collection of image viewer.
        /// Binarization is applied if necessary.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <param name="filename">The filename of image file.</param>
        private void OpenFile(ImageViewer viewer, string filename)
        {
            // remove zones
            RemoveZonesInVisualTool(_templateVisualTool);
            RemoveZonesInVisualTool(_filledVisualTool);

            _templateZones = null;

            _isTemplateMatchingExecuted = false;

            // if image collection of the image viewer is not empty
            if (viewer.Images.Count > 0)
                // clear the image collection of the image viewer
                viewer.Images.ClearAndDisposeItems();

            // create binarization form
            using (ImageBinarizationForm binarizationForm = new ImageBinarizationForm(
                new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Global),
                new RenderingSettings(300, 300)))
            {
                // select image from image collection
                VintasoftImage image = DemosCommonCode.Imaging.SelectImageForm.SelectImageFromFile(filename);

                // if the selected image is null 
                if (image == null)
                    return;

                // if binarization is canceled
                if (binarizationForm.Cancel)
                {
                    image.Dispose();
                    return;
                }

                if (image.PixelFormat != PixelFormat.BlackWhite)
                {
                    ProcessingCommandBase processingCommand = null;
                    // if settings shall be applied for all remaining images or
                    // settings are approved
                    if (binarizationForm.ApplyForAll || binarizationForm.ShowDialog(image))
                    {
                        image.RenderingSettings = binarizationForm.GetRenderingSettings();
                        processingCommand = binarizationForm.GetProcessingCommand();
                    }
                    // if binarization is canceled
                    if (binarizationForm.Cancel || binarizationForm.Skip)
                    {
                        image.Dispose();
                        return;
                    }
                    // if processing command is set
                    if (processingCommand != null)
                    {
                        try
                        {
                            processingCommand.ExecuteInPlace(image);
                        }
                        catch (Exception ex)
                        {
                            DemosTools.ShowErrorMessage(ex);
                            image.Dispose();
                            return;
                        }
                    }
                }



                viewer.Image = image;
            }
        }

        #endregion

        #endregion

    }
}
