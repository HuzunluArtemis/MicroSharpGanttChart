// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Windows.Forms;

namespace MicroSharpGanttChart
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
            DoLogin();
        }

        private static void DoLogin()
        {
            if (Settings.Default.PasswordLogin) Application.Run(new FormLogin());
            else Application.Run(new FormMain());
        }
    }
}
