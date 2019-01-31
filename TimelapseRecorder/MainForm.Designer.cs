namespace TimelapseRecorder
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DirectoryLabel = new MaterialSkin.Controls.MaterialLabel();
            this.directoryTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.showInFileExplorerButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.framesPerSecondLabel = new MaterialSkin.Controls.MaterialLabel();
            this.divisorTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.startRecordingButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.recordingTimer = new System.Windows.Forms.Timer(this.components);
            this.dividerTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.divisionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.screensComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.Controls.Add(this.DirectoryLabel);
            this.flowLayoutPanel.Controls.Add(this.directoryTextField);
            this.flowLayoutPanel.Controls.Add(this.fileTypeComboBox);
            this.flowLayoutPanel.Controls.Add(this.showInFileExplorerButton);
            this.flowLayoutPanel.Controls.Add(this.screensComboBox);
            this.flowLayoutPanel.Controls.Add(this.framesPerSecondLabel);
            this.flowLayoutPanel.Controls.Add(this.divisorTextField);
            this.flowLayoutPanel.Controls.Add(this.divisionLabel);
            this.flowLayoutPanel.Controls.Add(this.dividerTextField);
            this.flowLayoutPanel.Controls.Add(this.startRecordingButton);
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 64);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(600, 171);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Depth = 0;
            this.DirectoryLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.DirectoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DirectoryLabel.Location = new System.Drawing.Point(3, 0);
            this.DirectoryLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(175, 19);
            this.DirectoryLabel.TabIndex = 6;
            this.DirectoryLabel.Text = "Save images to directory";
            // 
            // directoryTextField
            // 
            this.directoryTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTextField.Depth = 0;
            this.directoryTextField.Hint = "";
            this.directoryTextField.Location = new System.Drawing.Point(3, 22);
            this.directoryTextField.MaxLength = 32767;
            this.directoryTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.directoryTextField.Name = "directoryTextField";
            this.directoryTextField.PasswordChar = '\0';
            this.directoryTextField.SelectedText = "";
            this.directoryTextField.SelectionLength = 0;
            this.directoryTextField.SelectionStart = 0;
            this.directoryTextField.Size = new System.Drawing.Size(597, 23);
            this.directoryTextField.TabIndex = 5;
            this.directoryTextField.TabStop = false;
            this.directoryTextField.UseSystemPasswordChar = false;
            this.directoryTextField.TextChanged += new System.EventHandler(this.directoryTextField_TextChanged);
            // 
            // fileTypeComboBox
            // 
            this.fileTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileTypeComboBox.FormattingEnabled = true;
            this.fileTypeComboBox.ItemHeight = 13;
            this.fileTypeComboBox.Location = new System.Drawing.Point(3, 51);
            this.fileTypeComboBox.Name = "fileTypeComboBox";
            this.fileTypeComboBox.Size = new System.Drawing.Size(400, 21);
            this.fileTypeComboBox.TabIndex = 8;
            this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fileTypeComboBox_SelectedIndexChanged);
            // 
            // showInFileExplorerButton
            // 
            this.showInFileExplorerButton.AutoSize = true;
            this.showInFileExplorerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showInFileExplorerButton.Depth = 0;
            this.showInFileExplorerButton.Icon = null;
            this.showInFileExplorerButton.Location = new System.Drawing.Point(410, 54);
            this.showInFileExplorerButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.showInFileExplorerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.showInFileExplorerButton.Name = "showInFileExplorerButton";
            this.showInFileExplorerButton.Primary = false;
            this.showInFileExplorerButton.Size = new System.Drawing.Size(178, 36);
            this.showInFileExplorerButton.TabIndex = 7;
            this.showInFileExplorerButton.Text = "Show in file explorer";
            this.showInFileExplorerButton.UseVisualStyleBackColor = true;
            this.showInFileExplorerButton.Click += new System.EventHandler(this.showInFileExplorerButton_Click);
            // 
            // framesPerSecondLabel
            // 
            this.framesPerSecondLabel.AutoSize = true;
            this.framesPerSecondLabel.Depth = 0;
            this.framesPerSecondLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.framesPerSecondLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.framesPerSecondLabel.Location = new System.Drawing.Point(3, 123);
            this.framesPerSecondLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.framesPerSecondLabel.Name = "framesPerSecondLabel";
            this.framesPerSecondLabel.Size = new System.Drawing.Size(137, 19);
            this.framesPerSecondLabel.TabIndex = 12;
            this.framesPerSecondLabel.Text = "Frames per second";
            // 
            // divisorTextField
            // 
            this.divisorTextField.Depth = 0;
            this.divisorTextField.Hint = "";
            this.divisorTextField.Location = new System.Drawing.Point(146, 126);
            this.divisorTextField.MaxLength = 32767;
            this.divisorTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.divisorTextField.Name = "divisorTextField";
            this.divisorTextField.PasswordChar = '\0';
            this.divisorTextField.SelectedText = "";
            this.divisorTextField.SelectionLength = 0;
            this.divisorTextField.SelectionStart = 0;
            this.divisorTextField.Size = new System.Drawing.Size(75, 23);
            this.divisorTextField.TabIndex = 9;
            this.divisorTextField.TabStop = false;
            this.divisorTextField.Text = "1";
            this.divisorTextField.UseSystemPasswordChar = false;
            this.divisorTextField.TextChanged += new System.EventHandler(this.divisorTextField_TextChanged);
            // 
            // startRecordingButton
            // 
            this.startRecordingButton.AutoSize = true;
            this.startRecordingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startRecordingButton.Depth = 0;
            this.startRecordingButton.Icon = null;
            this.startRecordingButton.Location = new System.Drawing.Point(329, 126);
            this.startRecordingButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.startRecordingButton.Name = "startRecordingButton";
            this.startRecordingButton.Primary = true;
            this.startRecordingButton.Size = new System.Drawing.Size(142, 36);
            this.startRecordingButton.TabIndex = 4;
            this.startRecordingButton.Text = "Start recording";
            this.startRecordingButton.UseVisualStyleBackColor = true;
            this.startRecordingButton.Click += new System.EventHandler(this.startRecordingButton_Click);
            // 
            // recordingTimer
            // 
            this.recordingTimer.Tick += new System.EventHandler(this.recordingTimer_Tick);
            // 
            // dividerTextField
            // 
            this.dividerTextField.Depth = 0;
            this.dividerTextField.Hint = "";
            this.dividerTextField.Location = new System.Drawing.Point(248, 126);
            this.dividerTextField.MaxLength = 32767;
            this.dividerTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.dividerTextField.Name = "dividerTextField";
            this.dividerTextField.PasswordChar = '\0';
            this.dividerTextField.SelectedText = "";
            this.dividerTextField.SelectionLength = 0;
            this.dividerTextField.SelectionStart = 0;
            this.dividerTextField.Size = new System.Drawing.Size(75, 23);
            this.dividerTextField.TabIndex = 11;
            this.dividerTextField.TabStop = false;
            this.dividerTextField.Text = "1";
            this.dividerTextField.UseSystemPasswordChar = false;
            this.dividerTextField.TextChanged += new System.EventHandler(this.dividerTextField_TextChanged);
            // 
            // divisionLabel
            // 
            this.divisionLabel.AutoSize = true;
            this.divisionLabel.Depth = 0;
            this.divisionLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.divisionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.divisionLabel.Location = new System.Drawing.Point(227, 123);
            this.divisionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.divisionLabel.Name = "divisionLabel";
            this.divisionLabel.Size = new System.Drawing.Size(15, 19);
            this.divisionLabel.TabIndex = 10;
            this.divisionLabel.Text = "/";
            // 
            // screensComboBox
            // 
            this.screensComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screensComboBox.FormattingEnabled = true;
            this.screensComboBox.ItemHeight = 13;
            this.screensComboBox.Location = new System.Drawing.Point(3, 99);
            this.screensComboBox.Name = "screensComboBox";
            this.screensComboBox.Size = new System.Drawing.Size(585, 21);
            this.screensComboBox.TabIndex = 13;
            this.screensComboBox.SelectedIndexChanged += new System.EventHandler(this.screensComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 235);
            this.Controls.Add(this.flowLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(600, 235);
            this.MinimumSize = new System.Drawing.Size(600, 235);
            this.Name = "MainForm";
            this.Text = "Timelapse recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private MaterialSkin.Controls.MaterialLabel DirectoryLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField directoryTextField;
        private MaterialSkin.Controls.MaterialRaisedButton startRecordingButton;
        private MaterialSkin.Controls.MaterialFlatButton showInFileExplorerButton;
        private System.Windows.Forms.ComboBox fileTypeComboBox;
        private MaterialSkin.Controls.MaterialLabel framesPerSecondLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField divisorTextField;
        private MaterialSkin.Controls.MaterialLabel divisionLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField dividerTextField;
        private System.Windows.Forms.Timer recordingTimer;
        private System.Windows.Forms.ComboBox screensComboBox;
    }
}

