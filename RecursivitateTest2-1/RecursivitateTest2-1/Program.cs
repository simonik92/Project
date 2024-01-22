using System;

class Program
{
    const string Hexa = "0123456789ABCDEF";
    const int MagicNumber = 16;

    public static void Main(string[] args)
    {
        int input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Reverse(input));
    }

    public static string Reverse(int n)
    {
        string sumOfProd = "";
        return n == 0 ? "0" : Result(Sum(ref n, ref sumOfProd));
    }

    public static string Sum(ref int n, ref string sumOfProd)
    {
        if (n == 0)
        {
            return sumOfProd;
        }

        int rest = n % MagicNumber;
        n /= MagicNumber;
        sumOfProd += Hexa[rest];
        return Sum(ref n, ref sumOfProd);
    }

    public static string Result(string sum)
    {
        string result = "";
        for (int i = sum.Length - 1; i >= 0; i--)
        {
            result += sum[i];
        }

        return result;
    }
}