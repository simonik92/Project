using System;

class Program
{
    const int V = 2;

    public static void Main(string[] args)
    {
        int number = NumberValidation();
        int counting = Counting(number);
        int[] rest = DevideTheNumberByTwo(number, counting);

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

    public static int NumberValidation()
    {
        string stringNumber = Console.ReadLine();
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
}