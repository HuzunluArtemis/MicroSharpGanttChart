// Copyright © 2021 HuzunluArtemis. Licensed under GPL-v3 (https://www.gnu.org/licenses/gpl-3.0.html)
using System;
using System.Collections.Generic;
using System.Drawing;
using MicroSharpGanttChart.HelperFuncs;
using System.Windows.Forms;
using GanttChart;

namespace MicroSharpGanttChart
{
    public partial class FormEditText : Form
    {
        internal string toEditRow;
        internal int process;
        internal object obj;
        // 0 = rename row
        // 1 = add row
        // 2 = add rows
        // 3 = rename timeblock
        // 4 = delete row 
        // 5 = delete rows
        // 6 = open chart from clipboard
        public FormEditText()
        {
            InitializeComponent();
        }

        private void FormEditRowName_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(int.MaxValue, 94);
            this.MinimumSize = new Size(402, 94);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;

            if (process == 2 || process == 5)
            {
                string info = Locales.Local.tooltipSampleAddMultiRow;
                ToolTip toolTip = new ToolTip();
                txtEdit.ForeColor = Color.Blue;
                toolTip.SetToolTip(txtEdit, info);
                toolTip.SetToolTip(this, info);
                toolTip.SetToolTip(btnEdit, info);
                toolTip.SetToolTip(label1, info);
            }
            if (process == 6) txtEdit.Multiline = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtEdit.Text = txtEdit.Text.Trim();

            if (!StringFuncs.IsValidString(txtEdit.Text))
            {
                MessageBox.Show(Locales.Local.wrnNotValidString
                    + Environment.NewLine
                    + Locales.Local.wrnNothingChanged);
                return;
            }
            switch (process)
            {
                case 0:
                    int ro = MainChart.CountSameText(txtEdit.Text);
                    if (ro > 0)
                    {
                        MessageBox.Show(Locales.Local.wrnSameRowAvailable);
                        this.Close();
                        return;
                    }
                    RowFuncs.EditRow(toEditRow, txtEdit.Text);
                    break;
                case 1:
                    {
                        int rowcount = MainChart.CountSameText(txtEdit.Text);
                        if (rowcount > 0)
                        {
                            MessageBox.Show(Locales.Local.wrnSameRowAvailable);
                            this.Close();
                            return;
                        }
                        Row row = new Row(txtEdit.Text);
                        MainChart._ganttChart.Rows.Add(row);
                        break;
                    }
                case 2:
                    {
                        string text = txtEdit.Text.Trim('|');
                        string[] list = text.Split('|');
                        List<string> cannotadded = new List<string>();
                        foreach (string item in list)
                        {
                            string itemm = StringFuncs.CleanString(item);
                            int rowcount = MainChart.CountSameText(itemm);
                            if (rowcount > 0) cannotadded.Add(itemm);
                            else
                            {
                                Row row = new Row(itemm);
                                MainChart._ganttChart.Rows.Add(row);
                            }

                        }
                        if (cannotadded.Count > 0)
                        {
                            string joined = string.Join(", ", cannotadded);
                            joined = joined.Trim();
                            MessageBox.Show(String.Format(Locales.Local.wrnSameRowsAvailable, joined));
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            TimeBlock typed = (TimeBlock)obj;
                            typed.Text = txtEdit.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString() + Environment.NewLine +
                                Environment.NewLine + Locales.Local.wrnNothingChanged);
                        }
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            Row typed = MainChart.FindRowWithText(txtEdit.Text);
                            if (typed == null)
                            {
                                MessageBox.Show("Cannot find row: " + txtEdit.Text);
                                return;
                            }
                            MainChart._ganttChart.Rows.Remove(typed);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString() + Environment.NewLine +
                                Environment.NewLine + Locales.Local.wrnNothingChanged);
                        }
                        break;
                    }
                case 5:
                    {
                        string text = txtEdit.Text.Trim('|');
                        string[] list = text.Split('|');
                        List<string> cannotadded = new List<string>();
                        foreach (string item in list)
                        {
                            string itemm = StringFuncs.CleanString(item);
                            Row typed = MainChart.FindRowWithText(itemm);
                            if (typed == null) cannotadded.Add(itemm);
                            else MainChart._ganttChart.Rows.Remove(typed);


                        }
                        if (cannotadded.Count > 0)
                        {
                            string joined = string.Join(", ", cannotadded);
                            joined = joined.Trim();
                            MessageBox.Show(String.Format(Locales.Local.wrnSameRowsAvailable, joined));
                        }

                        break;
                    }
                case 6:
                    {
                        if (Threads.AskForDeleteAllRows())
                        {
                            MainChart._ganttChart.Rows.Clear();
                            string rows = txtEdit.Text;
                            rows = HelperFuncs.StringFuncs.TrimStart(rows, Environment.NewLine);
                            rows = HelperFuncs.StringFuncs.TrimEnd(rows, Environment.NewLine);
                            string[] rowsall = rows.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                            List<Row> deserializedRows = new List<Row>();
                            foreach (string item in rowsall)
                            {
                                //icons error fix
                                string abc = HelperFuncs.StringFuncs.FixIconError(item);
                                deserializedRows.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Row>(abc));
                            }
                            foreach (Row item in deserializedRows) MainChart._ganttChart.Rows.Add(item);
                        }

                        break;
                    }
            }
            Threads.GetIconsToRAM();
            Threads.ApplyIcons();
            MainChart._ganttChart.UpdateView();
            this.Close();
        }

        private void txtEdit_TextChanged(object sender, EventArgs e)
        {
            if (process == 0 || process == 1)
            {
                int rowcount = MainChart.CountSameText(txtEdit.Text);
                ToolTip toolTip = new ToolTip();
                if (rowcount > 0)
                {
                    txtEdit.ForeColor = Color.Red;

                    toolTip.SetToolTip(txtEdit, Locales.Local.wrnSameRowAvailable);
                }
                else
                {
                    txtEdit.ForeColor = Color.Blue;
                    toolTip.SetToolTip(txtEdit, Locales.Local.wrnNoProblem);
                }
            }
        }

        private void txtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEdit_Click(null, null);
        }
    }
}
