using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private IEnumerable<int> numbers;

        public int Add(string s)
        {
            Parameter input = new Parameter(s);
            numbers = input.GetNumbers();
            return numbers.Sum();
        }
    }
}