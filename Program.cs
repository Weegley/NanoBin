using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace NanoBin
{
    
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
            {
                ResourceManager resMan = new ResourceManager("NanoBin.Strings", typeof(MainForm).Assembly);
                MessageBox.Show(null, resMan.GetString("strAnotherInstanceRunning"), resMan.GetString("strERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                resMan.ReleaseAllResources();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
