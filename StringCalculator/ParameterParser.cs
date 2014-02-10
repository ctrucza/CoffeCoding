using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class ParameterParser
    {
        private const string separatorPrefix = "//";
        private IEnumerable<string> lines;
        private IEnumerable<string> numberLines;
        private readonly List<int> numbers = new List<int>();
        private char[] separators;

        public void Parse(string input)
        {
            if (input == "")
                return;

            SplitLines(input);

            FindSeparators();
            FindNumberLines();

            foreach (string line in numberLines)
            {
                IEnumerable<int> numbersInLine = GetNumbersFromLine(line, separators);
                numbers.AddRange(numbersInLine);
            }
        }

        private void SplitLines(string input)
        {
            lines = input.Split('\n');
        }

        private void FindSeparators()
        {
            var separatorLine = lines.SingleOrDefault(IsSeparatorLine);
            if (separatorLine == null)
                separators =  new[] { ',' };
            else
            {
                var separatorString = separatorLine.Replace(separatorPrefix, "");
                separators = new[] { separatorString[0] };
            }
        }

        private void FindNumberLines()
        {
            numberLines = lines.Where(IsNumberLine);
        }

        private static bool IsSeparatorLine(string line)
        {
            return line.StartsWith(separatorPrefix);
        }

        private static bool IsNumberLine(string line)
        {
            return !IsSeparatorLine(line);
        }

        private static IEnumerable<int> GetNumbersFromLine(string line, char[] separators)
        {
            var numbers = line.Split(separators);
            var numbersFromLine = numbers.Select(int.Parse);
            return numbersFromLine;
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers;
        }
    }
}