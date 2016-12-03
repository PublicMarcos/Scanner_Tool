using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.WinFroms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Scanner_Tool
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme((Primary)39041, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)39041, TextShade.WHITE);
        }

        private PageControl CurPageControl { get; set; }
        private Outlook.Application olook { get; set; }
        internal Twain TwainLib { get; set; }
        private ScanSettings ScanSettings { get; set; }
        private Settings ProgramSettings { get; set; }
        private bool ScanFinished { get; set; }
        private int ScannedPageCount { get; set; }
        private MaterialRaisedButton[] AllButtons { get; set; }
        private MaterialCheckBox[] AllCheckBoxes { get; set; }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                AllPagesTabControl.TabPages.Clear();
                CurPageControl = new PageControl(AllPagesTabControl);
                ProgramSettings = new Settings();
                ProgramSettings.Load();
                InsertionCheckBox.Checked = ProgramSettings.UseInsertion;
                DoubleSidedCheckBox.Checked = ProgramSettings.UseDoubleSided;
                GreyCheckBox.Checked = ProgramSettings.UseGrey;
                CheckIfEmptyCheckBox.Checked = ProgramSettings.CheckIfEmpty;
                EdgeDetectionCheckBox.Checked = ProgramSettings.UseEdgeDetection;
                RotationCorrectionCheckBox.Checked = ProgramSettings.UseRotationCorrection;
                VendorToolCheckBox.Checked = ProgramSettings.UseVendorTool;
                this.Size = new Size(ProgramSettings.SizeX, ProgramSettings.SizeY);
                Form1_ResizeEnd(null, null);
                this.Text = "Scanner Tool  (v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
                AllButtons = new MaterialRaisedButton[] { ScannerSelectionButton, ResetScanButton, AddScanButton, ScanAndSendFastButton, ScanAndSaveFastButton, SendButton, SaveButton, MovePageForwardButton, MovePageBackButton, RotateImageButton, DeletePageButton };
                AllCheckBoxes = new MaterialCheckBox[] { InsertionCheckBox, DoubleSidedCheckBox, GreyCheckBox, EdgeDetectionCheckBox, RotationCorrectionCheckBox, CheckIfEmptyCheckBox, VendorToolCheckBox };
                try
                {
                    olook = new Outlook.Application();
                }
                catch
                {
                    MessageBox.Show("Ihr Outlook wurde nicht ordnungsgemäß installiert.");
                    Environment.Exit(1075);
                }
                ResetTwain(0);
                if (!string.IsNullOrEmpty(ProgramSettings.ScannerProductName))
                {
                    TwainLib.SelectSource(ProgramSettings.ScannerProductName);
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DisableAllButtons(bool activate)
        {
            for (int i = 0; i < AllButtons.Length; i++)
            {
                if (AllButtons[i].InvokeRequired)
                {
                    AllButtons[i].Invoke(new Action(() =>
                    {
                        AllButtons[i].Enabled = activate;
                    }));
                }
                else
                {
                    AllButtons[i].Enabled = activate;
                }
            }
            for (int i = 0; i < AllCheckBoxes.Length; i++)
            {
                if (AllCheckBoxes[i].InvokeRequired)
                {
                    AllCheckBoxes[i].Invoke(new Action(() =>
                    {
                        if (!activate)
                        {
                            AllCheckBoxes[i].Tag = AllCheckBoxes[i].Enabled;
                            AllCheckBoxes[i].Enabled = false;
                        }
                        else if ((bool)AllCheckBoxes[i].Tag)
                        {
                            AllCheckBoxes[i].Enabled = true;
                        }
                    }));
                }
                else
                {
                    if (!activate)
                    {
                        AllCheckBoxes[i].Tag = AllCheckBoxes[i].Enabled;
                        AllCheckBoxes[i].Enabled = false;
                    }
                    else if ((bool)AllCheckBoxes[i].Tag)
                    {
                        AllCheckBoxes[i].Enabled = true;
                    }
                }
            }
            if (activate)
            {
                if (StatusBar.InvokeRequired)
                {
                    StatusBar.Invoke(new Action(() =>
                    {
                        StatusBar.Visible = false;
                    }));
                }
                else
                {
                    StatusBar.Visible = false;
                }
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool ResetTwain(int Modus)
        {
            try
            {
                TwainLib = new Twain(new WinFormsWindowMessageHook(this));
                TwainLib.TransferImage += delegate (Object sender2, TransferImageEventArgs args)
                {
                    new Thread(delegate ()
                    {
                        if (!ReferenceEquals(args.Image, null))
                        {
                            ScannedPageCount++;
                            if (!CheckIfEmptyCheckBox.Checked || !IsImageEmpty(args.Image))
                            {
                                using (var imageFactory = new ImageFactory(preserveExifData: true))
                                {
                                    var ImageByteArray = ImageToByteArray(args.Image);
                                    Image ScannedImage;
                                    using (var CurImageStream = new MemoryStream())
                                    {
                                        imageFactory.Load(ImageByteArray).BitDepth(32).Format(new JpegFormat { Quality = 100 }).Save(CurImageStream);
                                        ScannedImage = Image.FromStream(CurImageStream);
                                    }
                                    CurPageControl.AddTab(ScannedImage);
                                }
                            }
                            if (ScanFinished)
                            {
                                switch (Modus)
                                {
                                    case 0:
                                        DisableAllButtons(true);
                                        EnableButtons();
                                        ChageStatusText("Status:");
                                        break;
                                    case 1:
                                        if (AllPagesTabControl.TabCount > 0)
                                        {
                                            ChageStatusText("Status: PDF wird erstellt");
                                            var TempPath = GetRandomTempFilePath();
                                            new Thread(delegate ()
                                            {
                                                CurPageControl.CreatePDF(TempPath, StatusBar);
                                                ChageStatusText("Status:");
                                                SavePDFDialog(TempPath);
                                                DisableAllButtons(true);
                                                EnableButtons();
                                            }).Start();
                                        }
                                        break;
                                    case 2:
                                        if (AllPagesTabControl.TabCount > 0)
                                        {
                                            ChageStatusText("Status: PDF wird erstellt");
                                            var TempPath = GetRandomTempFilePath();
                                            new Thread(delegate ()
                                            {
                                                CurPageControl.CreatePDF(TempPath, StatusBar);
                                                ChageStatusText("Status: Email wurde geöffnet");
                                                OpenEmail(TempPath);
                                                DisableAllButtons(true);
                                                EnableButtons();
                                            }).Start();
                                        }
                                        break;
                                }
                            }
                            GC.Collect();
                        }
                    }).Start();
                };
                TwainLib.ScanningComplete += delegate
                {
                    ScanFinished = true;
                    if (ScannedPageCount == 0)
                    {
                        ChageStatusText("Status:");
                        DisableAllButtons(true);
                        EnableButtons();
                    }
                };
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLowerInvariant().Contains("default source".ToLowerInvariant()))
                {
                    MessageBox.Show("Sie müssen zuerst ein Scanner durch die Treiber einrichten.");
                }
                else
                {
                    Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                }
                Environment.Exit(1);
                return false;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool IsImageEmpty(Image CurRAWImage)
        {
            var Colors = new Dictionary<int, int>();
            var CurColor = 0;
            using (var CurImage = new Bitmap(CurRAWImage))
            {
                for (int i = 0; i < CurImage.Width; i += 2)
                {
                    for (int i2 = 0; i2 < CurImage.Height; i2 += 2)
                    {
                        CurColor = CurImage.GetPixel(i, i2).ToArgb();
                        if (!Colors.ContainsKey(CurColor))
                        {
                            Colors.Add(CurColor, 1);
                        }
                        else
                        {
                            Colors[CurColor]++;
                        }
                    }
                }
                var AverageColor = Colors.OrderBy(i => i.Value).Last().Key;
                var MostCummonColor = AverageColor;
                if (MostCummonColor < 0)
                {
                    MostCummonColor *= -1;
                }
                var ColorPixelCount = 0;
                foreach (var CurItem in Colors)
                {
                    if ((CurItem.Key != AverageColor))
                    {
                        var CurColorItem = Convert.ToDouble(CurItem.Key);
                        if (CurColorItem < 0)
                        {
                            CurColorItem *= -1;
                        }
                        if (MostCummonColor > CurColorItem)
                        {
                            if ((((MostCummonColor - CurColorItem) / MostCummonColor) * 100) > 30)
                            {
                                System.Threading.Interlocked.Add(ref ColorPixelCount, CurItem.Value);
                            }
                        }
                        else
                        {
                            if ((((CurColorItem - MostCummonColor) / CurColorItem) * 100) > 30)
                            {
                                System.Threading.Interlocked.Add(ref ColorPixelCount, CurItem.Value);
                            }
                        }

                    }
                }
                if (((Convert.ToDouble(ColorPixelCount) / Colors.OrderBy(i => i.Value).Last().Value) * 100) > 0.5)
                {
                    Colors = null;
                    return false;
                }
            }
            Colors = null;
            return true;
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private byte[] ImageToByteArray(Image Bild)
        {
            try
            {
                using (var MS = new MemoryStream())
                {
                    Bild.Save(MS, System.Drawing.Imaging.ImageFormat.Bmp);
                    MS.Flush();
                    return MS.ToArray();
                }
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
                return null;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void InsertionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DoubleSidedCheckBox.Enabled = InsertionCheckBox.Checked;
            if (!InsertionCheckBox.Checked)
            {
                DoubleSidedCheckBox.Checked = false;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DoubleSidedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIfEmptyCheckBox.Enabled = DoubleSidedCheckBox.Checked;
            if (!DoubleSidedCheckBox.Checked)
            {
                CheckIfEmptyCheckBox.Checked = false;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool StartScan()
        {
            try
            {
                ScanFinished = false;
                DisableAllButtons(false);
                ScannedPageCount = 0;
                ChageStatusText("Status: Es wird gescannt");
                ScanSettings = new ScanSettings();
                ScanSettings.UseDocumentFeeder = InsertionCheckBox.Checked;
                ScanSettings.AbortWhenNoPaperDetectable = false;
                ScanSettings.UseAutoFeeder = InsertionCheckBox.Checked;
                ScanSettings.ShowTwainUI = VendorToolCheckBox.Checked;
                ScanSettings.ShowProgressIndicatorUI = true;
                ScanSettings.Area = null;
                ScanSettings.ShouldTransferAllPages = true;
                ScanSettings.UseDuplex = DoubleSidedCheckBox.Checked;
                var QualitySettings = new ResolutionSettings();
                QualitySettings.Dpi = 200;
                if (GreyCheckBox.Checked)
                {
                    QualitySettings.ColourSetting = ColourSetting.GreyScale;
                }
                else
                {
                    QualitySettings.ColourSetting = ColourSetting.Colour;
                }
                ScanSettings.Resolution = QualitySettings;
                ScanSettings.Rotation = new RotationSettings()
                {
                    AutomaticRotate = RotationCorrectionCheckBox.Checked,
                    AutomaticBorderDetection = EdgeDetectionCheckBox.Checked
                };
                try
                {
                    TwainLib.StartScanning(ScanSettings);
                }
                catch (TwainException ex)
                {
                    MessageBox.Show(ex.Message);
                    DisableAllButtons(true);
                    EnableButtons();
                    this.Focus();
                    ChageStatusText("Status:");
                }
                return true;
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
                return false;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void OpenEmail(string AttachmentPath)
        {
            try
            {
                Outlook.MailItem CurMail = (Outlook.MailItem)olook.CreateItem(Outlook.OlItemType.olMailItem);
                CurMail.Subject = string.Empty;
                if (!Program.KeinNetzwerk)
                {
                    CurMail.To = "...@....de";//Hier die Standard Empfängeradresse eintragen
                }
                CurMail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                CurMail.HTMLBody = "<html style='font-family: Arial;'></html>";
                CurMail.Importance = Outlook.OlImportance.olImportanceNormal;
                CurMail.Attachments.Add(AttachmentPath, Outlook.OlAttachmentType.olByValue);
                CurMail.Display(false);
                GC.Collect();
            }
            catch
            {
                MessageBox.Show("Sie müssen zuerst Outlook im Hintergrund am laufen haben, um die Email versenden zu können.");
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SavePDFDialog(string PDFPath)
        {
            try
            {
                var savePDFDialog = new SaveFileDialog();
                savePDFDialog.CheckPathExists = true;
                savePDFDialog.CheckFileExists = false;
                savePDFDialog.OverwritePrompt = true;
                savePDFDialog.ValidateNames = true;
                savePDFDialog.Title = "PDF Datei speichern:";
                savePDFDialog.Filter = "PDF Datei|*.pdf";
                savePDFDialog.FileName = Path.GetFileNameWithoutExtension(PDFPath);
                savePDFDialog.InitialDirectory = ProgramSettings.SavePath;
                this.Invoke(new Action(() =>
                {
                    if (savePDFDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        if (File.Exists(savePDFDialog.FileName))
                        {
                            File.Delete(savePDFDialog.FileName);
                        }
                        File.Copy(PDFPath, savePDFDialog.FileName);
                        ProgramSettings.SavePath = Path.GetDirectoryName(savePDFDialog.FileName);
                        ChageStatusText("Status: PDF wurde gespeichert");
                    }
                }));
                GC.Collect();
            }
            catch
            {
                Program.MeldeFehler("Datei konnte nicht gespeichert werden.");
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DeletePageButton_Click(object sender, EventArgs e)
        {
            try
            {
                var CurIndex = AllPagesTabControl.SelectedIndex;
                CurPageControl.ClearTab(CurIndex);
                AllPagesTabControl.TabPages.RemoveAt(CurIndex);
                for (int i = 0; i < AllPagesTabControl.TabPages.Count; i++)
                {
                    AllPagesTabControl.TabPages[i].Text = "Seite " + (i + 1).ToString();
                }
                EnableButtons();
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void EnableButtons()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    switch (AllPagesTabControl.TabCount)
                    {
                        case 0:
                            RotateImageButton.Enabled = false;
                            DeletePageButton.Enabled = false;
                            MovePageForwardButton.Enabled = false;
                            MovePageBackButton.Enabled = false;
                            SendButton.Enabled = false;
                            SaveButton.Enabled = false;
                            break;
                        case 1:
                            RotateImageButton.Enabled = true;
                            DeletePageButton.Enabled = true;
                            MovePageForwardButton.Enabled = false;
                            MovePageBackButton.Enabled = false;
                            SendButton.Enabled = true;
                            SaveButton.Enabled = true;
                            break;
                        default:
                            RotateImageButton.Enabled = true;
                            DeletePageButton.Enabled = true;
                            MovePageForwardButton.Enabled = true;
                            MovePageBackButton.Enabled = true;
                            SendButton.Enabled = true;
                            SaveButton.Enabled = true;
                            break;
                    }
                }));
            }
            else
            {
                switch (AllPagesTabControl.TabCount)
                {
                    case 0:
                        RotateImageButton.Enabled = false;
                        DeletePageButton.Enabled = false;
                        MovePageForwardButton.Enabled = false;
                        MovePageBackButton.Enabled = false;
                        SendButton.Enabled = false;
                        SaveButton.Enabled = false;
                        break;
                    case 1:
                        RotateImageButton.Enabled = true;
                        DeletePageButton.Enabled = true;
                        MovePageForwardButton.Enabled = false;
                        MovePageBackButton.Enabled = false;
                        SendButton.Enabled = true;
                        SaveButton.Enabled = true;
                        break;
                    default:
                        RotateImageButton.Enabled = true;
                        DeletePageButton.Enabled = true;
                        MovePageForwardButton.Enabled = true;
                        MovePageBackButton.Enabled = true;
                        SendButton.Enabled = true;
                        SaveButton.Enabled = true;
                        break;
                }
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ChageStatusText(string Text)
        {
            if (StatusLabel.InvokeRequired)
            {
                StatusLabel.Invoke(new Action(() =>
                {
                    StatusLabel.Text = Text;
                }));
            }
            else
            {
                StatusLabel.Text = Text;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string RandomText(int Länge)
        {
            var CurRandom = new Random();
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", Länge).Select(s => s[CurRandom.Next(s.Length)]).ToArray());
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetRandomTempFilePath()
        {
            try
            {
                var TempPath = Path.GetTempPath() + @"Scanner Tool\Gescanntes Dokument vom " + DateTime.Now.ToString("dd-MM-yyyy H.mm") + "Uhr ID_" + RandomText(10) + ".pdf";
                if (!Directory.Exists(Path.GetDirectoryName(TempPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(TempPath));
                }
                else if (File.Exists(TempPath))
                {
                    {
                        File.Delete(TempPath);
                    }
                }
                return TempPath;
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
                return null;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool SaveSettings()
        {
            ProgramSettings.ScannerProductName = TwainLib.GetSelectedSource();
            ProgramSettings.UseInsertion = InsertionCheckBox.Checked;
            ProgramSettings.UseDoubleSided = DoubleSidedCheckBox.Checked;
            ProgramSettings.UseGrey = GreyCheckBox.Checked;
            ProgramSettings.CheckIfEmpty = CheckIfEmptyCheckBox.Checked;
            ProgramSettings.UseEdgeDetection = EdgeDetectionCheckBox.Checked;
            ProgramSettings.UseRotationCorrection = RotationCorrectionCheckBox.Checked;
            ProgramSettings.UseVendorTool = VendorToolCheckBox.Checked;
            ProgramSettings.Save();
            return true;
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void RotateImageButton_Click(object sender, EventArgs e)
        {
            ((Tab)AllPagesTabControl.SelectedTab.Tag).RotateImage();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ScannerSelectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                TwainLib.SelectSource();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler("Bei diesen Fehler hilft es oft die Konfigurationsdatei(Settings.cfg) zu löschen:\n\n" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\n" + ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ResetScanButton_Click(object sender, EventArgs e)
        {
            CurPageControl.ClearTabs();
            EnableButtons();
            GC.Collect();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void AddScanButton_Click(object sender, EventArgs e)
        {
            ResetTwain(0);
            StartScan();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons(false);
            ChageStatusText("Status: PDF wird erstellt");
            var TempPath = GetRandomTempFilePath();
            new Thread(delegate ()
            {
                CurPageControl.CreatePDF(TempPath, StatusBar);
                ChageStatusText("Status:");
                SavePDFDialog(TempPath);
                DisableAllButtons(true);
            }).Start();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ScanAndSaveFastButton_Click(object sender, EventArgs e)
        {
            ResetScanButton_Click(null, null);
            ResetTwain(1);
            StartScan();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SendButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons(false);
            ChageStatusText("Status: PDF wird erstellt");
            var TempPath = GetRandomTempFilePath();
            new Thread(delegate ()
            {
                CurPageControl.CreatePDF(TempPath, StatusBar);
                ChageStatusText("Status: Email wurde geöffnet");
                OpenEmail(TempPath);
                DisableAllButtons(true);
            }).Start();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ScanAndSendFastButton_Click(object sender, EventArgs e)
        {
            ResetScanButton_Click(null, null);
            ResetTwain(2);
            StartScan();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MovePageForwardButton_Click(object sender, EventArgs e)
        {
            try
            {
                var CurIndex = AllPagesTabControl.SelectedIndex;
                var CurTab = AllPagesTabControl.SelectedTab;
                if (CurIndex > 0)
                {
                    var OldIndex = CurIndex - 1;
                    var OldTab = AllPagesTabControl.TabPages[CurIndex - 1];
                    OldTab.Text = "Seite " + (CurIndex + 1).ToString();
                    CurTab.Text = "Seite " + (OldIndex + 1).ToString();
                    AllPagesTabControl.TabPages.Remove(OldTab);
                    AllPagesTabControl.TabPages.Insert(CurIndex, OldTab);
                    ((Tab)CurTab.Tag).Index = OldIndex;
                    ((Tab)OldTab.Tag).Index = CurIndex;
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MovePageBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var CurIndex = AllPagesTabControl.SelectedIndex;
                var CurTab = AllPagesTabControl.SelectedTab;
                if (CurIndex < (AllPagesTabControl.TabPages.Count - 1))
                {
                    var OldIndex = CurIndex + 1;
                    var OldTab = AllPagesTabControl.TabPages[CurIndex + 1];
                    OldTab.Text = "Seite " + (CurIndex + 1).ToString();
                    CurTab.Text = "Seite " + (OldIndex + 1).ToString();
                    AllPagesTabControl.TabPages.Remove(OldTab);
                    AllPagesTabControl.TabPages.Insert(CurIndex, OldTab);
                    ((Tab)CurTab.Tag).Index = OldIndex;
                    ((Tab)OldTab.Tag).Index = CurIndex;
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if ((this.Size.Width < 737) || (this.Size.Height < 707))
            {
                this.Size = new Size(737, 707);
            }
            ProgramSettings.SizeX = this.Size.Width;
            ProgramSettings.SizeY = this.Size.Height;
            AllPagesTabControl.Size = new Size(this.Size.Width - AllPagesTabControl.Location.X - 5, this.Size.Height - AllPagesTabControl.Location.Y - 5);
            StatusBar.Location = new Point(StatusBar.Location.X, this.Height - StatusBar.Size.Height - 16);

            StatusLabel.Location = new Point(StatusLabel.Location.X, StatusBar.Location.Y - StatusLabel.Size.Height - 11);
        }
    }
}
