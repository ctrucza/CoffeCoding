using System.Collections.Generic;

namespace StringCalculator
{
    public class SeparatorLine
    {
        private string input;
        private List<char> separators = new List<char>();

        public SeparatorLine(string s)
        {
            input = s;
            RemoveMarker();

            if (ContainsMultipleSeparators())
            {
                GetMultipleSeparators();
            }
            else
            {
                System.Diagnostics.Debug.Assert(input.Length == 1);
                separators.Add(input[0]);
            }
        }

        public char[] GetSeparators()
        {
            return separators.ToArray();
        }

        private void RemoveMarker()
        {
            input = input.Substring(2, input.Length - 2);
        }

        private bool ContainsMultipleSeparators()
        {
            return input.StartsWith("[") && input.EndsWith("]");
        }

        private void GetMultipleSeparators()
        {
            TrimEnds();
            TrimSeparatorSeparators();
            separators = new List<char>();
            separators.AddRange(input);
        }

        private void TrimSeparatorSeparators()
        {
            input = input.Replace("][", "");
        }

        private void TrimEnds()
        {
            input = input.Substring(1, input.Length - 2);
        }
    }
}