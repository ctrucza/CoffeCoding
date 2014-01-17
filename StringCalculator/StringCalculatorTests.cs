using System;
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
            if (numbers == "")
                return 0;
            var bunchOfIntegers = ParseNumbers(numbers);
            return bunchOfIntegers.Sum();
        }

        private IEnumerable<int> ParseNumbers(string numbers)
        {

            var lines = SplitNumbersIntoLines(numbers).ToList();

            char delimiter = GetDelimiter(lines);
            
            return GetNumberLines(lines, delimiter);
        }

        private IEnumerable<int> GetNumberLines(IEnumerable<string> lines, char delimiter)
        {
            List<int> result = new List<int>();
            var operationLines = lines.Where(line => !line.StartsWith("//"));
            foreach (var line in operationLines)
            {
                result.AddRange(GetNumbersInLine(line, delimiter));
            }
            return result;
        }

        private char GetDelimiter(IEnumerable<string> lines)
        {
            char delimiter = ',';

            var delimiterLine = lines.SingleOrDefault(line => line.StartsWith("//"));
            if (delimiterLine != null)
                delimiter = GetDelimiterFromLine(delimiterLine);

            return delimiter;
        }

        private char GetDelimiterFromLine(string delimiterLine)
        {
            return delimiterLine.Substring(2,1)[0];
        }

        private IEnumerable<int> GetNumbersInLine(string line, char delimiter)
        {
            var bunchOfNumbers = SplitNumbers(line, delimiter);
            if (bunchOfNumbers.Any(number => number == ""))
                throw new ArgumentException(line);

            var bunchOfIntegers = TransformNumbers(bunchOfNumbers);
            return bunchOfIntegers;
        }

        private IEnumerable<string> SplitNumbersIntoLines(string numbers)
        {
            return numbers.Split('\n');
        }

        private IEnumerable<int> TransformNumbers(IEnumerable<string> bunchOfNumbers)
        {
            var result = new List<int>();
            foreach (string number in bunchOfNumbers)
            {
                result.Add(NumberAsInt(number));
            }
            return result;
        }

        private int NumberAsInt(string number)
        {
            return Int32.Parse(number);
        }

        private IEnumerable<string> SplitNumbers(string numbers, char delimiter)
        {
            return numbers.Split(delimiter);
        }
    }
}