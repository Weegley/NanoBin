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
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chkHideOnRun = new System.Windows.Forms.CheckBox();
            this.chkshowNotifications = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSizeGb)).BeginInit();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(350, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Файлов: 0, размер: 0 МБ";
            // 
            // chkAutoClean
            // 
            this.chkAutoClean.Location = new System.Drawing.Point(20, 50);
            this.chkAutoClean.Name = "chkAutoClean";
            this.chkAutoClean.Size = new System.Drawing.Size(143, 23);
            this.chkAutoClean.TabIndex = 1;
            this.chkAutoClean.Text = "Автоочистка:";
            // 
            // chkNoConfirm
            // 
            this.chkNoConfirm.Location = new System.Drawing.Point(20, 79);
            this.chkNoConfirm.Name = "chkNoConfirm";
            this.chkNoConfirm.Size = new System.Drawing.Size(200, 20);
            this.chkNoConfirm.TabIndex = 2;
            this.chkNoConfirm.Text = "Без подтверждения";
            // 
            // chkNoProgress
            // 
            this.chkNoProgress.Location = new System.Drawing.Point(20, 105);
            this.chkNoProgress.Name = "chkNoProgress";
            this.chkNoProgress.Size = new System.Drawing.Size(200, 20);
            this.chkNoProgress.TabIndex = 3;
            this.chkNoProgress.Text = "Без окна прогресса";
            // 
            // chkNoSound
            // 
            this.chkNoSound.Location = new System.Drawing.Point(20, 131);
            this.chkNoSound.Name = "chkNoSound";
            this.chkNoSound.Size = new System.Drawing.Size(200, 20);
            this.chkNoSound.TabIndex = 4;
            this.chkNoSound.Text = "Без звука";
            // 
            // numMaxSizeGb
            // 
            this.numMaxSizeGb.DecimalPlaces = 1;
            this.numMaxSizeGb.Location = new System.Drawing.Point(169, 52);
            this.numMaxSizeGb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMaxSizeGb.Name = "numMaxSizeGb";
            this.numMaxSizeGb.Size = new System.Drawing.Size(71, 20);
            this.numMaxSizeGb.TabIndex = 5;
            this.numMaxSizeGb.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(20, 198);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 30);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(130, 198);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(100, 30);
            this.btnEmpty.TabIndex = 7;
            this.btnEmpty.Text = "Очистить";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnDrives
            // 
            this.btnDrives.Location = new System.Drawing.Point(240, 198);
            this.btnDrives.Name = "btnDrives";
            this.btnDrives.Size = new System.Drawing.Size(120, 30);
            this.btnDrives.TabIndex = 8;
            this.btnDrives.Text = "По дискам";
            this.btnDrives.Click += new System.EventHandler(this.btnDrives_Click);
            // 
            // lstLog
            // 
            this.lstLog.Location = new System.Drawing.Point(20, 238);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(340, 82);
            this.lstLog.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ГБ";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "NanoBin — монитор корзины";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmptyRecycleBin,
            this.menuExit});
            this.trayMenu.Name = "contextMenuStrip";
            this.trayMenu.Size = new System.Drawing.Size(175, 48);
            // 
            // menuEmptyRecycleBin
            // 
            this.menuEmptyRecycleBin.Name = "menuEmptyRecycleBin";
            this.menuEmptyRecycleBin.Size = new System.Drawing.Size(174, 22);
            this.menuEmptyRecycleBin.Text = "Очистить корзину";
            this.menuEmptyRecycleBin.Click += new System.EventHandler(this.menuEmptyRecycleBin_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(174, 22);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // chkHideOnRun
            // 
            this.chkHideOnRun.AutoSize = true;
            this.chkHideOnRun.Location = new System.Drawing.Point(20, 157);
            this.chkHideOnRun.Name = "chkHideOnRun";
            this.chkHideOnRun.Size = new System.Drawing.Size(138, 17);
            this.chkHideOnRun.TabIndex = 11;
            this.chkHideOnRun.Text = "Запускать свёрнутым";
            this.chkHideOnRun.UseVisualStyleBackColor = true;
            // 
            // chkshowNotifications
            // 
            this.chkshowNotifications.AutoSize = true;
            this.chkshowNotifications.Location = new System.Drawing.Point(20, 180);
            this.chkshowNotifications.Name = "chkshowNotifications";
            this.chkshowNotifications.Size = new System.Drawing.Size(159, 17);
            this.chkshowNotifications.TabIndex = 12;
            this.chkshowNotifications.Text = "Показывать уведомления";
            this.chkshowNotifications.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(374, 337);
            this.Controls.Add(this.chkshowNotifications);
            this.Controls.Add(this.chkHideOnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkAutoClean);
            this.Controls.Add(this.chkNoConfirm);
            this.Controls.Add(this.chkNoProgress);
            this.Controls.Add(this.chkNoSound);
            this.Controls.Add(this.numMaxSizeGb);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnDrives);
            this.Controls.Add(this.lstLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NanoBin — монитор корзины";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSizeGb)).EndInit();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.CheckBox chkshowNotifications;
    }
}
