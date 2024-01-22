using System;

class Program
{
    public static void Main(string[] args)
    {
        string line1 = Console.ReadLine();
        string[] primaLinie = new string[3];
        ExtragereaNumerelorDinLinie(line1, primaLinie);
        string line2 = Console.ReadLine();
        string[] secondLine = new string[3];
        ExtragereaNumerelorDinLinie(line2, secondLine);
        string line3 = Console.ReadLine();
        string[] thirdLine = new string[3];
        ExtragereaNumerelorDinLinie(line3, thirdLine);
        string[] numereExtrase = new string[15];
        for (int i = 0; i < numereExtrase.Length; i++)
        {
            numereExtrase[i] = Console.ReadLine();
        }

        bool esteLinie1 = AvemLinieSauNuAvem(primaLinie, numereExtrase);
        bool esteLinie2 = AvemLinieSauNuAvem(secondLine, numereExtrase);
        bool esteLinie3 = AvemLinieSauNuAvem(thirdLine, numereExtrase);
        BingoSauLinie(esteLinie1, esteLinie2, esteLinie3);
    }

    public static void ExtragereaNumerelorDinLinie(string linie, string[] numarLinie)
    {
        int count = 0;
        for (int i = 0; i < linie.Length; i++)
        {
            if (linie[i] != ' ')
            {
                numarLinie[count] += linie[i];
            }
            else
            {
                count++;
            }
        }
    }

    public static bool AvemLinieSauNuAvem(string[] numarLinie, string[] numereExtrase)
    {
        int count = 0;
        for (int i = 0; i < numarLinie.Length; i++)
        {
            for (int j = 0; j < numereExtrase.Length; j++)
            {
                if (numarLinie[i] == numereExtrase[j])
                {
                    count++;
                }
            }
        }

        return count == numarLinie.Length;
    }

    public static void BingoSauLinie(bool esteLinie1, bool esteLinie2, bool esteLinie3)
    {
        if (esteLinie1 && esteLinie2 && esteLinie3)
        {
            Console.WriteLine("bingo");
        }
        else if (esteLinie1 || esteLinie2 || esteLinie3)
        {
            Console.WriteLine("linie");
        }
        else
        {
            Console.WriteLine("nimic");
        }
    }
}