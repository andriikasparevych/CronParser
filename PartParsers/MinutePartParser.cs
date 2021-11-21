namespace CronParser.PartParsers
{
    internal class MinutePartParser : CronPartParser
    {
        public override int MaxValue => 59;
    }
}
