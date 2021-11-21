using NUnit.Framework;

namespace CronParser.Tests {

    [TestFixture]    
    public class CronParserTests {
        
        [TestCaseSource(nameof(TestCases))]
        public void ParseTest(string input, CronParsingResult expected) {           
            var parser = new CronParser();

            var actual = parser.Parse(input);

            Assert.AreEqual(expected, actual); 
        }

        static object[] TestCases = {
            new object[] {"1 2 3 4 5 /usr/bin/find", new CronParsingResult("1","2","3","4","5","/usr/bin/find")},
            new object[] {"1,2 2 3 4 5 /usr/bin/find", new CronParsingResult("1 2","2","3","4","5","/usr/bin/find")},
            new object[] {"1-5 2 3 4 5 /usr/bin/find", new CronParsingResult("1 2 3 4 5","2","3","4","5","/usr/bin/find")},
            new object[] {"1-5/2 2 3 4 5 /usr/bin/find", new CronParsingResult("1 3 5","2","3","4","5","/usr/bin/find")},
            new object[] {"*/15 2 3 4 5 /usr/bin/find", new CronParsingResult("0 15 30 45","2","3","4","5","/usr/bin/find")}
        };
    }
}