using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Reverse(n);
    }

    public static void Reverse(int n)
    {
        int sumOfProd = 1;
        Sum(n, ref sumOfProd);
    }

    public static void Sum(int n, ref int sumOfProd)
    {
        int p = 1;
        do
        {
            Console.Write("1 ");
            for (int i = 1; i < sumOfProd; i++)
            {
                p = p * ((sumOfProd - 1) - i + 1) / i;
                Console.Write(p + " ");
            }

            Console.WriteLine();
            sumOfProd++;
        }
        while (sumOfProd <= n);
    }
}