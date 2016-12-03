using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scanner_Tool
{
    internal sealed class Settings
    {
        internal Settings()
        {
            this.ScannerProductName = string.Empty;
            this.UseInsertion = true;
            this.UseDoubleSided = false;
            this.UseGrey = true;
            this.CheckIfEmpty = false;
            this.UseEdgeDetection = true;
            this.UseRotationCorrection = true;
            this.UseVendorTool = false;
            this.SizeX = 737;
            this.SizeY = 707;
            this.SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            AppDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        internal string ScannerProductName { get; set; }
        internal bool UseInsertion { get; set; }
        internal bool UseDoubleSided { get; set; }
        internal bool UseGrey { get; set; }
        internal bool CheckIfEmpty { get; set; }
        internal bool UseEdgeDetection { get; set; }
        internal bool UseRotationCorrection { get; set; }
        internal bool UseVendorTool { get; set; }
        internal string SavePath { get; set; }
        internal int SizeX { get; set; }
        internal int SizeY { get; set; }
        private string AppDataRoamingPath { get; set; }

        internal bool Load()
        {
            try
            {
                var test = Path.Combine(AppDataRoamingPath, "Scanner Tool");
                if (Directory.Exists(Path.Combine(AppDataRoamingPath, "Scanner Tool")))
                {
                    if (File.Exists(Path.Combine(AppDataRoamingPath, "Scanner Tool", "Settings.cfg")))
                    {
                        bool BoolDummy;
                        var ConfigFileLines = File.ReadAllLines(Path.Combine(AppDataRoamingPath, "Scanner Tool", "Settings.cfg"), Encoding.UTF8);
                        for (int i = 0; i < ConfigFileLines.Length; i++)
                        {
                            if (ConfigFileLines[i].Contains("="))
                            {
                                if (ConfigFileLines[i].StartsWith("ScannerProductName", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ScannerProductName = ConfigFileLines[i].Split('=')[1];
                                }
                                else if (ConfigFileLines[i].StartsWith("UseInsertion", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseInsertion = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("UseDoubleSided", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseDoubleSided = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("UseGrey", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseGrey = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("CheckIfEmpty", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        CheckIfEmpty = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("UseEdgeDetection", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseEdgeDetection = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("UseRotationCorrection", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseRotationCorrection = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("UseVendorTool", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (bool.TryParse(ConfigFileLines[i].Split('=')[1], out BoolDummy))
                                    {
                                        UseVendorTool = BoolDummy;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("SizeX", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    var CurSizeX = SizeX;
                                    if (int.TryParse(ConfigFileLines[i].Split('=')[1], out CurSizeX))
                                    {
                                        SizeX = CurSizeX;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("SizeY", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    var CurSizeY = SizeY;
                                    if (int.TryParse(ConfigFileLines[i].Split('=')[1], out CurSizeY))
                                    {
                                        SizeY = CurSizeY;
                                    }
                                }
                                else if (ConfigFileLines[i].StartsWith("SavePath", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    SavePath = ConfigFileLines[i].Split('=')[1];
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.MeldeFehler(ex.Message + "\n" + ex.StackTrace);
                Environment.Exit(1);
                return false;
            }
            return false;
        }
        internal bool Save()
        {
            try
            {
                if (!Directory.Exists(Path.Combine(AppDataRoamingPath, "Scanner Tool")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDataRoamingPath, "Scanner Tool"));
                }
                else if (File.Exists(Path.Combine(AppDataRoamingPath, "Scanner Tool", "Settings.cfg")))
                {
                    File.Delete(Path.Combine(AppDataRoamingPath, "Scanner Tool", "Settings.cfg"));
                }
                var CurSB = new StringBuilder();
                CurSB.AppendLine("ScannerProductName=" + ScannerProductName);
                CurSB.AppendLine("UseInsertion=" + UseInsertion.ToString());
                CurSB.AppendLine("UseDoubleSided=" + UseDoubleSided.ToString());
                CurSB.AppendLine("UseGrey=" + UseGrey.ToString());
                CurSB.AppendLine("CheckIfEmpty=" + CheckIfEmpty.ToString());
                CurSB.AppendLine("UseEdgeDetection=" + UseEdgeDetection.ToString());
                CurSB.AppendLine("UseRotationCorrection=" + UseRotationCorrection.ToString());
                CurSB.AppendLine("UseVendorTool=" + UseVendorTool.ToString());
                CurSB.AppendLine("SizeX=" + SizeX.ToString());
                CurSB.AppendLine("SizeY=" + SizeY.ToString());
                CurSB.AppendLine("SavePath=" + SavePath);
                File.WriteAllText(Path.Combine(AppDataRoamingPath, "Scanner Tool", "Settings.cfg"), CurSB.ToString());
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
}
