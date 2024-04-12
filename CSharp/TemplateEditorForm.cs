using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.FormsProcessing.FormRecognition;
#if !REMOVE_OCR_PLUGIN
using Vintasoft.Imaging.FormsProcessing.FormRecognition.Ocr;
using Vintasoft.Imaging.FormsProcessing.FormRecognition.Ocr.UI;
#endif
using Vintasoft.Imaging.FormsProcessing.FormRecognition.Omr;
using Vintasoft.Imaging.FormsProcessing.FormRecognition.Omr.UI;
using Vintasoft.Imaging.FormsProcessing.FormRecognition.UI;
using Vintasoft.Imaging.FormsProcessing.FormRecognition.UI.VisualTools;
using Vintasoft.Imaging.ImageProcessing;
#if !REMOVE_OCR_PLUGIN
using Vintasoft.Imaging.Ocr;
using Vintasoft.Imaging.Ocr.Tesseract;
#endif
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;

namespace FormsProcessingDemo
{
    /// <summary>
    /// A form that allows to edit form templates.
    /// </summary>
    public partial class TemplateEditorForm : Form
    {

        #region Fields

        /// <summary>
        /// Form template manager.
        /// </summary>
        FormTemplateManager _templateManager;

        /// <summary>
        /// Current image processing command which is used for image binarization.
        /// </summary>
        ChangePixelFormatToBlackWhiteCommand _binarizeCommand;

        /// <summary>
        /// Current rendering settings which are used for vector image rendering.
        /// </summary>
        RenderingSettings _renderingSettings;

        /// <summary>
        /// Form field template editor tool.
        /// </summary>
        FormFieldTemplateEditorTool _fieldTemplateEditorTool;

        /// <summary>
        /// Dictionary that binds template images and tree view nodes.
        /// </summary>
        Dictionary<VintasoftImage, TreeNode> _imagesToTemplateTreeNodes =
            new Dictionary<VintasoftImage, TreeNode>();

        /// <summary>
        /// Dictionary that binds form field templates and tree view nodes.
        /// </summary>
        Dictionary<FormFieldTemplate, TreeNode> _formFieldTemplateToTreeNodes =
            new Dictionary<FormFieldTemplate, TreeNode>();

        /// <summary>
        /// Root node of the tree view.
        /// </summary>
        TreeNode _templatesRootNode;

        /// <summary>
        /// Current form field template view in internal "copy" buffer (field template view to copy).
        /// </summary>
        FormFieldTemplateView _fieldTemplateViewCopy = null;

        OpenFileDialog _openDocumentDialog = new OpenFileDialog();

        OpenFileDialog _openImageOrDocumentDialog = new OpenFileDialog();


        /// <summary>
        /// Indicates that text recognition must be executed in multiple threads.
        /// </summary>
        bool _recognizeTextInMultipleThreads = false;

        /// <summary>
        /// The maximum count of threads, which can be used for text recognition.
        /// </summary>
        int _maxOcrThreads = Environment.ProcessorCount;

        /// <summary>
        /// The directory, where Tesseract5.Vintasoft.xXX.dll is located.
        /// </summary>
        string _tesseractOcrDllDirectory = string.Empty;


        #region File Dialog Filters

        /// <summary>
        /// File extensions for template images.
        /// </summary>
        static readonly string ImageFileExtensions = "*.bmp;*.tif;*.tiff;*.png;*.jpg;*.jpeg;*.pdf";

        /// <summary>
        /// File extensions for document templates.
        /// </summary>
        static readonly string FormDocumentTemplateExtensions = "*.fdt";

        /// <summary>
        /// File extensions for page templates.
        /// </summary>
        static readonly string FormPageTemplateExtensions = "*.fpt";

        /// <summary>
        /// File dialog filter for all template images.
        /// </summary>
        static readonly string ImageFilesFilter;

        /// <summary>
        /// File dialog filter for all document templates.
        /// </summary>
        static readonly string FormDocumentTemplatesFilter;

        /// <summary>
        /// File dialog filter for all page templates.
        /// </summary>
        static readonly string FormPageTemplatesFilter;

        /// <summary>
        /// File dialog filter for all supported template files.
        /// </summary>
        static readonly string AllSupportedTemplateFilesFilter;

        #endregion

        #endregion



        #region Constructors

        static TemplateEditorForm()
        {
            ImageFilesFilter = string.Format(
                "Image Files|{0}",
                ImageFileExtensions);
            FormDocumentTemplatesFilter = string.Format(
                "Form Document Template Files|{0}",
                FormDocumentTemplateExtensions);
            FormPageTemplatesFilter = string.Format(
                "Form Page Template Files|{0}",
                FormPageTemplateExtensions);
            AllSupportedTemplateFilesFilter = string.Format(
                "All Template Files|{0};{1}",
                ImageFileExtensions,
                FormDocumentTemplateExtensions);
        }

        public TemplateEditorForm()
        {
            InitializeComponent();
        }

        public TemplateEditorForm(
            FormTemplateManager templateManager,
            ChangePixelFormatToBlackWhiteCommand binarizeCommand,
            RenderingSettings renderingSettings,
            string tesseractOcrDllDirectory)
            : this()
        {
            _templateManager = templateManager;
            _binarizeCommand = binarizeCommand;
            _renderingSettings = renderingSettings;
            _tesseractOcrDllDirectory = tesseractOcrDllDirectory;

            templateManager.TemplateImages.ImageCollectionChanged +=
                new EventHandler<ImageCollectionChangeEventArgs>(TemplateImages_ImageCollectionChanged);

            CodecsFileFilters.SetOpenFileDialogFilter(openImageFileDialog);

            // create a visual tool for editing form field templates
            _fieldTemplateEditorTool = new FormFieldTemplateEditorTool();
            _fieldTemplateEditorTool.FocusedFieldTemplateViewChanged +=
                new EventHandler(fieldTemplateEditorTool_FocusedFieldTemplateViewChanged);
            _fieldTemplateEditorTool.MouseDoubleClick +=
                new VisualToolMouseEventHandler(fieldTemplateEditorTool_MouseDoubleClick);

            // set the template images as the images of the viewer
            imageViewer1.Images = templateManager.TemplateImages;
            // set the visual tool
            imageViewer1.VisualTool = _fieldTemplateEditorTool;
            imageViewer1.FocusedIndexChanged +=
                new EventHandler<FocusedIndexChangedEventArgs>(imageViewer1_FocusedIndexChanged);

            _templatesRootNode = templatesTreeView.Nodes[0];
            templatesTreeView.AfterSelect += new TreeViewEventHandler(templatesTreeView_AfterSelect);
            templatesTreeView.MouseDoubleClick += new MouseEventHandler(templatesTreeView_MouseDoubleClick);
            templatesTreeView.AfterLabelEdit += new NodeLabelEditEventHandler(templatesTreeView_AfterLabelEdit);

            _openDocumentDialog.Multiselect = false;
            _openDocumentDialog.Filter = FormDocumentTemplatesFilter;
            DemosTools.SetTestFilesFolder(_openDocumentDialog);

            _openImageOrDocumentDialog.Multiselect = false;
            _openImageOrDocumentDialog.Filter = string.Format(
                "{0}|{1}|{2}",
                AllSupportedTemplateFilesFilter,
                ImageFilesFilter,
                FormDocumentTemplatesFilter);
            DemosTools.SetTestFilesFolder(_openImageOrDocumentDialog);

#if REMOVE_OCR_PLUGIN
            ocrToolStripMenuItem.Enabled = false;
            ocrToolStripButton.Enabled = false;
            addOCRFieldToolStripMenuItem.Enabled = false;
            defaultOcrSettingsToolStripMenuItem.Enabled = false;
#endif

            DemosTools.SetTestFilesFolder(openImageFileDialog);
        }

