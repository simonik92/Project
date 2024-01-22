using System;

class Program
{
    public const string Symbols = "!@#$%^&*()_-+=?{}[]:;\"\'|\\~`<,>./§±";
    public const string SimilarChars = "l1Io0O";
    public const string AmbiguousChars = "{}[]()/\\'\"~,;.";

    public static void Main(string[] args)
    {
        string password = Console.ReadLine();
        int smallLetters = Convert.ToInt32(Console.ReadLine());
        int capitalLetters = Convert.ToInt32(Console.ReadLine());
        int numberOfDigits = Convert.ToInt32(Console.ReadLine());
        int symbols = Convert.ToInt32(Console.ReadLine());
        bool similarCharacters = Convert.ToBoolean(Console.ReadLine());
        bool ambiguousCharacters = Convert.ToBoolean(Console.ReadLine());
        bool a = HasSmallLetters(password, smallLetters);
        bool b = HasCapitalLetters(password, capitalLetters);
        bool c = HasDigits(password, numberOfDigits);
        bool d = HasSymbols(password, symbols);
        bool e = HasSimiliarChars(password, similarCharacters);
        bool f = HasAmbiguousChars(password, ambiguousCharacters);
        bool g = false;
        if (a)
        {
            g = a == b == c == d == e == f;
        }

        Console.WriteLine(g);
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

    public static bool HasSmallLetters(string input, int smallLetters)
    {
        bool result = false;
        if (CountingTheSmallLetters(input) >= smallLetters)
        {
            result = true;
        }

        return result;
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

    public static bool HasCapitalLetters(string input, int capitalLetters)
    {
        bool result = false;
        if (CountingTheCapitalLetters(input) >= capitalLetters)
        {
            result = true;
        }

        return result;
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

    public static bool HasDigits(string input, int numberOfDigits)
    {
        bool result = false;
        if (CountingTheDigits(input) >= numberOfDigits)
        {
            result = true;
        }

        return result;
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

    public static bool HasSymbols(string input, int symbols)
    {
        bool result = false;
        if (CountingSymbols(input) >= symbols)
        {
            result = true;
        }

        return result;
    }

    public static bool HasSimiliarChars(string input, bool similarCharacters)
    {
        return similarCharacters || SimChars(input, similarCharacters);
    }

    public static bool SimChars(string input, bool similarCharacters)
    {
        bool result = false;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < SimilarChars.Length; j++)
            {
                if (input[i] == SimilarChars[j])
                {
                    result = true;
                }
            }
        }

        return similarCharacters == result;
    }

    public static bool HasAmbiguousChars(string input, bool ambiguousCharacters)
    {
        return ambiguousCharacters || AmbiChars(input, ambiguousCharacters);
    }

    public static bool AmbiChars(string input, bool ambiguousCharacters)
    {
        bool result = false;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < AmbiguousChars.Length; j++)
            {
                if (input[i] == AmbiguousChars[j])
                {
                    result = true;
                }
            }
        }

        return ambiguousCharacters == result;
    }
}