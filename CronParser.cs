using CronParser.PartParsers;

namespace CronParser
{
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

    public record CronParsingResult(string Minute, string Hour, string DayOfMonth, string Month, string DayOfWeek, string Command) {
    }
}
