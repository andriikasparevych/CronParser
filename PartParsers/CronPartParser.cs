namespace CronParser.PartParsers
{
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
}
