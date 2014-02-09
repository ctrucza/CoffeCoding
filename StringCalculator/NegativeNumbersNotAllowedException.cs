using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    internal class NegativeNumbersNotAllowedException: ArgumentException
    {
        public NegativeNumbersNotAllowedException(IEnumerable<int> negativeNumbers)
            :base(BuildMessage(negativeNumbers))
        {
            
        }
        private static string BuildMessage(IEnumerable<int> negativeNumbers)
        {
            var negativeNumbersAsStrings = negativeNumbers.Select(n => n.ToString());

            var message = "Negative numbers not allowed: ";
            message += negativeNumbersAsStrings.Aggregate((m, n) => m + ", " + n);
            return message;
        }
    }
}