using System;

class Program
{
    const int V = 2;
    const int D = 10;

    public static void Main(string[] args)
    {
        long type = NumberValidation();
        long number = NumberValidation();
        int counting = Counting(number);
        int countingBinary = CountBinaryNumber(number);
        int[] rest = DevideTheNumberByTwo(number, counting);
        double zecimal = TransformInZecimal(number, countingBinary);

        if (type == 1)
        {
            if (number <= 0)
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }
            else
            {
                for (int i = 0; i < counting; i++)
                {
                    Console.Write(rest[i]);
                }
            }
        }
        else if (type == V)
        {
            if (!IsBinar(number))
            {
                Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
            }
            else
            {
                Console.WriteLine(zecimal);
            }
        }
        else
        {
            Console.WriteLine("Operatie invalida.");
        }
    }

    public static long NumberValidation()
    {
        string stringNumber = Console.ReadLine();
        if (long.TryParse(stringNumber, out long value))
        {
            return value;
        }

        return 0;
    }

    public static int Counting(long number)
    {
        int count = 0;
        do
        {
            number /= V;
            count++;
        }
        while (number > 0);

        return count;
    }

    public static int CountBinaryNumber(long number)
    {
        int count = 0;
        do
        {
            number /= D;
            count++;
        }
        while (number > 0);

        return count;
    }

    public static int[] DevideTheNumberByTwo(long number, int counting)
    {
        int[] rest = new int[counting];
        for (int i = counting - 1; i >= 0; i--)
        {
            rest[i] = (int)(number % V);
            number /= V;
        }

        return rest;
    }

    public static double TransformInZecimal(long number, int count)
    {
        double result = 0;
        for (int i = 0; i < count; i++)
        {
            double powOfTwo = Math.Pow(V, i);
            double rest = number % D;
            result += rest * powOfTwo;
            number /= D;
        }

        return result;
    }

    public static bool IsBinar(long number)
    {
        bool result = true;
        do
        {
            long rest = number % D;
            if (rest < 0 || rest > 1)
            {
                result = false;
            }

            number /= D;
        }
        while (number > 0);

        return result;
    }
}