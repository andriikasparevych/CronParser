namespace CronParser.PartParsers
{
    internal class HourPartParser : CronPartParser
    {
        public override int MaxValue => 23;
    }
}
