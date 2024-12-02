using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Drawing.Gdi;

using DemosCommonCode.Imaging;

namespace DemosCommonCode
{
    /// <summary>
    /// A control that allows to:
    /// <ul>
    /// <li>view and select the image processing commands</li>
    /// <li>view source image</li>
    /// <li>apply selected image processing command to the source image and view the processed image</li>
    /// </ul>
    /// </summary>
    public partial class ImageProcessingControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingControl"/> class.
        /// </summary>
        public ImageProcessingControl()
        {
            InitializeComponent();

            sourceImageViewer.Images.ImageCollectionChanged +=
                new EventHandler<ImageCollectionChangeEventArgs>(Images_ImageCollectionChanged);

            sourceImageViewer.ScrollChanged += new PropertyChangedEventHandler<Point>(sourceImageViewer_ScrollChanged);
            processedImageViewer.ScrollChanged += new PropertyChangedEventHandler<Point>(processedImageViewer_ScrollChanged);

            UpdateUI();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the available image processing commands.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, ProcessingCommandBase[]> AvailableProcessingCommands
        {
            get
            {
                return imageProcessingCommandsEditor1.AvailableProcessingCommands;
            }
            set
            {
                imageProcessingCommandsEditor1.AvailableProcessingCommands = value;
                UpdateUI();
            }
        }

        /// <summary>
        /// Gets or sets the selected commands.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProcessingCommandBase[] SelectedCommands
        {
            get
            {
                return imageProcessingCommandsEditor1.SelectedCommands;
            }
            set
            {
                imageProcessingCommandsEditor1.SelectedCommands = value;
            }
        }

        /// <summary>
        /// Gets the processed image.
        /// </summary>
        [Browsable(false)]
        public VintasoftImage ProcessedImage
        {
            get
            {
                return processedImageViewer.Image;
            }
        }

        /// <summary>
        /// Gets the main image viewer of control.
        /// </summary>
        [Browsable(false)]
        public ImageViewer ImageViewer
        {
            get
            {
                return sourceImageViewer;
            }
        }

        bool _useMultithreading = false;
        /// <summary>
        /// Gets or sets a value indicating
        /// whether the image processing commands must be executed parallely.
        /// </summary>
        /// <value>
        /// <b>true</b> if image processing commands must be executed parallely;
        /// otherwise, <b>false</b>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseMultithreading
        {
            get
            {
                return _useMultithreading;
            }
            set
            {
                _useMultithreading = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Synchronizes the viewer settings.
        /// </summary>
        public void SynchronizeViewerSettings()
        {
            SynchronizeViewerSettings(sourceImageViewer, processedImageViewer);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ProcessingCommandsChanged event of imageProcessingCommandsEditor1 object.
        /// </summary>
        private void imageProcessingCommandsEditor1_ProcessingCommandsChanged(object sender, EventArgs e)
        {
            // update the user interface
            UpdateUI();
        }


        #region Execute Processing Commands

        /// <summary>
        /// Handles the Click event of executeCommandOnImageButton object.
        /// </summary>
        private void executeCommandOnImageButton_Click(object sender, EventArgs e)
        {
            OnExecuteCommandStarted();
            try
            {

                // if viewer of the processed image has the highlighted result
                VisualTool processedImageViewerVisualTool = processedImageViewer.VisualTool;
                if (processedImageViewerVisualTool != null)
                {
                    // clear the highlighted result from the viewer of the processed image
                    processedImageViewer.VisualTool = null;
                    processedImageViewerVisualTool.Dispose();
                }

                // create a list image processing commands to execute
                List<ProcessingCommandBase> commandsList = new List<ProcessingCommandBase>();
                for (int i = 0; i < imageProcessingCommandsEditor1.SelectedCommands.Length; i++)
                {
                    ProcessingCommandBase command = (ProcessingCommandBase)imageProcessingCommandsEditor1.SelectedCommands[i];
                    if (UseMultithreading)
                        command = new ParallelizingProcessingCommand(command);
                    commandsList.Add(command);
                }

                CompositeCommand compositeCommand;
                try
                {
                    // create a composite command
                    compositeCommand = new CompositeCommand(commandsList.ToArray());
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    return;
                }

                // specify that command should return results of image processing
                compositeCommand.Results = new ProcessingCommandResults();

                ProcessingCommandBase executingCommand = compositeCommand;

                List<ProcessingCommandWithRegion> commandsWithChangedRegion = new List<ProcessingCommandWithRegion>();

                GraphicsPath path = null;
                if (sourceImageViewer.VisualTool is RectangularSelectionToolWithCopyPaste)
                {
                    // rectangular selection
                    RegionOfInterest region = new RegionOfInterest(
                        ((RectangularSelectionToolWithCopyPaste)sourceImageViewer.VisualTool).Rectangle);
                    if (region.Width > 0 && region.Height > 0)
                    {
                        for (int i = 0; i < commandsList.Count; i++)
                        {
                            ProcessingCommandWithRegion command = commandsList[i] as ProcessingCommandWithRegion;
                            if (command != null)
                            {
                                commandsWithChangedRegion.Add(command);
                                command.RegionOfInterest = region;
                                // if command change image size then
                                if (IsChangeImageSize(command))
                                    break;
                            }
                            else if (commandsList[i] is DrawImageCommand)
                            {
                                ((DrawImageCommand)commandsList[i]).DestRect = region.GetBoundingBox();
                            }
                        }
                    }
                }
                else if (sourceImageViewer.VisualTool is CustomSelectionTool)
                {
                    // custom selection
                    if (compositeCommand.CanModifyImage)
                    {
                        SelectionRegionBase selection = ((CustomSelectionTool)sourceImageViewer.VisualTool).Selection;
                        if (selection != null)
                        {
                            // get custom selection as graphical path
                            path = selection.GetAsGraphicsPath();
                            // if first command is Crop then
                            if (commandsList[0] is CropCommand)
                            {
                                // first command is crop to selection
                                CropCommand crop = (CropCommand)commandsList[0];
                                commandsList[0] = GetCropToPathCommand(path, path.GetBounds(), crop);
                                commandsWithChangedRegion.Add(crop);
                                // create a composite command
                                compositeCommand = new CompositeCommand(commandsList.ToArray());
                                executingCommand = compositeCommand;
                            }
                            else
                            {
                                // process path (custom selection)
                                executingCommand = new ProcessPathCommand(compositeCommand, new GdiGraphicsPath(path, false));
                            }
                        }
                    }
                }

                executingCommand.Progress += new EventHandler<ImageProcessingProgressEventArgs>(executingCommand_Progress);

                // execute the command
                VintasoftImage processedImage;
                try
                {
                    processedImage = executingCommand.Execute(sourceImageViewer.Image);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    return;
                }
                finally
                {
                    for (int i = 0; i < commandsWithChangedRegion.Count; i++)
                        commandsWithChangedRegion[i].RegionOfInterest = null;
                    if (path != null)
                        path.Dispose();
                }

                // if there is no processed image (info commands executed)
                if (processedImage == null)
                    // set clone of the source image as processed image
                    processedImage = (VintasoftImage)sourceImageViewer.Image.Clone();

                // raise ProcessedImageReceived event
                OnProcessedImageReceived(processedImage);

                // set processed image in processedImageViewer
                UpdateProcessedImage(processedImage);

                // if there are results after execution of commands
                if (compositeCommand.Results != null)
                {
                    // for each result
                    for (int i = 0; i < compositeCommand.Results.Count; i++)
                    {
                        ProcessingCommandResult result = compositeCommand.Results[i];

                        // show result in the property grid
                        PropertyGridForm dlg = new PropertyGridForm(result, string.Format("{0} Results", compositeCommand.Name));
                        dlg.ShowDialog();

#if !REMOVE_DOCCLEANUP_PLUGIN
                        // if result is a document segmentation result
                        DocumentSegmentationCommandResult docSegmentationResult = result as DocumentSegmentationCommandResult;
                        if (docSegmentationResult != null)
                        {
                            // highlight the document segmentation result in the viewer of processed image
                            processedImageViewer.VisualTool = CreateHighlightTool(docSegmentationResult.Regions);
                        }

                        HalftoneRecognitionCommandResult halftoneRecognitionResult = result as HalftoneRecognitionCommandResult;
                        if (halftoneRecognitionResult != null)
                        {
                            ReadOnlyCollection<Point[]> halftoneRegions = halftoneRecognitionResult.HalftoneRegions;
                            if (halftoneRegions.Count > 0)
                            {
                                VisualTool[] tools = new VisualTool[halftoneRegions.Count];
                                for (int t = 0; t < halftoneRegions.Count; t++)
                                {
                                    tools[t] = CreateSelectionTool(halftoneRegions[t]);
                                }
                                processedImageViewer.VisualTool = new CompositeVisualTool(tools);
                            }
                        }

                        // if result is a image segmentation result
                        ImageSegmentationCommandResult imgSegmentationResult = result as ImageSegmentationCommandResult;
                        if (imgSegmentationResult != null)
                        {
                            // highlight the image segmentation result in the viewer of processed image
                            processedImageViewer.VisualTool = CreateHighlightTool(imgSegmentationResult.Regions);
                        }
#endif

                        // if result is a border detection result
                        GetBorderRectCommandResult getBorderResult = result as GetBorderRectCommandResult;
                        if (getBorderResult != null)
                        {
                            // highlight the border detection result in the viewer of processed image
                            processedImageViewer.VisualTool = CreateHighlightTool(getBorderResult.BorderRect);
                        }
                    }
                }

            }
            finally
            {
                OnExecuteCommandFinished();
            }
        }

        /// <summary>
        /// Handles the Progress event of executingCommand object.
        /// </summary>
        private void executingCommand_Progress(object sender, ImageProcessingProgressEventArgs e)
        {
            if (ExecuteCommandProgress != null)
                // raise the execute command progress event
                ExecuteCommandProgress(sender, e);
        }

        #endregion


        #region Image Viewers

        /// <summary>
        /// Handles the FocusedIndexChanged event of sourceImageViewer object.
        /// </summary>
        private void sourceImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            // update the user interface
            UpdateUI();
        }

        /// <summary>
        /// Handles the ZoomChanged event of sourceImageViewer object.
        /// </summary>
        private void sourceImageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            // synchronize the size mode and zoom
            SynchronizeSizeMode(sourceImageViewer, processedImageViewer);
        }

        /// <summary>
        /// Handles the ZoomChanged event of processedImageViewer object.
        /// </summary>
        private void processedImageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            // synchronize the size mode and zoom
            SynchronizeSizeMode(processedImageViewer, sourceImageViewer);
        }

        /// <summary>
        /// Handles the ScrollChanged event of sourceImageViewer object.
        /// </summary>
        private void sourceImageViewer_ScrollChanged(object sender, PropertyChangedEventArgs<Point> e)
        {
            // synchronize the scrolls
            SyncScrolls(sourceImageViewer, processedImageViewer);
        }

        /// <summary>
        /// Handles the ScrollChanged event of processedImageViewer object.
        /// </summary>
        private void processedImageViewer_ScrollChanged(object sender, PropertyChangedEventArgs<Point> e)
        {
            // synchronize the scrolls
            SyncScrolls(processedImageViewer, sourceImageViewer);
        }

        /// <summary>
        /// Handles the ImageCollectionChanged event of Images object.
        /// </summary>
        private void Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            // if processing image must be removed
            if (e.Action == ImageCollectionChangeAction.Clear ||
                e.Action == ImageCollectionChangeAction.RemoveImages)
            {
                // update processing image
                UpdateProcessedImage(null);
            }
        }

