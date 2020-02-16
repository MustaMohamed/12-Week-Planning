using System;

namespace Framework.Constants
{
    public static class Calender
    {
        public const short DaysOfWeek = 7;
        public static int DaysOfMonth => DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);
        public static int DaysOfFebruary => DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);
    }
}