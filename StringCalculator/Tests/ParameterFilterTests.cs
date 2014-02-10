using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    class ParameterFilterTests
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException))]
        public void AddNumbers_NegativeNumber_Fails()
        {
            ParameterFilter parameterFilter = new ParameterFilter(new[] { -1 });
            parameterFilter.GetNumbers();
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1")]
        public void AddNumbers_NegativeNumber_ThrowsAndIncludesTheNumber()
        {
            ParameterFilter parameterFilter = new ParameterFilter(new[] { -1 });
            parameterFilter.GetNumbers();
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1, -2")]
        public void AddNumbers_TwoNegativeNumbers_ThrowsAndIncludesBothNumbers()
        {
            ParameterFilter parameterFilter = new ParameterFilter(new[] { -1, -2 });
            parameterFilter.GetNumbers();
        }

        [Test]
        public void AddNumbers_NotNegativeNumber_DoesNotThrow()
        {
            Assert.DoesNotThrow( () => new ParameterFilter(new[]{1}) );
        }

        [Test]
        public void AddNumbers_LargeNumber_LargeNumberIsRemoved()
        {
            ParameterFilter parameterFilter = new ParameterFilter(new[] { 1001 });
            CollectionAssert.IsEmpty(parameterFilter.GetNumbers());
        }

    }
}
