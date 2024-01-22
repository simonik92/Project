using System;

namespace PasswordComplexityLevel
{
    enum PasswordComplexityLevel
    {
        High,
        Medium,
        Low
    }

    struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool CanContainSimilarChars;
        public bool CanContainAmbiguousChars;
    }

    class Program
    {
        public const string Symbols = "!@#$%^&*()_-+=?{}[]:;\"\'|\\~`<,>./§±";

        public static void Main()
        {
            string password = Console.ReadLine();
            Console.WriteLine(GetPasswordComplexityLevel(password));
            Console.Read();
        }

        public static int CountingTheSmallLetters(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (char letter = 'a'; letter <= 'z'; letter++)
                {
                    if (input[i] == letter)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int CountingTheCapitalLetters(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (char letter = 'A'; letter <= 'Z'; letter++)
                {
                    if (input[i] == letter)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int CountingTheDigits(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (char letter = '0'; letter <= '9'; letter++)
                {
                    if (input[i] == letter)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int CountingSymbols(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Symbols.Length; j++)
                {
                    if (input[i] == Symbols[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static PasswordComplexityLevel GetPasswordComplexityLevel(string password)
        {
            PasswordComplexity passwordComplexity = new PasswordComplexity();
            passwordComplexity.MinLowercaseChars = CountingTheSmallLetters(password);
            passwordComplexity.MinUpercaseChars = CountingTheCapitalLetters(password);
            passwordComplexity.MinDigits = CountingTheDigits(password);
            passwordComplexity.MinSymbols = CountingSymbols(password);
            passwordComplexity.CanContainSimilarChars = true;
            passwordComplexity.CanContainAmbiguousChars = true;
            PasswordComplexity passwordComplexity1 = GetHighPasswordComplexity();
            PasswordComplexity passwordComplexity2 = GetMediumPasswordComplexity();
            if (PasswordComplexityCompare(passwordComplexity, passwordComplexity1))
            {
                return PasswordComplexityLevel.High;
            }
            else if (PasswordComplexityCompare(passwordComplexity, passwordComplexity2))
            {
                return PasswordComplexityLevel.Medium;
            }
            else
            {
                return PasswordComplexityLevel.Low;
            }
        }

        public static bool PasswordComplexityCompare(PasswordComplexity x, PasswordComplexity y)
        {
            bool a = x.MinLowercaseChars >= y.MinLowercaseChars;
            bool b = x.MinUpercaseChars >= y.MinUpercaseChars;
            bool c = x.MinDigits >= y.MinDigits;
            bool d = x.MinSymbols >= y.MinSymbols;
            bool e = false;
            e = a ? a == b == c == d : a;
            return e;
        }

        public static PasswordComplexity GetHighPasswordComplexity()
        {
            const int HighComplexityMinLowercaseChars = 5;
            const int HighComplexityMinUppercaseChars = 2;
            const int HighComplexityMinDigits = 2;
            const int HighComplexityMinSymbols = 2;

            return new PasswordComplexity
            {
                MinLowercaseChars = HighComplexityMinLowercaseChars,
                MinUpercaseChars = HighComplexityMinUppercaseChars,
                MinDigits = HighComplexityMinDigits,
                MinSymbols = HighComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        static PasswordComplexity GetMediumPasswordComplexity()
        {
            const int MediumComplexityMinLowercaseChars = 3;
            const int MediumComplexityMinUpercaseChars = 1;
            const int MediumComplexityMinDigits = 1;
            const int MediumComplexityMinSymbols = 1;

            return new PasswordComplexity
            {
                MinLowercaseChars = MediumComplexityMinLowercaseChars,
                MinUpercaseChars = MediumComplexityMinUpercaseChars,
                MinDigits = MediumComplexityMinDigits,
                MinSymbols = MediumComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }
    }
}
