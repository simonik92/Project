using System;

class Program
{
    public const int MagicNumber = 2;

    public static void Main(string[] args)
    {
        int inputNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(inputNumber));
    }

    public static int Fibonacci(int n)
    {
        if (n < MagicNumber)
        {
            return n;
        }

        return Fibonacci(n - 1) + Fibonacci(n - MagicNumber);
    }
}