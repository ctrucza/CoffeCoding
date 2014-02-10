using System.Collections.Generic;

namespace StringCalculator
{
    internal class Parameter
    {
        private readonly ParameterParser parser = new ParameterParser();
        private readonly ParameterFilter filter = new ParameterFilter();

        public Parameter(string input)
        {
            parser.Parse(input);
        }

        public IEnumerable<int> GetNumbers()
        {
            IEnumerable<int> allNumbers = parser.GetNumbers();
            filter.AddNumbers(allNumbers);
            return filter.GetNumbers();
        }
    }
}