// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using GanttChart;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MicroSharpGanttChart
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitChart();
        }

        internal object _tempRow;
        internal string _tempEditRowname;
        internal DateTime _tempDateTime;
        internal object _tempTimeBlock;

        private void InitChart()
        {
            //
            this.panelMain.Controls.Add(MainChart._ganttChart); //Add the chart to the form
            MainChart._ganttChart.Dock = DockStyle.Fill; //Expand the chart to fill the form

            //Add data

            Threads.CreateRowsDatabase();

            MainChart._ganttChart.RowSingleClick += RowSingleClick;
            MainChart._ganttChart.RowDoubleClick += RowDoubleClick;
            MainChart._ganttChart.MainCanvasSingleClick += CanvasSingleClick;
            MainChart._ganttChart.MainCanvasDoubleClick += CanvasDoubleClick;
            MainChart._ganttChart.TimeBlockSingleClick += TimeBlockSingleClick;
            MainChart._ganttChart.TimeBlockDoubleClick += TimeBlockDoubleClick;
            MainChart.GetChartBGFromSettings(MainChart._ganttChart);
        }
        private void RowSingleClick(RowClickedEventArgs e)
        {
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;
            if (MainChart._ganttChart.isRightClick)
            {
                _tempRow = e.ClickedRow;
                // selected row operations
                ToolStripMenuItem name = new ToolStripMenuItem(string.Format(Locales.Local.toolSelectedRow, e.ClickedRow.Text), Locales.Local.toRight);
                ToolStripItem edit = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedEditRow, e.ClickedRow.Text));
                edit.Click += new EventHandler(this.editRow);
                ToolStripItem delete = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedDeleteRow, e.ClickedRow.Text));
                delete.Click += new EventHandler(this.deleteRow);
                ToolStripItem clear = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedClearRow, e.ClickedRow.Text));
                clear.Click += new EventHandler(this.clearRow);
                ToolStripItem hideshow = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedHideRow, e.ClickedRow.Text));
                hideshow.Click += new EventHandler(this.HideRow);
                ToolStripItem seticon = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedSetIconRow, e.ClickedRow.Text));
                seticon.Click += new EventHandler(this.SetRowIcon);
                ToolStripItem delicon = name.DropDownItems.Add(string.Format(Locales.Local.toolSelectedDeleteIcon, e.ClickedRow.Text));
                delicon.Click += new EventHandler(this.DeleteRowIcon);

                name.DropDownItems.Add(edit);
                name.DropDownItems.Add(delete);
                name.DropDownItems.Add(clear);
                name.DropDownItems.Add(hideshow);
                name.DropDownItems.Add(seticon);
                name.DropDownItems.Add(delicon);

                // sort
                ToolStripMenuItem sort = new ToolStripMenuItem(Locales.Local.toolSortAllRows);
                ToolStripItem sortaz = sort.DropDownItems.Add(Locales.Local.toolSortRowsAZ);
                sortaz.Click += new EventHandler(this.sortAlAZ);
                ToolStripItem sortza = sort.DropDownItems.Add(Locales.Local.toolSortRowsZA);
                sortza.Click += new EventHandler(this.sortAllZA);


                sort.DropDownItems.Add(sortaz);
                sort.DropDownItems.Add(sortza);

                // add row
                ToolStripMenuItem addrow = new ToolStripMenuItem(Locales.Local.toolAddRow);
                ToolStripItem addrowone = sort.DropDownItems.Add(Locales.Local.toolAddSingleRow);
                addrowone.Click += new EventHandler(this.rowToolStripMenuItem_Click);
                ToolStripItem addrowmulti = sort.DropDownItems.Add(Locales.Local.toolAddMultiRows);
                addrowmulti.Click += new EventHandler(this.rowsToolStripMenuItem_Click);

                addrow.DropDownItems.Add(addrowone);
                addrow.DropDownItems.Add(addrowmulti);

                // delete all rows

                ToolStripMenuItem delallrows = new ToolStripMenuItem(Locales.Local.toolDeleteAll);
                ToolStripItem exceptthis = delallrows.DropDownItems.Add(String.Format(Locales.Local.toolDeleteExceptThis, e.ClickedRow.Text));
                exceptthis.Click += everythingToolStripMenuItemExceptThis_Click;
                ToolStripItem everything = delallrows.DropDownItems.Add(Locales.Local.toolDeleteAll);
                everything.Click += everythingToolStripMenuItem_Click;


                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;
                cms.Items.Add(name);
                cms.Items.Add(sort);
                cms.Items.Add(addrow);
                cms.Items.Add(delallrows);
                //
                cms.Refresh();
                cms.Show(posX, posY);
                // MessageBox.Show("right: " + e.ClickedRow.Text);
            }
            else
            {
                // MessageBox.Show("left: " + e.ClickedRow.Text);
            }

        }
        internal void CanvasSingleClick(CanvasClickedEventArgs e)
        {
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;

            if (MainChart._ganttChart.isRightClick)
            {
                //string a = ObjectDumper.Dump(e.RelatedRow);
                //string b = ObjectDumper.Dump(e.ClickedLocation);
                //MessageBox.Show("right: " + e.ClickedLocation.ToString()
                //    + Environment.NewLine + Environment.NewLine
                //    + a
                //    + Environment.NewLine + Environment.NewLine
                //    + b);

                DateTime location = (DateTime)e.ClickedLocation;
                string hour = location.TimeOfDay.ToString();
                ToolStripMenuItem name = new ToolStripMenuItem(string.Format(Locales.Local.strAddTimeBlock, hour));
                ContextMenuStrip cms = new ContextMenuStrip();
                _tempDateTime = (DateTime)e.ClickedLocation;
                _tempRow = e.RelatedRow;
                cms.Items.Add(name);
                name.Click += AddTimeBlock;
                cms.Show(posX, posY);
            }


        }

        private void AddTimeBlock(object sender, EventArgs e)
        {
            DateTime comingdate = _tempDateTime;
            ChartFuncs.FormTimeBlock settings = new ChartFuncs.FormTimeBlock();
            settings.Text = Locales.Local.strAddTimeBlockTitle;
            settings.process = 1;
            settings.row = (Row)_tempRow;
            settings.dtStart.Value = comingdate;
            settings.dtEnd.Value = comingdate.AddHours(Settings.Default.defaultTimeBlockAddHour);
            settings.ShowDialog();

        }

        internal void CanvasDoubleClick(CanvasClickedEventArgs e)
        {
            _tempDateTime = (DateTime)e.ClickedLocation;
            _tempRow = e.RelatedRow;
            AddTimeBlock(null, null);
        }
        internal void TimeBlockDoubleClick(TimeBlockClickedEventArgs e)
        {
            TimeBlock eTimeBlock = e.ClickedTimeBlock;
            _tempRow = e.RelatedRow;
            ChartFuncs.FormTimeBlock settings = new ChartFuncs.FormTimeBlock();
            settings.Text = e.ClickedTimeBlock.Text;
            settings.row = (Row)_tempRow;
            settings.process = 0;
            settings.TimeBlock = eTimeBlock;
            settings.ShowDialog();
        }
        internal void TimeBlockSingleClick(TimeBlockClickedEventArgs e)
        {

            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;
            if (MainChart._ganttChart.isRightClick)
            {
                TimeBlock eTimeBlock = e.ClickedTimeBlock;
                _tempTimeBlock = eTimeBlock;
                _tempRow = e.RelatedRow;

                ToolStripMenuItem name = new ToolStripMenuItem(string.Format(Locales.Local.toolQuickOperations, eTimeBlock.Text), Locales.Local.toRight);

                // edit
                ToolStripItem edit = name.DropDownItems.Add(string.Format(Locales.Local.toolEditTimeBlockName, eTimeBlock.Text));
                edit.Tag = eTimeBlock;
                edit.Click += editTimeBlock;

                // delete
                ToolStripItem delete = name.DropDownItems.Add(string.Format(Locales.Local.toolDeleteTimeBlock, eTimeBlock.Text));
                delete.Tag = eTimeBlock;
                delete.Click += deleteTimeBlock;

                // hide
                ToolStripItem hideshow = name.DropDownItems.Add(string.Format(Locales.Local.toolHideTimeBlock, eTimeBlock.Text));
                hideshow.Tag = eTimeBlock;
                hideshow.Click += hideTimeBlock;


                name.DropDownItems.Add(edit);
                name.DropDownItems.Add(delete);
                name.DropDownItems.Add(hideshow);


                ToolStripMenuItem settings = new ToolStripMenuItem(string.Format(Locales.Local.toolSettingsTimeBlock, eTimeBlock.Text), Locales.Local.toRight);
                settings.Tag = eTimeBlock;
                settings.Click += settingsTimeBlock;

                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;
                cms.Items.Add(name);
                cms.Items.Add(settings);
                //
                cms.Refresh();
                cms.Show(posX, posY);
                // MessageBox.Show("right: " + e.ClickedRow.Text);
            }
            else
            {
                // MessageBox.Show("left: " + e.ClickedRow.Text);
            }

            //if (MainChart._ganttChart.isRightClick)
            //{
            //    string a = ObjectDumper.Dump(e.RelatedRow);
            //    string b = ObjectDumper.Dump(e.ClickedTimeBlock);
            //    MessageBox.Show("right: " + e.ClickedTimeBlock.ToString()
            //        + Environment.NewLine + Environment.NewLine
            //        + a
            //        + Environment.NewLine + Environment.NewLine
            //        + b);

            //    e.ClickedTimeBlock.Text = "yeni text";
            //}
            //string bo = ObjectDumper.Dump(e.ClickedTimeBlock);
            //MessageBox.Show(bo);


        }
        private void settingsTimeBlock(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string newname = menuItem.Text;
            ChartFuncs.FormTimeBlock settings = new ChartFuncs.FormTimeBlock();
            settings.Text = menuItem.Text;
            settings.row = (Row)_tempRow;
            settings.TimeBlock = (TimeBlock)menuItem.Tag;
            settings.process = 0;
            settings.ShowDialog();

        }

        private void editTimeBlock(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string newname = (_tempTimeBlock as TimeBlock).Text;
            FormEditText formEditRowName = new FormEditText();
            formEditRowName.obj = menuItem.Tag;
            string renamingStr = Locales.Local.strRename;
            formEditRowName.process = 3;
            formEditRowName.Text = renamingStr;
            formEditRowName.label1.Text = renamingStr;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmRename;
            formEditRowName.ShowDialog();

        }
        private void hideTimeBlock(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string todelete = (_tempTimeBlock as TimeBlock).Text;
            DialogResult dialogResult = MessageBox.Show(string.Format(Locales.Local.wrnHideTimeBlock, todelete), "?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    TimeBlock comingtb = (TimeBlock)menuItem.Tag;
                    comingtb.IsVisible = !comingtb.IsVisible;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Nothing has been changed");
                }
            }
        }



        private void deleteTimeBlock(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string todelete = (_tempTimeBlock as TimeBlock).Text;
            DialogResult dialogResult = MessageBox.Show(
                string.Format(Locales.Local.wrnDeleteTimeBlock, todelete), "?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    TimeBlock comingtb = (TimeBlock)menuItem.Tag;
                    Row row = (Row)_tempRow;
                    row.TimeBlocks.Remove(comingtb);
                    _tempRow = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Nothing has been changed");
                }

            }

        }

        private void sortAlAZ(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(Locales.Local.wrnSortAllRows, "?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                RowFuncs.SortAllRows(false);
        }
        private void sortAllZA(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(Locales.Local.wrnSortAllRows, "?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                RowFuncs.SortAllRows(true);
        }

        private void HideRow(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                string.Format(Locales.Local.wrnHide, (_tempRow as Row).Text),
                "?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                RowFuncs.HideRow(_tempRow as Row);
        }


        private void SetRowIcon(object sender, EventArgs e)
        {
            string todelete = (_tempRow as Row).Text;
            Threads.GetIconsToRAM();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog(this);
            string command = string.Empty;
            if (Threads._iconPath != null || Threads._iconRawName != null)
            {
                bool existname = Threads._iconRawName.Exists(x => x == todelete);

                if (existname)
                {
                    command = @"UPDATE Icons SET IconAdress = " + "'" + fileDialog.FileName + "'"
                                    + " WHERE RowName = " + "'" + todelete + "'";
                }
                else
                {
                    command = @"INSERT INTO Icons (RowName,IconAdress) Values ('" +
                                todelete + "','" + fileDialog.FileName + "')";
                }
            }
            else
            {
                return;
            }
            SQLiteConnection con = new SQLiteConnection("data source=" + Threads.FullPathFilenameDB);
            SQLiteCommand com = new SQLiteCommand(con);
            con.Open();
            com.CommandText = command;
            com.ExecuteNonQuery();
            con.Close();
            Threads.GetIconsToRAM();
            Threads.ApplyIcons();

        }

        private void DeleteRowIcon(object sender, EventArgs e)
        {
            string todelete = (_tempRow as Row).Text;

            Threads.GetIconsToRAM();

            string command = string.Empty;
            if (Threads._iconPath != null || Threads._iconRawName != null)
            {
                bool existname = Threads._iconRawName.Exists(x => x == todelete);

                if (existname)
                {
                    command = @"DELETE FROM Icons"
                    + " WHERE RowName = " + "'" + todelete + "'";
                }
                Row row = MainChart.FindRowWithText(todelete);
                row.Icon = null;
                SQLiteConnection con = new SQLiteConnection("data source=" + Threads.FullPathFilenameDB);
                SQLiteCommand com = new SQLiteCommand(con);
                con.Open();
                com.CommandText = command;
                com.ExecuteNonQuery();
                con.Close();
                return;

            }
            else
            {
                Row row = MainChart.FindRowWithText(todelete);
                row.Icon = null;
                return;
            }
        }

        private void editRow(object sender, EventArgs e)
        {
            string newname = (_tempRow as Row).Text;

            FormEditText formEditRowName = new FormEditText();
            formEditRowName.toEditRow = newname;
            formEditRowName.process = 0;
            formEditRowName.Text = Locales.Local.strRename;
            formEditRowName.label1.Text = Locales.Local.strRename;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmRename;
            formEditRowName.ShowDialog();

        }

        private void deleteRow(object sender, EventArgs e)
        {
            string todelete = (_tempRow as Row).Text;
            DialogResult dialogResult = MessageBox.Show(string.Format(Locales.Local.wrnDeleteRow, todelete), "?" + todelete, MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                RowFuncs.RemoveRow(todelete);

        }

        private void clearRow(object sender, EventArgs e)
        {
            string todelete = (_tempRow as Row).Text;
            DialogResult dialogResult = MessageBox.Show(string.Format(Locales.Local.wrnClearRow, todelete), "?" + todelete, MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                RowFuncs.ClearRow(todelete);

        }

        private void RowDoubleClick(RowClickedEventArgs e)
        {
            if (!MainChart._ganttChart.isRightClick)
            {
                _tempRow = e.ClickedRow;
                _tempEditRowname = e.ClickedRow.Text;
                editRow(null, null);
            }


        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;
            Threads.GetLanguage();
            DoTranslation();
            Threads.CreateDB();
            Threads.GetIconsToRAM();
            Threads.ApplyIcons();
        }

        private void DoTranslation()
        {
            this.Text = Threads.ProgramName + " v" + Threads.ProgramVersion;
            FileTool.Text = Locales.Local.toolFile;
            HelpTool.Text = Locales.Local.toolHelp;
            aboutToolStripMenuItem.Text = Locales.Local.stripAbout;
            licenseToolStripMenuItem.Text = Locales.Local.stripLicense;
            exitToolStripMenuItem.Text = Locales.Local.stripExit;
            projectPageToolStripMenuItem.Text = Locales.Local.mainProjectPage;
            projectRepoToolStripMenuItem.Text = Locales.Local.mainProjectRepo;
            restartToolStripMenuItem.Text = Locales.Local.stripRestart;
            toolStripDropDownEdit.Text = Locales.Local.stripEdit;
            settingsToolStripMenuItem.Text = Locales.Local.stripSettings;
            fullScreenToolStripMenuItem.Text = Locales.Local.toolFullScreen;
            newToolStripMenuItem.Text = Locales.Local.toolNew;
            NewRowToolStripMenuItem.Text = Locales.Local.toolNewRow;
            NewRowsToolStripMenuItem.Text = Locales.Local.toolNewRows;
            openChartToolStripMenuItem.Text = Locales.Local.toolOpenChart;
            deleteToolStripMenuItem.Text = Locales.Local.toolDelete;
            DeleteRowToolStripMenuItem.Text = Locales.Local.toolDeleteRow;
            DeleteRowsowsToolStripMenuItem.Text = Locales.Local.toolDeleteRows;
            DeleteAllToolStripMenuItem.Text = Locales.Local.toolDeleteAll;
            saveChangesToolStripMenuItem.Text = Locales.Local.toolSaveChanges;
            advancedToolStripMenuItem.Text = Locales.Local.toolAdvanced;
            openFromClipBoardToolStripMenuItem.Text = Locales.Local.toolAdvancedPasteChart;
            copyEverythingToClipboardToolStripMenuItem.Text = Locales.Local.toolAdvancedCopyChart;
        }

        #region toolstrip items
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => AppQuiting();
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e) => AppRestarting();

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Threads.ShowAbout();
        }

        private void projectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Threads.ProgramPage);
        }

        private void projectRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Threads.ProgramRepo);
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLicense license = new FormLicense();
            license.ShowDialog();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locales.Local.Culture = new System.Globalization.CultureInfo("");
            Settings.Default.Language = 0;
            Threads.GetLanguage();
            DoTranslation();
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locales.Local.Culture = new System.Globalization.CultureInfo("tr-TR");
            Settings.Default.Language = 1;
            Threads.GetLanguage();
            DoTranslation();

        }
        #endregion toolstrip items

        private static void AppQuiting()
        {
            if (Settings.Default.ConfirmExiting)
            {
                DialogResult result = MessageBox.Show(Locales.Local.confirmExit, Locales.Local.confirmExitTitle,
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        Application.Exit();
                        break;
                    default:
                        return;
                }

            }
            else
            {
                Application.Exit();
            }
        }

        private static void AppRestarting()
        {
            if (Settings.Default.ConfirmRestart)
            {
                DialogResult result = MessageBox.Show(Locales.Local.confirmRestart, Locales.Local.confirmRestartTitle,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        Application.Restart();
                        break;
                    default:
                        return;
                }
            }
            else
            {
                Application.Restart();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // user kapatıyorsa
            {
                e.Cancel = true;
                AppQuiting();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
            MainChart.GetChartBGFromSettings(MainChart._ganttChart);
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoFullScreen.FullScreen(this);
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditText formEditRowName = new FormEditText();
            string proc = Locales.Local.strAddRow;
            formEditRowName.Text = proc;
            formEditRowName.process = 1;
            formEditRowName.label1.Text = proc;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmAddRow;
            formEditRowName.ShowDialog();
        }

        private void rowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditText formEditRowName = new FormEditText();
            string proc = Locales.Local.strAddRows;
            formEditRowName.Text = proc;
            formEditRowName.process = 2;
            formEditRowName.label1.Text = proc;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmAddRows;
            formEditRowName.ShowDialog();
        }


        private void everythingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Threads.AskForDeleteAllRows())
            {
                MainChart._ganttChart.Rows.Clear();
            }


        }



        private void everythingToolStripMenuItemExceptThis_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string todelete = (_tempRow as Row).Text;
            Threads.settingsAskCountValidate();
            bool delete = false;
            for (int i = 1; i <= Settings.Default.askCountDeleteEverything; i++)
            {
                DialogResult dialogResult = MessageBox.Show(string.Format(Locales.Local.wrnDeleteAllRowsExcept, todelete),
                    "?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (i == Settings.Default.askCountDeleteEverything)
                    {
                        delete = true;
                        break;
                    }
                    continue;
                }
                else
                {
                    delete = false;
                    break;
                }

            }
            if (delete)
            {
                foreach (Row item in MainChart._ganttChart.Rows.ToArray())
                {
                    if (item.Text != todelete)
                    {
                        MainChart._ganttChart.Rows.Remove(item);
                    }
                }
            }

            MainChart._ganttChart.UpdateView();


        }

        private void rowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEditText formEditRowName = new FormEditText();
            string proc = Locales.Local.strDeleteRow;
            formEditRowName.Text = proc;
            formEditRowName.process = 4;
            formEditRowName.label1.Text = proc;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmDelete;
            formEditRowName.ShowDialog();
        }

        private void rowsToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            FormEditText formEditRowName = new FormEditText();
            string proc = Locales.Local.strDeleteRows;
            formEditRowName.Text = proc;
            formEditRowName.process = 5;
            formEditRowName.label1.Text = proc;
            formEditRowName.btnEdit.Text = Locales.Local.strConfirmDeletes;
            formEditRowName.ShowDialog();
        }


        private void copyEverythingToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string all = Threads.GetMainChartInString();
            Clipboard.SetText(all);

        }



        private void openFromClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditText formEditText = new FormEditText();
            formEditText.Text = Locales.Local.strOpenChartWithString;
            formEditText.label1.Text = Locales.Local.strOpenChartWithString;
            formEditText.btnEdit.Text = Locales.Local.strConfirmOpenChart;
            formEditText.process = 6;
            formEditText.ShowDialog();
        }

        private void SaveChangesToolStripMenuItem_Click(object sender, EventArgs e) => Threads.SaveChangesRows();


        private void openChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "json";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "json (*.json)|*.json";

            openFileDialog.ShowDialog();
            string file = openFileDialog.FileName;
            if (file != null && file != "" && file != " ")
            {
                DialogResult dialogResult = MessageBox.Show(Locales.Local.wrnSaveCurrentChart, "?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    Threads.SaveChangesRows();
                }
                MainChart._ganttChart.Rows.Clear();
                string rows = string.Empty;
                rows = File.ReadAllText(file);
                rows = HelperFuncs.StringFuncs.TrimStart(rows, Environment.NewLine);
                rows = HelperFuncs.StringFuncs.TrimEnd(rows, Environment.NewLine);
                string[] rowsall = rows.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                List<Row> deserializedRows = new List<Row>();
                foreach (string item in rowsall)
                {
                    string abc = HelperFuncs.StringFuncs.FixIconError(item); //fix icon error
                    deserializedRows.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Row>(abc));
                }
                foreach (Row item in deserializedRows)
                {
                    MainChart._ganttChart.Rows.Add(item);
                }
            }
        }


    }
}

