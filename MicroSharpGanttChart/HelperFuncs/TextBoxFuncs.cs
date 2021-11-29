using System.Windows.Forms;

namespace MicroSharpGanttChart.HelperFuncs
{
    internal static class TextBoxFuncs
    {
        /// <summary>
        /// only allow decimal
        /// usage: txtDaysInChart.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigit;
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyPressEventArgs</param>
        internal static void OnlyAllowDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        /// <summary>
        /// only allow decimal and "." 
        /// usage: txtDaysInChart.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigitAndDecimalPoint;
        /// dot can be in start position like: ".2626"
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyPressEventArgs</param>
        internal static void OnlyAllowDigitDotStartDotYes(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;

        }

        /// <summary>
        /// only allow decimal and "." 
        /// usage: txtDaysInChart.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigitAndDecimalPoint;
        /// dot cannot be in start position like: ".2626"
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyPressEventArgs</param>
        internal static void OnlyAllowDigitDotStartDotNo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;


            // only allow one decimal point
            if ((e.KeyChar == '.') && (((sender as TextBox).Text.IndexOf('.') > -1))) e.Handled = true;

            bool isStartsWithDot = (sender as TextBox).Text.StartsWith(".");
            bool isEmpty = (sender as TextBox).Text.Length == 0;

            if ((e.KeyChar == '.') && (isStartsWithDot || isEmpty)) e.Handled = true;

        }

        /// <summary>
        /// only allow decimal and "-" 
        /// usage: txtDaysInChart.KeyPress += HelperFuncs.TextBoxFuncs.OnlyAllowDigitMinus;
        /// minus be in start position like: "-2626"
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyPressEventArgs</param>
        internal static void OnlyAllowDigitMinus(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-')) e.Handled = true;

            // only allow one -
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1)) e.Handled = true;

        }

    }
}
