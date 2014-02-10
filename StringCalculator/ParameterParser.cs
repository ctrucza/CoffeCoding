using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class ParameterParser
    {
        private const string separatorPrefix = "//";
        private IEnumerable<string> lines;
        private IEnumerable<NumberLine> numberLines;
        private readonly List<int> numbers = new List<int>();
        private char[] separators;

        public ParameterParser(string input)
        {
            if (input == "")
                return;

            Parse(input);

            foreach (NumberLine line in numberLines)
            {
                numbers.AddRange(line.GetNumbers());
            }
        }

        public IEnumerable<int> GetNumbers()
        {
            return numbers;
        }

        private void Parse(string input)
        {
            SplitLines(input);
            FindSeparators();
            FindNumberLines();
        }

        private void SplitLines(string input)
        {
            lines = input.Split('\n');
        }

        private void FindSeparators()
        {
            string separatorLine = lines.SingleOrDefault(IsSeparatorLine);

            if (separatorLine == null)
                separators =  new[] { ',' };
            else
            {
                SeparatorLine s = new SeparatorLine(separatorLine);
                separators = s.GetSeparators();
            }
        }

        private void FindNumberLines()
        {
            numberLines = lines.Where(IsNumberLine).Select(line=>new NumberLine(line, separators));
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