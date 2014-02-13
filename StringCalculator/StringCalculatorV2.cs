using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculatorV2
    {
        private const string SeparatorLineMarker = "//";

        public int Add(string input)
        {
            string[] lines = BreakIntoLines(input);
            char[] separators = FindSeparators(lines);
            string[] numberLines = FindNumberLines(lines);
            int[] numbers = ExtractNumbers(numberLines, separators);
            int[] validNumbers = ValidateNumbers(numbers);
            return SumNumbers(validNumbers);
        }

        private static int SumNumbers(int[] validNumbers)
        {
            return validNumbers.Sum();
        }

        private static int[] ValidateNumbers(int[] numbers)
        {
            CheckForNegativeNumbers(numbers);

            return FilterLargeNumbers(numbers);
        }

        private static int[] FilterLargeNumbers(int[] numbers)
        {
            const int MaximumNumber = 1000;
            return numbers.Where(n => n <= MaximumNumber).ToArray();
        }

        private static void CheckForNegativeNumbers(int[] numbers)
        {
            int[] negativeNumbers = GetNegativeNumbers(numbers);
            if (negativeNumbers.Any())
            {
                throw new NegativeNumbersNotAllowedException(negativeNumbers);
            }
        }

        private static int[] GetNegativeNumbers(int[] numbers)
        {
            return numbers.Where(n => n < 0).ToArray();
        }

        private static int[] ExtractNumbers(string[] numberLines, char[] separators)
        {
            List<int> result = new List<int>();
            foreach (string line in numberLines)
            {
                if (line == "")
                    continue;

                int[] numbersInLine = ExtractNumbersFromLine(line, separators);
                result.AddRange(numbersInLine);
            }

            return result.ToArray();
        }

        private static int[] ExtractNumbersFromLine(string line, char[] separators)
        {
            List<int> result = new List<int>();
            string[] strings = line.Split(separators);
            foreach (string s in strings)
            {
                result.Add(int.Parse(s));
            }
            return result.ToArray();
        }


        private static string[] BreakIntoLines(string input)
        {
            return input.Split('\n');
        }

        private static string[] FindNumberLines(string[] lines)
        {
            return lines.Where(line => !line.StartsWith(SeparatorLineMarker)).ToArray();
        }

        private char[] FindSeparators(string[] lines)
        {
            var separatorLine = FindSeparatorLine(lines);
            return ExtractSeparators(separatorLine);
        }

        private char[] ExtractSeparators(string separatorLine)
        {
            if (separatorLine == null)
                return GetDefaultSeparators();

            if (ContainsMultipleSeparators(separatorLine))
                return GetMultipleSeparators(separatorLine);

            return GetSingleSeparator(separatorLine);
        }

        private static char[] GetMultipleSeparators(string separatorLine)
        {
            separatorLine = TrimEnds(separatorLine);
            separatorLine = TrimSeparatorSeparators(separatorLine);
            return separatorLine.ToCharArray();
        }

        private static string TrimEnds(string separatorLine)
        {
            return separatorLine.Substring(1, separatorLine.Length - 2);
        }

        private static string TrimSeparatorSeparators(string separatorLine)
        {
            return separatorLine.Replace("][", "");
        }

        private static char[] GetSingleSeparator(string separatorLine)
        {
            Debug.Assert(separatorLine.Length == 1);
            return new[] {separatorLine[0]};
        }

        private static bool ContainsMultipleSeparators(string separatorLine)
        {
            return separatorLine.StartsWith("[") && separatorLine.EndsWith("]");
        }

        private static char[] GetDefaultSeparators()
        {
            return new[] { '\n', ',' };
        }

        private static string FindSeparatorLine(string[] lines)
        {
            var fullLine = lines.SingleOrDefault(line => line.StartsWith(SeparatorLineMarker));            
            return RemoveLeadingMarker(fullLine, SeparatorLineMarker);
        }

        private static string RemoveLeadingMarker(string fullLine, string separatorLineMarker)
        {
            if (fullLine == null)
                return null;
            Debug.Assert(fullLine.StartsWith(separatorLineMarker));
            
            int markerLength = separatorLineMarker.Length;
            return fullLine.Substring(markerLength, fullLine.Length - markerLength);
        }
    }
}