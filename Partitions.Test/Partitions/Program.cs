using System;

namespace Partitions;

public class Program
{
    public static string print = "";
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(GeneratePartitions(n));
    }

    static string Partition(int i, int[] a, int n)
    {

        for (int j = a[i - 1]; j <= n - 1; j++)
        {
            a[i] = j;

            if (Sum(i, a) <= n)
            {
                if (Sum(i, a) == n)
                {
                    print += NextNumber(i, a) + "\n";
                }
                else
                {
                    Partition(i + 1, a, n);
                }
            }
        }
        return print;
    }


    public static string GeneratePartitions(int n)
    {
        int[] a = new int[100];
        a[0] = 1;
        return Partition(a[0], a, n);
    }

    public static int Sum(int k, int[] a)
    {
        int i;
        int s = 0;

        for (i = 1; i <= k; i++)
        {
            s += a[i];
        }

        return s;
    }

    public static string NextNumber(int k, int[] a)
    {
        string result = "";
        for (int i = 1; i <= k; i++)
        {
            result += a[i];

            if (i < k)
            {
                result += " + ";
            }
        }
        return result;
    }
}