        #endregion



        #region Properties

#if !REMOVE_OCR_PLUGIN
        OcrEngineSettings _defaultOcrEngineSettings;
        /// <summary>
        /// Gets or sets the default OCR engine settings for newly created OCR fields.
        /// </summary>
        public OcrEngineSettings DefaultOcrEngineSettings
        {
            get
            {
                return _defaultOcrEngineSettings;
            }
            set
            {
                _defaultOcrEngineSettings = value;
            }
        }

        OcrRecognitionRegionSplittingSettings _defaultOcrRecognitionRegionSplittingSettings;
        /// <summary>
        /// Gets or sets the default OCR recognition region splitting settings.
        /// </summary>
        public OcrRecognitionRegionSplittingSettings DefaultOcrRecognitionRegionSplittingSettings
        {
            get
            {
                return _defaultOcrRecognitionRegionSplittingSettings;
            }
            set
            {
                _defaultOcrRecognitionRegionSplittingSettings = value;
            }
        }
#endif

#if !REMOVE_BARCODE_SDK
        ReaderSettings _defaultBarcodeReaderSettings;
        /// <summary>
        /// Gets or sets the default barcode reader settings for newly created barcode fields.
        /// </summary>
        public ReaderSettings DefaultBarcodeReaderSettings
        {
            get
            {
                return _defaultBarcodeReaderSettings;
            }
            set
            {
                _defaultBarcodeReaderSettings = value;
            }
        } 
#endif

        /// <summary>
        /// Gets a value indicating whether image background compensation 
        /// must be automatically executed for all pages.
        /// </summary>
        public bool AutomaticallyImageBackgroundCompensation
        {
            get
            {
                return automaticallyCompensateForAllPagesToolStripMenuItem.Checked;
            }
        }

#if !REMOVE_OCR_PLUGIN
        /// <summary>
        /// Gets a value indicating whether OCR engine is available.
        /// </summary>
        public bool IsOcrEngineAvailable
        {
            get
            {
                return OcrFieldTemplate.OcrEngineManager != null;
            }
        }
#endif

        #endregion



        #region Methods

        #region Template Editor Form

        /// <summary>
        /// Form is shown.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _templatesRootNode.Expand();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Ok button click event handler.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            int templateCount = _templateManager.TemplateImages.Count;
            bool isImageLoaded = imageViewer1.Image != null;
            bool isFieldTemplateSelected = _fieldTemplateEditorTool.FocusedFieldTemplateView != null;
            bool containsFieldTemplates = isImageLoaded &&
                _fieldTemplateEditorTool.FieldTemplateCollection != null &&
                _fieldTemplateEditorTool.FieldTemplateCollection.Count > 0;
#if !REMOVE_OCR_PLUGIN
            bool isOcrEngineAvailable = IsOcrEngineAvailable;
#endif

            // "File" menu
            //
            saveDocumentAsToolStripMenuItem.Enabled = templateCount > 0;

            // "Page" menu
            //
            loadPageFieldTemplatesToolStripMenuItem.Enabled = templateCount > 0;
            savePageFieldTemplatesToolStripMenuItem.Enabled = templateCount > 0;

            // "View" menu
            //
            imageViewerToolStrip.SaveButtonEnabled = templateCount > 0;

            // "Field templates" menu
            //
            templateImageBackgroundCompensatToolStripMenuItem.Enabled = templateCount > 0;
            bool automaticallyCompensation = AutomaticallyImageBackgroundCompensation;
            compensateForAllPagesToolStripMenuItem.Enabled = !automaticallyCompensation;
            compensateForCurrentPageToolStripMenuItem.Enabled = !automaticallyCompensation;
            ignoreForAllPagesToolStripMenuItem.Enabled = !automaticallyCompensation;
            ignoreForCurrentPageToolStripMenuItem.Enabled = !automaticallyCompensation;
            cutToolStripMenuItem.Enabled = isFieldTemplateSelected;
            copyToolStripMenuItem.Enabled = isFieldTemplateSelected;
            pasteToolStripMenuItem.Enabled = _fieldTemplateViewCopy != null;
            deleteToolStripMenuItem.Enabled = isFieldTemplateSelected;
            deleteAllToolStripMenuItem.Enabled = containsFieldTemplates;
            groupToolStripMenuItem.Enabled = containsFieldTemplates;
            ungroupToolStripMenuItem.Enabled = containsFieldTemplates;

            // "OMR" menu
            //
            addOmrRectangleToolStripMenuItem.Enabled = isImageLoaded;
            addOmrEllipseToolStripMenuItem.Enabled = isImageLoaded;
            addTableOfOmrRectanglesToolStripMenuItem.Enabled = isImageLoaded;
            addTableOfOmrEllipsesToolStripMenuItem.Enabled = isImageLoaded;

#if !REMOVE_OCR_PLUGIN
            // "OCR" menu
            //
            addOCRFieldToolStripMenuItem.Enabled = isImageLoaded && isOcrEngineAvailable;
            defaultOcrSettingsToolStripMenuItem.Enabled = isOcrEngineAvailable;
#endif

            // "Barcode" menu
            //
            addBarcodeFieldToolStripMenuItem.Enabled = isImageLoaded;

            // Toolstrip
            omrRectangleToolStripButton.Enabled = isImageLoaded;
            omrEllipseToolStripButton.Enabled = isImageLoaded;
            tableOfOmrRectanglesToolStripButton.Enabled = isImageLoaded;
            tableOfOmrEllipsesToolStripButton.Enabled = isImageLoaded;
#if !REMOVE_OCR_PLUGIN
            ocrToolStripButton.Enabled = isImageLoaded && isOcrEngineAvailable;
#endif
            barcodeToolStripButton.Enabled = isImageLoaded;
        }

        /// <summary>
        /// Updates information about focused image.
        /// </summary>
        private void UpdateImageInfo()
        {
            VintasoftImage image = imageViewer1.Image;
            if (image != null)
            {
                ImageSize size = ImageSize.FromPixels(image.Width, image.Height, image.Resolution);
                imageInfoLabel.Text = string.Format(
                    "Pixel Size: {0}x{1}; Resolution: {2}; Physical Size: {3}x{4} mm",
                    size.WidthInPixels,
                    size.HeightInPixels,
                    size.Resolution,
                    Math.Round(size.WidthInInch * 25.4),
                    Math.Round(size.HeightInInch * 25.4));
            }
            else
            {
                imageInfoLabel.Text = "";
            }
        }

        /// <summary>
        /// Sets the selected object in property grid.
        /// </summary>
        /// <param name="selectedObject">The selected object.</param>
        private void SetSelectedObjectInPropertyGrid(object selectedObject)
        {
            if (selectedObject != null)
            {
                propertyGrid1.SelectedObject = selectedObject;
                propertyGridGroupBox.Text = selectedObject.GetType().Name;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                propertyGridGroupBox.Text = "<No selected object>";
            }
        }

        /// <summary>
        /// Creates a name for a template image.
        /// </summary>
        /// <param name="image">The template image.</param>
        private string GetTemplateName(VintasoftImage image)
        {
            switch (image.SourceInfo.SourceType)
            {
                case ImageSourceType.File:
                    if (image.SourceInfo.PageCount == 1)
                        return Path.GetFileNameWithoutExtension(image.SourceInfo.Filename);

                    return string.Format(
                        "{0}, Page {1}",
                        Path.GetFileName(image.SourceInfo.Filename),
                        image.SourceInfo.PageIndex + 1);

                default:
                    return "Template";
            }
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Clears image collection of the image viewer and adds template image(s)
        /// to the image collection of the image viewer.
        /// </summary>
        private void openTemplateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImages(false);
        }

