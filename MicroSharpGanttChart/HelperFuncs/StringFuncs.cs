using System;
using System.Windows.Forms;

namespace MicroSharpGanttChart.HelperFuncs
{
    internal static class StringFuncs
    {
        #region unselect textbox

        internal static void UnselectTextbox(TextBox textBox)
        {
            textBox.Select(0, 0);
        }
        internal static void SelectAllTextBox(TextBox textBox)
        {
            textBox.SelectAll();
        }
        internal static void UnselectTextbox(RichTextBox textBox)
        {
            textBox.EnableContextMenu();
            textBox.Select(0, 0);
        }

        #endregion unselect textbox

        internal static string TrimStart(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            if (!string.IsNullOrEmpty(value))
            {
                while (!string.IsNullOrEmpty(inputText) && inputText.StartsWith(value, comparisonType))
                {
                    inputText = inputText.Substring(value.Length - 1);
                }
            }

            return inputText;
        }

        internal static string TrimEnd(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            if (!string.IsNullOrEmpty(value))
            {
                while (!string.IsNullOrEmpty(inputText) && inputText.EndsWith(value, comparisonType))
                {
                    inputText = inputText.Substring(0, (inputText.Length - value.Length));
                }
            }

            return inputText;
        }

        internal static string Trim(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            return TrimStart(TrimEnd(inputText, value, comparisonType), value, comparisonType);
        }

        internal static string FixIconError(string value)
        {
            value = value.Replace("\"Icon\":\"System.Drawing.Bitmap\",", string.Empty);
            return value;
        }

        internal static string CleanString(string itemm)
        {
            itemm = itemm.Replace(" ", "");
            itemm = itemm.Trim();
            return itemm;
        }
        internal static bool IsValidString(string text)
        {
            text = text.Trim();
            bool isnull = string.IsNullOrWhiteSpace(text);
            bool isempty = string.IsNullOrEmpty(text);
            if (isnull || isempty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
