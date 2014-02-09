using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    class ParameterTests
    {

        [Test]
        public void GetNumbers_EmptyString_ReturnsEmptyCollection()
        {
            Parameter input = new Parameter("");
            CollectionAssert.IsEmpty(input.GetNumbers());
        }

        [Test]
        public void GetNumbers_SingleNumber_ReturnsSingleNumber()
        {
            Parameter input = new Parameter("1");
            CollectionAssert.Contains(input.GetNumbers(), 1);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnTheSameLine_ReturnsTheTwoNumbers()
        {
            Parameter input = new Parameter("1,2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnSeparateLines_ReturnsTheTwoNumbers()
        {
            Parameter input = new Parameter("1\n2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNumbers_TwoSeparators_Throws()
        {
            Parameter input = new Parameter("1\n,2");
            input.GetNumbers();
        }

        [Test]
        public void GetNumbers_TwoNumbersWithCustomSeparator_ReturnsTheTwoNumbers()
        {
            Parameter input = new Parameter("//#\n1\n2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);            
        }

    }
}
