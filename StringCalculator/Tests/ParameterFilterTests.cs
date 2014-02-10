using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    class ParameterFilterTests
    {
        private ParameterFilter parameterFilter;

        [SetUp]
        public void SetUp()
        {
            parameterFilter = new ParameterFilter();
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException))]
        public void AddNumbers_NegativeNumber_Fails()
        {
            parameterFilter.FilterNumbers(new[] { -1 });
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1")]
        public void AddNumbers_NegativeNumber_ThrowsAndIncludesTheNumber()
        {
            parameterFilter.FilterNumbers(new[]{-1});
        }

        [Test]
        [ExpectedException(typeof(NegativeNumbersNotAllowedException), ExpectedMessage = "Negative numbers not allowed: -1, -2")]
        public void AddNumbers_TwoNegativeNumbers_ThrowsAndIncludesBothNumbers()
        {
            parameterFilter.FilterNumbers(new[] { -1, -2 });
        }

        [Test]
        public void AddNumbers_NotNegativeNumber_DoesNotThrow()
        {
            Assert.DoesNotThrow( () => 
                parameterFilter.FilterNumbers(new[]{1})
                );
        }

        [Test]
        public void AddNumbers_LargeNumber_LargeNumberIsRemoved()
        {
            CollectionAssert.IsEmpty(parameterFilter.FilterNumbers(new[] { 1001 }));
        }

    }
}
