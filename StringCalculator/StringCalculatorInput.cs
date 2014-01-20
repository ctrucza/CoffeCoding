using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    internal class StringCalculatorInput
    {
        private readonly string inputString;
        private IEnumerable<string> lines;
        private const string separatorPrefix = "//";

        public StringCalculatorInput(string input)
        {
            inputString = input;
        }

        public IEnumerable<int> GetNumbers()
        {
            if (inputString == "")
                return new List<int>();

            lines = inputString.Split('\n');

            char[] separators = FindSeparators();
            var numberLines = FindNumberLines();

            List<int> result = new List<int>();
            foreach (var line in numberLines)
            {
                result.AddRange(GetNumbersFromLine(line, separators));
            }
            return result;
        }

        private static IEnumerable<int> GetNumbersFromLine(string line, char[] separators)
        {
            var numbers = line.Split(separators);
            if (numbers.Any(number => number == ""))
            {
                throw new ArgumentException("numbers");
            }

            var numbersFromLine = numbers.Select(int.Parse).ToList();
            return numbersFromLine;
        }

        private char[] FindSeparators()
        {
            var separatorLine = lines.SingleOrDefault(IsSeparatorLine);
            if (separatorLine == null)
                return new[] { ',' };
            var separatorString = separatorLine.Replace(separatorPrefix, "");
            return new[] { separatorString[0] };

        }

        private IEnumerable<string> FindNumberLines()
        {
            return lines.Where(IsNumberLine);
        }

        private static bool IsSeparatorLine(string line)
        {
            return line.StartsWith(separatorPrefix);
        }

        private static bool IsNumberLine(string line)
        {
            return !IsSeparatorLine(line);
        }
    }
}