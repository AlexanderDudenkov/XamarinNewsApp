using NUnit.Framework;

using NewsApp.util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    [TestFixture]
    public class FormattingStringTest
    {
        private IFormattingString subject;

        [SetUp]
        public void BeforeTestSuit()
        {
            subject = new FormattingString();
        }

        [TestCase("", "", TestName = "test 1")]
        [TestCase("", "", 100, TestName = "test 2")]
        [TestCase("", "", 0, TestName = "test 3")]
        [TestCase("", "", null, TestName = "test 4")]
        [TestCase("", "", -1, TestName = "test 5")]
        [TestCase("12345678901234567890", "12345678901234567890", TestName = "test 6")]
        [TestCase("1234567890 123456789", "1234567890 123456789", TestName = "test 7")]
        [TestCase("1234567890...", "1234567890 1234567890", TestName = "test 8")]
        [TestCase("12345678901...", "12345678901 234567890", TestName = "test 9")]
        [TestCase("1234567890123456789...", "1234567890123456789 0", TestName = "test 10")]
        [TestCase("1...", "1 2345678901234567890", TestName = "test 11")]
        [TestCase("...", " 12345678901234567890", TestName = "test 12")]
        [TestCase("...", "1234567890123456789012", TestName = "test 13")]
        [TestCase("", null, TestName = "test 14")]
        [TestCase("12345678901234567890...", "12345678901234567890!", TestName = "test 15")]
        [TestCase("12345678901234567890...", "12345678901234567890=", TestName = "test 16")]
        [TestCase("1234567890...", "1234567890-1234567890", TestName = "test 17")]
        [TestCase("...", ":12345678901234567890", TestName = "test 18")]
        [TestCase("12345678901234567890...", "12345678901234567890+1234567890", TestName = "test 19")]
        [TestCase("1234567890 12345...", "1234567890 12345 678901234567890", TestName = "test 20")]
        [TestCase("12345 67890 12345...", "12345 67890 12345 678901234567890", TestName = "test 21")]
        [TestCase("1-2+3*4(5)6[7]8\"9\"0...", "1-2+3*4(5)6[7]8\"9\"0%1 ", TestName = "test 22")]
        public void FormattingDescriptionTest(string exp, string input, int DescLength = 20)
        {
            var output = subject.FormattingDescription(Constants.SYMBOLS, input, DescLength);
            Assert.AreEqual(exp, output);
        }
    }
}
