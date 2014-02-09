using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private static StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Add_SingleNumber_ReturnsNumber(string numbers, int expected)
        {
            Assert.AreEqual(expected, stringCalculator.Add(numbers));
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, stringCalculator.Add(""));
        }

        [Test]
        [TestCase("1,1",2)]
        [TestCase("1,1,1",3)]
        [TestCase("1,2,3",6)]
        public void Add_ManyNumbers_ResturnsTheirSum(string numbers, int expected)
        {
            Assert.AreEqual(expected, stringCalculator.Add(numbers));
        }

        [Test]
        public void Add_NewLine_TreatedAsSeparator()
        {
            Assert.AreEqual(3,stringCalculator.Add("1\n2"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_TwoSeparatorsNextToEachOther_IsError()
        {
            stringCalculator.Add("1\n,2");
        }

        [Test]
        public void Add_WithCustomDelimiter_UsesTheCustomDelimiter()
        {
            Assert.AreEqual(3, stringCalculator.Add("//%\n1%2"));
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1")]
        public void Add_NegativeNumber_ThrowsAndIncludesTheNumber()
        {
            StringCalculator calculator = new StringCalculator();
            calculator.Add("-1");
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1, -2")]
        public void Add_TwoNegativeNumbers_ThrowsAndIncludesBothNumbers()
        {
            StringCalculator calculator = new StringCalculator();
            calculator.Add("-1, -2");
        }

        [Test]
        public void Add_NumbersGreaterThan1000_AreIgnored()
        {
            StringCalculator calculator = new StringCalculator();
            Assert.AreEqual(2, calculator.Add("2,1001"));
        }
    }
}