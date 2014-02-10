using System.Collections.Generic;

namespace StringCalculator
{
    internal class Parameter
    {
        private readonly IEnumerable<int> allNumbers;

        public Parameter(string input)
        {
            ParameterParser parser = new ParameterParser(input);
            allNumbers = parser.GetNumbers();
        }

        public IEnumerable<int> GetNumbers()
        {
            ParameterFilter filter = new ParameterFilter(allNumbers);
            return filter.GetNumbers();
        }
    }
}