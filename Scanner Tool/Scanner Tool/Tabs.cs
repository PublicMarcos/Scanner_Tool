using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scanner_Tool
{
    internal sealed class PageControl
    {
        internal PageControl(TabControl TabControl)
        {
            this.FormTabControl = TabControl;
            this.Tabs = new List<Tab>();
        }
        private List<Tab> Tabs { get; set; }
        private TabControl FormTabControl { get; set; }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        internal void AddTab(Image ScannedImage)
        {
            try
            {
                var CurFormTab = new TabPage(Tabs.Count.ToString());
                var CurTab = new Tab(Tabs.Count + 1, CurFormTab);
                Tabs.Add(CurTab);
                FormTabControl.Invoke(new Action(() =>
                {
                    FormTabControl.TabPages.Add(CurFormTab);
                    CurFormTab.BackgroundImageLayout = ImageLayout.Zoom;
                    CurFormTab.BackgroundImage = ScannedImage;
                    CurTab.ScannedImage = ScannedImage;
                    CurFormTab.Tag = CurTab;
                }));
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        internal bool ClearTabs()
        {
            Tabs.Clear();
            FormTabControl.TabPages.Clear();
            return true;
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        internal void ClearTab(int Index)
        {
            try
            {
                Tabs.RemoveAt(Index);
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private byte[] BildToByteArray(Image Bild)
        {
            try
            {
                using (var MS = new MemoryStream())
                {
                    Bild.Save(MS, ImageFormat.Jpeg);
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
        internal bool CreatePDF(string PDFPath, ProgressBar PBar)
        {
            try
            {
                if (Tabs.Count > 0)
                {
                    PBar.Invoke(new Action(() =>
                    {
                        PBar.Maximum = Tabs.Count;
                        PBar.Value = 0;
                        PBar.Visible = true;
                        PBar.Style = ProgressBarStyle.Marquee;
                    }));
                    if (File.Exists(PDFPath))
                    {
                        File.Delete(PDFPath);
                    }
                    var CurDocument = new iTextSharp.text.Document();
                    var CurPdfWriter = PdfWriter.GetInstance(CurDocument, new FileStream(PDFPath, FileMode.Create, FileAccess.Write, FileShare.None));
                    CurPdfWriter.SetFullCompression();
                    Tabs = Tabs.OrderBy(o => o.Index).ToList();
                    for (int i = 0; i < Tabs.Count; i++)
                    {
                        var CurImage = Tabs[i].ScannedImage;
                        var CurRectangle = new iTextSharp.text.Rectangle(CurImage.Width, CurImage.Height);
                        CurDocument.SetPageSize(CurRectangle);
                        CurDocument.SetMargins(0, 0, 0, 0);
                        if (i == 0)
                        {
                            CurDocument.Open();
                        }
                        if (i < (Tabs.Count - 1))
                        {
                            CurDocument.NewPage();
                        }
                        CurDocument.Add(iTextSharp.text.Image.GetInstance(CurImage, (iTextSharp.text.BaseColor)null));
                        PBar.Invoke(new Action(() =>
                        {
                            PBar.Style = ProgressBarStyle.Continuous;
                            PBar.Value++;
                        }));
                    }
                    CurDocument.Close();
                }
                else
                {
                    MessageBox.Show("Keine Scanns vorhanden");
                }
                GC.Collect();
                return true;
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
                return false;
            }
        }
    }

    internal sealed class Tab
    {
        internal Tab(int Index, TabPage FormTab)
        {
            this.Index = Index;
            this.FormTab = FormTab;
            this.FormTab.Text = "Seite " + Index.ToString();
        }
        internal TabPage FormTab { get; set; }
        internal int Index { get; set; }
        internal Image ScannedImage { get; set; }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        internal void RotateImage()
        {
            try
            {
                ScannedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                FormTab.BackgroundImage = (Image)ScannedImage.Clone();
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }
    }
}
