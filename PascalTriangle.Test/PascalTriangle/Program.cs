namespace PascalTriangle;

public class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Triangle(n));
    }

    public static string Triangle(int n)
    {
        int baseNumber = 1;
        return Sum(n, ref baseNumber);
    }

    public static string Sum(int n, ref int baseNumber)
    {
        string result = "";
        int p = 1;
        do
        {
            result += "1 ";
            for (int i = 1; i < baseNumber; i++)
            {
                p = p * ((baseNumber - 1) - i + 1) / i;
                result += p + " ";
            }
            result += "\n";
            baseNumber++;
        }
        while (baseNumber <= n);

        return result;
    }
}

