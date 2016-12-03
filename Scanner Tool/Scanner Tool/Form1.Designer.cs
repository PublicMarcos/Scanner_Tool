namespace Scanner_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InsertionCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.RotationCorrectionCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.EdgeDetectionCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckIfEmptyCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.GreyCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.DoubleSidedCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.VendorToolCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.ScannerSelectionButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ResetScanButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AddScanButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ScanAndSendFastButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ScanAndSaveFastButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SendButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SaveButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.MovePageForwardButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.MovePageBackButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.RotateImageButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DeletePageButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AllPagesTabControl = new System.Windows.Forms.TabControl();
            this.StatusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.StatusBar = new System.Windows.Forms.ProgressBar();
            this.AllPagesTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // InsertionCheckBox
            // 
            this.InsertionCheckBox.AutoSize = true;
            this.InsertionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.InsertionCheckBox.Depth = 0;
            this.InsertionCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.InsertionCheckBox.Location = new System.Drawing.Point(12, 166);
            this.InsertionCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.InsertionCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.InsertionCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.InsertionCheckBox.Name = "InsertionCheckBox";
            this.InsertionCheckBox.Ripple = true;
            this.InsertionCheckBox.Size = new System.Drawing.Size(146, 30);
            this.InsertionCheckBox.TabIndex = 22;
            this.InsertionCheckBox.Text = "Einschub benutzen";
            this.InsertionCheckBox.UseVisualStyleBackColor = false;
            this.InsertionCheckBox.CheckedChanged += new System.EventHandler(this.InsertionCheckBox_CheckedChanged);
            // 
            // RotationCorrectionCheckBox
            // 
            this.RotationCorrectionCheckBox.AutoSize = true;
            this.RotationCorrectionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RotationCorrectionCheckBox.Checked = true;
            this.RotationCorrectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RotationCorrectionCheckBox.Depth = 0;
            this.RotationCorrectionCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.RotationCorrectionCheckBox.Location = new System.Drawing.Point(12, 286);
            this.RotationCorrectionCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.RotationCorrectionCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RotationCorrectionCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.RotationCorrectionCheckBox.Name = "RotationCorrectionCheckBox";
            this.RotationCorrectionCheckBox.Ripple = true;
            this.RotationCorrectionCheckBox.Size = new System.Drawing.Size(115, 30);
            this.RotationCorrectionCheckBox.TabIndex = 23;
            this.RotationCorrectionCheckBox.Text = "Drehkorrektur";
            this.RotationCorrectionCheckBox.UseVisualStyleBackColor = false;
            // 
            // EdgeDetectionCheckBox
            // 
            this.EdgeDetectionCheckBox.AutoSize = true;
            this.EdgeDetectionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.EdgeDetectionCheckBox.Checked = true;
            this.EdgeDetectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EdgeDetectionCheckBox.Depth = 0;
            this.EdgeDetectionCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.EdgeDetectionCheckBox.Location = new System.Drawing.Point(12, 256);
            this.EdgeDetectionCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.EdgeDetectionCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.EdgeDetectionCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.EdgeDetectionCheckBox.Name = "EdgeDetectionCheckBox";
            this.EdgeDetectionCheckBox.Ripple = true;
            this.EdgeDetectionCheckBox.Size = new System.Drawing.Size(126, 30);
            this.EdgeDetectionCheckBox.TabIndex = 24;
            this.EdgeDetectionCheckBox.Text = "Randerkennung";
            this.EdgeDetectionCheckBox.UseVisualStyleBackColor = false;
            // 
            // CheckIfEmptyCheckBox
            // 
            this.CheckIfEmptyCheckBox.AutoSize = true;
            this.CheckIfEmptyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CheckIfEmptyCheckBox.Depth = 0;
            this.CheckIfEmptyCheckBox.Enabled = false;
            this.CheckIfEmptyCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckIfEmptyCheckBox.Location = new System.Drawing.Point(12, 316);
            this.CheckIfEmptyCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.CheckIfEmptyCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckIfEmptyCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckIfEmptyCheckBox.Name = "CheckIfEmptyCheckBox";
            this.CheckIfEmptyCheckBox.Ripple = true;
            this.CheckIfEmptyCheckBox.Size = new System.Drawing.Size(172, 30);
            this.CheckIfEmptyCheckBox.TabIndex = 25;
            this.CheckIfEmptyCheckBox.Text = "Leere Seiten ignorieren";
            this.CheckIfEmptyCheckBox.UseVisualStyleBackColor = false;
            // 
            // GreyCheckBox
            // 
            this.GreyCheckBox.AutoSize = true;
            this.GreyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.GreyCheckBox.Depth = 0;
            this.GreyCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.GreyCheckBox.Location = new System.Drawing.Point(12, 226);
            this.GreyCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.GreyCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.GreyCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.GreyCheckBox.Name = "GreyCheckBox";
            this.GreyCheckBox.Ripple = true;
            this.GreyCheckBox.Size = new System.Drawing.Size(59, 30);
            this.GreyCheckBox.TabIndex = 26;
            this.GreyCheckBox.Text = "Grau";
            this.GreyCheckBox.UseVisualStyleBackColor = false;
            // 
            // DoubleSidedCheckBox
            // 
            this.DoubleSidedCheckBox.AutoSize = true;
            this.DoubleSidedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DoubleSidedCheckBox.Depth = 0;
            this.DoubleSidedCheckBox.Enabled = false;
            this.DoubleSidedCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.DoubleSidedCheckBox.Location = new System.Drawing.Point(12, 196);
            this.DoubleSidedCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DoubleSidedCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DoubleSidedCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.DoubleSidedCheckBox.Name = "DoubleSidedCheckBox";
            this.DoubleSidedCheckBox.Ripple = true;
            this.DoubleSidedCheckBox.Size = new System.Drawing.Size(107, 30);
            this.DoubleSidedCheckBox.TabIndex = 27;
            this.DoubleSidedCheckBox.Text = "Doppelseitig";
            this.DoubleSidedCheckBox.UseVisualStyleBackColor = false;
            this.DoubleSidedCheckBox.CheckedChanged += new System.EventHandler(this.DoubleSidedCheckBox_CheckedChanged);
            // 
            // VendorToolCheckBox
            // 
            this.VendorToolCheckBox.AutoSize = true;
            this.VendorToolCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.VendorToolCheckBox.Depth = 0;
            this.VendorToolCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.VendorToolCheckBox.Location = new System.Drawing.Point(12, 346);
            this.VendorToolCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorToolCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.VendorToolCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.VendorToolCheckBox.Name = "VendorToolCheckBox";
            this.VendorToolCheckBox.Ripple = true;
            this.VendorToolCheckBox.Size = new System.Drawing.Size(215, 30);
            this.VendorToolCheckBox.TabIndex = 28;
            this.VendorToolCheckBox.Text = "Herstellerprogramm benutzen";
            this.VendorToolCheckBox.UseVisualStyleBackColor = false;
            // 
            // ScannerSelectionButton
            // 
            this.ScannerSelectionButton.Depth = 0;
            this.ScannerSelectionButton.Location = new System.Drawing.Point(12, 73);
            this.ScannerSelectionButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ScannerSelectionButton.Name = "ScannerSelectionButton";
            this.ScannerSelectionButton.Primary = true;
            this.ScannerSelectionButton.Size = new System.Drawing.Size(264, 23);
            this.ScannerSelectionButton.TabIndex = 30;
            this.ScannerSelectionButton.Text = "Scanner auswählen";
            this.ScannerSelectionButton.UseVisualStyleBackColor = true;
            this.ScannerSelectionButton.Click += new System.EventHandler(this.ScannerSelectionButton_Click);
            // 
            // ResetScanButton
            // 
            this.ResetScanButton.Depth = 0;
            this.ResetScanButton.Location = new System.Drawing.Point(12, 102);
            this.ResetScanButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ResetScanButton.Name = "ResetScanButton";
            this.ResetScanButton.Primary = true;
            this.ResetScanButton.Size = new System.Drawing.Size(264, 23);
            this.ResetScanButton.TabIndex = 31;
            this.ResetScanButton.Text = "Scans zurücksetzen";
            this.ResetScanButton.UseVisualStyleBackColor = true;
            this.ResetScanButton.Click += new System.EventHandler(this.ResetScanButton_Click);
            // 
            // AddScanButton
            // 
            this.AddScanButton.Depth = 0;
            this.AddScanButton.Location = new System.Drawing.Point(12, 131);
            this.AddScanButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddScanButton.Name = "AddScanButton";
            this.AddScanButton.Primary = true;
            this.AddScanButton.Size = new System.Drawing.Size(264, 32);
            this.AddScanButton.TabIndex = 32;
            this.AddScanButton.Text = "Scan hinzufügen";
            this.AddScanButton.UseVisualStyleBackColor = true;
            this.AddScanButton.Click += new System.EventHandler(this.AddScanButton_Click);
            // 
            // ScanAndSendFastButton
            // 
            this.ScanAndSendFastButton.Depth = 0;
            this.ScanAndSendFastButton.Location = new System.Drawing.Point(12, 379);
            this.ScanAndSendFastButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ScanAndSendFastButton.Name = "ScanAndSendFastButton";
            this.ScanAndSendFastButton.Primary = true;
            this.ScanAndSendFastButton.Size = new System.Drawing.Size(264, 32);
            this.ScanAndSendFastButton.TabIndex = 33;
            this.ScanAndSendFastButton.Text = "Schnell scannen und senden";
            this.ScanAndSendFastButton.UseVisualStyleBackColor = true;
            this.ScanAndSendFastButton.Click += new System.EventHandler(this.ScanAndSendFastButton_Click);
            // 
            // ScanAndSaveFastButton
            // 
            this.ScanAndSaveFastButton.Depth = 0;
            this.ScanAndSaveFastButton.Location = new System.Drawing.Point(12, 417);
            this.ScanAndSaveFastButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ScanAndSaveFastButton.Name = "ScanAndSaveFastButton";
            this.ScanAndSaveFastButton.Primary = true;
            this.ScanAndSaveFastButton.Size = new System.Drawing.Size(264, 23);
            this.ScanAndSaveFastButton.TabIndex = 34;
            this.ScanAndSaveFastButton.Text = "Schnell scannen und speichern";
            this.ScanAndSaveFastButton.UseVisualStyleBackColor = true;
            this.ScanAndSaveFastButton.Click += new System.EventHandler(this.ScanAndSaveFastButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Depth = 0;
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(12, 446);
            this.SendButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendButton.Name = "SendButton";
            this.SendButton.Primary = true;
            this.SendButton.Size = new System.Drawing.Size(264, 32);
            this.SendButton.TabIndex = 35;
            this.SendButton.Text = "Senden";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Depth = 0;
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(12, 484);
            this.SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Primary = true;
            this.SaveButton.Size = new System.Drawing.Size(264, 23);
            this.SaveButton.TabIndex = 36;
            this.SaveButton.Text = "Speichern";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MovePageForwardButton
            // 
            this.MovePageForwardButton.Depth = 0;
            this.MovePageForwardButton.Enabled = false;
            this.MovePageForwardButton.Location = new System.Drawing.Point(291, 73);
            this.MovePageForwardButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.MovePageForwardButton.Name = "MovePageForwardButton";
            this.MovePageForwardButton.Primary = true;
            this.MovePageForwardButton.Size = new System.Drawing.Size(104, 23);
            this.MovePageForwardButton.TabIndex = 37;
            this.MovePageForwardButton.Text = "Seite <--";
            this.MovePageForwardButton.UseVisualStyleBackColor = true;
            this.MovePageForwardButton.Click += new System.EventHandler(this.MovePageForwardButton_Click);
            // 
            // MovePageBackButton
            // 
            this.MovePageBackButton.Depth = 0;
            this.MovePageBackButton.Enabled = false;
            this.MovePageBackButton.Location = new System.Drawing.Point(401, 73);
            this.MovePageBackButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.MovePageBackButton.Name = "MovePageBackButton";
            this.MovePageBackButton.Primary = true;
            this.MovePageBackButton.Size = new System.Drawing.Size(104, 23);
            this.MovePageBackButton.TabIndex = 38;
            this.MovePageBackButton.Text = "Seite -->";
            this.MovePageBackButton.UseVisualStyleBackColor = true;
            this.MovePageBackButton.Click += new System.EventHandler(this.MovePageBackButton_Click);
            // 
            // RotateImageButton
            // 
            this.RotateImageButton.Depth = 0;
            this.RotateImageButton.Enabled = false;
            this.RotateImageButton.Location = new System.Drawing.Point(511, 73);
            this.RotateImageButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RotateImageButton.Name = "RotateImageButton";
            this.RotateImageButton.Primary = true;
            this.RotateImageButton.Size = new System.Drawing.Size(104, 23);
            this.RotateImageButton.TabIndex = 39;
            this.RotateImageButton.Text = "Bild drehen";
            this.RotateImageButton.UseVisualStyleBackColor = true;
            this.RotateImageButton.Click += new System.EventHandler(this.RotateImageButton_Click);
            // 
            // DeletePageButton
            // 
            this.DeletePageButton.Depth = 0;
            this.DeletePageButton.Enabled = false;
            this.DeletePageButton.Location = new System.Drawing.Point(621, 73);
            this.DeletePageButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeletePageButton.Name = "DeletePageButton";
            this.DeletePageButton.Primary = true;
            this.DeletePageButton.Size = new System.Drawing.Size(104, 23);
            this.DeletePageButton.TabIndex = 40;
            this.DeletePageButton.Text = "Bild löschen";
            this.DeletePageButton.UseVisualStyleBackColor = true;
            this.DeletePageButton.Click += new System.EventHandler(this.DeletePageButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(428, 564);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.ImageKey = "(Keine)";
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(428, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // AllPagesTabControl
            // 
            this.AllPagesTabControl.Controls.Add(this.tabPage1);
            this.AllPagesTabControl.Controls.Add(this.tabPage2);
            this.AllPagesTabControl.Controls.Add(this.tabPage3);
            this.AllPagesTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPagesTabControl.Location = new System.Drawing.Point(291, 102);
            this.AllPagesTabControl.Multiline = true;
            this.AllPagesTabControl.Name = "AllPagesTabControl";
            this.AllPagesTabControl.SelectedIndex = 0;
            this.AllPagesTabControl.Size = new System.Drawing.Size(436, 593);
            this.AllPagesTabControl.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Location = new System.Drawing.Point(8, 638);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(56, 19);
            this.StatusLabel.TabIndex = 41;
            this.StatusLabel.Text = "Status:";
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(12, 668);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(264, 23);
            this.StatusBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.StatusBar.TabIndex = 42;
            this.StatusBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(737, 707);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.DeletePageButton);
            this.Controls.Add(this.RotateImageButton);
            this.Controls.Add(this.MovePageBackButton);
            this.Controls.Add(this.MovePageForwardButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ScanAndSaveFastButton);
            this.Controls.Add(this.ScanAndSendFastButton);
            this.Controls.Add(this.AddScanButton);
            this.Controls.Add(this.ResetScanButton);
            this.Controls.Add(this.ScannerSelectionButton);
            this.Controls.Add(this.VendorToolCheckBox);
            this.Controls.Add(this.DoubleSidedCheckBox);
            this.Controls.Add(this.GreyCheckBox);
            this.Controls.Add(this.CheckIfEmptyCheckBox);
            this.Controls.Add(this.EdgeDetectionCheckBox);
            this.Controls.Add(this.RotationCorrectionCheckBox);
            this.Controls.Add(this.InsertionCheckBox);
            this.Controls.Add(this.AllPagesTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Scanner Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.AllPagesTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialCheckBox InsertionCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox RotationCorrectionCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox EdgeDetectionCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox CheckIfEmptyCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox GreyCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox DoubleSidedCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox VendorToolCheckBox;
        private MaterialSkin.Controls.MaterialRaisedButton ScannerSelectionButton;
        private MaterialSkin.Controls.MaterialRaisedButton ResetScanButton;
        private MaterialSkin.Controls.MaterialRaisedButton AddScanButton;
        private MaterialSkin.Controls.MaterialRaisedButton ScanAndSendFastButton;
        private MaterialSkin.Controls.MaterialRaisedButton ScanAndSaveFastButton;
        private MaterialSkin.Controls.MaterialRaisedButton SendButton;
        private MaterialSkin.Controls.MaterialRaisedButton SaveButton;
        private MaterialSkin.Controls.MaterialRaisedButton MovePageForwardButton;
        private MaterialSkin.Controls.MaterialRaisedButton MovePageBackButton;
        private MaterialSkin.Controls.MaterialRaisedButton RotateImageButton;
        private MaterialSkin.Controls.MaterialRaisedButton DeletePageButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl AllPagesTabControl;
        private MaterialSkin.Controls.MaterialLabel StatusLabel;
        private System.Windows.Forms.ProgressBar StatusBar;
    }
}

