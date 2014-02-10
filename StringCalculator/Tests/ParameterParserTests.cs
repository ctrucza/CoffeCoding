using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class ParameterParserTests
    {
        private ParameterParser parameterParser;


        [Test]
        public void Parse_EmptyInput_NoNumbers()
        {
            parameterParser = new ParameterParser("");
            CollectionAssert.IsEmpty(parameterParser.GetNumbers());
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Parse_SingleNumber_NumberParsed(string input, int expected)
        {
            parameterParser = new ParameterParser(input);
            List<int> numbers = parameterParser.GetNumbers().ToList();
            Assert.AreEqual(1, numbers.Count());
            CollectionAssert.Contains(numbers, expected);
        }

        [Test]
        [TestCase("1,2", new[]{1,2})]
        [TestCase("1,2,3", new[] { 1, 2, 3 })]
        public void Parse_ManyNumbers_ResturnsTheirSum(string input, int[] expected)
        {
            parameterParser = new ParameterParser(input);
            List<int> numbers = parameterParser.GetNumbers().ToList();
            Assert.AreEqual(expected.Count(), numbers.Count());
            foreach (int n in expected)
            {
                CollectionAssert.Contains(numbers, n);
            }
        }

        [Test]
        public void Parse_NewLine_TreatedAsSeparator()
        {
            parameterParser = new ParameterParser("1\n2");
            List<int> numbers = parameterParser.GetNumbers().ToList();
            Assert.AreEqual(2, numbers.Count());
            CollectionAssert.Contains(numbers, 1);
            CollectionAssert.Contains(numbers, 2);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Add_TwoSeparatorsNextToEachOther_IsError()
        {
            parameterParser = new ParameterParser("1\n,2");
        }

        [Test]
        public void Add_WithCustomDelimiter_UsesTheCustomDelimiter()
        {
            parameterParser = new ParameterParser("//%\n1%2");
            List<int> numbers = parameterParser.GetNumbers().ToList();
            Assert.AreEqual(2, numbers.Count());
            CollectionAssert.Contains(numbers, 1);
            CollectionAssert.Contains(numbers, 2);
        }

        [Test]
        public void Parse_WithMultipleSeparators_ConsidersAllSeparators()
        {
            parameterParser = new ParameterParser("//[$][%]\n1$2%3");
            List<int> numbers = parameterParser.GetNumbers().ToList();
            Assert.AreEqual(3, numbers.Count());
            CollectionAssert.Contains(numbers, 1);
            CollectionAssert.Contains(numbers, 2);
            CollectionAssert.Contains(numbers, 3);

        }

    }
}
