using System;

class Program
{
    public static void Main(string[] args)
    {
        int[] a = new int[100];
        int n = Convert.ToInt32(Console.ReadLine());
        a[0] = 1;
        Back(a[0], a, n);
    }

    public static void Back(int i, int[] a, int n)
    {
        for (int j = a[i - 1]; j <= n - 1; j++)
        {
            a[i] = j;

            if (Suma(i, a) <= n)
            {
                if (Suma(i, a) == n)
                {
                    Afisare(i, a);
                    Console.WriteLine("");
                }
                else
                {
                    Back(i + 1, a, n);
                }
            }
        }
    }

    public static int Suma(int k, int[] a)
    {
        int i;
        int s = 0;

        for (i = 1; i <= k; i++)
        {
            s += a[i];
        }

        return s;
    }

    public static void Afisare(int k, int[] a)
    {
        for (int i = 1; i <= k; i++)
        {
            Console.Write(a[i]);
            if (i < k)
            {
                Console.Write(" + ");
            }
        }
    }
}