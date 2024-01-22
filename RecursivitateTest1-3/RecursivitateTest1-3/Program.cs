using System;

class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Console.WriteLine(Reverse(input));
    }

    public static string Reverse(string n)
    {
        string sumOfProd = "";
        int wordLength = n.Length;
        return Sum(n, ref sumOfProd, ref wordLength);
    }

    public static string Sum(string n, ref string sumOfProd, ref int wordLength)
    {
        if (wordLength == 0)
        {
            return sumOfProd;
        }

        wordLength--;
        sumOfProd += n[wordLength] + Sum(n, ref sumOfProd, ref wordLength);
        return sumOfProd;
    }
}