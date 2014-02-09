using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    class BunchOfNumbers
    {
        private readonly List<int> numbers = new List<int>();

        public void AddNumbers(IEnumerable<int> bunchOfNumbers)
        {
            numbers.AddRange(bunchOfNumbers);
            Validate();
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers;
        }

        private void Validate()
        {
            if (!numbers.Any(n => n < 0)) 
                return;

            string message = BuildMessage();
            throw new ArgumentException(message);
        }

        private string BuildMessage()
        {
            var negativeNumbers = numbers.Where(n => n < 0);
            var negativeNumbersAsStrings = negativeNumbers.Select(n => n.ToString());

            var message = "Negative numbers not allowed: ";
            message += negativeNumbersAsStrings.Aggregate((m, n) => m + ", " + n);
            return message;
        }

    }
}