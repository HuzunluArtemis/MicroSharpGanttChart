// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Windows.Forms;

namespace MicroSharpGanttChart
{
    public partial class FormLicense : Form
    {
        private void DoTranslation()
        {
            this.Text = string.Format(Locales.Local.licenseTitle,
                Threads.ProgramName + " v" + Threads.ProgramVersion);
        }

        public FormLicense()
        {
            InitializeComponent();
            // select latest index for beauty view
            HelperFuncs.StringFuncs.UnselectTextbox(rtxtLicense);
        }

        private void FormLicense_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;
            DoTranslation();
        }
    }
}
