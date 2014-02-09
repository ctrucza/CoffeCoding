using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    class BunchOfNumbersTests
    {
        private BunchOfNumbers bunchOfNumbers;

        [SetUp]
        public void SetUp()
        {
            bunchOfNumbers = new BunchOfNumbers();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNumbers_NegativeNumber_Fails()
        {
            bunchOfNumbers.AddNumbers(new[] { -1 });
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Negative numbers not allowed: -1")]
        public void AddNumbers_NegativeNumber_ThrowsAndIncludesTheNumber()
        {
            bunchOfNumbers.AddNumbers(new[]{-1});
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Negative numbers not allowed: -1, -2")]
        public void AddNumbers_TwoNegativeNumbers_ThrowsAndIncludesBothNumbers()
        {
            bunchOfNumbers.AddNumbers(new[] { -1, -2 });
        }

        [Test]
        public void AddNumbers_NotNegativeNumber_DoesNotFail()
        {
            bunchOfNumbers.AddNumbers(new[]{1});
            CollectionAssert.IsNotEmpty(bunchOfNumbers.GetNumbers());
        }

        [Test]
        public void AddNumbers_LargeNumber_LargeNumberIsRemoved()
        {
            bunchOfNumbers.AddNumbers(new[]{1001});
            CollectionAssert.IsEmpty(bunchOfNumbers.GetNumbers());
        }

    }
}
