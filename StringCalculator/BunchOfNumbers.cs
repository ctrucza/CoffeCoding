using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    class BunchOfNumbers
    {
        private readonly List<int> numbers = new List<int>();
        private const int MAX_NUMBER = 1000;

        public void AddNumbers(IEnumerable<int> bunchOfNumbers)
        {
            numbers.AddRange(bunchOfNumbers);
            CheckForNegativeNumbers();
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers.Where(n => n <= MAX_NUMBER);
        }

        private void CheckForNegativeNumbers()
        {
            if (!numbers.Any(n => n < 0))
                return;
            throw new NegativeNumbersNotAllowedException(numbers.Where(n => n < 0));
            //string message = BuildMessage();
            //throw new ArgumentException(message);
        }


    }
}