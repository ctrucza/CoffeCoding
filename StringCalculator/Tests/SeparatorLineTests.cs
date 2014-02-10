using System.Linq;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class SeparatorLineTests
    {
        [Test]
        public void SingleSeparator()
        {
            SeparatorLine separatorLine = new SeparatorLine("//%");
            Assert.AreEqual(1, separatorLine.GetSeparators().Count());
            CollectionAssert.Contains(separatorLine.GetSeparators(), '%');
        }

        [Test]
        public void MultipleSeparators()
        {
            SeparatorLine separatorLine = new SeparatorLine("//[$][%]");
            Assert.AreEqual(2, separatorLine.GetSeparators().Count());
            CollectionAssert.Contains(separatorLine.GetSeparators(), '$');
            CollectionAssert.Contains(separatorLine.GetSeparators(), '%');            
        }
    }
}
