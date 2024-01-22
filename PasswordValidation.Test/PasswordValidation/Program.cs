namespace PasswordValidation;

public class Program
{
    public struct SymbolsAndChars
    {
        public const string Symbols = "!@#$%^&*()_-+=?{}[]:;\"\'|\\~`<,>./§±";
        public const string SimilarChars = "l1Io0O";
        public const string AmbiguousChars = "{}[]()/\\'\"~,;.";
    }

    public struct Conditions
    {
        public int SmallLetters;
        public int CapitalLetters;
        public int NumberOfDigits;
        public int Symbols;
        public bool SimilarCharacters;
        public bool AmbiguousCharacters;

        public Conditions(int smallLetters, int capitalLetters, int numberOfDigits, int symbols, bool similarCharacters, bool ambiguousCharacters)
        {
            this.SmallLetters = smallLetters;
            this.CapitalLetters = capitalLetters;
            this.NumberOfDigits = numberOfDigits;
            this.Symbols = symbols;
            this.SimilarCharacters = similarCharacters;
            this.AmbiguousCharacters = ambiguousCharacters;
        }
    }


    public static void Main(string[] args)
    {
        string password = Console.ReadLine();
        Conditions conditions = ReadConditions();
        Console.WriteLine(IsPasswordCorrect(password, conditions));
    }

    public static Conditions ReadConditions()
    {
        string[] conditions = new string[6];
        for (int i = 0; i < 6; i++)
        {
            conditions[i] = Console.ReadLine();
        }
        return new Conditions(Convert.ToInt32(conditions[0]), Convert.ToInt32(conditions[1]), Convert.ToInt32(conditions[2]), Convert.ToInt32(conditions[3]), Convert.ToBoolean(conditions[4]), Convert.ToBoolean(conditions[5]));
    }

    public static bool IsPasswordCorrect(string password, Conditions conditions)
    {
        bool a = HasSmallLetters(password, conditions.SmallLetters);
        bool b = HasCapitalLetters(password, conditions.CapitalLetters);
        bool c = HasDigits(password, conditions.NumberOfDigits);
        bool d = HasSymbols(password, conditions.Symbols);
        bool e = HasSimiliarChars(password, conditions.SimilarCharacters);
        bool f = HasAmbiguousChars(password, conditions.AmbiguousCharacters);
        bool g = false;
        if (a)
        {
            g = a == b == c == d == e == f;
        }
        return g;
    }

    static int CountingTheSmallLetters(string input)
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

    static bool HasSmallLetters(string input, int smallLetters)
    {
        bool result = false;
        if (CountingTheSmallLetters(input) >= smallLetters)
        {
            result = true;
        }

        return result;
    }

    static int CountingTheCapitalLetters(string input)
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

    static bool HasCapitalLetters(string input, int capitalLetters)
    {
        bool result = false;
        if (CountingTheCapitalLetters(input) >= capitalLetters)
        {
            result = true;
        }

        return result;
    }

    static int CountingTheDigits(string input)
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

    static bool HasDigits(string input, int numberOfDigits)
    {
        bool result = false;
        if (CountingTheDigits(input) >= numberOfDigits)
        {
            result = true;
        }

        return result;
    }

    static int CountingSymbols(string input)
    {
        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < SymbolsAndChars.Symbols.Length; j++)
            {
                if (input[i] == SymbolsAndChars.Symbols[j])
                {
                    count++;
                }
            }
        }

        return count;
    }

    static bool HasSymbols(string input, int symbols)
    {
        bool result = false;
        if (CountingSymbols(input) >= symbols)
        {
            result = true;
        }

        return result;
    }

    static bool HasSimiliarChars(string input, bool similarCharacters)
    {
        return similarCharacters || SimChars(input, similarCharacters);
    }

    static bool SimChars(string input, bool similarCharacters)
    {
        bool result = false;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < SymbolsAndChars.SimilarChars.Length; j++)
            {
                if (input[i] == SymbolsAndChars.SimilarChars[j])
                {
                    result = true;
                }
            }
        }

        return similarCharacters == result;
    }

    static bool HasAmbiguousChars(string input, bool ambiguousCharacters)
    {
        return ambiguousCharacters || AmbiChars(input, ambiguousCharacters);
    }

    static bool AmbiChars(string input, bool ambiguousCharacters)
    {
        bool result = false;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < SymbolsAndChars.AmbiguousChars.Length; j++)
            {
                if (input[i] == SymbolsAndChars.AmbiguousChars[j])
                {
                    result = true;
                }
            }
        }

        return ambiguousCharacters == result;
    }
}