        #endregion

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isCommandsToProcessSpecified = imageProcessingCommandsEditor1.SelectedCommands != null &&
                                                imageProcessingCommandsEditor1.SelectedCommands.Length > 0;
            bool isImageSpecified = sourceImageViewer.Image != null;

            executeCommandOnImageButton.Enabled = isImageSpecified && isCommandsToProcessSpecified;
        }


        #region Execute Processing Commands

        /// <summary>
        /// Determines that the image processing command changes the image size.
        /// </summary>
        /// <param name="command">The image processing command.</param>
        /// <returns>
        /// <b>true</b> - the image processing command changes the image size;
        /// <b>false</b> - the image processing command does NOT change the image size.</returns>
        private bool IsChangeImageSize(ProcessingCommandBase command)
        {
            return
                command is ResizeCommand ||
                command is ResampleCommand ||
                command is ResizeCanvasCommand ||
                command is CropCommand ||
                command is Vintasoft.Imaging.ImageProcessing.Transforms.FlipCommand ||
                command is Vintasoft.Imaging.ImageProcessing.Transforms.RotateCommand ||
                command is Vintasoft.Imaging.ImageProcessing.Transforms.SkewCommand ||
                command is Vintasoft.Imaging.ImageProcessing.Transforms.QuadrilateralWarpCommand;
        }

        /// <summary>
        /// Creates the "Crop to custom selection" composite command. 
        /// </summary>
        private ProcessingCommandBase GetCropToPathCommand(
            GraphicsPath path,
            RectangleF pathBounds,
            CropCommand crop)
        {
            Rectangle viewerImageRect = new Rectangle(0, 0, sourceImageViewer.Image.Width, sourceImageViewer.Image.Height);
            crop.RegionOfInterest = new RegionOfInterest(GetBoundingRect(RectangleF.Intersect(pathBounds, viewerImageRect)));

            // overlay command
            OverlayCommand overlay = new OverlayCommand(crop.Execute(sourceImageViewer.Image));

            // overlay with path command
            ProcessPathCommand overlayWithPath = new ProcessPathCommand(overlay, new GdiGraphicsPath(path, false));

            // clear image command
            ClearImageCommand clearImage = new ClearImageCommand(Color.Transparent);

            // create composite command: clear, overlay with path, crop
            return new CompositeCommand(clearImage, overlayWithPath, crop);
        }

        /// <summary>
        /// Returns a bounding rectangle of specified <see cref="RectangleF"/>.
        /// </summary>
        private Rectangle GetBoundingRect(RectangleF rect)
        {
            float dx = rect.X - (int)rect.X;
            float dy = rect.Y - (int)rect.Y;
            return new Rectangle((int)rect.X, (int)rect.Y, (int)(rect.Width + 1 + dx), (int)(rect.Height + 1 + dy));
        }

