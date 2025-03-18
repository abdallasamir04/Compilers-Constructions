using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copmilers
{
    public class IdentifierValidator
    {
        public static bool IsLetter(char ch)
        {
            return Char.IsLetter(ch);
        }

        public static bool IsLetterOrDigit(char ch)
        {
            return Char.IsLetterOrDigit(ch);
        }

        public static string GetIdentifier(string input)
        {
            input = input.Trim();
            var identifier = new List<char>();

            if (IsLetter(input[0]))
            {
                identifier.Add(input[0]);
                int i = 1;
                while (i < input.Length && IsLetterOrDigit(input[i]))
                {
                    identifier.Add(input[i]);
                    i++;
                }
            }
            else
            {
                return null;
            }

            return new string(identifier.ToArray());
        }
    }

}
