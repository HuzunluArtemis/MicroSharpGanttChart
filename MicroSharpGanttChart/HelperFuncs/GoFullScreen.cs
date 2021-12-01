// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSharpGanttChart
{
    internal class GoFullScreen
    {
        /*
         * A function to put a System.Windows.Forms.Form in fullscreen mode
         * Author: Danny Battison
         * Contact: gabehabe@googlemail.com
         */
        static internal System.Drawing.Point restoreLocation;
        static internal int restoreWidth;
        static internal int restoreHeight;
        static internal bool fullscreen = false;

        /// <summary>
        /// Makes the form either fullscreen, or restores it to it's original size/location
        /// </summary>

        internal static void FullScreen(System.Windows.Forms.Form form)
        {
            switch (fullscreen)
            {
                case false:
                    restoreLocation = form.Location;
                    restoreWidth = form.Width;
                    restoreHeight = form.Height;
                    //form.TopMost = true;
                    form.Location = new System.Drawing.Point(0, 0);
                    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    form.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    form.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    fullscreen = true;
                    break;
                case true:
                    //form.TopMost = false;
                    form.Location = restoreLocation;
                    form.Width = restoreWidth;
                    form.Height = restoreHeight;
                    // these are the two variables you may wish to change, depending
                    // on the design of your form (WindowState and FormBorderStyle)
                    form.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    fullscreen = false;
                    break;
            }
        }
    }

}
