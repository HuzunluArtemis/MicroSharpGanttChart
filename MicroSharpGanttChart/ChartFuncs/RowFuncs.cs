using System;
using System.Drawing;
using System.Windows.Forms;
using GanttChart;
using MicroSharpGanttChart.HelperFuncs;

namespace MicroSharpGanttChart
{
    internal class RowFuncs
    {
        internal static bool EditRow(string old, string news)
        {
            if (!StringFuncs.IsValidString(news))
            {
                MessageBox.Show("Not valid string. nothing has been changed");
                return false;
            }

            int rowcount = MainChart.CountSameText(news);
            if (rowcount > 0)
            {
                MessageBox.Show("same named row found. give another name.");
                return false;
            }

            Row row = MainChart.FindRowWithText(old);
            try
            {
                row.Text = news;
                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        internal static bool RemoveRow(string rowname)
        {
            if (!StringFuncs.IsValidString(rowname))
            {
                MessageBox.Show("Not valid string. nothing has been changed");
                return false;
            }
            try
            {
                Row row = MainChart.FindRowWithText(rowname);
                MainChart._ganttChart.Rows.Remove(row);

                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        internal static bool ClearRow(string rowname)
        {
            if (!StringFuncs.IsValidString(rowname))
            {
                MessageBox.Show("Not valid string. nothing has been changed");
                return false;
            }
            try
            {
                Row row = MainChart.FindRowWithText(rowname);
                string todeletecount = row.TimeBlocks.Count.ToString();
                row.TimeBlocks.Clear();

                MessageBox.Show(todeletecount + " TimeBlocks Deleted.");

                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        internal static bool HideRow(Row row)
        {
            
            try
            {
                bool e = row.IsVisible;
                row.IsVisible = !e;

                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        internal static bool HideRow(string rowname)
        {
            if (!StringFuncs.IsValidString(rowname))
            {
                MessageBox.Show("Not valid string. nothing has been changed");
                return false;
            }
            try
            {
                Row row = MainChart.FindRowWithText(rowname);
                bool e = row.IsVisible;
                row.IsVisible = !e;

                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        internal static bool SetRowIcon(string rowname, Image icon)
        {
            if (!StringFuncs.IsValidString(rowname))
            {
                MessageBox.Show("Not valid string. nothing has been changed");
                return false;
            }
            try
            {
                Row row = MainChart.FindRowWithText(rowname);
                row.Icon = icon;

                MainChart._ganttChart.UpdateView();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        internal static bool SortAllRows(bool reverse = false)
        {
            try
            {
                if (reverse)
                {
                    MainChart._ganttChart.Rows.Sort(CompareByNameZA);
                    return true;
                }
                else
                {
                    MainChart._ganttChart.Rows.Sort(CompareByNameAZ);
                    return true;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        private static int CompareByNameAZ(Row x, Row y)
        {
            return string.Compare(x.Text, y.Text, StringComparison.OrdinalIgnoreCase);

        }

        private static int CompareByNameZA(Row x, Row y)
        {
            return string.Compare(y.Text, x.Text, StringComparison.OrdinalIgnoreCase);

        }
    }
}