        /// <summary>
        /// Clears image collection of the image viewer and adds template document(s)
        /// to the image collection of the image viewer.
        /// </summary>
        private void openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocument(false);
        }

        /// <summary>
        /// Adds template image(s) to the image collection of the image viewer.
        /// </summary>
        private void addTemplateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImages(true);
        }

        /// <summary>
        /// Adds template document(s) to the image collection of the image viewer.
        /// </summary>
        private void addDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocument(true);
        }

        /// <summary>
        /// Saves current template document to new source.
        /// </summary>
        private void saveDocumentAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string documentName = _templatesRootNode.Text;
            if (documentName == "Untitled")
                documentName = string.Empty;
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = documentName;
                saveDialog.Filter = FormDocumentTemplatesFilter;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    _templateManager.SaveToDocument(saveDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Closes the current template document.
        /// </summary>
        private void closeDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseDocument();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion


        #region 'Page' menu

        /// <summary>
        /// Loads form field template collection of the current page template from a file.
        /// </summary>
        private void loadPageFieldTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = FormPageTemplatesFilter;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    // load page template from file
                    FormPageTemplate pageTemplate = FormPageTemplate.Deserialize(openDialog.FileName);
                    VintasoftImage templateImage = imageViewer1.Image;
                    // set the page template to the current image
                    _templateManager.SetPageTemplate(templateImage, pageTemplate);
                    // set items of page template as current items of the visual tool
                    SetCurrentFormFieldTemplates(pageTemplate.Items);
                    // add field templates to the tree view
                    foreach (FormFieldTemplate formFieldTemplate in pageTemplate.Items)
                        AddFormFieldTemplateTreeNode(templateImage, formFieldTemplate);

#if !REMOVE_OCR_PLUGIN
                    // check OCR availability
                    CheckOcrAvailability();
#endif
                }
            }
        }

        /// <summary>
        /// Saves form field template collection of the current page template to a file.
        /// </summary>
        private void savePageFieldTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = FormPageTemplatesFilter;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // get the page template
                    FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(imageViewer1.Image);
                    // save to a file
                    FormPageTemplate.Serialize(saveDialog.FileName, pageTemplate);
                }
            }
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Shows the image viewer settings.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageViewerSettingsForm viewerSettingsDialog = new ImageViewerSettingsForm(imageViewer1);
            viewerSettingsDialog.ShowDialog();
        }

        #endregion


        #region 'Form field templates' menu

        /// <summary>
        /// Enables/disables Automatically Compensation.
        /// </summary>
        private void automaticallyCompensateForAllPagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_templateManager != null)
                UpdateUI();
        }

        /// <summary>
        /// Compensates the background for all template images.
        /// </summary>
        private void compensateForAllPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int imageCount = _templateManager.TemplateImages.Count;
            for (int i = 0; i < imageCount; i++)
            {
                currentActionLabel.Text = string.Format("Processing image {0} of {1}...", i + 1, imageCount);
                VintasoftImage templateImage = _templateManager.TemplateImages[i];
                FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(templateImage);
                _templateManager.CompensateTemplateImageBackground(templateImage, pageTemplate);
            }
            currentActionLabel.Text = "";
            DemosTools.ShowInfoMessage("Template images background compensation is done.");
        }

        /// <summary>
        /// Compensates the background for current template image.
        /// </summary>
        private void compensateForCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage currentImage = imageViewer1.Image;
            FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(currentImage);
            _templateManager.CompensateTemplateImageBackground(currentImage, pageTemplate);
            DemosTools.ShowInfoMessage("Template image background compensation is done.");
        }

        /// <summary>
        /// Ignores the background compensation for all template images.
        /// </summary>
        private void ignoreForAllPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int imageCount = _templateManager.TemplateImages.Count;
            // for each template images
            for (int i = 0; i < imageCount; i++)
            {
                currentActionLabel.Text = string.Format("Processing image {0} of {1}...", i + 1, imageCount);
                // get reference to the template image
                VintasoftImage templateImage = _templateManager.TemplateImages[i];
                // get reference to the form definition associated with template image
                FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(templateImage);
                // remove information about compensation of background of template image
                _templateManager.CompensateTemplateImageBackground(null, pageTemplate);
            }
            currentActionLabel.Text = "";
            DemosTools.ShowInfoMessage("Template images background compensation is done.");
        }

        /// <summary>
        /// Ignores the background compensation for current template image.
        /// </summary>
        private void ignoreForCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(imageViewer1.Image);
            _templateManager.CompensateTemplateImageBackground(null, pageTemplate);
            DemosTools.ShowInfoMessage("Template image background compensation is done.");
        }

        /// <summary>
        /// Cuts selected form field template.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fieldTemplateViewCopy != null)
                _fieldTemplateViewCopy.Dispose();
            _fieldTemplateViewCopy = GetFocusedFieldTemplateCopy();
            DeleteFocusedFieldTemplate();
        }

        /// <summary>
        /// Copies selected form field template.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fieldTemplateViewCopy != null)
                _fieldTemplateViewCopy.Dispose();
            _fieldTemplateViewCopy = GetFocusedFieldTemplateCopy();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Pastes form field template from "internal" buffer and makes it active.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectangleF boundingBox = _fieldTemplateViewCopy.FieldTemplate.BoundingBox;
            boundingBox.Offset(20f, 20f);
            _fieldTemplateViewCopy.FieldTemplate.BoundingBox = boundingBox;
            FormFieldTemplateView fieldTemplateViewCopy =
                (FormFieldTemplateView)_fieldTemplateViewCopy.Clone();

            AddFormFieldTemplateTreeNode(imageViewer1.Image, fieldTemplateViewCopy.FieldTemplate);
            _fieldTemplateEditorTool.FieldTemplateViewCollection.Add(fieldTemplateViewCopy);
            _fieldTemplateEditorTool.FocusedFieldTemplateView = fieldTemplateViewCopy;

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Removes selected form field template from collection.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFocusedFieldTemplate();
        }

        /// <summary>
        /// Removes all form field templates from collection.
        /// </summary>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            FormPageTemplate templatePage = _templateManager.GetPageTemplate(image);
            foreach (FormFieldTemplate item in templatePage.Items)
                RemoveFormFieldTemplateTreeNode(item);
            templatePage.Items.Clear();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Shows a form that allows to select some of the form field templates
        /// and combine selected templates in a group.
        /// </summary>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check available field template count
            if (_fieldTemplateEditorTool.FieldTemplateCollection.Count < 2)
            {
                DemosTools.ShowInfoMessage("There shall be at least 2 field templates on a form.");
                return;
            }

            // open a form that allows to select some of the form field templates
            using (FieldTemplatesSelectionForm selectionForm = new FieldTemplatesSelectionForm(
                _fieldTemplateEditorTool.FieldTemplateCollection))
            {
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    // get selected field templates
                    ICollection<FormFieldTemplate> selectedTemplates = selectionForm.SelectedFieldTemplates;
                    // if it is possible to make a group
                    if (selectedTemplates.Count > 1)
                    {
                        // create a group
                        FormFieldTemplateGroup templateGroup = new FormFieldTemplateGroup();
                        // for each selected template
                        foreach (FormFieldTemplate selectedTemplate in selectedTemplates)
                        {
                            // remove the template from the collection
                            _fieldTemplateEditorTool.FieldTemplateCollection.Remove(selectedTemplate);
                            RemoveFormFieldTemplateTreeNode(selectedTemplate);
                            // add the template to the group
                            templateGroup.Items.Add(selectedTemplate);
                        }
                        // add the group to the collection
                        _fieldTemplateEditorTool.FieldTemplateCollection.Add(templateGroup);
                        AddFormFieldTemplateTreeNode(imageViewer1.Image, templateGroup);
                        // subscribe to the PropertyChanged event
                        templateGroup.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(templateGroup_PropertyChanged);
                    }
                    else
                    {
                        DemosTools.ShowWarningMessage("You should select at least 2 form field templates to create a group.");
                    }
                }
            }
        }

        /// <summary>
        /// Shows a form that allows to select some of the form field template groups
        /// and split selected groups into separate form field templates.
        /// </summary>
        private void ungroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<FormFieldTemplate> templateGroups = new List<FormFieldTemplate>();

            foreach (FormFieldTemplate fieldTemplate in _fieldTemplateEditorTool.FieldTemplateCollection)
            {
                if (fieldTemplate is FormFieldTemplateGroup)
                    templateGroups.Add(fieldTemplate);
            }

            // check available field template group count
            if (templateGroups.Count == 0)
            {
                DemosTools.ShowInfoMessage("No field template groups found.");
                return;
            }

            // open a form that allows to select some of the form field templates
            using (FieldTemplatesSelectionForm selectionForm = new FieldTemplatesSelectionForm(templateGroups))
            {
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    // get selected field templates
                    ICollection<FormFieldTemplate> selectedTemplates = selectionForm.SelectedFieldTemplates;
                    // if at least one template group is selected
                    if (selectedTemplates.Count > 0)
                    {
                        // for each selected template group
                        foreach (FormFieldTemplate selectedTemplate in selectedTemplates)
                        {
                            // get as template group
                            FormFieldTemplateGroup selectedTemplateGroup = (FormFieldTemplateGroup)selectedTemplate;
                            // unsubscribe from the PropertyChanged event
                            selectedTemplateGroup.PropertyChanged -=
                                new EventHandler<ObjectPropertyChangedEventArgs>(templateGroup_PropertyChanged);
                            // remove the template group from the collection
                            _fieldTemplateEditorTool.FieldTemplateCollection.Remove(selectedTemplateGroup);
                            RemoveFormFieldTemplateTreeNode(selectedTemplateGroup);
                            VintasoftImage image = imageViewer1.Image;
                            // add items of the group to the collection
                            foreach (FormFieldTemplate nestedTemplate in selectedTemplateGroup.Items)
                            {
                                _fieldTemplateEditorTool.FieldTemplateCollection.Add(nestedTemplate);
                                AddFormFieldTemplateTreeNode(image, nestedTemplate);
                            }
                        }
                    }
                    else
                    {
                        DemosTools.ShowWarningMessage("You should select at least 1 form field template group to ungroup.");
                    }
                }
            }
        }

        #endregion


        #region 'OCR' menu

        /// <summary>
        /// Adds an OCR field template to an image and starts building of it.
        /// </summary>
        private void ocrToolStripButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_OCR_PLUGIN
            AddFormFieldTemplate(new OcrFieldTemplate((OcrEngineSettings)_defaultOcrEngineSettings.Clone(),
                 (OcrRecognitionRegionSplittingSettings)_defaultOcrRecognitionRegionSplittingSettings.Clone()));
