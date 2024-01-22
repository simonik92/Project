using System;

class Program
{
    public const int Variable = 2;

    static void Main()
    {
        Console.WriteLine();
        string input = Console.ReadLine();

        RearrangeCharacters(input);
    }

    static void RearrangeCharacters(string input)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        List<char> sortedChars = new List<char>(charCount.Keys);
        sortedChars.Sort((x, y) => charCount[y].CompareTo(charCount[x]));

        int maxCount = charCount[sortedChars[0]];

        if (maxCount > (input.Length + 1) / Variable)
        {
            Console.WriteLine("nu");
            return;
        }

        char[] result = new char[input.Length];
        int index = 0;

        for (int i = 0; i < sortedChars.Count; i++)
        {
            char c = sortedChars[i];
            while (charCount[c] > 0)
            {
                if (index >= input.Length)
                {
                    index = 1;
                }

                result[index] = c;
                index += Variable;
                charCount[c]--;
            }
        }

        Console.WriteLine("da");
        Console.WriteLine(new string(result));
    }
}