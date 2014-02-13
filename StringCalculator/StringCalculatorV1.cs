using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private IEnumerable<int> numbers;

        public int Add(string s)
        {
            Parameter parameter = new Parameter(s);
            numbers = parameter.GetNumbers();
            return numbers.Sum();
        }
    }
}