#if !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary>
        /// Creates the highlight tool.
        /// </summary>
        /// <param name="segmentationRegions">The segmentation regions.</param>
        private VisualTool CreateHighlightTool(ReadOnlyCollection<ImageRegion> segmentationRegions)
        {
            // create an array of text/image/line regions
            List<ImageRegion> textRegions = new List<ImageRegion>();
            List<ImageRegion> imageRegions = new List<ImageRegion>();
            List<ImageRegion> lineRegions = new List<ImageRegion>();
            for (int i = 0; i < segmentationRegions.Count; i++)
            {
                if (segmentationRegions[i].Type == ImageRegionType.Text)
                    textRegions.Add(segmentationRegions[i]);
                else if (segmentationRegions[i].Type == ImageRegionType.Line)
                    lineRegions.Add(segmentationRegions[i]);
                else
                    imageRegions.Add(segmentationRegions[i]);
            }

            // create the highlight objects for regions
            //
            SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(100, Color.Yellow));

            ColoredObjects<ImageRegion> highlightTextRegions = new ColoredObjects<ImageRegion>(textRegions);
            highlightTextRegions.Pen = Pens.Green;
            highlightTextRegions.Brush = highlightBrush;

            ColoredObjects<ImageRegion> highlightLineRegions = new ColoredObjects<ImageRegion>(lineRegions);
            highlightLineRegions.Pen = Pens.Blue;
            highlightLineRegions.Brush = highlightBrush;

            ColoredObjects<ImageRegion> highlightImageRegions = new ColoredObjects<ImageRegion>(imageRegions);
            highlightImageRegions.Pen = Pens.Red;
            highlightImageRegions.Brush = highlightBrush;


            // create the highlight tool
            HighlightTool<ImageRegion> highlightTool = new HighlightTool<ImageRegion>();

            // add highlight objects to the highlight tool
            highlightTool.Items.Add(highlightTextRegions);
            highlightTool.Items.Add(highlightLineRegions);
            highlightTool.Items.Add(highlightImageRegions);

            return highlightTool;
        }

        /// <summary>
        /// Creates the highlight tool.
        /// </summary>
        /// <param name="segmentationRegions">The segmentation regions.</param>
        private VisualTool CreateHighlightTool(ReadOnlyCollection<Rectangle> segmentationRegions)
        {
            // create an array of text/image/line regions
            List<ImageRegion> imageRegions = new List<ImageRegion>();
            for (int i = 0; i < segmentationRegions.Count; i++)
            {
                Rectangle rectangle = segmentationRegions[i];
                ImageRegion imageRegion = new ImageRegion(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                imageRegions.Add(imageRegion);
            }

            ColoredObjects<ImageRegion> highlightImageRegions = new ColoredObjects<ImageRegion>(imageRegions);
            highlightImageRegions.Pen = Pens.Green;
            highlightImageRegions.Brush = new SolidBrush(Color.FromArgb(100, Color.Yellow));


            // create the highlight tool
            HighlightTool<ImageRegion> highlightTool = new HighlightTool<ImageRegion>();

            // add highlight object to the highlight tool
            highlightTool.Items.Add(highlightImageRegions);

            return highlightTool;
        }
#endif

        /// <summary>
        /// Creates the highlight tool.
        /// </summary>
        /// <param name="imageRect">The region on image.</param>
        private VisualTool CreateHighlightTool(Rectangle imageRect)
        {
            List<ImageRegion> regions = new List<ImageRegion>();
            regions.Add(new ImageRegion(imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height));
            ColoredObjects<ImageRegion> highlightImageRegions = new ColoredObjects<ImageRegion>(regions);
            highlightImageRegions.Pen = new Pen(Color.Yellow);
            highlightImageRegions.Pen.DashStyle = DashStyle.Dash;

            // create the highlight tool
            HighlightTool<ImageRegion> highlightTool = new HighlightTool<ImageRegion>();

            // add highlight object to the highlight tool
            highlightTool.Items.Add(highlightImageRegions);

            return highlightTool;
        }

#if !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary>
        /// Creates the selection tool.
        /// </summary>
        /// <param name="halftoneRegionContour">The contour of halftone region.</param>
        private CustomSelectionTool CreateSelectionTool(Point[] halftoneRegionContour)
        {
            PointF[] floatPoints = new PointF[halftoneRegionContour.Length];
            for (int i = 0; i < halftoneRegionContour.Length; i++)
                floatPoints[i] = new PointF(halftoneRegionContour[i].X, halftoneRegionContour[i].Y);
            CustomSelectionTool tool = new CustomSelectionTool();
            tool.Selection = new PolygonalSelectionRegion(floatPoints);
            tool.Selection.TransformInteractionController = null;
            tool.Selection.BuildingInteractionController = null;
            return tool;
        }
#endif

        /// <summary>
        /// Command execution is started.
        /// </summary>
        private void OnExecuteCommandStarted()
        {
            Enabled = false;
            if (ExecuteCommandStarted != null)
                ExecuteCommandStarted(this, EventArgs.Empty);
        }

        /// <summary>
        /// Processed image is received.
        /// </summary>
        private void OnProcessedImageReceived(VintasoftImage image)
        {
            if (ProcessedImageReceived != null)
                ProcessedImageReceived(this, new ImageEventArgs(image));
        }

        /// <summary>
        /// Command execution is finished.
        /// </summary>
        private void OnExecuteCommandFinished()
        {
            Enabled = true;
            if (ExecuteCommandFinished != null)
                ExecuteCommandFinished(this, EventArgs.Empty);
        }

        #endregion


        #region Image Viewers

        /// <summary>
        /// Synchronizes the viewer settings.
        /// </summary>
        /// <param name="source">The source image viewer.</param>
        /// <param name="destination">The destination image viewer.</param>
        private void SynchronizeViewerSettings(ImageViewer source, ImageViewer destination)
        {
            destination.ImageAnchor = source.ImageAnchor;
            destination.RenderingQuality = source.RenderingQuality;
            destination.FocusPointAnchor = source.FocusPointAnchor;
            destination.IsFocusPointFixed = source.IsFocusPointFixed;
            destination.RendererCacheSize = source.RendererCacheSize;
            destination.ViewerBufferSize = source.ViewerBufferSize;
            destination.MinImageSizeWhenZoomBufferUsed = source.MinImageSizeWhenZoomBufferUsed;

            destination.ImageRenderingSettings.InterpolationMode = source.ImageRenderingSettings.InterpolationMode;
            destination.ImageRenderingSettings.SmoothingMode = source.ImageRenderingSettings.SmoothingMode;
            destination.ImageRenderingSettings.Resolution = source.ImageRenderingSettings.Resolution;

            destination.IsKeyboardNavigationEnabled = source.IsKeyboardNavigationEnabled;
            destination.KeyboardNavigationScrollStep = source.KeyboardNavigationScrollStep;
            destination.KeyboardNavigationZoomStep = source.KeyboardNavigationZoomStep;

            destination.BackColor = source.BackColor;
        }

        /// <summary>
        /// Synchronizes the size mode of image viewer.
        /// </summary>
        /// <param name="source">The source image viewer.</param>
        /// <param name="destination">The destination image viewer.</param>
        private void SynchronizeSizeMode(ImageViewer source, ImageViewer destination)
        {
            if (destination.SizeMode != source.SizeMode)
                destination.SizeMode = source.SizeMode;

            if (destination.SizeMode == ImageSizeMode.Zoom &&
                destination.Zoom != source.Zoom)
                destination.Zoom = source.Zoom;
        }

        /// <summary>
        /// Synchronize the scroll positions in the source and destination viewers.
        /// </summary>
        /// <param name="source">Source image viewer.</param>
        /// <param name="destination">Destination image viewer.</param>
        private void SyncScrolls(ImageViewer source, ImageViewer destination)
        {
            if (destination.Image == null)
                return;

            PointF imageLocation = source.PointToImageF(
                new PointF(source.ClientSize.Width / 2f,
                           source.ClientSize.Height / 2f));
            destination.ScrollToPoint(imageLocation);
            destination.Invalidate();
            source.Invalidate();
            Update();            
        }

        /// <summary>
        /// Updates the processed image of image viewer.
        /// </summary>
        /// <param name="image">The image.</param>
        private void UpdateProcessedImage(VintasoftImage image)
        {
            VintasoftImage currentImage = processedImageViewer.Image;
            if (currentImage == null)
            {
                if (image != null)
                    processedImageViewer.Image = image;
            }
            else
            {
                if (image == null)
                {
                    processedImageViewer.Image = null;
                    currentImage.Dispose();
                }
                else
                {
                    processedImageViewer.Image.SetImage(image);
                }
            }
        }

        #endregion

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the command execution is started.
        /// </summary>
        public event EventHandler ExecuteCommandStarted;

        /// <summary>
        /// Occurs when progress, of the command execution, is changed.
        /// </summary>
        public event EventHandler<ImageProcessingProgressEventArgs> ExecuteCommandProgress;

        /// <summary>
        /// Occurs when processed image received.
        /// </summary>
        public event EventHandler<ImageEventArgs> ProcessedImageReceived;

        /// <summary>
        /// Occurs when the command execution is finished.
        /// </summary>
        public event EventHandler ExecuteCommandFinished;

        #endregion

    }
}
