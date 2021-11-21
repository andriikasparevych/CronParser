using NUnit.Framework;

namespace CronParser.Tests {

    [TestFixture]    
    public class CronParserTests {
        
        [TestCase]
        public void SimpleCaseWithoutSpecialOperators() {
            var input = "1 2 3 4 5 /usr/bin/find";
            var expected = new CronParsingResult("1","2","3","4","5","/usr/bin/find");
            
            var parser = new CronParser();

            var actual = parser.Parse(input);

            Assert.AreEqual(expected, actual); 
        }
    }
}