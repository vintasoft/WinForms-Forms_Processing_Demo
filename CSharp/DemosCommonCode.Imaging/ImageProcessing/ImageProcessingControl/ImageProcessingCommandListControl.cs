using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;


namespace DemosCommonCode
{
    /// <summary>
    /// A control that allows to view the available image processing commands.
    /// </summary>
    public partial class ImageProcessingCommandListControl : UserControl
    {

        #region Constants

        /// <summary>
        /// The value, from command type list, that defines that all commands must be shown.
        /// </summary>
        private const string ALL_COMMANDS_KEY = "All";

        #endregion



        #region Fields

        /// <summary>
        /// The dictionary: command name =>  image processing command that must be shown in list box.
        /// </summary>
        Dictionary<string, ProcessingCommandBase> _commandListBoxItems = new Dictionary<string, ProcessingCommandBase>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingCommandListControl"/> class.
        /// </summary>
        public ImageProcessingCommandListControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        private Dictionary<string, ProcessingCommandBase[]> _availableProcessingCommands = null;
        /// <summary>
        /// Gets or sets the image processing commands, which can be shown in this control.
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
                return _availableProcessingCommands;
            }
            set
            {
                if (_availableProcessingCommands != value)
                {
                    _availableProcessingCommands = value;

                    UpdateProcessingCommands();

                    commandListBox.Enabled = _availableProcessingCommands != null;
                }
            }
        }

        /// <summary>
        /// Gets the selected image processing command.
        /// </summary>
        [Browsable(false)]
        public ProcessingCommandBase SelectedProcessingCommand
        {
            get
            {
                if (commandListBox.SelectedIndex == -1)
                    return null;
                else
                {
                    string commandName = (string)commandListBox.SelectedItem;
                    return _commandListBoxItems[commandName];
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the SelectedIndexChanged event of commandTypeComboBox object.
        /// </summary>
        private void commandTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update commands
            UpdateCommandListBox(commandTypeComboBox.Text);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of commandListBox object.
        /// </summary>
        private void commandListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedProcessingCommandChanged != null)
                // raise the selected processing command changed event
                SelectedProcessingCommandChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of commandListBox object.
        /// </summary>
        private void commandListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MouseDoubleClickOnSelectedProcessingCommand != null)
                // raise the mouse double click on selected processing command event
                MouseDoubleClickOnSelectedProcessingCommand(this, EventArgs.Empty);
        }


        /// <summary>
        /// Updates the processing commands.
        /// </summary>
        private void UpdateProcessingCommands()
        {
            if (_availableProcessingCommands != null && _availableProcessingCommands.Count > 1)
            {
                string[] commandTypeNames = GetCommandTypeNames();

                InitCommandTypeComboBox(commandTypeNames);
            }
            else
            {
                commandTypesPanel.Visible = false;

                UpdateCommandListBox(ALL_COMMANDS_KEY);
            }
        }

        /// <summary>
        /// Returns the command type names.
        /// </summary>
        /// <returns>The command type names.</returns>
        private string[] GetCommandTypeNames()
        {
            string[] commandTypeNames = new string[_availableProcessingCommands.Count];
            _availableProcessingCommands.Keys.CopyTo(commandTypeNames, 0);

            for (int i = 0; i < commandTypeNames.Length; i++)
            {
                if (string.IsNullOrEmpty(commandTypeNames[i] ))
                    throw new ArgumentException("Command type can not be empty.");
            }

            return commandTypeNames;
        }

        /// <summary>
        /// Inits the command type list box.
        /// </summary>
        /// <param name="commandTypeNames">The command type names.</param>
        private void InitCommandTypeComboBox(string[] commandTypeNames)
        {
            commandTypesPanel.Visible = true;

            commandTypeComboBox.BeginUpdate();
            try
            {
                commandTypeComboBox.Items.Clear();
                commandTypeComboBox.Items.Add(ALL_COMMANDS_KEY);

                foreach (string commandTypeName in commandTypeNames)
                {
                    if (string.IsNullOrEmpty(commandTypeName))
                        throw new ArgumentException("Command type can not be empty.");
                    commandTypeComboBox.Items.Add(commandTypeName);
                }

                commandTypeComboBox.SelectedItem = ALL_COMMANDS_KEY;
            }
            finally
            {
                commandTypeComboBox.EndUpdate();
            }
        }

        /// <summary>
        /// Updates the list box with image processing commands.
        /// </summary>
        /// <param name="commandType">The type of commands.</param>
        private void UpdateCommandListBox(string commandType)
        {
            _commandListBoxItems.Clear();
            commandListBox.BeginUpdate();
            commandListBox.Items.Clear();

            try
            {
                if (_availableProcessingCommands == null)
                    return;

                // if all commands must be shown in list box
                if (commandType == ALL_COMMANDS_KEY)
                {
                    foreach (string typeName in _availableProcessingCommands.Keys)
                    {
                        ProcessingCommandBase[] processingCommands = _availableProcessingCommands[typeName];
                        AddProcessingCommandToCommandListBox(processingCommands);
                    }
                }
                // if only commands of specified type must be shown in list box
                else
                {
                    ProcessingCommandBase[] processingCommands = _availableProcessingCommands[commandType];
                    AddProcessingCommandToCommandListBox(processingCommands);
                }
            }
            finally
            {
                commandListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Adds the processing command to command ListBox.
        /// </summary>
        /// <param name="processingCommands">The processing commands.</param>
        private void AddProcessingCommandToCommandListBox(params ProcessingCommandBase[] processingCommands)
        {
            foreach (ProcessingCommandBase processingCommand in processingCommands)
            {
                commandListBox.Items.Add(processingCommand.Name);
                _commandListBoxItems.Add(processingCommand.Name, processingCommand);
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when selected processing command is changed.
        /// </summary>
        public event EventHandler SelectedProcessingCommandChanged;

        /// <summary>
        /// Occurs when selected processing command is double clicked.
        /// </summary>
        public event EventHandler MouseDoubleClickOnSelectedProcessingCommand;

        #endregion

    }

}
