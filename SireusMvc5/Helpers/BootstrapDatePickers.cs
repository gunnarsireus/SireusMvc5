using System;
using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapDatePickers
    {
        public static MvcHtmlString BootstrapDatePickerThisMonth(this HtmlHelper helper, string id,
            Enums.DatePickerStyle style)
        {
            var format =
                "<div id=\"{0}\" data-date-language=\"sv\" data-date-format=\"yyyy-mm-dd\" " +
                "data-date-today-highlight=\"true\" data-date-week-start=\"1\" {1} " +
                "data-date=\"{2}\" data-date-start-date=\"{3}\" data-date-end-date=\"{4}\"></div>";
            var now = DateTime.Now;
            var todaydate = now.ToString(@"yyyy-MM-dd");
            var firstdate = now.ToString(@"yyyy-MM-01");
            var finaldate = now.ToString(@"yyyy-MM-") + DateTime.DaysInMonth(now.Year, now.Month);
            return new MvcHtmlString(string.Format(format, id, ToBootstrapStyle(style), todaydate, firstdate, finaldate));
        }

        public static MvcHtmlString BootstrapDatePickerPickMonth(this HtmlHelper helper, string id)
        {
            var format =
                "<div id=\"{0}\" data-date-language=\"sv\" data-date-format=\"yyyy-mm\" " +
                "data-min-view-mode=\"months\" data-start-view=\"year\" " +
                "data-date=\"{1}\" data-date-end-date=\"{2}\"></div>";
            var now = DateTime.Now;
            var todaydate = now.ToString(@"yyyy-MM-dd");
            return new MvcHtmlString(string.Format(format, id, todaydate, todaydate));
        }

        private static string ToBootstrapStyle(Enums.DatePickerStyle style)
        {
            switch (style)
            {
                case Enums.DatePickerStyle.Plain:
                    return "";
                case Enums.DatePickerStyle.Weeks:
                    return "data-date-calendar-weeks=\"true\"";
                case Enums.DatePickerStyle.TodayButton:
                    return "data-date-today-btn=\"linked\"";
                case Enums.DatePickerStyle.WeeksAndTodayButton:
                    return "data-date-calendar-weeks=\"true\" data-date-today-btn=\"linked\"";
                default:
                    return "";
            }
        }
    }
}