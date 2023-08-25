using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;

using DemosCommonCode.Imaging;


namespace DemosCommonCode
{
    /// <summary>
    /// A control that allows to select the image processing commands.
    /// </summary>
    public partial class ImageProcessingCommandSelectionControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="ImageProcessingCommandSelectionControl"/> class.
        /// </summary>
        public ImageProcessingCommandSelectionControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the available processing commands.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public Dictionary<string, ProcessingCommandBase[]> AvailableProcessingCommands
        {
            get
            {
                return imageProcessingCommandsViewer1.AvailableProcessingCommands;
            }
            set
            {
                imageProcessingCommandsViewer1.AvailableProcessingCommands = value;
                UpdateUI();
            }
        }

        /// <summary>
        /// Gets or sets the selected commands.
        /// </summary>
        [Browsable(false)]
        public ProcessingCommandBase[] SelectedCommands
        {
            get
            {
                if (commandsToProcessListBox.Items.Count == 0)
                    return null;

                ProcessingCommandBase[] commands =
                    new ProcessingCommandBase[commandsToProcessListBox.Items.Count];

                for (int i = 0; i < commands.Length; i++)
                    commands[i] = (ProcessingCommandBase)commandsToProcessListBox.Items[i];

                return commands;
            }
            set
            {
                commandsToProcessListBox.BeginUpdate();
                commandsToProcessListBox.Items.Clear();
                if (value != null)
                {
                    foreach (ProcessingCommandBase command in value)
                        commandsToProcessListBox.Items.Add(command);
                }
                commandsToProcessListBox.EndUpdate();

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the SelectedProcessingCommandChanged event of ImageProcessingCommandsViewer1 object.
        /// </summary>
        private void imageProcessingCommandsViewer1_SelectedProcessingCommandChanged(
            object sender,
            EventArgs e)
        {
            // update the user interface
            UpdateUI();
        }

        /// <summary>
        /// Handles the MouseDoubleClickOnSelectedProcessingCommand event of ImageProcessingCommandsViewer1 object.
        /// </summary>
        private void imageProcessingCommandsViewer1_MouseDoubleClickOnSelectedProcessingCommand(
            object sender,
            EventArgs e)
        {
            // if the processing command is selected
            if (imageProcessingCommandsViewer1.SelectedProcessingCommand != null)
                // add the selected processing command to process list
                AddSelectedCommandToProcessList();
        }

        /// <summary>
        /// Handles the Click event of AddCommandToListButton object.
        /// </summary>
        private void addCommandToListButton_Click(object sender, EventArgs e)
        {
            // add the selected processing command to process list
            AddSelectedCommandToProcessList();
        }


        /// <summary>
        /// Handles the Click event of RemoveCommandFromListButton object.
        /// </summary>
        private void removeCommandFromListButton_Click(object sender, EventArgs e)
        {
            // get selected processing command
            int index = commandsToProcessListBox.SelectedIndex;
            // remove the selected processing command
            commandsToProcessListBox.Items.RemoveAt(index);

            // if the current index is greater than the number of processing commands
            if (index >= commandsToProcessListBox.Items.Count)
                index--;
            // update selected index
            commandsToProcessListBox.SelectedIndex = index;
            OnProcessingCommandsChanged();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of RemoveAllCommandsFromList object.
        /// </summary>
        private void removeAllCommandsFromList_Click(object sender, EventArgs e)
        {
            // clear processing commands list
            commandsToProcessListBox.Items.Clear();
            OnProcessingCommandsChanged();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of MoveUpButton object.
        /// </summary>
        private void moveUpButton_Click(object sender, EventArgs e)
        {
            // move down the selected processing commands
            MoveListBoxSelectedItem(commandsToProcessListBox, -1);
            OnProcessingCommandsChanged();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of MoveDownButton object.
        /// </summary>
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            // move up the selected processing commands
            MoveListBoxSelectedItem(commandsToProcessListBox, 1);
            OnProcessingCommandsChanged();

            UpdateUI();
        }


        /// <summary>
        /// Handles the DoubleClick event of CommandsToProcessListBox object.
        /// </summary>
        private void commandsToProcessListBox_DoubleClick(object sender, EventArgs e)
        {
            if (commandsToProcessListBox.SelectedItem != null)
                // set the selected processing command properties
                SetCommandProperties((ProcessingCommandBase)commandsToProcessListBox.SelectedItem);
        }

        /// <summary>
        /// Handles the Click event of SetCommandPropertiesButton object.
        /// </summary>
        private void setCommandPropertiesButton_Click(object sender, EventArgs e)
        {
            // set the selected processing command properties
            SetCommandProperties((ProcessingCommandBase)commandsToProcessListBox.SelectedItem);
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of CommandsToProcessListBox object.
        /// </summary>
        private void commandsToProcessListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update user interface
            UpdateUI();
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isAddCommandSelected = imageProcessingCommandsViewer1.SelectedProcessingCommand != null;
            bool isCommandToProcessSelected = commandsToProcessListBox.SelectedIndex != -1;
            bool isFirstCommandToProcessSelected = commandsToProcessListBox.SelectedIndex == 0;
            bool isLastCommandToProcessSelected =
                commandsToProcessListBox.SelectedIndex == commandsToProcessListBox.Items.Count - 1;
            bool isCommandsToProcessSpecified = commandsToProcessListBox.Items.Count > 0;

            addCommandToListButton.Enabled = isAddCommandSelected;

            removeCommandFromListButton.Enabled = isCommandToProcessSelected;
            removeAllCommandsFromList.Enabled = isCommandsToProcessSpecified;
            moveUpButton.Enabled = isCommandToProcessSelected && !isFirstCommandToProcessSelected;
            moveDownButton.Enabled = isCommandToProcessSelected && !isLastCommandToProcessSelected;
            setCommandPropertiesButton.Enabled = isCommandToProcessSelected;
        }

        /// <summary>
        /// Adds the selected processing command to the list of image processing commands.
        /// </summary>
        private void AddSelectedCommandToProcessList()
        {
            ProcessingCommandBase command = imageProcessingCommandsViewer1.SelectedProcessingCommand;
            try
            {
                commandsToProcessListBox.Items.Add((ProcessingCommandBase)command.Clone());
                OnProcessingCommandsChanged();
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
            UpdateUI();
        }

        /// <summary>
        /// Moves processing command, in the list of image processing commands, at delta positions.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="delta">The delta.</param>
        private void MoveListBoxSelectedItem(ListBox listBox, int delta)
        {
            object item = listBox.SelectedItem;
            listBox.BeginUpdate();
            int index = listBox.SelectedIndex;
            listBox.Items.RemoveAt(index);
            int newIndex = index + delta;
            listBox.Items.Insert(newIndex, item);
            listBox.SelectedIndex = newIndex;
            listBox.EndUpdate();
        }


        /// <summary>
        /// Sets the processing command properties.
        /// </summary>
        /// <param name="command">The command.</param>
        private void SetCommandProperties(ProcessingCommandBase command)
        {
            using (PropertyGridForm form = new PropertyGridForm(
                command,
                string.Format("{0} Properties", command.Name)))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this.ParentForm;
                form.ShowDialog();
                OnProcessingCommandsChanged();
            }
        }

        /// <summary>
        /// Raizes
        /// the <see cref="E:DemosCommonCode.ImageProcessingCommandsEditor.ProcessingCommandsChanged" />
        /// event.
        /// </summary>
        private void OnProcessingCommandsChanged()
        {
            if (ProcessingCommandsChanged != null)
                ProcessingCommandsChanged(this, EventArgs.Empty);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the processing commands is changed.
        /// </summary>
        public event EventHandler ProcessingCommandsChanged;

        #endregion

    }
}
