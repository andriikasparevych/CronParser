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
            
            return new CronParsingResult(ConvertToString(ParseCronExpression(minute)),
                                        ConvertToString(ParseCronExpression(hour)),
                                        ConvertToString(ParseCronExpression(dayOfMonth)),
                                        ConvertToString(ParseCronExpression(month)),
                                        ConvertToString(ParseCronExpression(dayOfWeek)),
                                        command);
        }

        private IEnumerable<int> ParseCronExpression(string input) {

            var commaParts = input.Split(',');
            if (commaParts.Length > 1) {
                return commaParts.SelectMany(ParseCronExpression);
            }

            var slashParts = input.Split('/');
            if (slashParts.Length > 1) {
                var expression = slashParts[0];
                var everyModifier = int.Parse(slashParts[1]);

                var iterations = ParseCronExpression(expression);
                return iterations.Where((value, index) => index % everyModifier == 0).ToArray();
            }

            var dashParts = input.Split('-');
            if (dashParts.Length > 1) {
                var from = int.Parse(dashParts[0]);
                var to = int.Parse(dashParts[1]);
                return Enumerable.Range(from, to);
            }

            return new [] { int.Parse(input) };
        }

        private static string ConvertToString(IEnumerable<int> intArr) {
            return string.Join(' ', intArr);
        }
    }
    
    public class CronPartParser {
        public int MaxValue { get; }

    } 


    public record CronParsingResult(string Minute, string Hour, string DayOfMonth, string Month, string DayOfWeek, string Command) {
    }
}
