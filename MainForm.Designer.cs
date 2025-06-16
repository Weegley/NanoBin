namespace NanoBin
{
    partial class MainForm
    {
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkAutoClean;
        private System.Windows.Forms.CheckBox chkNoConfirm;
        private System.Windows.Forms.CheckBox chkNoProgress;
        private System.Windows.Forms.CheckBox chkNoSound;
        private System.Windows.Forms.NumericUpDown numMaxSizeGb;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btnDrives;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lstLog;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem menuEmptyRecycleBin;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.CheckBox chkHideOnRun;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkAutoClean = new System.Windows.Forms.CheckBox();
            this.chkNoConfirm = new System.Windows.Forms.CheckBox();
            this.chkNoProgress = new System.Windows.Forms.CheckBox();
            this.chkNoSound = new System.Windows.Forms.CheckBox();
            this.numMaxSizeGb = new System.Windows.Forms.NumericUpDown();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnDrives = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEmptyRecycleBin = new System.Windows.Forms.ToolStripMenuItem();
            this.opneRecycleBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chkHideOnRun = new System.Windows.Forms.CheckBox();
            this.chkshowNotifications = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSizeGb)).BeginInit();
            this.trayMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // chkAutoClean
            // 
            resources.ApplyResources(this.chkAutoClean, "chkAutoClean");
            this.chkAutoClean.Name = "chkAutoClean";
            this.chkAutoClean.ClientSizeChanged += new System.EventHandler(this.chkAutoClean_ClientSizeChanged);
            // 
            // chkNoConfirm
            // 
            resources.ApplyResources(this.chkNoConfirm, "chkNoConfirm");
            this.chkNoConfirm.Name = "chkNoConfirm";
            this.chkNoConfirm.CheckedChanged += new System.EventHandler(this.chkNoConfirm_CheckedChanged);
            // 
            // chkNoProgress
            // 
            resources.ApplyResources(this.chkNoProgress, "chkNoProgress");
            this.chkNoProgress.Name = "chkNoProgress";
            // 
            // chkNoSound
            // 
            resources.ApplyResources(this.chkNoSound, "chkNoSound");
            this.chkNoSound.Name = "chkNoSound";
            // 
            // numMaxSizeGb
            // 
            this.numMaxSizeGb.DecimalPlaces = 1;
            resources.ApplyResources(this.numMaxSizeGb, "numMaxSizeGb");
            this.numMaxSizeGb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMaxSizeGb.Name = "numMaxSizeGb";
            this.numMaxSizeGb.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEmpty
            // 
            resources.ApplyResources(this.btnEmpty, "btnEmpty");
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnDrives
            // 
            resources.ApplyResources(this.btnDrives, "btnDrives");
            this.btnDrives.Name = "btnDrives";
            this.btnDrives.Click += new System.EventHandler(this.btnDrives_Click);
            // 
            // lstLog
            // 
            resources.ApplyResources(this.lstLog, "lstLog");
            this.lstLog.Name = "lstLog";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmptyRecycleBin,
            this.opneRecycleBinToolStripMenuItem,
            this.menuExit});
            this.trayMenu.Name = "contextMenuStrip";
            resources.ApplyResources(this.trayMenu, "trayMenu");
            // 
            // menuEmptyRecycleBin
            // 
            this.menuEmptyRecycleBin.Name = "menuEmptyRecycleBin";
            resources.ApplyResources(this.menuEmptyRecycleBin, "menuEmptyRecycleBin");
            this.menuEmptyRecycleBin.Click += new System.EventHandler(this.menuEmptyRecycleBin_Click);
            // 
            // opneRecycleBinToolStripMenuItem
            // 
            this.opneRecycleBinToolStripMenuItem.Name = "opneRecycleBinToolStripMenuItem";
            resources.ApplyResources(this.opneRecycleBinToolStripMenuItem, "opneRecycleBinToolStripMenuItem");
            this.opneRecycleBinToolStripMenuItem.Click += new System.EventHandler(this.opneRecycleBinToolStripMenuItem_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // chkHideOnRun
            // 
            resources.ApplyResources(this.chkHideOnRun, "chkHideOnRun");
            this.chkHideOnRun.Name = "chkHideOnRun";
            this.chkHideOnRun.UseVisualStyleBackColor = true;
            // 
            // chkshowNotifications
            // 
            resources.ApplyResources(this.chkshowNotifications, "chkshowNotifications");
            this.chkshowNotifications.Name = "chkshowNotifications";
            this.chkshowNotifications.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnEmpty);
            this.groupBox1.Controls.Add(this.btnDrives);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.numMaxSizeGb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkshowNotifications);
            this.Controls.Add(this.chkHideOnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkAutoClean);
            this.Controls.Add(this.chkNoConfirm);
            this.Controls.Add(this.chkNoProgress);
            this.Controls.Add(this.chkNoSound);
            this.Controls.Add(this.lstLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSizeGb)).EndInit();
            this.trayMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.CheckBox chkshowNotifications;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem opneRecycleBinToolStripMenuItem;
    }
}
