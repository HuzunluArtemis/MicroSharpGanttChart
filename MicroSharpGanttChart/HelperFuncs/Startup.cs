using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace MicroSharpGanttChart
{
    internal static class Startup
    {
        private static string KeyLocation = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        internal static void AddToStartup(string AppName)
        {
            if (string.IsNullOrEmpty(AppName))
            {
                throw new ArgumentException($"'{nameof(AppName)}' cannot be null or empty.", nameof(AppName));
            }
            RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyLocation, true);
            key.SetValue(AppName, Application.ExecutablePath);
        }

        internal static void RemoveFromStartup(string AppName)
        {
            if (string.IsNullOrEmpty(AppName))
            {
                throw new ArgumentException($"'{nameof(AppName)}' cannot be null or empty.", nameof(AppName));
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyLocation, true);
            key.DeleteValue(AppName, false);
        }

        internal static string RegistryValueExists(string AppName)
        {

            if (string.IsNullOrEmpty(AppName))
            {
                throw new ArgumentException($"'{nameof(AppName)}' cannot be null or empty.", nameof(AppName));
            }

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyLocation, true);

                if (key == null)
                    return "null";
                else
                {
                    Object o = key.GetValue(AppName);
                    if (o == null)
                        return "false";
                    else
                    {
                        if (o.ToString() == Application.ExecutablePath)
                            return "true";
                        else
                            return "diff";
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "false";
            }
        }
    }
}