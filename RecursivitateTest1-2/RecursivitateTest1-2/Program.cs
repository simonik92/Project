using System;

class Program
{
    public static void Main(string[] args)
    {
        int inputNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Sum(inputNumber));
    }

    public static int Sum(int n)
    {
        int sumOfProd = 0;
        return Sum(n, ref sumOfProd);
    }

    public static int Sum(int n, ref int sumOfProd)
    {
        if (n == 0)
        {
            return sumOfProd;
        }

        sumOfProd += (n * n) + Sum(n - 1, ref sumOfProd);
        return sumOfProd;
    }
}