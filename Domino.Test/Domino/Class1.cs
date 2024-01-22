namespace Domino;

public class DominoPairs
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] domino = DominoPieces(n);
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(GenerateDominoPairs(n, domino, x));
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

    public static string GenerateDominoPairs(int k, string[] a, int x)
    {
        string print = "";
        int printNumber = 0;
        for (int i = 0; i < k; i++)
        {
            int count = 0;
            string[] pieces = DominoRestPieces(a, a[i]);
            string result = "";
            string saveTheData = "";
            if (x == 1)
            {
                print += GenerateOnePiece(pieces, ref a[i], x, ref count, ref result, ref printNumber);
            }
            else
            {
                print += GeneratePairs(pieces, ref a[i], x, ref count, ref result, ref saveTheData, ref printNumber);
            }
        }

        print += printNumber == 0 ? "N/A" : "";
        return print;
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

    public static string GeneratePairs(string[] a, ref string b, int x, ref int count, ref string result, ref string saveTheData, ref int printNumber)
    {
        saveTheData += b;

        if (count == x - 1)
        {
            result += saveTheData + "\n";
            count--;
            printNumber++;
            return "";
        }

        for (int i = 0; i < a.Length; i++)
        {
            if (b[b.Length - 1] == a[i][0])
            {
                count++;
                if (saveTheData[saveTheData.Length-1] != ' ')
                {
                    saveTheData += " ";
                }
                saveTheData += GeneratePairs(DominoRestPieces(a, a[i]), ref a[i], x, ref count, ref result, ref saveTheData, ref printNumber);
            }
        }

        count--;
        return result;
    }

    public static string GenerateOnePiece(string[] a, ref string b, int x, ref int count, ref string result, ref int printNumber)
    {
        result += b;

        if (count == x - 1)
        {
            result += "\n";
            count = 0;
            printNumber++;
        }

        return result;
    }
}