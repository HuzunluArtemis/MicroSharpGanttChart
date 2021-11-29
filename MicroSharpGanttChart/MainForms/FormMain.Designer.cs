namespace MicroSharpGanttChart
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FileTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRowsowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyEverythingToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "information.icon.png");
            this.imageList.Images.SetKeyName(1, "settings.icon.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Language:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTool,
            this.LanguageTool,
            this.toolStripDropDownEdit,
            this.HelpTool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(808, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // FileTool
            // 
            this.FileTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openChartToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.saveChangesToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.toolStripSeparator1,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.FileTool.Image = ((System.Drawing.Image)(resources.GetObject("FileTool.Image")));
            this.FileTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileTool.Name = "FileTool";
            this.FileTool.Size = new System.Drawing.Size(38, 22);
            this.FileTool.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewRowToolStripMenuItem,
            this.NewRowsToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // NewRowToolStripMenuItem
            // 
            this.NewRowToolStripMenuItem.Name = "NewRowToolStripMenuItem";
            this.NewRowToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.NewRowToolStripMenuItem.Text = "Row";
            this.NewRowToolStripMenuItem.Click += new System.EventHandler(this.rowToolStripMenuItem_Click);
            // 
            // NewRowsToolStripMenuItem
            // 
            this.NewRowsToolStripMenuItem.Name = "NewRowsToolStripMenuItem";
            this.NewRowsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.NewRowsToolStripMenuItem.Text = "Rows...";
            this.NewRowsToolStripMenuItem.Click += new System.EventHandler(this.rowsToolStripMenuItem_Click);
            // 
            // openChartToolStripMenuItem
            // 
            this.openChartToolStripMenuItem.Name = "openChartToolStripMenuItem";
            this.openChartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openChartToolStripMenuItem.Text = "Open Chart";
            this.openChartToolStripMenuItem.Click += new System.EventHandler(this.openChartToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteRowToolStripMenuItem,
            this.DeleteRowsowsToolStripMenuItem,
            this.DeleteAllToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // DeleteRowToolStripMenuItem
            // 
            this.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem";
            this.DeleteRowToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.DeleteRowToolStripMenuItem.Text = "Row";
            this.DeleteRowToolStripMenuItem.Click += new System.EventHandler(this.rowToolStripMenuItem1_Click);
            // 
            // DeleteRowsowsToolStripMenuItem
            // 
            this.DeleteRowsowsToolStripMenuItem.Name = "DeleteRowsowsToolStripMenuItem";
            this.DeleteRowsowsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.DeleteRowsowsToolStripMenuItem.Text = "Rows...";
            this.DeleteRowsowsToolStripMenuItem.Click += new System.EventHandler(this.rowsToolStripMenuItemDelete_Click);
            // 
            // DeleteAllToolStripMenuItem
            // 
            this.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            this.DeleteAllToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.DeleteAllToolStripMenuItem.Text = "All Rows";
            this.DeleteAllToolStripMenuItem.Click += new System.EventHandler(this.everythingToolStripMenuItem_Click);
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveChangesToolStripMenuItem.Text = "Save Changes";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.SaveChangesToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyEverythingToClipboardToolStripMenuItem,
            this.openFromClipBoardToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // copyEverythingToClipboardToolStripMenuItem
            // 
            this.copyEverythingToClipboardToolStripMenuItem.Name = "copyEverythingToClipboardToolStripMenuItem";
            this.copyEverythingToClipboardToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.copyEverythingToClipboardToolStripMenuItem.Text = "Copy Everything to Clipboard";
            this.copyEverythingToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyEverythingToClipboardToolStripMenuItem_Click);
            // 
            // openFromClipBoardToolStripMenuItem
            // 
            this.openFromClipBoardToolStripMenuItem.Name = "openFromClipBoardToolStripMenuItem";
            this.openFromClipBoardToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.openFromClipBoardToolStripMenuItem.Text = "Open from ClipBoard";
            this.openFromClipBoardToolStripMenuItem.Click += new System.EventHandler(this.openFromClipBoardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LanguageTool
            // 
            this.LanguageTool.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LanguageTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LanguageTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.turkceToolStripMenuItem});
            this.LanguageTool.Image = ((System.Drawing.Image)(resources.GetObject("LanguageTool.Image")));
            this.LanguageTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LanguageTool.Name = "LanguageTool";
            this.LanguageTool.Size = new System.Drawing.Size(72, 22);
            this.LanguageTool.Text = "Language";
            this.LanguageTool.ToolTipText = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // turkceToolStripMenuItem
            // 
            this.turkceToolStripMenuItem.Name = "turkceToolStripMenuItem";
            this.turkceToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.turkceToolStripMenuItem.Text = "Türkçe";
            this.turkceToolStripMenuItem.Click += new System.EventHandler(this.türkçeToolStripMenuItem_Click);
            // 
            // toolStripDropDownEdit
            // 
            this.toolStripDropDownEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.toolStripDropDownEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownEdit.Image")));
            this.toolStripDropDownEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownEdit.Name = "toolStripDropDownEdit";
            this.toolStripDropDownEdit.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownEdit.Text = "Edit";
            this.toolStripDropDownEdit.ToolTipText = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.fullScreenToolStripMenuItem.Text = "FullScreen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // HelpTool
            // 
            this.HelpTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPageToolStripMenuItem,
            this.projectRepoToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.HelpTool.Image = ((System.Drawing.Image)(resources.GetObject("HelpTool.Image")));
            this.HelpTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpTool.Name = "HelpTool";
            this.HelpTool.Size = new System.Drawing.Size(45, 22);
            this.HelpTool.Text = "Help";
            // 
            // projectPageToolStripMenuItem
            // 
            this.projectPageToolStripMenuItem.Name = "projectPageToolStripMenuItem";
            this.projectPageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.projectPageToolStripMenuItem.Text = "Project Page";
            this.projectPageToolStripMenuItem.Click += new System.EventHandler(this.projectPageToolStripMenuItem_Click);
            // 
            // projectRepoToolStripMenuItem
            // 
            this.projectRepoToolStripMenuItem.Name = "projectRepoToolStripMenuItem";
            this.projectRepoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.projectRepoToolStripMenuItem.Text = "Project Repo";
            this.projectRepoToolStripMenuItem.Click += new System.EventHandler(this.projectRepoToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(808, 517);
            this.panelMain.TabIndex = 19;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 542);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton LanguageTool;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton FileTool;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton HelpTool;
        private System.Windows.Forms.ToolStripMenuItem projectPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectRepoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownEdit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteRowsowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyEverythingToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFromClipBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

