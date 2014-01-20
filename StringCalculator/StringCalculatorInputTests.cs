using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    class StringCalculatorInputTests
    {

        [Test]
        public void GetNumbers_EmptyString_ReturnsEmptyCollection()
        {
            StringCalculatorInput input = new StringCalculatorInput("");
            CollectionAssert.IsEmpty(input.GetNumbers());
        }

        [Test]
        public void GetNumbers_SingleNumber_ReturnsSingleNumber()
        {
            StringCalculatorInput input = new StringCalculatorInput("1");
            CollectionAssert.Contains(input.GetNumbers(), 1);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnTheSameLine_ReturnsTheTwoNumbers()
        {
            StringCalculatorInput input = new StringCalculatorInput("1,2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);
        }

        [Test]
        public void GetNumbers_TwoNumbersOnSeparateLines_ReturnsTheTwoNumbers()
        {
            StringCalculatorInput input = new StringCalculatorInput("1\n2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNumbers_TwoSeparators_Throws()
        {
            StringCalculatorInput input = new StringCalculatorInput("1\n,2");
            input.GetNumbers();
        }

        [Test]
        public void GetNumbers_TwoNumbersWithCustomSeparator_ReturnsTheTwoNumbers()
        {
            StringCalculatorInput input = new StringCalculatorInput("//#\n1\n2");
            CollectionAssert.Contains(input.GetNumbers(), 1);
            CollectionAssert.Contains(input.GetNumbers(), 2);            
        }

    }
}