#endif
        }

        /// <summary>
        /// Shows the default OCR settings for newly added OCR fields.
        /// </summary>
        private void defaultOcrSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_OCR_PLUGIN
            using (OcrSettingsForm settingsForm = new OcrSettingsForm(
                (TesseractOcrSettings)_defaultOcrEngineSettings,
                OcrFieldTemplate.OcrEngineManager.SupportedLanguages,
                OcrBinarizationMode.Global,
                false,
                _defaultOcrRecognitionRegionSplittingSettings,
                _recognizeTextInMultipleThreads,
                _maxOcrThreads))
            {
                settingsForm.CanChooseBinarization = false;
                settingsForm.ShowHighlightLowConfidenceWordsCheckBox = false;
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    OcrFieldTemplate.OcrEngineManager = CreateOcrEngineManager(
                        _tesseractOcrDllDirectory,
                        settingsForm.UseMultithreading,
                        settingsForm.MaxThreads);
                }
            }
#endif
        }

#if !REMOVE_OCR_PLUGIN        
        /// <summary>
        /// Creates the OCR engine manager for the specified settings.
        /// </summary>
        /// <param name="tesseractOcrDllDirectory">The directory,
        /// where Tesseract5.Vintasoft.xXX.dll is located.</param>
        /// <param name="recognizeTextInMultipleThreads">Indicates that
        /// text recognition must be executed in multiple threads.</param>
        /// <param name="maxOcrThreads">The maximum count of threads,
        /// which can be used for text recognition.</param>
        private OcrEngineManager CreateOcrEngineManager(
            string tesseractOcrDllDirectory,
            bool useMultithreading,
            int maxOcrThreads)
        {
            OcrEngineManager manager = OcrFieldTemplate.OcrEngineManager;

            if (_recognizeTextInMultipleThreads != useMultithreading ||
                _maxOcrThreads != maxOcrThreads)
            {
                TesseractOcr ocrEngine = new TesseractOcr(tesseractOcrDllDirectory);
                TesseractOcr[] additionalOcrEngines = null;

                if (useMultithreading && maxOcrThreads > 1)
                {
                    additionalOcrEngines = new TesseractOcr[maxOcrThreads - 1];

                    for (int i = 0; i < additionalOcrEngines.Length; i++)
                        additionalOcrEngines[i] = new TesseractOcr(tesseractOcrDllDirectory);
                }

                manager = new OcrEngineManager(ocrEngine, additionalOcrEngines);
                manager.RecognitionRegionSplittingSettings = _defaultOcrRecognitionRegionSplittingSettings;

                _recognizeTextInMultipleThreads = useMultithreading;
                _maxOcrThreads = maxOcrThreads;
            }

            return manager;
        }
#endif

        #endregion


        #region 'OMR' menu

        /// <summary>
        /// Adds an OMR rectangular field template to an image and starts building of it.
        /// </summary>
        private void omrRectangleToolStripButton_Click(object sender, EventArgs e)
        {
            AddFormFieldTemplate(new OmrRectangularFieldTemplate());
        }

        /// <summary>
        /// Adds an OMR elliptical field template to an image and starts building of it.
        /// </summary>
        private void omrEllipseToolStripButton_Click(object sender, EventArgs e)
        {
            AddFormFieldTemplate(new OmrEllipticalFieldTemplate());
        }

        /// <summary>
        /// Adds a table of OMR rectangular field templates to an image and starts building of it.
        /// </summary>
        private void tableOfOmrRectanglesToolStripButton_Click(object sender, EventArgs e)
        {
            AddOmrTemplateTable(new OmrRectangularFieldTemplate());
        }

        /// <summary>
        /// Adds a table of OMR elliptical field templates to an image and starts building of it.
        /// </summary>
        private void tableOfOmrEllipsesToolStripButton_Click(object sender, EventArgs e)
        {
            AddOmrTemplateTable(new OmrEllipticalFieldTemplate());
        }

        #endregion


        #region 'Barcode' menu

        /// <summary>
        /// Adds a barcode field template to an image and starts building of it.
        /// </summary>
        private void barcodeToolStripButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            AddFormFieldTemplate(new BarcodeFieldTemplate(_defaultBarcodeReaderSettings.Clone())); 
#endif
        }

        /// <summary>
        /// Shows the default barcode reading settings for newly added barcode fields.
        /// </summary>
        private void barcodeReaderDefaultSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            using (BarcodeReaderSettingsForm settingsForm = new BarcodeReaderSettingsForm(_defaultBarcodeReaderSettings))
            {
                settingsForm.ShowDialog();
            } 
