namespace CronParser // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new CronParser();
            var result = parser.Parse(args[0]);

            Console.WriteLine(result.ToString());
        }
    }
}
