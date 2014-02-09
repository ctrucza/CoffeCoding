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

            RemoveNumbersLargerThan1000();

            return numbers.Sum();
        }

        private void RemoveNumbersLargerThan1000()
        {
            numbers = numbers.Where(n => n <= 1000);
        }
    }
}