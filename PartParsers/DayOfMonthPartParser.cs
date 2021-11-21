namespace CronParser.PartParsers
{
    internal class DayOfMonthPartParser : CronPartParser
    {
        public override int MinValue => 1;
        
        // Assuming all months have 31 days to save time
        public override int MaxValue => 31;
    }
}
