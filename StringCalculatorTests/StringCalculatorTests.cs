using NUnit.Framework;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_SingleNumber_ReturnsNumber()
        {
            Assert.AreEqual(1,Add("1"));
        }

        private int Add(string numbers)
        {
            return 1;
        }
    }
}