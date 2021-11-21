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
            
            return new CronParsingResult(ParseCronExpression(minute),
                                        ParseCronExpression(hour),
                                        ParseCronExpression(dayOfMonth),
                                        ParseCronExpression(month),
                                        ParseCronExpression(dayOfWeek),
                                        command);
        }

        private string ParseCronExpression(string input) {
            return input;
        }
    }

    public record CronParsingResult(string Minute, string Hour, string DayOfMonth, string Month, string DayOfWeek, string Command) {
    }
}
