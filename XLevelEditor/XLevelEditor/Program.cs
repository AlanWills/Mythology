using System;
using System.Windows.Forms;

namespace XLevelEditor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FormMain formMain = new FormMain())
            {
                Application.Run(formMain);
            }
        }
    }
#endif
}

