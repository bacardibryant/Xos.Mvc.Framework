using System;
using System.Collections.Generic;

namespace Xos.Mvc.Framework.Extensions
{
    public static class Extensions
    {
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            var candidateDate = date;
            while (candidateDate.DayOfWeek != DayOfWeek.Sunday)
            {
                candidateDate = candidateDate.AddDays(-1);
            }
            return candidateDate;
        }

        public static DateTime LastDayOfWeek(this DateTime date)
        {
            var candidateDate = date;
            while (candidateDate.DayOfWeek != DayOfWeek.Saturday)
            {
                candidateDate = candidateDate.AddDays(1);
            }

            // set time to just before midnight to include all records for the given date.
            candidateDate = new DateTime(candidateDate.Year, candidateDate.Month, candidateDate.Day, 23, 59, 59, 59);
            return candidateDate;
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            var candidateDate = new DateTime(date.Year, date.Month, 1);
            return candidateDate;
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            // set datetime to just before midnight.
            var candidateDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59,
                59, 59);
            return candidateDate;
        }

        public static int Plus(this int number, int shift)
        {
            return number + shift;
        }

        public static void Times(this int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }

        public static void Times(this int count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(i);
            }
        }

        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}