namespace CronParser.PartParsers
{
    internal class MonthPartParser : CronPartParser
    {
        public override int MinValue => 1;
        public override int MaxValue => 12;

    }
}
