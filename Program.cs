namespace CronParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var parser = new CronParser();
             var result = parser.Parse(args[0]);

             Console.WriteLine(FormatOutput(result));
        }

        private static string FormatOutput(CronParsingResult result) {
            return $"{"minute", -20}{result.Minute}{Environment.NewLine}"
                    + $"{"hour", -20}{result.Hour}{Environment.NewLine}"
                    + $"{"day of month", -20}{result.DayOfMonth}{Environment.NewLine}"
                    + $"{"month", -20}{result.Month}{Environment.NewLine}"
                    + $"{"day of week", -20}{result.DayOfWeek}{Environment.NewLine}"
                    + $"{"command", -20}{result.Command}{Environment.NewLine}";
        }
    }
}
