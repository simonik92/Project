using System;

class Program
{
    private const int V = 1;

    public static void Main(string[] args)
    {
        string inputData = Console.ReadLine();
        char[] cripted = { '0', 'O', 'o', '1', 'l' };
        int numbers = CountingTheInputNumbers(inputData);
        string[] inputCode = new string[numbers];
        Extract(inputData, inputCode);

        for (int i = 0; i < inputCode.Length; i++)
        {
            TransformTheCripted(inputCode[i], cripted);
        }
    }

    public static int CountingTheInputNumbers(string input)
    {
        int count = 1;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ' ')
            {
                count++;
            }
        }

        return count;
    }

    public static void Extract(string elements, string[] inputCode)
    {
        int count = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] != ' ')
            {
                inputCode[count] += elements[i];
            }
            else
            {
                count++;
            }
        }
    }

    public static void TransformTheCripted(string input, char[] cripted)
    {
        double finalResult = 0;
        double result = 0;
        double pow = input.Length - 1;
        for (int j = 0; j < input.Length; j++)
        {
            result += Math.Pow(cripted.Length, pow);
            pow--;
            for (int k = 0; k < cripted.Length; k++)
            {
                if (input[j] == cripted[k])
                {
                    result *= k + V;
                    finalResult += result;
                    result = 0;
                }
            }
        }

        Console.Write(finalResult + " ");
    }
}