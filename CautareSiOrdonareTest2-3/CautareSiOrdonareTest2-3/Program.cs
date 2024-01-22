using System;

namespace SortRandomNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadNumbers();
            ShellSort(numbers);
            Print(numbers);
            Console.Read();
        }

        static void ShellSort(int[] numbers)
        {
            const int magicNumber = 2;

            for (int interval = numbers.Length / 2; interval > 0; interval /= magicNumber)
            {
                for (int i = interval; i < numbers.Length; i++)
                {
                    var currentKey = numbers[i];
                    var k = i;
                    while (k >= interval && numbers[k - interval] > currentKey)
                    {
                        numbers[k] = numbers[k - interval];
                        k -= interval;
                    }

                    numbers[k] = currentKey;
                }
            }
        }

        static void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\n");
        }

        static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }
    }
}
