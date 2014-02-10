using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class NumberLine
    {
        private readonly List<int> numbers = new List<int>();

        public NumberLine(string line, char[] separators)
        {
            string[] numbersAsStrings = line.Split(separators);
            numbers.AddRange(numbersAsStrings.Select(int.Parse));
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers;
        }
    }
}
