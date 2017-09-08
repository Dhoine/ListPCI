using System;
using System.Windows.Forms;

namespace ListPCI
{
    internal static class Program
    {
        /// <summary>
        ///     App's main entry point.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Pcilist());
        }
    }
}