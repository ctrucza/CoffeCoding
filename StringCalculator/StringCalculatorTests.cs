using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private int Add(string numbers)
        {
            var bunchOfIntegers = ParseNumbers(numbers);
            return bunchOfIntegers.Sum();
        }

        private IEnumerable<int> ParseNumbers(string numbers)
        {
            var bunchOfNumbers = SplitNumbers(numbers);
            var bunchOfIntegers = TransformNumbers(bunchOfNumbers);
            return bunchOfIntegers;
        }

        private IEnumerable<int> TransformNumbers(IEnumerable<string> bunchOfNumbers)
        {
            List<int> result = new List<int>();
            foreach (string aNumber in bunchOfNumbers)
            {
                result.Add(NumberAsInt(aNumber));
            }
            return result;
        }

        private int NumberAsInt(string aNumber)
        {
            if (aNumber == "")
                return 0;
            return Int32.Parse(aNumber);
        }

        private IEnumerable<string> SplitNumbers(string numbers)
        {
            return numbers.Split(',');
        }
    }
}