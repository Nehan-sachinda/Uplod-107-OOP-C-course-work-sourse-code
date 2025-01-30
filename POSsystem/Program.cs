using System;
using System.Windows.Forms;

namespace POSsystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application with the SignUp form
            Application.Run(new Login());
        }
    }
}
