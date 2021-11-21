namespace CronParser.PartParsers
{
    internal class DayOfWeekPartParser : CronPartParser
    {
        public override int MinValue => 1;
        public override int MaxValue => 7;
    }
}
