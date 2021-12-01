// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicroSharpGanttChart
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        

        #region move methods

        private bool mouseDown;
        private Point lastLocation;

        internal static bool IsMiddleClick(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    return true;
                default:
                    return false;
            }
        }

        private void DragMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void DragMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void DragMouseUp(object sender, MouseEventArgs e)
        {
            if (IsMiddleClick(e))
                Threads.ShowAbout();

            mouseDown = false;


        }

        #endregion move methods

        private void DoTranslation()
        {
            lblPassword.Text = Locales.Local.loginLabelEnterPassword;
            this.Text = string.Format(Locales.Local.loginTitle, Threads.ProgramLittleName);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;
            txtPassword.UseSystemPasswordChar = true;
            Size a = new Size(303, 349);
            this.MaximumSize = a;
            this.MinimumSize = a;

            Threads.GetLanguage();
            DoTranslation();
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == Settings.Default.PasswordLoginStr)
            {
                lblPassword.ForeColor = Color.ForestGreen;
                FormMain formMain = new FormMain();
                formMain.Show();
                this.Hide();
            }
            else
            {
                lblPassword.ForeColor = Color.DarkRed;
            }
        }
    }
}
