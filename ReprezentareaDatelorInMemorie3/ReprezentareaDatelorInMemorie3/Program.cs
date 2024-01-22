using System;

class Program
{
    const int V = 2;
    const int D = 10;
    const int NOT = 3;

    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int type = NumberValidation(input);
        string number = Console.ReadLine();

        if (type == 1)
        {
            ConvertToBinar(number);
        }
        else if (type == V)
        {
            ConvertToZecimal(number);
        }
        else if (type == NOT)
        {
            ApplyNot(number);
        }
        else
        {
            Console.WriteLine("Operatie invalida.");
        }
    }

    public static void ConvertToBinar(string number)
    {
        if (!int.TryParse(number, out int value) || value < 0)
        {
            Console.WriteLine("Programul converteste doar numere intregi pozitive.");
        }
        else
        {
            int counting = Counting(value);
            int[] rest = DevideTheNumberByTwo(value, counting);

            for (int i = 0; i < counting; i++)
            {
                Console.Write(rest[i]);
            }
        }
    }

    public static void ConvertToZecimal(string number)
    {
        if (!long.TryParse(number, out long value) || !IsBinar(number))
        {
            Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
        }
        else
        {
            int countingBinary = CountBinaryNumber(value);
            double zecimal = TransformInZecimal(value, countingBinary);
            Console.WriteLine(zecimal);
        }
    }

    public static void ApplyNot(string number)
    {
        Console.WriteLine(IsBinar(number) ? TransformToNOT(number) : "Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
    }

    public static int NumberValidation(string stringNumber)
    {
        if (int.TryParse(stringNumber, out int value))
        {
            return value;
        }

        return 0;
    }

    public static int Counting(int number)
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

    public static int[] DevideTheNumberByTwo(int number, int counting)
    {
        int[] rest = new int[counting];
        for (int i = counting - 1; i >= 0; i--)
        {
            rest[i] = number % V;
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

    public static bool IsBinar(string number)
    {
        bool result = true;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != '0' && number[i] != '1')
            {
                result = false;
            }
        }

        return result;
    }

    public static string TransformToNOT(string number)
    {
        int count = 0;
        string notNumber = "";
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '0')
            {
                notNumber += '1';
                count++;
            }
            else if (count > 0 && number[i] == '1')
            {
                notNumber += '0';
            }
            else if (count == 0 && i == number.Length - 1)
            {
                notNumber += '0';
            }
        }

        return notNumber;
    }
}