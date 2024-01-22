using System;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadNumbers();
            int numberToFind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(BinarySearch(numbers, numberToFind));
            Console.Read();
        }

        private static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }

        static int BinarySearch(int[] sequence, int toFind)
        {
            int start = 0;
            int end = sequence.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (CheckNumberAtIndex(sequence, mid, toFind))
                {
                    return mid;
                }
                else if (sequence[mid] < toFind)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        static bool CheckNumberAtIndex(int[] numbers, int index, int numberToCheck)
        {
            Console.WriteLine("Checking index " + index + " (value " + numbers[index] + ")");
            return numbers[index] == numberToCheck;
        }
    }
}
