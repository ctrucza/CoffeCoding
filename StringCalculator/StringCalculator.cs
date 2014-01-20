using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private IEnumerable<int> numbers;

        public int Add(string s)
        {
            StringCalculatorInput input = new StringCalculatorInput(s);

            numbers = input.GetNumbers().ToList();

            CheckForNegatives();
            RemoveNumbersLargerThan1000();

            return numbers.Sum();
        }

        private void RemoveNumbersLargerThan1000()
        {
            numbers = numbers.Where(n => n <= 1000);
        }

        private void CheckForNegatives()
        {
            if (AllNumbersPositive()) 
                return;

            var message = "Negative numbers not allowed: ";
            var negativeNumbers = numbers.Where(n => n < 0);
            var negativeNumbersAsStrings = negativeNumbers.Select(n => n.ToString());
            message += negativeNumbersAsStrings.Aggregate((m, n) => m + ", " + n);
            throw new ArgumentException(message);
        }

        private bool AllNumbersPositive()
        {
            return numbers.All(number => number >= 0);
        }
    }
}