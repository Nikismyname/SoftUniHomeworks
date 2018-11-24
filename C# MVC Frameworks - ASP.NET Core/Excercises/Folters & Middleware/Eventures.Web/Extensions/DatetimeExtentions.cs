namespace Eventures.Web.Extensions
{
    using System;

    public static class DatetimeExtentions
    {
        public static string ToEventuresFormat (this DateTime date)
        {
            return date.ToString("dd-MMM-yyyy hh:mm:ss");
        }
    }
}
