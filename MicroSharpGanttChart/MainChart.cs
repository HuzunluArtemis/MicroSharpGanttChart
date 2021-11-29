using GanttChart;
using System;

namespace MicroSharpGanttChart
{
    internal static class MainChart
    {


        internal static Chart _ganttChart = new Chart();


        internal static void GetChartBGFromSettings(Chart ganttChart)
        {

            MainChart._ganttChart.StartDate = DateTime.Today.AddDays(Settings.Default.ShowBackDays);
            MainChart._ganttChart.EndDate = DateTime.Today.AddDays(Settings.Default.DaysInChart);
            MainChart.ValidateDates();

            ganttChart.BackgroundColor = Settings.Default.ChartBG;
            ganttChart.ShowNowIndicator = Settings.Default.ShowNowIndicator;
            //

            MainChart._ganttChart.StartHourInDay = Settings.Default.StartHourInDay;
            MainChart._ganttChart.EndHourInDay = Settings.Default.EndHourInDay;

            //
            MainChart._ganttChart.indicatorTopTriangle = Settings.Default.indicatorTopTriangle;
            MainChart._ganttChart.indicatorBottomTriangle = Settings.Default.indicatorBottomTriangle;
            MainChart._ganttChart.indicatorColor = Settings.Default.indicatorColor;

            MainChart.ValidateHours();
            //

            ganttChart.UpdateView();
        }
        internal static Row FindRowWithText(string text)
        {
            return MainChart._ganttChart.Rows.Find(x => x.Text == text);
        }

        internal static int CountSameText(string rowname)
        {
            System.Collections.Generic.List<Row> rows = MainChart._ganttChart.Rows.FindAll(x => x.Text == rowname);
            return rows.Count;
        }

        #region validate variables

        internal static int ValidateNotZeroOrNegative(int sample)
        {
            if (sample <= 0)
                return 1;
            else
                return sample;
        }
        internal static void ValidateDates()
        {
            if (MainChart._ganttChart.StartDate >= MainChart._ganttChart.EndDate)
                MainChart._ganttChart.StartDate = MainChart._ganttChart.EndDate.AddDays(-1);
        }

        internal static void ValidateHours()
        {
            MainChart.ValidateNotZeroOrNegative(MainChart._ganttChart.EndHourInDay);
            MainChart.ValidateNotZeroOrNegative(MainChart._ganttChart.EndHourInDay);
            //
            if (MainChart._ganttChart.StartHourInDay > 23)
                MainChart._ganttChart.StartHourInDay = 23;
            if (MainChart._ganttChart.StartHourInDay < 0)
                MainChart._ganttChart.StartHourInDay = 0;
            if (MainChart._ganttChart.EndHourInDay > 24)
                MainChart._ganttChart.EndHourInDay = 24;
            if (MainChart._ganttChart.EndHourInDay < 0)
                MainChart._ganttChart.EndHourInDay = 0;
            if (MainChart._ganttChart.StartHourInDay >= MainChart._ganttChart.EndHourInDay)
            {
                MainChart._ganttChart.StartHourInDay = Threads.StartHourInDay;
                MainChart._ganttChart.EndHourInDay = Threads.EndHourInDay;
            }
        }
        #endregion validate variables
    }
}
