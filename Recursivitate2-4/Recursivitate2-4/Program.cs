using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] domino = DominoPieces(n);
        int x = Convert.ToInt32(Console.ReadLine());
        Suma(n, domino, x);
    }

    public static string[] DominoPieces(int n)
    {
        string[] result = new string[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = Console.ReadLine();
        }

        return result;
    }

    public static void Suma(int k, string[] a, int x)
    {
        int printNumber = 0;
        for (int i = 0; i < k; i++)
        {
            int count = 0;
            string[] pieces = DominoRestPieces(a, a[i]);
            string result = "";
            if (x == 1)
            {
                AfisareCu1(pieces, ref a[i], x, ref count, ref result, ref printNumber);
            }
            else
            {
                Afisare(pieces, ref a[i], x, ref count, ref result, ref printNumber);
            }
        }

        string print = printNumber == 0 ? "N/A" : "";
        Console.WriteLine(print);
    }

    public static string[] DominoRestPieces(string[] a, string b)
    {
        string[] result = new string[a.Length - 1];
        int count = 0;
        int countTheOnePiece = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b || countTheOnePiece > 0)
            {
                result[count] += a[i];
                count++;
            }
            else if (a[i] == b)
            {
                countTheOnePiece++;
            }
        }

        return result;
    }

    public static string Afisare(string[] a, ref string b, int x, ref int count, ref string result, ref int printNumber)
    {
        result += b;

        if (count == x - 1)
        {
            Console.WriteLine(result);
            count--;
            printNumber++;
            return "";
        }

        for (int i = 0; i < a.Length; i++)
            {
                if (b[b.Length - 1] == a[i][0])
                {
                    count++;
                    result += " ";
                    result += Afisare(DominoRestPieces(a, a[i]), ref a[i], x, ref count, ref result, ref printNumber);
                }
            }

        count--;
        return "";
    }

    public static string AfisareCu1(string[] a, ref string b, int x, ref int count, ref string result, ref int printNumber)
    {
        result += b;

        if (count == x - 1)
        {
            Console.WriteLine(result);
            count = 0;
            printNumber++;
        }

        return "";
    }
}