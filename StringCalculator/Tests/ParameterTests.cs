using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    class ParameterTests
    {

        [Test]
        public void GetNumbers_EmptyString_ReturnsEmptyCollection()
        {
            Parameter parameter = new Parameter("");
            CollectionAssert.IsEmpty(parameter.GetNumbers());
        }

        [Test]
        public void GetNumbers_SingleNumber_ReturnsSingleNumber()
        {
            Parameter parameter = new Parameter("1");
            CollectionAssert.Contains(parameter.GetNumbers(), 1);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnTheSameLine_ReturnsTheTwoNumbers()
        {
            Parameter parameter = new Parameter("1,2");
            CollectionAssert.Contains(parameter.GetNumbers(), 1);
            CollectionAssert.Contains(parameter.GetNumbers(), 2);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnSeparateLines_ReturnsTheTwoNumbers()
        {
            Parameter parameter = new Parameter("1\n2");
            CollectionAssert.Contains(parameter.GetNumbers(), 1);
            CollectionAssert.Contains(parameter.GetNumbers(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNumbers_TwoSeparators_Throws()
        {
            Parameter parameter = new Parameter("1\n,2");
            parameter.GetNumbers();
        }

        [Test]
        public void GetNumbers_TwoNumbersWithCustomSeparator_ReturnsTheTwoNumbers()
        {
            Parameter parameter = new Parameter("//#\n1\n2");
            CollectionAssert.Contains(parameter.GetNumbers(), 1);
            CollectionAssert.Contains(parameter.GetNumbers(), 2);            
        }

    }
}
