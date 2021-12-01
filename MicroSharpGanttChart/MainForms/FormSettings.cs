// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Drawing;
using System.Windows.Forms;
using ColorPickerWPF;

namespace MicroSharpGanttChart
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            txtDaysInChart.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigit;
            txtEndHourInDay.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigit;
            txtShowBackDays.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigitMinus;
            txtStartHourInDay.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigit;
            txtAskCount.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigit;
        }

        private void DoTranslation()
        {
            this.Text = string.Format(Locales.Local.settingsTitle, Threads.ProgramName + " v" + Threads.ProgramVersion);
            this.chkStartup.Text = Locales.Local.settingStartup;
            this.chkConfirmRestart.Text = Locales.Local.settingConfirmRestart;
            this.chkConfirmExit.Text = Locales.Local.settingConfirmExit;
            this.chkPasswordLogin.Text = Locales.Local.settingPasswordLogin;
            this.btnLoadDefaults.Text = Locales.Local.settingLoadDefaults;
            this.btnSave.Text = Locales.Local.settingSaveChanges;
            this.btnCancel.Text = Locales.Local.settingCancel;
            this.tabApperence.Text = Locales.Local.setTabAppearance;
            this.tabGeneral.Text = Locales.Local.setTabGeneral;
            this.chkAskCount.Text = Locales.Local.askCount;
            this.chkSaveAndClose.Text = Locales.Local.chkSaveAndCloseInOneSec;
            //2. page
            this.chkUseSystemColorPicker.Text = Locales.Local.setUseSystemColorPicker;
            this.chkBGColor.Text = Locales.Local.setCustomChartBackColor;
            this.lblDaysInChart.Text = Locales.Local.setDaysInChart;
            this.lblShowBackDays.Text = Locales.Local.setShowDaysAgo;
            this.lblStartHourInDay.Text = Locales.Local.setStartHourInDay;
            this.lblEndHourInDay.Text = Locales.Local.setEndHourInDay;
            this.chkShowNowIndicator.Text = Locales.Local.setShowNowIndicator;
            this.chkindicatorTopTriangle.Text = Locales.Local.setIndicatorTopTriangle;
            this.chkindicatorBottomTriangle.Text = Locales.Local.setIndicatorBottomTriangle;
            this.chkIndicatorColor.Text = Locales.Local.setIndicatorColor;

        }

        private void LoadSettings()
        {

            // password login
            this.chkPasswordLogin.Checked = Settings.Default.PasswordLogin;
            this.txtPasswordLogin.Text = Settings.Default.PasswordLoginStr;
            // startup setting
            if (Startup.RegistryValueExists(Threads.ProgramName) == "true")
                this.chkStartup.Checked = true;
            else if (Startup.RegistryValueExists(Threads.ProgramName) == "diff")
            {
                this.chkStartup.CheckState = CheckState.Indeterminate;
                this.chkStartup.ForeColor = Color.Crimson;
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(this.chkStartup, Locales.Local.settingsWarningStartup);

            }

            else
                this.chkStartup.Checked = false;
            // load chartbg
            chkBGColor.Checked = !(Settings.Default.ChartBG == Threads.defaultChartBGColor);
            // end load chartbg
            chkConfirmExit.Checked = Settings.Default.ConfirmExiting;
            chkConfirmRestart.Checked = Settings.Default.ConfirmRestart;
            btnBGColor.BackColor = Settings.Default.ChartBG;
            txtDaysInChart.Text = Settings.Default.DaysInChart.ToString();
            txtShowBackDays.Text = Settings.Default.ShowBackDays.ToString();
            chkShowNowIndicator.Checked = Settings.Default.ShowNowIndicator;
            txtStartHourInDay.Text = Settings.Default.StartHourInDay.ToString();
            txtEndHourInDay.Text = Settings.Default.EndHourInDay.ToString();
            chkSaveAndClose.Checked = Settings.Default.SaveAndCloseSettings;
            chkUseSystemColorPicker.Checked = Settings.Default.UseSystemColorPicker;
            chkindicatorTopTriangle.Checked = Settings.Default.indicatorTopTriangle;
            chkindicatorBottomTriangle.Checked = Settings.Default.indicatorBottomTriangle;
            //load indicator color
            chkIndicatorColor.Checked = !(Settings.Default.indicatorColor == Threads.indicatorColor);
            btnIndicatorColor.BackColor = Settings.Default.indicatorColor;
            //
            chkAskCount.Checked = !(Settings.Default.askCountDeleteEverything == Threads.defaultAskCount);
            txtAskCount.Text = Settings.Default.askCountDeleteEverything.ToString();



        }
        private void LoadDefaultSettings()
        {
            chkPasswordLogin.Checked = false;
            txtPasswordLogin.Text = string.Empty;
            chkStartup.Checked = false;
            chkConfirmExit.Checked = true;
            chkConfirmRestart.Checked = true;
            btnBGColor.BackColor = Threads.defaultChartBGColor;
            chkUseSystemColorPicker.Checked = false;
            txtDaysInChart.Text = Threads.DaysInChart.ToString();
            txtShowBackDays.Text = Threads.ShowBackDays.ToString();
            txtStartHourInDay.Text = Threads.StartHourInDay.ToString();
            txtEndHourInDay.Text = Threads.EndHourInDay.ToString();
            chkShowNowIndicator.Checked = Threads.ShowNowIndicator;
            chkSaveAndClose.Checked = Threads.SaveAndCloseSettings;
            chkindicatorTopTriangle.Checked = Threads.indicatorTopTriangle;
            chkindicatorBottomTriangle.Checked = Threads.indicatorBottomTriangle;
            chkIndicatorColor.Checked = false;
            btnIndicatorColor.BackColor = Threads.indicatorColor;
            txtAskCount.Text = Threads.defaultAskCount.ToString();
            chkAskCount.Checked = false;
            Threads.ShowLabelInfo(lblInfo, Locales.Local.settingsLoadedDefaults, 0);
        }


        private void SaveSettings()
        {
            // key var mı bak varsa elleme yoksa elle.
            if (chkStartup.Checked)
            {
                if (!(Startup.RegistryValueExists(Threads.ProgramName) == "true"))
                    Startup.AddToStartup(Threads.ProgramName);
            }
            else
            {
                Startup.RemoveFromStartup(Threads.ProgramName);
            }
            // save passwords
            Settings.Default.PasswordLogin = chkPasswordLogin.Checked;
            if (chkPasswordLogin.Checked)
            { Settings.Default.PasswordLoginStr = txtPasswordLogin.Text; }
            Settings.Default.ConfirmExiting = chkConfirmExit.Checked;
            Settings.Default.ConfirmRestart = chkConfirmRestart.Checked;

            // get bg
            if (chkBGColor.Checked)
                Settings.Default.ChartBG = btnBGColor.BackColor;
            else
                Settings.Default.ChartBG = Threads.defaultChartBGColor;
            // get bg
            Settings.Default.ShowNowIndicator = chkShowNowIndicator.Checked;
            Settings.Default.UseSystemColorPicker = chkUseSystemColorPicker.Checked;
            Settings.Default.DaysInChart = MainChart.ValidateNotZeroOrNegative(int.Parse(txtDaysInChart.Text));
            Settings.Default.ShowBackDays = int.Parse(txtShowBackDays.Text);
            //
            Settings.Default.StartHourInDay = int.Parse(txtStartHourInDay.Text);
            Settings.Default.EndHourInDay = int.Parse(txtEndHourInDay.Text);
            //
            Settings.Default.SaveAndCloseSettings = chkSaveAndClose.Checked;
            // indicator
            Settings.Default.indicatorBottomTriangle = chkindicatorBottomTriangle.Checked;
            Settings.Default.indicatorTopTriangle = chkindicatorTopTriangle.Checked;
            if (chkIndicatorColor.Checked)
                Settings.Default.indicatorColor = btnIndicatorColor.BackColor;
            else
                Settings.Default.indicatorColor = Threads.indicatorColor;
            // askcount
            if (chkAskCount.Checked)
                Settings.Default.askCountDeleteEverything = int.Parse(txtAskCount.Text);
            else
                Settings.Default.askCountDeleteEverything = Threads.defaultAskCount;
            // save to settings


            Settings.Default.Save();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;
            LoadSettings();
            DoTranslation();
            rtxtAbout.Text = Threads.AboutText;
            rtxtAbout.Text += Environment.NewLine;
            rtxtAbout.Text += Threads.ProgramPage;
            rtxtAbout.Text += Environment.NewLine;
            rtxtAbout.Text += Environment.NewLine;
            rtxtAbout.Text += Threads.ProgramRepo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveSettings();
            Threads.ShowLabelInfo(lblInfo, Locales.Local.settingsSavedChanges, 1000);
            if (Settings.Default.SaveAndCloseSettings)
            {
                this.Close();
            }

        }



        private void chkPasswordLogin_CheckedChanged(object sender, EventArgs e) => txtPasswordLogin.Enabled = chkPasswordLogin.Checked;

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void BtnLoadDefaults_Click(object sender, EventArgs e)
        {
            LoadDefaultSettings();
        }

        private void ChkBGColor_CheckedChanged(object sender, EventArgs e) => btnBGColor.Enabled = chkBGColor.Checked;

        private void PickColor(Button button, CheckBox checkBox)
        {
            if (Settings.Default.UseSystemColorPicker)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.AnyColor = true;
                colorDialog.AllowFullOpen = true;
                Color color = colorDialog.Color;
                DialogResult result = colorDialog.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:

                        color = colorDialog.Color;
                        button.BackColor = color;
                        button.ForeColor = Color.Black;
                        button.Refresh();
                        checkBox.Checked = true;
                        button.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // tp
                System.Windows.Media.Color color = new System.Windows.Media.Color();
                ColorPickerWindow colorPicker = new ColorPickerWindow();
                colorPicker.Title = "Renk Seçici";
                bool ok = ColorPickerWindow.ShowDialog(out color);
                if (ok)
                {
                    button.Invoke((MethodInvoker)(() => button.BackColor = ColorConvert.ToDrawingColor(color)));
                }
                // tp
            }


        }

        private void BtnBGColor_Click(object sender, EventArgs e) => PickColor(btnBGColor, chkBGColor);

        private void btnBGColor_BackColorChanged(object sender, EventArgs e)
        {
            Threads.SetChartBG(MainChart._ganttChart, btnBGColor.BackColor);
        }

        private void ChkUseSystemColorPicker_CheckedChanged(object sender, EventArgs e) => Settings.Default.UseSystemColorPicker = chkUseSystemColorPicker.Checked;

        private void btnIndicatorColor_Click(object sender, EventArgs e) => PickColor(btnIndicatorColor, chkIndicatorColor);

        private void chkIndicatorColor_CheckedChanged(object sender, EventArgs e) => btnIndicatorColor.Enabled = chkIndicatorColor.Checked;

        private void chkAskCount_CheckedChanged(object sender, EventArgs e) => txtAskCount.Enabled = chkAskCount.Checked;


    }
}
