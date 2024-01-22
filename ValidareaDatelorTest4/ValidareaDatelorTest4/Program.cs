using System;

class Program
{
    public static void Main(string[] args)
    {
        int[,] sudoku = CreateTheSudoku();
        Console.WriteLine(ValidateSolution(sudoku));
    }

    public static string[] GetValues()
    {
        const int length = 9;
        string[] separator = { " ", "  " };
        return Console.ReadLine().Split(separator, length, StringSplitOptions.RemoveEmptyEntries);
    }

    public static int[,] CreateTheSudoku()
    {
        int size = 9;
        int count = 0;
        int[,] linie = new int[size, size];
        do
        {
            string[] stringValues = GetValues();
            size--;
            if (stringValues.Length == 0)
            {
                size++;
            }

            if (stringValues.Length > 0 && ValidateInputData(stringValues, out int[] values))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    linie[count, i] = values[i];
                }

                count++;
            }
        }
        while (size > 0);
        return linie;
    }

    public static bool ValidateInputData(string[] stringValues, out int[] values)
    {
        values = new int[stringValues.Length];
        for (int i = 0; i < stringValues.Length; i++)
        {
            if (!int.TryParse(stringValues[i], out values[i]) || stringValues.Length != 9 || values[i] < 1 || values[i] > stringValues.Length)
            {
                return false;
            }
        }

        return true;
    }

    public static bool ValidateSolution(int[,] sudoku)
    {
        const int length = 9;
        bool result = true;
        for (int index = 0; index < length; index++)
        {
            bool line = CheckTheLine(sudoku, index);
            bool column = CheckTheColumn(sudoku, index);
            bool block = CheckTheBlock(sudoku);
            if (!line || !column || !block)
            {
                result = false;
            }
        }

        return result;
    }

    private static bool CheckTheLine(int[,] sudoku, int index)
    {
        const int length = 9;
        int[] line = new int[9];
        bool result = true;
        string val = "";
        for (int i = 0; i < length; i++)
        {
            line[i] = sudoku[index, i];
            val += line[i];
        }

        for (char digit = '1'; digit <= '9'; digit++)
        {
            if (val.IndexOf(digit) != -1)
            {
                continue;
            }

            result = false;
        }

        return result;
    }

    private static bool CheckTheColumn(int[,] sudoku, int index)
    {
        const int length = 9;
        int[] column = new int[9];
        bool result = true;
        string val = "";
        for (int i = 0; i < length; i++)
        {
            column[i] = sudoku[i, index];
            val += column[i];
        }

        for (char digit = '1'; digit <= '9'; digit++)
        {
            if (val.IndexOf(digit) != -1)
            {
                continue;
            }

            result = false;
        }

        return result;
    }

    private static bool CheckTheBlock(int[,] sudoku)
    {
        const int length = 3;
        const int doubleOfLength = 6;
        bool result = true;
        int count = 0;
        string val = "";
        int[,] block = new int[3, 3];
        do
        {
            for (int i = 0 + count; i < length; i++)
            {
                for (int j = 0 + count; j < length; j++)
                {
                    block[i, j] = sudoku[i, j];
                    val += block[i, j];
                }
            }

            for (char digit = '1'; digit <= '9'; digit++)
            {
                if (val.IndexOf(digit) != -1)
                {
                    continue;
                }

                result = false;
            }

            count += length;
        }
        while (count < doubleOfLength);

        return result;
    }
}