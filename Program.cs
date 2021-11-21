using System;
using System.Collections.Generic;
using System.Linq;

namespace CronParser // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
/*
*\/15 0 1,15 * 1-5 /usr/bin/find

minute 0 15 30 45
hour 0
day of month 1 15
month 1 2 3 4 5 6 7 8 9 10 11 12
day of week 1 2 3 4 5
command /usr/bin/find

*/
    public class CronParser {
        public CronParsingResult Parse(string cron) {
            var parts = cron.Split(' ');
            return Parse(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
        }

        public CronParsingResult Parse(string minute, string hour, string dayOfMonth, string month, string dayOfWeek, string command) {
            
            return new CronParsingResult(ConvertToString(new MinutePartParser().Parse(minute)),
                                        ConvertToString(new HourPartParser().Parse(hour)),
                                        ConvertToString(new DayOfMonthPartParser().Parse(dayOfMonth)),
                                        ConvertToString(new MonthPartParser().Parse(month)),
                                        ConvertToString(new DayOfWeekPartParser().Parse(dayOfWeek)),
                                        command);
        }

        private static string ConvertToString(IEnumerable<int> intArr) {
            return string.Join(' ', intArr);
        }
    }

    internal class MinutePartParser : CronPartParser
    {
        public override int MaxValue => 59;
    }

    internal class HourPartParser : CronPartParser
    {
        public override int MaxValue => 23;
    }

    internal class DayOfMonthPartParser : CronPartParser
    {
        public override int MinValue => 1;
        
        // Assuming all months have 31 days to save time
        public override int MaxValue => 31;
    }

    internal class MonthPartParser : CronPartParser
    {
        public override int MaxValue => 11;
    }

    internal class DayOfWeekPartParser : CronPartParser
    {
        public override int MinValue => 1;
        public override int MaxValue => 7;
    }


    internal abstract class CronPartParser {
        public virtual int MinValue => 0;

        public abstract int MaxValue { get; }

        public IEnumerable<int> Parse(string input) {
            var commaParts = input.Split(',');
            if (commaParts.Length > 1) {
                return commaParts.SelectMany(Parse);
            }

            var slashParts = input.Split('/');
            if (slashParts.Length > 1) {
                var expression = slashParts[0];
                var everyModifier = int.Parse(slashParts[1]);

                var iterations = Parse(expression);
                return iterations.Where((value, index) => index % everyModifier == 0).ToArray();
            }

            var dashParts = input.Split('-');
            if (dashParts.Length > 1) {
                var from = int.Parse(dashParts[0]);
                var to = int.Parse(dashParts[1]);
                return Enumerable.Range(from, to);
            }

            if (input == "*") {
                return GetFullRange();
            }

            return new [] { int.Parse(input) };
        }

        protected IEnumerable<int> GetFullRange() {
            return Enumerable.Range(MinValue, MaxValue);
        }
    } 


    public record CronParsingResult(string Minute, string Hour, string DayOfMonth, string Month, string DayOfWeek, string Command) {
    }
}
