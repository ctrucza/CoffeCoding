﻿using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    class ParameterFilter
    {
        private readonly List<int> numbers = new List<int>();
        private const int MAX_NUMBER = 1000;

        public ParameterFilter(IEnumerable<int> allNumbers)
        {
            numbers.AddRange(allNumbers);
            CheckForNegativeNumbers();
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers.Where(n => n <= MAX_NUMBER);
        }

        private void CheckForNegativeNumbers()
        {
            if (numbers.Any(n => n < 0))
            {
                throw new NegativeNumbersNotAllowedException(numbers.Where(n => n < 0));
            }
        }
    }
}