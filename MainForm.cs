// RecycleBinMonitor.cs
using NanoBin.Properties;
using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace NanoBin
{
    public partial class MainForm : Form
    {
        private readonly ResourceManager resMan;

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct SHQUERYRBINFO
        {
            public int cbSize;
            public long i64Size;
            public long i64NumItems;
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        private static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        [Flags]
        public enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x00000004
        }
        public SHQUERYRBINFO info;
        private readonly Icon iconFull;
        private readonly Icon iconEmpty;
        public MainForm()
        {
            resMan = new ResourceManager("NanoBin.Strings", typeof(MainForm).Assembly);
            InitializeComponent();

            iconFull = (Icon)Properties.Resources.tray_full.Clone();   // Clone = независимая копия
            iconEmpty = (Icon)Properties.Resources.tray_empty.Clone();

            info = new SHQUERYRBINFO();

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            numMaxSizeGb.Minimum = 0.1M;
            numMaxSizeGb.Maximum = 100;
            numMaxSizeGb.DecimalPlaces = 1;
            numMaxSizeGb.Increment = 0.1M;
            
            EnsureAppConfigExists();
            LoadSettingsFromConfig();
            
            UpdateStatus();
            timer1.Start();
            
        }

        private void LoadSettingsFromConfig()
        {
            bool.TryParse(ConfigurationManager.AppSettings["AutoCleanEnabled"], out bool autoClean);
            double.TryParse(ConfigurationManager.AppSettings["MaxRecycleSizeGb"], out double maxSizeGb);
            bool.TryParse(ConfigurationManager.AppSettings["NoConfirm"], out bool noConfirm);
            bool.TryParse(ConfigurationManager.AppSettings["NoProgress"], out bool noProgress);
            bool.TryParse(ConfigurationManager.AppSettings["NoSound"], out bool noSound);
            bool.TryParse(ConfigurationManager.AppSettings["HideOnRun"], out bool HideOnRun);
            bool.TryParse(ConfigurationManager.AppSettings["ShowNotifications"], out bool showNotifications);

            chkAutoClean.Checked = autoClean;
            if (maxSizeGb > 0) {
                numMaxSizeGb.Value = ((decimal)maxSizeGb); } else { numMaxSizeGb.Value = 1; }

            chkshowNotifications.Checked = showNotifications;
            chkNoConfirm.Checked = noConfirm;
            chkNoProgress.Checked = noProgress;
            chkNoSound.Checked = noSound;
            chkHideOnRun.Checked = HideOnRun;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {


            AutoEmptyRecycleBin();
            UpdateStatus();
            UpdateTrayIcon();
        }



        private RecycleFlags GetFlagsFromCheckboxes()
        {
            RecycleFlags flags = 0;
            if (chkNoConfirm.Checked) flags |= RecycleFlags.SHERB_NOCONFIRMATION;
            if (chkNoProgress.Checked) flags |= RecycleFlags.SHERB_NOPROGRESSUI;
            if (chkNoSound.Checked) flags |= RecycleFlags.SHERB_NOSOUND;
            return flags;
        }

        private (int ItemCount, double SizeMB) GetRecycleBinInfo()
        {
            
            info.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));

            int hr = SHQueryRecycleBin(null, ref info);
            if (hr != 0)
                return (-1, -1);

            return ((int)info.i64NumItems, Math.Round(info.i64Size / 1024.0 / 1024.0, 2));
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            OpenRecycleBin();
        }

        private void BtnEmpty_Click(object sender, EventArgs e)
        {


                DoManualClean();
 
        }

        private void BtnDrives_Click(object sender, EventArgs e)
        {
            string[] drives = Environment.GetLogicalDrives();
            StringBuilder sb = new StringBuilder();

            foreach (var drive in drives)
            {
                //SHQUERYRBINFO info = new SHQUERYRBINFO();
                info.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));
                int hr = SHQueryRecycleBin(drive, ref info);
                if (hr == 0 && info.i64NumItems > 0)
                {
                    //sb.AppendLine($"{drive} — {info.i64NumItems} файлов, {Math.Round(info.i64Size / 1024.0 / 1024.0, 2)} МБ");
                    sb.AppendLine(string.Format(resMan.GetString("byDriveString"), drive, info.i64NumItems, Math.Round(info.i64Size / 1024.0 / 1024.0, 2)));
                }
            }

            MessageBox.Show(sb.Length > 0 ? sb.ToString() : resMan.GetString("strAllbinsAreEmpty"));
        }

        private void UpdateStatus()
        {
            var info = GetRecycleBinInfo();
            lblStatus.Text = string.Format(resMan.GetString("StatusLabel"), info.ItemCount, info.SizeMB);
        }


        private void SaveSettingsToConfig()
        {
            EnsureAppConfigExists();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["HideOnRun"].Value = chkHideOnRun.Checked.ToString().ToLower();
            config.AppSettings.Settings["AutoCleanEnabled"].Value = chkAutoClean.Checked.ToString().ToLower();
            config.AppSettings.Settings["MaxRecycleSizeGb"].Value = numMaxSizeGb.Value.ToString();
            config.AppSettings.Settings["NoConfirm"].Value = chkNoConfirm.Checked.ToString().ToLower();
            config.AppSettings.Settings["NoProgress"].Value = chkNoProgress.Checked.ToString().ToLower();
            config.AppSettings.Settings["NoSound"].Value = chkNoSound.Checked.ToString().ToLower();
            config.AppSettings.Settings["showNotifications"].Value=chkshowNotifications.Checked.ToString().ToLower();
           
            

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettingsToConfig();
           
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
 
            
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                UpdateTrayIcon(); // выбираем иконку в зависимости от содержимого корзины
            }
        
        }
        private void UpdateTrayIcon()
        {
            var info = GetRecycleBinInfo();


            notifyIcon.Text = string.Format(resMan.GetString("strNotifyIconText"), info.ItemCount, Environment.NewLine, info.SizeMB);

            try
            {
                notifyIcon.Icon = info.ItemCount == 0 ? iconEmpty : iconFull;
            }
            catch (Exception)
            {
                MessageBox.Show("Error setting icon!");
                // лог/игнор
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                notifyIcon.Visible = false;
            }
        }

        private void MenuEmptyRecycleBin_Click(object sender, EventArgs e)
        {
            DoManualClean();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = chkHideOnRun.Checked == true ? FormWindowState.Minimized : FormWindowState.Normal;

        }
        private void ShowBalloonTip(string message)
        {
            if (!chkshowNotifications.Checked) return;
            notifyIcon.BalloonTipTitle = "NanoBin";
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(3000); // показывать 3 секунды
        }
        private void EnsureAppConfigExists()
        {
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            if (!File.Exists(configPath))
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = config.AppSettings.Settings;

                if (settings["HideOnRun"] == null)
                    settings.Add("HideOnRun", "false");
                
                if (settings["AutoCleanEnabled"] == null)
                    settings.Add("AutoCleanEnabled", "true");

                if (settings["MaxRecycleSizeGb"] == null)
                    settings.Add("MaxRecycleSizeGb", "1.0");

                if (settings["NoConfirm"] == null)
                    settings.Add("NoConfirm", "true");

                if (settings["NoProgress"] == null)
                    settings.Add("NoProgress", "true");

                if (settings["NoSound"] == null)
                    settings.Add("NoSound", "true");

                if (settings["ShowNotifications"] == null)
                    settings.Add("ShowNotifications", "true");

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void OpneRecycleBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRecycleBin();
        }

        private void ChkAutoClean_ClientSizeChanged(object sender, EventArgs e)
        {
            numMaxSizeGb.Left = chkAutoClean.Left + chkAutoClean.Width + 6;
            label1.Left = numMaxSizeGb.Left + numMaxSizeGb.Width + 6;
        }

        private void DoManualClean()
        {
            var info = GetRecycleBinInfo();
            if (info.ItemCount > 0)
            {
                try
                {
                    var flags = GetFlagsFromCheckboxes();
                    uint result = SHEmptyRecycleBin(IntPtr.Zero, null, flags);
                    if (result != 0) { return; }
                    else
                    {
                        LogManualClean(info);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        private void LogManualClean((int ItemCount, double SizeMB) info) 
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            lstLog.Items.Insert(0, string.Format(resMan.GetString("logBinManuallyCleaned"), time, info.SizeMB.ToString("F2")));
            ShowBalloonTip(string.Format(resMan.GetString("baloonManuallyCleaned"), info.SizeMB.ToString("F2")));
        }

        private void AutoEmptyRecycleBin()
        {

            if (chkAutoClean.Checked)
            {

                (int ItemCount, double SizeMB) info = GetRecycleBinInfo();

                double maxGb = (double)numMaxSizeGb.Value;
                if (info.SizeMB / 1024.0 >= maxGb)
                {
                    try
                    {
                        RecycleFlags flags = GetFlagsFromCheckboxes();
                        uint result = SHEmptyRecycleBin(IntPtr.Zero, null, flags);
                        if (result != 0) { return; }
                        else
                        {
                            LogAutoClean(info.SizeMB);
                        }
                    }
                    catch(Exception) { return; }

                }
            }

        }
        private void LogAutoClean(double sizeBefore)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            lstLog.Items.Insert(0, string.Format(resMan.GetString("logBinAutoCleaned"), time, sizeBefore.ToString("F2")));
            var msg = string.Format(resMan.GetString("baloonAutoCleaned"), sizeBefore.ToString("F2"));
            ShowBalloonTip(msg);
        }

        private void OpenRecycleBin()
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "shell:RecycleBinFolder");
            }
            catch (Exception ex)
            {
                MessageBox.Show(resMan.GetString("msgCouldNotOpenBin") + " " + ex.Message);
            }
        }
    }
}