#endif
        }

        #endregion


        #region Image viewer toolstrip

        /// <summary>
        /// Clears image collection of the image viewer and adds template image or document
        /// to the image collection of the image viewer.
        /// </summary>
        private void imageViewerToolStrip_OpenFile(object sender, EventArgs e)
        {
            OpenImageOrDocument();
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the KeyDown event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
            {
                DeleteFocusedFieldTemplate();
            }
        }

        /// <summary>
        /// Index of focused image in viewer is changed.
        /// </summary>
        private void imageViewer1_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            if (image == null)
            {
                _fieldTemplateEditorTool.FieldTemplateCollection = null;
            }
            else
            {
                // get the form page template
                FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(image);
                // set items of page template as current items of the visual tool
                SetCurrentFormFieldTemplates(pageTemplate.Items);
                // if image has a tree view node
                if (_imagesToTemplateTreeNodes.ContainsKey(image))
                {
                    // select the node in the tree view
                    templatesTreeView.SelectedNode = _imagesToTemplateTreeNodes[image];
                }
            }
            UpdateImageInfo();
        }

        #endregion


        #region Image collection

        /// <summary>
        /// Collection of template images is changed.
        /// </summary>
        private void TemplateImages_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            // synchronize the tree view of the template document
            switch (e.Action)
            {
                case ImageCollectionChangeAction.Clear:
                case ImageCollectionChangeAction.RemoveImages:
                    VintasoftImage[] images = e.Images;
                    for (int i = 0; i < images.Length; i++)
                    {
                        VintasoftImage removedImage = images[i];

                        TreeNode removedImageNode = _imagesToTemplateTreeNodes[removedImage];
                        for (int j = removedImageNode.Nodes.Count - 1; j >= 0; j--)
                            RemoveFormFieldTemplateTreeNode(removedImageNode.Nodes[j]);
                        _imagesToTemplateTreeNodes.Remove(removedImage);
                        removedImageNode.Tag = null;
                        _templatesRootNode.Nodes.Remove(removedImageNode);
                    }
                    break;
            }

            // update the UI
            UpdateUI();
        }

        #endregion


        #region File manipulation

        /// <summary>
        /// Opens image files and adds to the image collection of image viewer.
        /// Binarization is applied if necessary.
        /// </summary>
        /// <param name="append">Determines whether to append images to existing images in the collection.
        /// </param>
        private void OpenImages(bool append)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!append)
                {
                    // close existing template document
                    CloseDocument();
                }
                // create binarization form
                using (ImageBinarizationForm binarizationForm = new ImageBinarizationForm(
                    _binarizeCommand, _renderingSettings))
                {
                    foreach (string filename in openImageFileDialog.FileNames)
                    {
                        AddImage(filename, binarizationForm);
                        if (binarizationForm.Cancel)
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Adds images from specified file path to the image collection.
        /// </summary>
        /// <param name="filename">Path to the file.</param>
        /// <param name="binarizationForm">Binarization form.</param>
        private void AddImage(string filename, ImageBinarizationForm binarizationForm)
        {
            ImageCollection templateImages = _templateManager.TemplateImages;
            // temporary image collection for all images in current file
            ImageCollection addingImages = new ImageCollection();
            DocumentPasswordForm.EnableAuthentication(addingImages);
            try
            {
                try
                {
                    addingImages.Add(filename);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex, filename);
                    return;
                }

                foreach (VintasoftImage image in addingImages)
                {
                    // if binarization is canceled
                    if (binarizationForm.Cancel)
                    {
                        image.Dispose();
                        continue;
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
                            continue;
                        }
                        // if processing command is set
                        if (processingCommand != null)
                        {
                            bool processingError = false;
                            try
                            {
                                processingCommand.ExecuteInPlace(image);
                            }
                            catch (Exception ex)
                            {
                                DemosTools.ShowErrorMessage(ex);
                                image.Dispose();
                                processingError = true;
                            }
                            if (processingError)
                                continue;
                        }
                    }
                    templateImages.Add(image);
                    FormPageTemplate templatePage = _templateManager.GetPageTemplate(image);
                    templatePage.Name = GetTemplateName(image);
                    AddPageTreeNode(image, templatePage.Name);
                }
                addingImages.Clear();
            }
            finally
            {
                DocumentPasswordForm.DisableAuthentication(addingImages);
            }
        }

        /// <summary>
        /// Opens image file or template document and adds to the image collection of image viewer.
        /// Binarization is applied if necessary.
        /// </summary>
        private void OpenImageOrDocument()
        {
            if (_openImageOrDocumentDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = _openImageOrDocumentDialog.FileName;
                switch (Path.GetExtension(filename).ToLowerInvariant())
                {
                    case ".fdt":
                        AddDocument(filename, false);
                        break;

                    default:
                        // close existing template document
                        CloseDocument();
                        // create binarization form
                        using (ImageBinarizationForm binarizationForm = new ImageBinarizationForm(
                            _binarizeCommand, _renderingSettings))
                            AddImage(filename, binarizationForm);
                        break;
                }
            }
        }

        /// <summary>
        /// Opens template document and adds to the image collection of image viewer.
        /// Binarization is applied if necessary.
        /// </summary>
        /// <param name="append">Determines whether to append images to existing images in the collection.
        /// </param>
        private void OpenDocument(bool append)
        {
            if (_openDocumentDialog.ShowDialog() == DialogResult.OK)
                AddDocument(_openDocumentDialog.FileName, append);
        }

        /// <summary>
        /// Adds template document from specified file path to the image collection.
        /// Binarization is applied if necessary.
        /// </summary>
        /// <param name="filename">Path to the file.</param>
        /// <param name="append">Determines whether to append images to existing images in the collection.
        /// </param>
        internal void AddDocument(string filename, bool append)
        {
            FormDocumentTemplate templateDocument;
            try
            {
                templateDocument = FormDocumentTemplate.Deserialize(filename);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                return;
            }
            try
            {
                if (append)
                {
                    _templateManager.AddPageTemplatesFromDocument(templateDocument);
                }
                else
                {
                    _templateManager.LoadFromDocument(templateDocument);
                    if (string.IsNullOrEmpty(templateDocument.Name))
                        SetDefaultRootNode();
                    else
                        _templatesRootNode.Text = templateDocument.Name;
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            // images to remove from template manager
            List<VintasoftImage> imagesToRemove = new List<VintasoftImage>();

            // create binarization form
            using (ImageBinarizationForm binarizationForm = new ImageBinarizationForm(
                _binarizeCommand, _renderingSettings))
            {
                for (int i = 0; i < templateDocument.Pages.Count; i++)
                {
                    // current page template
                    FormPageTemplate templatePage = templateDocument.Pages[i];
                    if (!_templateManager.ContainsPageTemplate(templatePage))
                        continue;
                    // get corresponding template image
                    VintasoftImage templateImage = _templateManager.GetTemplateImage(templatePage);
                    // if binarization is canceled
                    if (binarizationForm.Cancel)
                    {
                        imagesToRemove.Add(templateImage);
                        continue;
                    }

                    if (templateImage.PixelFormat != PixelFormat.BlackWhite)
                    {
                        ProcessingCommandBase processingCommand = null;
                        // if settings shall be applied for all remaining images or
                        // settings are approved
                        if (binarizationForm.ApplyForAll || binarizationForm.ShowDialog(templateImage))
                        {
                            templateImage.RenderingSettings = binarizationForm.GetRenderingSettings();
                            processingCommand = binarizationForm.GetProcessingCommand();
                        }
                        // if binarization is canceled
                        if (binarizationForm.Cancel)
                        {
                            imagesToRemove.Add(templateImage);
                            continue;
                        }
                        // if processing command is set
                        if (processingCommand != null)
                            processingCommand.ExecuteInPlace(templateImage);
                    }

                    // add a node to the tree
                    string name = templatePage.Name;
                    if (string.IsNullOrEmpty(name))
                        name = templatePage.ImageFileName;
                    AddPageTreeNode(templateImage, name);
                    foreach (FormFieldTemplate formFieldTemplate in templatePage.Items)
                        AddFormFieldTemplateTreeNode(templateImage, formFieldTemplate);
                }
            }

            if (imagesToRemove.Count > 0)
            {
                // remove images from template manager
                foreach (VintasoftImage templateImage in imagesToRemove)
                {
                    _templateManager.RemovePage(templateImage);
                    templateImage.Dispose();
                }
                imagesToRemove.Clear();
            }

#if !REMOVE_OCR_PLUGIN
            // check OCR availability
            CheckOcrAvailability();
#endif
        }

        /// <summary>
        /// Closes the current template document.
        /// </summary>
        private void CloseDocument()
        {
            // remove and dispose existing template images
            _templateManager.TemplateImages.ClearAndDisposeItems();
            SetDefaultRootNode();
        }

#if !REMOVE_OCR_PLUGIN
        /// <summary>
        /// Checks availability of the OCR field recognition.
        /// </summary>
        private void CheckOcrAvailability()
        {
            if (!IsOcrEngineAvailable && ContainsOcrFields())
            {
                if (MessageBox.Show(
                    "Page templates contain at least one OCR field template, but OCR engine is not found.\r\n" +
                    "Would you like to remove all OCR field templates from the document template?",
                    "OCR field templates detected",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RemoveAllOcrFields();
                    DemosTools.ShowInfoMessage("All OCR field templates were removed.");
                }
            }
        }

        /// <summary>
        /// Determines whether template manager contains OCR fields.
        /// </summary>
        /// <returns><b>true</b> if the template manager contains at least one OCR field template;
        /// otherwise, <b>false</b>.</returns>
        private bool ContainsOcrFields()
        {
            foreach (VintasoftImage templateImage in _templateManager.TemplateImages)
            {
                FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(templateImage);
                if (ContainsOcrFields(pageTemplate))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified form field template contains OCR fields.
        /// </summary>
        /// <param name="template">The form field template.</param>
        /// <returns><b>true</b> if the template contains at least one OCR field template;
        /// otherwise, <b>false</b>.</returns>
        private bool ContainsOcrFields(FormFieldTemplate template)
        {
            FormFieldTemplateGroup templateGroup = template as FormFieldTemplateGroup;
            if (templateGroup == null)
                return false;

            foreach (FormFieldTemplate item in templateGroup.Items)
            {
                if (item is OcrFieldTemplate)
                    return true;

                if (ContainsOcrFields(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all OCR fields from template manager.
        /// </summary>
        private void RemoveAllOcrFields()
        {
            foreach (VintasoftImage templateImage in _templateManager.TemplateImages)
            {
                FormPageTemplate pageTemplate = _templateManager.GetPageTemplate(templateImage);
                RemoveAllOcrFields(pageTemplate);
            }
        }

        /// <summary>
        /// Removes all OCR fields from the specified form field template.
        /// </summary>
        /// <param name="template">The template.</param>
        private void RemoveAllOcrFields(FormFieldTemplate template)
        {
            FormFieldTemplateGroup templateGroup = template as FormFieldTemplateGroup;
            if (templateGroup != null)
            {
                List<FormFieldTemplate> ocrFieldTemplates = new List<FormFieldTemplate>();
                foreach (FormFieldTemplate item in templateGroup.Items)
                {
                    if (item is OcrFieldTemplate)
                        ocrFieldTemplates.Add(item);
                    else if (ContainsOcrFields(item))
                        RemoveAllOcrFields(item);
                }

                foreach (FormFieldTemplate item in ocrFieldTemplates)
                {
                    templateGroup.Items.Remove(item);
                    RemoveFormFieldTemplateTreeNode(item);
                }
            }
        }
#endif

        #endregion


        #region Field template editor tool

        /// <summary>
        /// Sets the current form field templates and adjusts the appearances of the views.
        /// </summary>
        /// <param name="fieldTemplates">The field templates.</param>
        private void SetCurrentFormFieldTemplates(FormFieldTemplateCollection fieldTemplates)
        {
            // set the collection of field templates as a current collection of the visual tool
            // (this will generate views for the field templates)
            _fieldTemplateEditorTool.FieldTemplateCollection = fieldTemplates;
            // if generated view collection exists
            if (_fieldTemplateEditorTool.FieldTemplateViewCollection != null)
                // set the appearances of generated views
                SetTemplateFieldsAppearance(_fieldTemplateEditorTool.FieldTemplateViewCollection);
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Mouse button is double clicked when field template editor tool is active.
        /// </summary>
        private void fieldTemplateEditorTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            FormFieldTemplateView fieldTemplateView =
                _fieldTemplateEditorTool.FocusedFieldTemplateView;
            // if form template view is found
            if (fieldTemplateView != null)
            {
                // if form template is OMR template table
                if (fieldTemplateView.FieldTemplate is OmrFieldTemplateTable)
                {
                    // get reference to the OMR template table
                    OmrFieldTemplateTable omrTemplateTable =
                        (OmrFieldTemplateTable)fieldTemplateView.FieldTemplate;
                    // create a form for editing the OMR template table cell values.
                    using (OmrTableCellValuesEditorForm cellValuesEditorForm =
                        new OmrTableCellValuesEditorForm(
                            omrTemplateTable.CellValues,
                            omrTemplateTable.Orientation))
                    {
                        // show the dialog
                        if (cellValuesEditorForm.ShowDialog() == DialogResult.OK)
                        {
                            // set the orientation of OMR template table
                            omrTemplateTable.Orientation = cellValuesEditorForm.Orientation;
                            // refresh the property grid
                            propertyGrid1.Refresh();
                        }
                    }
                }
#if !REMOVE_BARCODE_SDK
                else if (fieldTemplateView.FieldTemplate is BarcodeFieldTemplate)
                {
                    // Barcode Field
                    BarcodeFieldTemplate barcodeFieldTemplate = (BarcodeFieldTemplate)fieldTemplateView.FieldTemplate;
                    using (BarcodeReaderSettingsForm settingsForm = new BarcodeReaderSettingsForm(barcodeFieldTemplate.ReaderSettings))
                    {
                        // show the dialog
                        if (settingsForm.ShowDialog() == DialogResult.OK)
                        {
                            // refresh the property grid
                            propertyGrid1.Refresh();
                        }
                    }
                } 
#endif
#if !REMOVE_OCR_PLUGIN
                else if (fieldTemplateView.FieldTemplate is OcrFieldTemplate)
                {
                    // OCR Field
                    OcrFieldTemplate ocrFieldTemplate = (OcrFieldTemplate)fieldTemplateView.FieldTemplate;
                    using (OcrSettingsForm settingsForm = new OcrSettingsForm(
                        (TesseractOcrSettings)ocrFieldTemplate.OcrEngineSettings,
                        OcrFieldTemplate.OcrEngineManager.SupportedLanguages,
                        OcrBinarizationMode.Global,
                        false,
                        ocrFieldTemplate.OcrRecognitionRegionSplittingSettings,
                        _recognizeTextInMultipleThreads,
                        _maxOcrThreads))
                    {
                        settingsForm.CanChooseBinarization = false;
                        settingsForm.ShowHighlightLowConfidenceWordsCheckBox = false;
                        // show the dialog
                        if (settingsForm.ShowDialog() == DialogResult.OK)
                        {
                            OcrFieldTemplate.OcrEngineManager = CreateOcrEngineManager(
                                _tesseractOcrDllDirectory,
                                settingsForm.UseMultithreading,
                                settingsForm.MaxThreads);
                            // refresh the property grid
                            propertyGrid1.Refresh();
                        }
                    }
                }
#endif
            }
        }

        /// <summary>
        /// Focused field template view is changed.
        /// </summary>
        private void fieldTemplateEditorTool_FocusedFieldTemplateViewChanged(object sender, EventArgs e)
        {
            FormFieldTemplateView focusedFieldTemplateView = _fieldTemplateEditorTool.FocusedFieldTemplateView;
            if (focusedFieldTemplateView != null)
            {
                SetSelectedObjectInPropertyGrid(focusedFieldTemplateView.FieldTemplate);

                templatesTreeView.SelectedNode = _formFieldTemplateToTreeNodes[focusedFieldTemplateView.FieldTemplate];
            }
            else
            {
                SetSelectedObjectInPropertyGrid(null);

                VintasoftImage image = imageViewer1.Image;
                if (image != null)
                {
                    templatesTreeView.SelectedNode = _imagesToTemplateTreeNodes[imageViewer1.Image];
                }
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Adds specified form field template to an image and starts building of it.
        /// </summary>
        /// <param name="fieldTemplate">A form field template to add.</param>
        private void AddFormFieldTemplate(FormFieldTemplate fieldTemplate)
        {
            AddFormFieldTemplateTreeNode(imageViewer1.Image, fieldTemplate);
            FormFieldTemplateView fieldTemplateView = FormFieldTemplateViewFactory.CreateView(fieldTemplate);
            SetTemplateFieldAppearance(fieldTemplateView);
            _fieldTemplateEditorTool.AddAndBuild(fieldTemplateView);
        }

        /// <summary>
        /// Adds a table of OMR field templates to an image and starts building of it.
        /// </summary>
        /// <param name="cellTemplate">A template of table cell.</param>
        private void AddOmrTemplateTable(OmrFieldTemplate cellTemplate)
        {
            using (NewTableSetupForm tableSetupForm = new NewTableSetupForm(5, 5))
            {
                if (tableSetupForm.ShowDialog() == DialogResult.OK)
                {
                    OmrFieldTemplateTable templateTable = new OmrFieldTemplateTable(
                        cellTemplate,
                        tableSetupForm.RowCount,
                        tableSetupForm.ColumnCount,
                        OmrTableOrientation.Horizontal);
                    AddFormFieldTemplateTreeNode(imageViewer1.Image, templateTable);
                    // set default distance between columns
                    templateTable.DistanceBetweenColumns = 0.2f;
                    // set default distance between rows
                    templateTable.DistanceBetweenRows = 0.2f;
                    templateTable.BuildingFinished += new EventHandler<EventArgs>(
                        templateTable_BuildingFinished);
                    // create view for table
                    FormFieldTemplateView templateTableView =
                        FormFieldTemplateViewFactory.CreateView(templateTable);
                    SetTemplateFieldAppearance(templateTableView);
                    // build the table
                    _fieldTemplateEditorTool.AddAndBuild(templateTableView);
                }
            }
        }

        /// <summary>
        /// Rebuilding of items of a table of OMR field templates is finished.
        /// </summary>
        private void templateTable_BuildingFinished(object sender, EventArgs e)
        {
            OmrFieldTemplateTable templateTable = sender as OmrFieldTemplateTable;
            if (templateTable != null)
            {
                FormFieldTemplateView templateTableView =
                    _fieldTemplateEditorTool.FieldTemplateViewCollection.FindView(templateTable);
                if (templateTableView != null)
                    SetTemplateFieldAppearance(templateTableView);
            }
        }

        /// <summary>
        /// Deletes the focused form field template view from image.
        /// </summary>
        private bool DeleteFocusedFieldTemplate()
        {
            bool deleted = false;
            FormFieldTemplateView focusedFieldTemplateView =
                _fieldTemplateEditorTool.FocusedFieldTemplateView;
            if (focusedFieldTemplateView != null)
            {
                FormPageTemplate templatePage = _templateManager.GetPageTemplate(imageViewer1.Image);
                FormFieldTemplate fieldTemplate = focusedFieldTemplateView.FieldTemplate;
                focusedFieldTemplateView.IsVisible = false;
                DeleteFieldTemplate(templatePage.Items, fieldTemplate);
                deleted = true;
            }

            // update the UI
            UpdateUI();

            return deleted;
        }

        /// <summary>
        /// Deletes the field template.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="item">The item.</param>
        private bool DeleteFieldTemplate(FormFieldTemplateCollection collection, FormFieldTemplate item)
        {
            if (collection.Contains(item))
            {
                collection.Remove(item);
                RemoveFormFieldTemplateTreeNode(item);
                return true;
            }

            for (int i = 0; i < collection.Count; i++)
            {
                FormFieldTemplate currentTemplate = collection[i];
                if (collection[i] is FormFieldTemplateGroup)
                {
                    FormFieldTemplateGroup group = collection[i] as FormFieldTemplateGroup;
                    if (DeleteFieldTemplate(group.Items, item))
                    {
                        if (group.Items.Count == 0)
                        {
                            collection.Remove(currentTemplate);
                            RemoveFormFieldTemplateTreeNode(currentTemplate);
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        #endregion


        #region Form field view

        /// <summary>
        /// Sets the appearance of form field template view collection.
        /// </summary>
        /// <param name="fieldTemplateViews">A collection of views of the form field templates.</param>
        private void SetTemplateFieldsAppearance(FormFieldTemplateViewCollection fieldTemplateViews)
        {
            foreach (FormFieldTemplateView fieldTemplateView in fieldTemplateViews)
            {
                SetTemplateFieldAppearance(fieldTemplateView);
            }
        }

        /// <summary>
        /// Sets the appearance of form field template view.
        /// </summary>
        /// <param name="fieldTemplateView">The form field template view.</param>
        private void SetTemplateFieldAppearance(FormFieldTemplateView fieldTemplateView)
        {
            if (fieldTemplateView is FormFieldTemplateGroupView)
                foreach (FormFieldTemplateView nestedFieldView in ((FormFieldTemplateGroupView)fieldTemplateView).ViewItems)
                    SetTemplateFieldAppearance(nestedFieldView);

            if (fieldTemplateView.Pen != null)
                fieldTemplateView.Pen.Color = Color.FromArgb(fieldTemplateView.Pen.Color.A, Color.Red);
        }

        /// <summary>
        /// Returns a copy of focused form field template view.
        /// </summary>
        private FormFieldTemplateView GetFocusedFieldTemplateCopy()
        {
            FormFieldTemplateView focusedFieldTemplateView = _fieldTemplateEditorTool.FocusedFieldTemplateView;
            if (focusedFieldTemplateView == null)
                return null;

            return (FormFieldTemplateView)focusedFieldTemplateView.Clone();
        }

        #endregion


        #region Template tree view

        /// <summary>
        /// Adds a node in the pages tree.
        /// </summary>
        /// <param name="addedImage">Image of the page template.</param>
        /// <param name="templateName">Name of the page template.</param>
        private void AddPageTreeNode(VintasoftImage addedImage, string templateName)
        {
            TreeNode addedImageNode = new TreeNode();
            addedImageNode.Tag = addedImage;
            addedImageNode.Text = templateName;
            _imagesToTemplateTreeNodes.Add(addedImage, addedImageNode);
            _templatesRootNode.Nodes.Add(addedImageNode);
            _templatesRootNode.Expand();
        }

        private void AddFormFieldTemplateTreeNode(VintasoftImage image, FormFieldTemplate fieldTemplate)
        {
            TreeNode rootNode = _imagesToTemplateTreeNodes[image];
            AddFormFieldTemplateTreeNode(rootNode, fieldTemplate);
        }

        private void AddFormFieldTemplateTreeNode(TreeNode root, FormFieldTemplate fieldTemplate)
        {
            TreeNode node = new TreeNode();
            // set the text of the tree node
            SetFormFieldTemplateTreeNodeText(node, fieldTemplate);
            _formFieldTemplateToTreeNodes.Add(fieldTemplate, node);
            node.Tag = fieldTemplate;
            root.Nodes.Add(node);
            if (!root.IsExpanded)
                root.Expand();

            if (fieldTemplate is FormFieldTemplateGroup &&
                !(fieldTemplate is OmrFieldTemplateTable))
            {
                FormFieldTemplateGroup group = fieldTemplate as FormFieldTemplateGroup;
                foreach (FormFieldTemplate item in group.Items)
                    AddFormFieldTemplateTreeNode(node, item);
            }
        }

        private void RemoveFormFieldTemplateTreeNode(FormFieldTemplate fieldTemplate)
        {
            TreeNode node = _formFieldTemplateToTreeNodes[fieldTemplate];
            node.Tag = null;
            node.Remove();
            _formFieldTemplateToTreeNodes.Remove(fieldTemplate);

            if (fieldTemplate is FormFieldTemplateGroup &&
              !(fieldTemplate is OmrFieldTemplateTable))
            {
                FormFieldTemplateGroup group = fieldTemplate as FormFieldTemplateGroup;
                foreach (FormFieldTemplate item in group.Items)
                    RemoveFormFieldTemplateTreeNode(item);
            }
        }

        private void RemoveFormFieldTemplateTreeNode(TreeNode node)
        {
            for (int i = node.Nodes.Count - 1; i >= 0; i--)
                RemoveFormFieldTemplateTreeNode(node.Nodes[i]);
            node.Remove();
            FormFieldTemplate fieldTemplate = node.Tag as FormFieldTemplate;
            _formFieldTemplateToTreeNodes.Remove(fieldTemplate);
        }

        /// <summary>
        /// Sets default root node of the pages tree.
        /// </summary>
        private void SetDefaultRootNode()
        {
            _templatesRootNode.Text = "Untitled";
        }

        /// <summary>
        /// Updates names of tree nodes of subtree.
        /// </summary>
        /// <param name="node">The root node of the subtree.</param>
        private void UpdateNames(TreeNode node)
        {
            if (node.Tag is FormFieldTemplate)
            {
                FormFieldTemplate fieldTemplate = (FormFieldTemplate)node.Tag;
                // update the text of the tree node and 
                SetFormFieldTemplateTreeNodeText(node, fieldTemplate);
                // for each subnode
                foreach (TreeNode subnode in node.Nodes)
                    // update names of the subnode
                    UpdateNames(subnode);
            }
        }

        /// <summary>
        /// Sets the text of form field template tree node.
        /// </summary>
        /// <param name="node">The tree node of the form field template.</param>
        /// <param name="fieldTemplate">The form field template.</param>
        private void SetFormFieldTemplateTreeNodeText(TreeNode node, FormFieldTemplate fieldTemplate)
        {
            string text;
            if (string.IsNullOrEmpty(fieldTemplate.Name))
                // get name of the type
                text = fieldTemplate.GetType().Name;
            else
                // get name of the template
                text = fieldTemplate.Name;
            // if text is different
            if (node.Text != text)
                // set the text
                node.Text = text;
        }

        /// <summary>
        /// Handles the PropertyChanged event of the group of form field templates.
        /// </summary>
        private void templateGroup_PropertyChanged(object sender, ObjectPropertyChangedEventArgs e)
        {
            // if items are changed
            if (e.PropertyName == "Items")
            {
                // get the template group
                FormFieldTemplate templateGroup = sender as FormFieldTemplate;
                // get the tree node of the group
                TreeNode node = _formFieldTemplateToTreeNodes[templateGroup];
                // update the names
                UpdateNames(node);
            }
        }

        /// <summary>
        /// Handles the AfterSelect event of the templates TreeView.
        /// </summary>
        private void templatesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == _templatesRootNode)
            {
                SetSelectedObjectInPropertyGrid(_templateManager);
            }
            // if current node is a node of an image
            else if (e.Node.Tag is VintasoftImage)
            {
                // set it as a focused image

                VintasoftImage image = e.Node.Tag as VintasoftImage;
                int indexOfImage = imageViewer1.Images.IndexOf(image);
                if (indexOfImage >= 0)
                {
                    imageViewer1.FocusedIndex = indexOfImage;
                    FormPageTemplate template = _templateManager.GetPageTemplate(image);
                    SetSelectedObjectInPropertyGrid(template);
                }
            }
            else if (e.Node.Tag is FormFieldTemplate)
            {
                TreeNode node = e.Node.Parent;
                while (node != null)
                {
                    if (node.Tag is VintasoftImage)
                    {
                        VintasoftImage image = node.Tag as VintasoftImage;
                        int indexOfImage = imageViewer1.Images.IndexOf(image);
                        imageViewer1.FocusedIndex = indexOfImage;
                        break;
                    }
                    node = node.Parent;
                }

                FormFieldTemplate fieldTemplate = e.Node.Tag as FormFieldTemplate;
                if (_fieldTemplateEditorTool.FieldTemplateViewCollection != null)
                    _fieldTemplateEditorTool.FocusedFieldTemplateView =
                        _fieldTemplateEditorTool.FieldTemplateViewCollection.FindView(fieldTemplate);
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of propertyGrid1 object.
        /// </summary>
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label != "Name" && e.ChangedItem.Label != "DocumentName")
                return;

            TreeNode node = null;
            string name = (string)e.ChangedItem.Value;

            if (propertyGrid1.SelectedObject is FormPageTemplate)
            {
                node = _imagesToTemplateTreeNodes[imageViewer1.Image];
                if (string.IsNullOrEmpty(name))
                {
                    FormPageTemplate template = (FormPageTemplate)propertyGrid1.SelectedObject;
                    name = template.ImageFileName;
                }
                node.Text = name;
            }
            else if (propertyGrid1.SelectedObject is FormFieldTemplate)
            {
                node = _formFieldTemplateToTreeNodes[(FormFieldTemplate)propertyGrid1.SelectedObject];
                if (string.IsNullOrEmpty(name))
                    name = propertyGrid1.SelectedObject.GetType().Name;
                node.Text = name;

            }
            else if (propertyGrid1.SelectedObject is FormTemplateManager)
            {
                node = _templatesRootNode;
                if (string.IsNullOrEmpty(name))
                    SetDefaultRootNode();
                else
                    node.Text = name;
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of templatesTreeView object.
        /// </summary>
        void templatesTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (templatesTreeView.SelectedNode != null &&
                templatesTreeView.SelectedNode.Tag is FormFieldTemplate)
            {
                fieldTemplateEditorTool_MouseDoubleClick(sender, null);
            }
        }

        /// <summary>
        /// Handles the AfterLabelEdit event of templatesTreeView object.
        /// </summary>
        private void templatesTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return;

            if (e.Node.Tag is VintasoftImage)
            {
                FormPageTemplate template = _templateManager.GetPageTemplate((VintasoftImage)e.Node.Tag);
                if (string.IsNullOrEmpty(e.Label))
                {
                    e.CancelEdit = true;
                    e.Node.Text = template.ImageFileName;
                }
                template.Name = e.Label;
                propertyGrid1.Refresh();
            }
            else if (e.Node.Tag is FormFieldTemplate)
            {
                FormFieldTemplate fieldTemplate = e.Node.Tag as FormFieldTemplate;

                if (string.IsNullOrEmpty(e.Label))
                {
                    e.CancelEdit = true;
                    e.Node.Text = fieldTemplate.GetType().Name;
                }

                fieldTemplate.Name = e.Label;
                propertyGrid1.Refresh();
            }
            else if (e.Node == _templatesRootNode)
            {
                if (string.IsNullOrEmpty(e.Label))
                {
                    e.CancelEdit = true;
                    SetDefaultRootNode();
                }

                _templateManager.DocumentName = e.Label;
                propertyGrid1.Refresh();
            }
        }

        #endregion

        #endregion

    }
}
