namespace MicroSharpGanttChart
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkPasswordLogin = new System.Windows.Forms.CheckBox();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkConfirmExit = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkConfirmRestart = new System.Windows.Forms.CheckBox();
            this.chkBGColor = new System.Windows.Forms.CheckBox();
            this.btnBGColor = new System.Windows.Forms.Button();
            this.chkUseSystemColorPicker = new System.Windows.Forms.CheckBox();
            this.lblDaysInChart = new System.Windows.Forms.Label();
            this.txtDaysInChart = new System.Windows.Forms.TextBox();
            this.txtShowBackDays = new System.Windows.Forms.TextBox();
            this.lblShowBackDays = new System.Windows.Forms.Label();
            this.chkShowNowIndicator = new System.Windows.Forms.CheckBox();
            this.txtStartHourInDay = new System.Windows.Forms.TextBox();
            this.lblStartHourInDay = new System.Windows.Forms.Label();
            this.txtEndHourInDay = new System.Windows.Forms.TextBox();
            this.lblEndHourInDay = new System.Windows.Forms.Label();
            this.chkSaveAndClose = new System.Windows.Forms.CheckBox();
            this.chkindicatorTopTriangle = new System.Windows.Forms.CheckBox();
            this.chkindicatorBottomTriangle = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.chkAskCount = new System.Windows.Forms.CheckBox();
            this.txtAskCount = new System.Windows.Forms.TextBox();
            this.tabApperence = new System.Windows.Forms.TabPage();
            this.chkIndicatorColor = new System.Windows.Forms.CheckBox();
            this.btnIndicatorColor = new System.Windows.Forms.Button();
            this.tabLicense = new System.Windows.Forms.TabPage();
            this.rtxtLicense = new System.Windows.Forms.RichTextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.rtxtAbout = new System.Windows.Forms.RichTextBox();
            this.tabMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabApperence.SuspendLayout();
            this.tabLicense.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(6, 6);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(145, 17);
            this.chkStartup.TabIndex = 0;
            this.chkStartup.Text = "Start at Wİndows Startup";
            this.chkStartup.ThreeState = true;
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkPasswordLogin
            // 
            this.chkPasswordLogin.AutoSize = true;
            this.chkPasswordLogin.Location = new System.Drawing.Point(6, 29);
            this.chkPasswordLogin.Name = "chkPasswordLogin";
            this.chkPasswordLogin.Size = new System.Drawing.Size(133, 17);
            this.chkPasswordLogin.TabIndex = 3;
            this.chkPasswordLogin.Text = "Password when Login:";
            this.chkPasswordLogin.UseVisualStyleBackColor = true;
            this.chkPasswordLogin.CheckedChanged += new System.EventHandler(this.chkPasswordLogin_CheckedChanged);
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Enabled = false;
            this.txtPasswordLogin.Location = new System.Drawing.Point(216, 26);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.Size = new System.Drawing.Size(122, 20);
            this.txtPasswordLogin.TabIndex = 4;
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.Location = new System.Drawing.Point(240, 363);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(87, 23);
            this.btnLoadDefaults.TabIndex = 26;
            this.btnLoadDefaults.Text = "Load Defaults";
            this.btnLoadDefaults.UseVisualStyleBackColor = true;
            this.btnLoadDefaults.Click += new System.EventHandler(this.BtnLoadDefaults_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(414, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkConfirmExit
            // 
            this.chkConfirmExit.AutoSize = true;
            this.chkConfirmExit.Location = new System.Drawing.Point(6, 52);
            this.chkConfirmExit.Name = "chkConfirmExit";
            this.chkConfirmExit.Size = new System.Drawing.Size(144, 17);
            this.chkConfirmExit.TabIndex = 3;
            this.chkConfirmExit.Text = "Confirm when exiting app";
            this.chkConfirmExit.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 347);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 27;
            // 
            // chkConfirmRestart
            // 
            this.chkConfirmRestart.AutoSize = true;
            this.chkConfirmRestart.Location = new System.Drawing.Point(6, 75);
            this.chkConfirmRestart.Name = "chkConfirmRestart";
            this.chkConfirmRestart.Size = new System.Drawing.Size(157, 17);
            this.chkConfirmRestart.TabIndex = 3;
            this.chkConfirmRestart.Text = "Confirm when restarting app";
            this.chkConfirmRestart.UseVisualStyleBackColor = true;
            // 
            // chkBGColor
            // 
            this.chkBGColor.AutoSize = true;
            this.chkBGColor.Location = new System.Drawing.Point(6, 28);
            this.chkBGColor.Name = "chkBGColor";
            this.chkBGColor.Size = new System.Drawing.Size(171, 17);
            this.chkBGColor.TabIndex = 3;
            this.chkBGColor.Text = "Custom chart backgroud color:";
            this.chkBGColor.UseVisualStyleBackColor = true;
            this.chkBGColor.CheckedChanged += new System.EventHandler(this.ChkBGColor_CheckedChanged);
            // 
            // btnBGColor
            // 
            this.btnBGColor.BackColor = System.Drawing.Color.IndianRed;
            this.btnBGColor.Enabled = false;
            this.btnBGColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBGColor.ForeColor = System.Drawing.Color.Black;
            this.btnBGColor.Location = new System.Drawing.Point(216, 28);
            this.btnBGColor.Name = "btnBGColor";
            this.btnBGColor.Size = new System.Drawing.Size(122, 17);
            this.btnBGColor.TabIndex = 28;
            this.btnBGColor.UseVisualStyleBackColor = false;
            this.btnBGColor.BackColorChanged += new System.EventHandler(this.btnBGColor_BackColorChanged);
            this.btnBGColor.Click += new System.EventHandler(this.BtnBGColor_Click);
            // 
            // chkUseSystemColorPicker
            // 
            this.chkUseSystemColorPicker.AutoSize = true;
            this.chkUseSystemColorPicker.Location = new System.Drawing.Point(6, 6);
            this.chkUseSystemColorPicker.Name = "chkUseSystemColorPicker";
            this.chkUseSystemColorPicker.Size = new System.Drawing.Size(138, 17);
            this.chkUseSystemColorPicker.TabIndex = 3;
            this.chkUseSystemColorPicker.Text = "Use system color picker";
            this.chkUseSystemColorPicker.UseVisualStyleBackColor = true;
            this.chkUseSystemColorPicker.CheckedChanged += new System.EventHandler(this.ChkUseSystemColorPicker_CheckedChanged);
            // 
            // lblDaysInChart
            // 
            this.lblDaysInChart.AutoSize = true;
            this.lblDaysInChart.Location = new System.Drawing.Point(6, 54);
            this.lblDaysInChart.Name = "lblDaysInChart";
            this.lblDaysInChart.Size = new System.Drawing.Size(73, 13);
            this.lblDaysInChart.TabIndex = 29;
            this.lblDaysInChart.Text = "Days in Chart:";
            // 
            // txtDaysInChart
            // 
            this.txtDaysInChart.Location = new System.Drawing.Point(216, 51);
            this.txtDaysInChart.Name = "txtDaysInChart";
            this.txtDaysInChart.Size = new System.Drawing.Size(122, 20);
            this.txtDaysInChart.TabIndex = 4;
            // 
            // txtShowBackDays
            // 
            this.txtShowBackDays.Location = new System.Drawing.Point(216, 77);
            this.txtShowBackDays.Name = "txtShowBackDays";
            this.txtShowBackDays.Size = new System.Drawing.Size(122, 20);
            this.txtShowBackDays.TabIndex = 4;
            // 
            // lblShowBackDays
            // 
            this.lblShowBackDays.AutoSize = true;
            this.lblShowBackDays.Location = new System.Drawing.Point(6, 80);
            this.lblShowBackDays.Name = "lblShowBackDays";
            this.lblShowBackDays.Size = new System.Drawing.Size(185, 13);
            this.lblShowBackDays.TabIndex = 29;
            this.lblShowBackDays.Text = "show how many days ago (today = 0):";
            // 
            // chkShowNowIndicator
            // 
            this.chkShowNowIndicator.AutoSize = true;
            this.chkShowNowIndicator.Location = new System.Drawing.Point(6, 157);
            this.chkShowNowIndicator.Name = "chkShowNowIndicator";
            this.chkShowNowIndicator.Size = new System.Drawing.Size(122, 17);
            this.chkShowNowIndicator.TabIndex = 30;
            this.chkShowNowIndicator.Text = "Show Now Indicator";
            this.chkShowNowIndicator.UseVisualStyleBackColor = true;
            // 
            // txtStartHourInDay
            // 
            this.txtStartHourInDay.Location = new System.Drawing.Point(216, 103);
            this.txtStartHourInDay.Name = "txtStartHourInDay";
            this.txtStartHourInDay.Size = new System.Drawing.Size(122, 20);
            this.txtStartHourInDay.TabIndex = 4;
            // 
            // lblStartHourInDay
            // 
            this.lblStartHourInDay.AutoSize = true;
            this.lblStartHourInDay.Location = new System.Drawing.Point(6, 106);
            this.lblStartHourInDay.Name = "lblStartHourInDay";
            this.lblStartHourInDay.Size = new System.Drawing.Size(110, 13);
            this.lblStartHourInDay.TabIndex = 29;
            this.lblStartHourInDay.Text = "StartHourInDay (0-24)";
            // 
            // txtEndHourInDay
            // 
            this.txtEndHourInDay.Location = new System.Drawing.Point(216, 129);
            this.txtEndHourInDay.Name = "txtEndHourInDay";
            this.txtEndHourInDay.Size = new System.Drawing.Size(122, 20);
            this.txtEndHourInDay.TabIndex = 4;
            // 
            // lblEndHourInDay
            // 
            this.lblEndHourInDay.AutoSize = true;
            this.lblEndHourInDay.Location = new System.Drawing.Point(6, 132);
            this.lblEndHourInDay.Name = "lblEndHourInDay";
            this.lblEndHourInDay.Size = new System.Drawing.Size(107, 13);
            this.lblEndHourInDay.TabIndex = 29;
            this.lblEndHourInDay.Text = "EndHourInDay (0-24)";
            // 
            // chkSaveAndClose
            // 
            this.chkSaveAndClose.AutoSize = true;
            this.chkSaveAndClose.Location = new System.Drawing.Point(16, 367);
            this.chkSaveAndClose.Name = "chkSaveAndClose";
            this.chkSaveAndClose.Size = new System.Drawing.Size(200, 17);
            this.chkSaveAndClose.TabIndex = 31;
            this.chkSaveAndClose.Text = "Save and close settings in 1 second.";
            this.chkSaveAndClose.UseVisualStyleBackColor = true;
            // 
            // chkindicatorTopTriangle
            // 
            this.chkindicatorTopTriangle.AutoSize = true;
            this.chkindicatorTopTriangle.Location = new System.Drawing.Point(6, 183);
            this.chkindicatorTopTriangle.Name = "chkindicatorTopTriangle";
            this.chkindicatorTopTriangle.Size = new System.Drawing.Size(123, 17);
            this.chkindicatorTopTriangle.TabIndex = 30;
            this.chkindicatorTopTriangle.Text = "indicatorTopTriangle";
            this.chkindicatorTopTriangle.UseVisualStyleBackColor = true;
            // 
            // chkindicatorBottomTriangle
            // 
            this.chkindicatorBottomTriangle.AutoSize = true;
            this.chkindicatorBottomTriangle.Location = new System.Drawing.Point(6, 209);
            this.chkindicatorBottomTriangle.Name = "chkindicatorBottomTriangle";
            this.chkindicatorBottomTriangle.Size = new System.Drawing.Size(137, 17);
            this.chkindicatorBottomTriangle.TabIndex = 30;
            this.chkindicatorBottomTriangle.Text = "indicatorBottomTriangle";
            this.chkindicatorBottomTriangle.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabGeneral);
            this.tabMain.Controls.Add(this.tabApperence);
            this.tabMain.Controls.Add(this.tabLicense);
            this.tabMain.Controls.Add(this.tabAbout);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(473, 323);
            this.tabMain.TabIndex = 33;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.chkAskCount);
            this.tabGeneral.Controls.Add(this.chkStartup);
            this.tabGeneral.Controls.Add(this.chkPasswordLogin);
            this.tabGeneral.Controls.Add(this.chkConfirmExit);
            this.tabGeneral.Controls.Add(this.chkConfirmRestart);
            this.tabGeneral.Controls.Add(this.txtAskCount);
            this.tabGeneral.Controls.Add(this.txtPasswordLogin);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(465, 297);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // chkAskCount
            // 
            this.chkAskCount.AutoSize = true;
            this.chkAskCount.Location = new System.Drawing.Point(6, 98);
            this.chkAskCount.Name = "chkAskCount";
            this.chkAskCount.Size = new System.Drawing.Size(149, 17);
            this.chkAskCount.TabIndex = 5;
            this.chkAskCount.Text = "Ask Count When Deleting";
            this.chkAskCount.UseVisualStyleBackColor = true;
            this.chkAskCount.CheckedChanged += new System.EventHandler(this.chkAskCount_CheckedChanged);
            // 
            // txtAskCount
            // 
            this.txtAskCount.Enabled = false;
            this.txtAskCount.Location = new System.Drawing.Point(216, 95);
            this.txtAskCount.Name = "txtAskCount";
            this.txtAskCount.Size = new System.Drawing.Size(122, 20);
            this.txtAskCount.TabIndex = 4;
            // 
            // tabApperence
            // 
            this.tabApperence.Controls.Add(this.chkIndicatorColor);
            this.tabApperence.Controls.Add(this.btnIndicatorColor);
            this.tabApperence.Controls.Add(this.chkUseSystemColorPicker);
            this.tabApperence.Controls.Add(this.chkBGColor);
            this.tabApperence.Controls.Add(this.txtDaysInChart);
            this.tabApperence.Controls.Add(this.txtShowBackDays);
            this.tabApperence.Controls.Add(this.chkindicatorBottomTriangle);
            this.tabApperence.Controls.Add(this.txtStartHourInDay);
            this.tabApperence.Controls.Add(this.chkindicatorTopTriangle);
            this.tabApperence.Controls.Add(this.txtEndHourInDay);
            this.tabApperence.Controls.Add(this.chkShowNowIndicator);
            this.tabApperence.Controls.Add(this.btnBGColor);
            this.tabApperence.Controls.Add(this.lblEndHourInDay);
            this.tabApperence.Controls.Add(this.lblDaysInChart);
            this.tabApperence.Controls.Add(this.lblStartHourInDay);
            this.tabApperence.Controls.Add(this.lblShowBackDays);
            this.tabApperence.Location = new System.Drawing.Point(4, 22);
            this.tabApperence.Name = "tabApperence";
            this.tabApperence.Padding = new System.Windows.Forms.Padding(3);
            this.tabApperence.Size = new System.Drawing.Size(465, 297);
            this.tabApperence.TabIndex = 1;
            this.tabApperence.Text = "Apperence";
            this.tabApperence.UseVisualStyleBackColor = true;
            // 
            // chkIndicatorColor
            // 
            this.chkIndicatorColor.AutoSize = true;
            this.chkIndicatorColor.Location = new System.Drawing.Point(6, 232);
            this.chkIndicatorColor.Name = "chkIndicatorColor";
            this.chkIndicatorColor.Size = new System.Drawing.Size(94, 17);
            this.chkIndicatorColor.TabIndex = 31;
            this.chkIndicatorColor.Text = "Indicator Color";
            this.chkIndicatorColor.UseVisualStyleBackColor = true;
            this.chkIndicatorColor.CheckedChanged += new System.EventHandler(this.chkIndicatorColor_CheckedChanged);
            // 
            // btnIndicatorColor
            // 
            this.btnIndicatorColor.BackColor = System.Drawing.Color.IndianRed;
            this.btnIndicatorColor.Enabled = false;
            this.btnIndicatorColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndicatorColor.ForeColor = System.Drawing.Color.Black;
            this.btnIndicatorColor.Location = new System.Drawing.Point(216, 232);
            this.btnIndicatorColor.Name = "btnIndicatorColor";
            this.btnIndicatorColor.Size = new System.Drawing.Size(122, 17);
            this.btnIndicatorColor.TabIndex = 32;
            this.btnIndicatorColor.UseVisualStyleBackColor = false;
            this.btnIndicatorColor.Click += new System.EventHandler(this.btnIndicatorColor_Click);
            // 
            // tabLicense
            // 
            this.tabLicense.Controls.Add(this.rtxtLicense);
            this.tabLicense.Location = new System.Drawing.Point(4, 22);
            this.tabLicense.Name = "tabLicense";
            this.tabLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tabLicense.Size = new System.Drawing.Size(465, 297);
            this.tabLicense.TabIndex = 2;
            this.tabLicense.Text = "License";
            this.tabLicense.UseVisualStyleBackColor = true;
            // 
            // rtxtLicense
            // 
            this.rtxtLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtLicense.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLicense.Location = new System.Drawing.Point(3, 3);
            this.rtxtLicense.Name = "rtxtLicense";
            this.rtxtLicense.ReadOnly = true;
            this.rtxtLicense.ShowSelectionMargin = true;
            this.rtxtLicense.Size = new System.Drawing.Size(459, 291);
            this.rtxtLicense.TabIndex = 2;
            this.rtxtLicense.Text = resources.GetString("rtxtLicense.Text");
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.rtxtAbout);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(465, 297);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // rtxtAbout
            // 
            this.rtxtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtAbout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtAbout.Location = new System.Drawing.Point(3, 3);
            this.rtxtAbout.Name = "rtxtAbout";
            this.rtxtAbout.ReadOnly = true;
            this.rtxtAbout.ShowSelectionMargin = true;
            this.rtxtAbout.Size = new System.Drawing.Size(459, 291);
            this.rtxtAbout.TabIndex = 3;
            this.rtxtAbout.Text = "";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 396);
            this.Controls.Add(this.chkSaveAndClose);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnLoadDefaults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximumSize = new System.Drawing.Size(515, 434);
            this.MinimumSize = new System.Drawing.Size(515, 434);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabApperence.ResumeLayout(false);
            this.tabApperence.PerformLayout();
            this.tabLicense.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkPasswordLogin;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.Button btnLoadDefaults;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkConfirmExit;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox chkConfirmRestart;
        private System.Windows.Forms.CheckBox chkBGColor;
        private System.Windows.Forms.Button btnBGColor;
        private System.Windows.Forms.CheckBox chkUseSystemColorPicker;
        private System.Windows.Forms.Label lblDaysInChart;
        private System.Windows.Forms.TextBox txtDaysInChart;
        private System.Windows.Forms.TextBox txtShowBackDays;
        private System.Windows.Forms.Label lblShowBackDays;
        private System.Windows.Forms.CheckBox chkShowNowIndicator;
        private System.Windows.Forms.TextBox txtStartHourInDay;
        private System.Windows.Forms.Label lblStartHourInDay;
        private System.Windows.Forms.TextBox txtEndHourInDay;
        private System.Windows.Forms.Label lblEndHourInDay;
        private System.Windows.Forms.CheckBox chkSaveAndClose;
        private System.Windows.Forms.CheckBox chkindicatorTopTriangle;
        private System.Windows.Forms.CheckBox chkindicatorBottomTriangle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabApperence;
        private System.Windows.Forms.CheckBox chkIndicatorColor;
        private System.Windows.Forms.Button btnIndicatorColor;
        private System.Windows.Forms.CheckBox chkAskCount;
        private System.Windows.Forms.TextBox txtAskCount;
        private System.Windows.Forms.TabPage tabLicense;
        private System.Windows.Forms.RichTextBox rtxtLicense;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.RichTextBox rtxtAbout;
    }
}