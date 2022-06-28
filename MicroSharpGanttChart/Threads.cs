// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using GanttChart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MicroSharpGanttChart
{
    internal static class Threads
    {
        #region program strings

        internal readonly static string ProgramName = "MicroSharpGanttChart";
        internal readonly static string ProgramLittleName = "MSGC";
        internal readonly static string ProgramVersion = "0.1";
        internal readonly static string CurrentYear = DateTime.Now.Year.ToString();

        // about

        internal readonly static string AboutText = "Copyright © " + CurrentYear + " " + ProgramName + " by HuzunluArtemis"
            + Environment.NewLine + Environment.NewLine
            + "Github/Gitlab: @HuzunluArtemis" + Environment.NewLine
            + "Telegram Channel: @HuzunluArtemis" + Environment.NewLine
            + "License: https://www.gnu.org/licenses/gpl-3.0" + Environment.NewLine + Environment.NewLine
            + ProgramName + " is Free Software: You can use, study share and improve it at your will. Specifically you can redistribute and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version." + Environment.NewLine + Environment.NewLine;
        internal readonly static string ProgramPage = "https://huzunluartemis.github.io/" + ProgramName;
        internal readonly static string ProgramRepo = "https://github.com/huzunluartemis/" + ProgramName;
        internal readonly static string ProgramLicense = ProgramRepo + "/blob/main/LICENSE";


        // files & folders


        internal readonly static string ProgramDataDir = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), ProgramName);

        internal readonly static string FilenameDB = ProgramName + ".Main.db";
        internal readonly static string FilenameRowsDB = ProgramName + ".Rows.json";
        internal readonly static string FullPathFilenameDB = Path.Combine(ProgramDataDir, FilenameDB);
        internal readonly static string FullPathFilenameRowsDB = Path.Combine(ProgramDataDir, FilenameRowsDB);


        //default vars

        internal readonly static Color defaultChartBGColor = Color.FromArgb(240, 230, 250);
        internal readonly static int DaysInChart = 7;
        internal readonly static int ShowBackDays = 0;
        internal readonly static bool ShowNowIndicator = true;
        internal readonly static int StartHourInDay = 8;
        internal readonly static int EndHourInDay = 17;

        // indicator
        internal readonly static bool indicatorTopTriangle = true;
        internal readonly static bool indicatorBottomTriangle = true;
        internal readonly static Color indicatorColor = Color.Red;

        internal readonly static bool SaveAndCloseSettings = false;

        // icon list from db
        internal static List<string> _iconRawName = new List<string>();
        internal static List<string> _iconPath = new List<string>();

        // default ask count
        internal static short defaultAskCount = 3;

        #endregion program strings


        internal static void SetChartBG(Chart ganttChart, Color color)
        {
            ganttChart.BackgroundColor = color;
            ganttChart.UpdateView();
        }
        internal static bool ProgramDirExist()
        {
            try
            {
                if (Directory.Exists(ProgramDataDir))
                {
                    return true;
                }

                else
                {
                    Directory.CreateDirectory(ProgramDataDir);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                throw;
            }

        }

        #region get translations for everywhere


        internal static void GetLanguage()
        {
            // 0 = english
            // 1 = turkish

            switch (Settings.Default.Language)
            {
                case 0:
                    Locales.Local.Culture = new System.Globalization.CultureInfo("");
                    break;
                case 1:
                    Locales.Local.Culture = new System.Globalization.CultureInfo("tr-TR");
                    break;
            }
            Settings.Default.Save();
        }
        #endregion get translations for everywhere

        #region create database for settings

        internal static void CreateDB()
        {
            if (File.Exists(FullPathFilenameDB))
                return;
            else
            {
                try
                {
                    CreateProgramDir();

                    SQLiteConnection.CreateFile(FullPathFilenameDB);
                    SQLiteConnection con = new SQLiteConnection("data source=" + FullPathFilenameDB);
                    SQLiteCommand com = new SQLiteCommand(con);
                    con.Open();
                    //for icons
                    string icon = @"CREATE TABLE IF NOT EXISTS [Icons] (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [RowName] VARCHAR(100) NOT NULL,
                            [IconAdress] VARCHAR(1000) NOT NULL)";
                    com.CommandText = icon;
                    com.ExecuteNonQuery();

                    //for timeblocks, rows

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        internal static void GetIconsToRAM()
        {
            try
            {
                SQLiteConnection connect = new SQLiteConnection("data source=" + FullPathFilenameDB);
                connect.Open();
                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = @"SELECT DISTINCT * FROM Icons";
                fmd.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    string rowname = Convert.ToString(r["RowName"]);
                    string iconadress = Convert.ToString(r["IconAdress"]);
                    _iconPath.Add(iconadress);
                    _iconRawName.Add(rowname);
                }

                connect.Close();
            }
            catch (SQLiteException)
            {
                // ikonlar yok.
            }
        }

        internal static string GetMainChartInString()
        {
            List<string> serializedRows = new List<string>();
            foreach (Row item in MainChart._ganttChart.Rows)
            {
                serializedRows.Add(JsonConvert.SerializeObject(item));
            }
            string all = string.Empty;
            foreach (string item in serializedRows)
            {
                //icons error fix
                string abc = HelperFuncs.StringFuncs.FixIconError(item);
                //
                all += item;
                all += Environment.NewLine;

            }
            all = HelperFuncs.StringFuncs.TrimEnd(all, Environment.NewLine);
            return all;
        }

        internal static bool AskForDeleteAllRows()
        {
            Threads.settingsAskCountValidate();
            for (int i = 1; i <= Settings.Default.askCountDeleteEverything; i++)
            {
                DialogResult dialogResult = MessageBox.Show(Locales.Local.wrnDeleteAllRows,
                    "?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (i == Settings.Default.askCountDeleteEverything)
                    {
                        return true;
                    }
                    continue;

                }
                else
                {
                    return false;
                }

            }
            return false;
        }


        internal static void SaveChangesRows()
        {
            string text = Threads.GetMainChartInString();
            if (File.Exists(Threads.FullPathFilenameRowsDB))
            {
                DialogResult dialogResult = MessageBox.Show(Locales.Local.wrnOverwrite,
                    "?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    File.WriteAllText(Threads.FullPathFilenameRowsDB, text);
                }
            }
            else
            {
                ProgramDirExist();
                File.WriteAllText(Threads.FullPathFilenameRowsDB, text);
            }
        }

        internal static void CreateRowsDatabase()
        {
            if (File.Exists(FullPathFilenameRowsDB))
            {
                string rows = string.Empty;
                rows = File.ReadAllText(FullPathFilenameRowsDB);
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
            else
            {
                Row row1 = new Row("welcome");

                row1.TimeBlocks.Add(new TimeBlock("Shift 1", DateTime.Today.AddHours(0), DateTime.Today.AddHours(13)) { Color = Color.Red });

                Row row2 = new Row("to");
                row2.TimeBlocks.Add(new TimeBlock("Shift 1", DateTime.Today.AddHours(8), DateTime.Today.AddHours(10)) { Color = Color.Yellow });
                row2.TimeBlocks.Add(new TimeBlock("Shift 2", DateTime.Today.AddHours(13), DateTime.Today.AddHours(17)) { Color = Color.Purple });

                Row row3 = new Row("microSharp");
                row3.TimeBlocks.Add(new TimeBlock("Shift 1", DateTime.Today.AddHours(8), DateTime.Today.AddHours(10)) { Color = Color.Yellow });
                row3.TimeBlocks.Add(new TimeBlock("Shift 2", DateTime.Today.AddHours(13), DateTime.Today.AddHours(17)) { Color = Color.Purple });

                Row row4 = new Row("ganttChart");
                row4.TimeBlocks.Add(new TimeBlock("buralarda da sağ tıkla", DateTime.Today.AddHours(8), DateTime.Today.AddHours(10)) { Color = Color.Yellow });
                row4.TimeBlocks.Add(new TimeBlock("bazı yerlere çift tıkla", DateTime.Today.AddHours(13), DateTime.Today.AddHours(17)) { Color = Color.Purple });

                MainChart._ganttChart.Rows.Add(row1);
                MainChart._ganttChart.Rows.Add(row2);
                MainChart._ganttChart.Rows.Add(row3);
                MainChart._ganttChart.Rows.Add(row4);

                //write
                string all = GetMainChartInString();
                string path = FullPathFilenameRowsDB;
                SaveChangesRows();

                File.WriteAllText(path, all + Environment.NewLine, System.Text.Encoding.UTF8);

            }
        }
        internal static void ApplyIcons()
        {
            List<string> _iconRawName = Threads._iconRawName;
            List<string> _iconPath = Threads._iconPath;

            if (_iconPath == null || _iconRawName == null || _iconRawName.Count == 0 || _iconPath.Count == 0)
            {
                if (_iconPath == null || _iconRawName == null)
                {
                    return;
                }
                _iconPath.Clear();
                _iconRawName.Clear();
                Threads._iconRawName.Clear();
                Threads._iconPath.Clear();
                return;
            }

            try
            {
                for (int i = 0; i < MainChart._ganttChart.Rows.Count; i++)
                {
                    MainChart._ganttChart.Rows[i].Icon = null;
                }

                for (int i = 0; i < _iconRawName.Count; i++)
                {
                    if (!MainChart._ganttChart.Rows.Contains(MainChart.FindRowWithText(_iconRawName[i])))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            Image image = Image.FromFile(_iconPath[i]);
                            string rowname = _iconRawName[i];
                            RowFuncs.SetRowIcon(rowname, image);
                        }
                        catch (Exception zo)
                        {
                            MessageBox.Show(zo.Message);
                        }
                    }


                }

                Threads._iconRawName.Clear();
                Threads._iconPath.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        internal static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        internal static bool CreateProgramDir()
        {
            if (!Directory.Exists(ProgramDataDir))
                Directory.CreateDirectory(ProgramDataDir);

            return Directory.Exists(ProgramDataDir);
        }
        #endregion create database for settings

        #region about function

        internal static void ShowAbout()
        {
            DialogResult a = MessageBox.Show(AboutText + Locales.Local.aboutAskGoSource,
                String.Format(Locales.Local.aboutTitle, Threads.ProgramName + " v" + Threads.ProgramVersion),
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
                System.Diagnostics.Process.Start(ProgramPage);
        }

        #endregion about function



        #region label info
        internal static void ShowLabelInfo(Label label, string info, int sleepTime)
        {
            label.Visible = true;
            label.Text = info;
            label.ForeColor = System.Drawing.Color.Crimson;
            Threads.Wait(sleepTime);
        }



        #endregion label info

        internal static void settingsAskCountValidate()
        {

            if (Settings.Default.askCountDeleteEverything <= 0)
            {
                Settings.Default.askCountDeleteEverything = 3;
                Settings.Default.Save();
            }
        }

        #region wait func without ui lock
        internal static void Wait(int milliseconds)
        {
            Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        #endregion wait func without ui lock
    }
}