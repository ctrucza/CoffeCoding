using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Add_SingleNumber_ReturnsNumber(string numbers, int expected)
        {
            Assert.AreEqual(expected, Add(numbers));
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, Add(""));
        }

        [Test]
        [TestCase("1,1",2)]
        [TestCase("1,1,1",3)]
        [TestCase("1,2,3",6)]
        public void Add_ManyNumbers_ResturnsTheirSum(string numbers, int expected)
        {
            Assert.AreEqual(expected, Add(numbers));
        }

        [Test]
        public void Add_NewLine_TreatedAsSeparator()
        {
            Assert.AreEqual(3,Add("1\n2"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_TwoSeparatorsNextToEachOther_IsError()
        {
            Add("1\n,2");
        }

        [Test]
        public void Add_WithCustomDelimiter_UsesTheCustomDelimiter()
        {
            Assert.AreEqual(3, Add("//%\n1%2"));
        }

        private int Add(string numbers)
        {
            StringCalculator c = new StringCalculator();
            return c.Add(numbers);

        }


    }
}