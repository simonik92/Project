using System;

class Program
{
    const int V = 2;
    const int D = 10;
    const int NOT = 3;
    const int OR = 4;
    const int AND = 5;
    const int XOR = 6;
    const int Left = 7;
    const int Right = 8;
    const int Less = 9;
    const int Greater = 10;
    const int Equal = 11;
    const int NotEqual = 12;
    const int Aduna = 13;
    const int Scade = 14;
    const int Inmultire = 15;
    const int Impartire = 16;
    const int Factorial = 17;

    private const string NumberInvalid = "Nu s-a introdus un numar binar valid (format doar din 0 si 1).";

    public static void Main(string[] args)
    {
        int type = NumberValidation(Console.ReadLine());
        string number = Console.ReadLine();
        ApplyAll(number, type);
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
            Console.WriteLine(NumberInvalid);
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
        Console.WriteLine(IsBinar(number) ? TransformToNOT(number) : NumberInvalid);
    }

    public static int NumberValidation(string stringNumber)
    {
        if (int.TryParse(stringNumber, out int value))
        {
            return value;
        }

        return 0;
    }

    public static void ApplyOr(string number)
    {
        string secondNumber = Console.ReadLine();
        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? TransformToOr(number, secondNumber) : NumberInvalid);
    }

    public static void ApplyAnd(string number)
    {
        string secondNumber = Console.ReadLine();
        string numberAnd = TransformToAnd(number, secondNumber);
        string newNumberAnd = "";
        int count = 0;
        for (int i = 0; i < numberAnd.Length; i++)
        {
            if (numberAnd[i] == '1')
            {
                newNumberAnd += '1';
                count++;
            }
            else if (numberAnd[i] == '0' && count > 0)
            {
                newNumberAnd += '0';
            }
            else if (count == 0 && i == numberAnd.Length - 1)
            {
                newNumberAnd += '0';
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? newNumberAnd : NumberInvalid);
    }

    public static void ApplyXor(string number)
    {
        string secondNumber = Console.ReadLine();
        string numberXor = TransformToXor(number, secondNumber);
        string newNumberXor = "";
        int count = 0;
        for (int i = 0; i < numberXor.Length; i++)
        {
            if (numberXor[i] == '1')
            {
                newNumberXor += '1';
                count++;
            }
            else if (numberXor[i] == '0' && count > 0)
            {
                newNumberXor += '0';
            }
            else if (count == 0 && i == numberXor.Length - 1)
            {
                newNumberXor += '0';
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? newNumberXor : NumberInvalid);
    }

    public static void ApplyShiftLeft(string number)
    {
        string secondNumber = Console.ReadLine();
        int secondNumberInt = NumberValidation(secondNumber);
        for (int i = 0; i < secondNumberInt; i++)
        {
            number += '0';
        }

        Console.WriteLine(IsBinar(number) ? number : NumberInvalid);
    }

    public static void ApplyShiftRight(string number)
    {
        string secondNumber = Console.ReadLine();
        int secondNumberInt = NumberValidation(secondNumber);
        string result = "";
        if (secondNumberInt < 0)
        {
            Console.WriteLine("Numarul de pozitii trebuie sa fie intreg si pozitiv.");
        }
        else
        {
            if (secondNumberInt > number.Length)
            {
                result += '0';
            }
            else
            {
                for (int i = 0; i < number.Length - secondNumberInt; i++)
                {
                    result += number[i];
                }
            }

            Console.WriteLine(IsBinar(number) ? result : NumberInvalid);
        }
    }

    public static void ApplyLessThan(string number)
    {
        string secondNumber = Console.ReadLine();
        bool result = false;
        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1' && secondNumber[i] == '0')
            {
                result = false;
                break;
            }
            else if (number[i] == '0' && secondNumber[i] == '1')
            {
                result = true;
                break;
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyGreaterThan(string number)
    {
        string secondNumber = Console.ReadLine();
        bool result = false;
        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1' && secondNumber[i] == '0')
            {
                result = true;
                break;
            }
            else if (number[i] == '0' && secondNumber[i] == '1')
            {
                result = false;
                break;
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyEqual(string number)
    {
        string secondNumber = Console.ReadLine();
        bool result = true;
        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != secondNumber[i])
            {
                result = false;
                break;
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyNotEqual(string number)
    {
        string secondNumber = Console.ReadLine();
        bool result = false;
        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != secondNumber[i])
            {
                result = true;
                break;
            }
        }

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyAduna(string number)
    {
        string secondNumber = Console.ReadLine();

        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        string result = ExecuteAduna(number, secondNumber);

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyScade(string number)
    {
        string secondNumber = Console.ReadLine();
        if (number.Length < secondNumber.Length)
        {
            string r = number;
            number = secondNumber;
            secondNumber = r;
        }

        if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        int secondNum = CheckTheGreaterNumber(number, secondNumber);

        if (secondNum == 1)
        {
                string r = number;
                number = secondNumber;
                secondNumber = r;
        }

        string result = ExecuteScade(number, secondNumber);

        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyInmultire(string number)
    {
        string secondNumber = Console.ReadLine();
        long numberToInt = (long)ConvertTheNumberToZecimal(number);
        long secondNumberToInt = (long)ConvertTheNumberToZecimal(secondNumber);
        long multiply = numberToInt * secondNumberToInt;
        string result = ConvertTheNumberToBinar(multiply);
        Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
    }

    public static void ApplyImpartire(string number)
    {
        string secondNumber = Console.ReadLine();
        long numberToInt = (long)ConvertTheNumberToZecimal(number);
        long secondNumberToInt = (long)ConvertTheNumberToZecimal(secondNumber);
        if (secondNumberToInt != 0)
        {
            long divide = numberToInt / secondNumberToInt;
            string result = ConvertTheNumberToBinar(divide);
            Console.WriteLine(IsBinar(number) && IsBinar(secondNumber) ? result : NumberInvalid);
        }
        else
        {
            Console.WriteLine("Nu se poate imparti la 0!");
        }
    }

    public static void ApplyFactorial(string number)
    {
        long numberToInt = (long)ConvertTheNumberToZecimal(number);
        string fact = ExecuteTheFactoril(numberToInt);
        Console.WriteLine(IsBinar(number) ? fact : NumberInvalid);
    }

    public static string ExecuteTheFactoril(long secondNumber)
    {
        string result = "1";
        for (long i = 2; i <= secondNumber; i++)
        {
            string multiply = ConvertTheNumberToBinar(i);
            result = MultiplyInString(result, multiply);
        }

        return result;
    }

    public static string MultiplyInString(string number, string multiply)
    {
        string newBinarNumber = "";
        int count = 0;
        string sum = "0";
        for (int i = multiply.Length - 1; i >= 0; i--)
        {
            for (int j = number.Length - 1; j >= 0; j--)
            {
                newBinarNumber += (number[j] == '0' || multiply[i] == '0') ? "0" : "1";
            }

            string reverse = ReverseTheString(newBinarNumber);
            newBinarNumber = "";

            for (int k = count; k > 0; k--)
            {
                reverse += "0";
            }

            count++;

            sum = AddMethod(sum, reverse);
        }

        return sum;
    }

    public static string AddMethod(string number, string secondNumber)
    {
        if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        return ExecuteAduna(number, secondNumber);
    }

    public static string ReverseTheString(string number)
    {
        string result = "";
        for (int i = number.Length - 1; i >= 0; i--)
        {
            result += number[i];
        }

        return result;
    }

    public static double ConvertTheNumberToZecimal(string number)
    {
        double zecimal;
        if (!long.TryParse(number, out long value) || !IsBinar(number))
        {
            return 0;
        }

        int countingBinary = CountBinaryNumber(value);
        zecimal = TransformInZecimal(value, countingBinary);
        return zecimal;
    }

    public static decimal[] DevideOfDecimalNumberByTwo(decimal number, int counting)
    {
        decimal[] rest = new decimal[counting];
        for (long i = counting - 1; i >= 0; i--)
        {
            rest[i] = number % V;
            number /= V;
        }

        return rest;
    }

    public static int CountingTheDigitsOfDecimal(decimal number)
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

    public static string ConvertTheNumberToBinar(long number)
    {
        string result = "";
        long counting = CountingTheDigits(number);
        double[] rest = DevideTheDecimalNumberByTwo(number, counting);

        for (int i = 0; i < counting; i++)
        {
            result += rest[i];
        }

        return result;
    }

    public static int CountingTheDigits(long number)
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

    public static double[] DevideTheDecimalNumberByTwo(long number, long counting)
    {
        double[] rest = new double[counting];
        for (long i = counting - 1; i >= 0; i--)
        {
            rest[i] = number % V;
            number /= V;
        }

        return rest;
    }

    public static int CheckTheGreaterNumber(string number, string secondNumber)
    {
        int secondNum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1' && secondNumber[i] == '0')
            {
                break;
            }
            else if (number[i] == '0' && secondNumber[i] == '1')
            {
                secondNum++;
                break;
            }
        }

        return secondNum;
    }

    public static string ExecuteAduna(string number, string secondNumber)
    {
        string result = "";
        string finalResult = "";
        int count = 0;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (count == 0)
            {
                result += AdunaCandCountEZero(i, number, secondNumber);

                if (number[i] == '1' && secondNumber[i] == '1')
                {
                    count++;
                }
            }
            else
            {
                result += AdunaCandCountEUnu(i, number, secondNumber);
                if (number[i] == '0' && secondNumber[i] == '0')
                {
                    count--;
                }
            }
        }

        for (int i = result.Length - 1; i >= 0; i--)
        {
            finalResult += result[i];
        }

        finalResult = EliminaZerouri(finalResult);

        return finalResult;
    }

    public static string ExecuteScade(string number, string secondNumber)
    {
        string result = "";
        string finalResult = "";
        int count = 0;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (count == 0)
            {
                result += ScadeCandCountEZero(i, number, secondNumber);

                if (number[i] == '0' && secondNumber[i] == '1')
                {
                    count++;
                }
            }
            else
            {
                result += ScadeCandCountEUnu(i, number, secondNumber);
                if (number[i] == '1' && secondNumber[i] == '0')
                {
                    count--;
                }
            }
        }

        for (int i = result.Length - 1; i >= 0; i--)
        {
            finalResult += result[i];
        }

        finalResult = EliminaZerouri(finalResult);

        return finalResult;
    }

    public static string EliminaZerouri(string finalResult)
    {
        int count = 0;
        string result = "";
        for (int i = 0; i < finalResult.Length; i++)
        {
            if (finalResult[i] == '1')
            {
                result += finalResult[i];
                count++;
            }
            else
            {
                if (count > 0)
                {
                    result += finalResult[i];
                }
            }
        }

        if (result == "")
        {
            result += "0";
        }

        return result;
    }

    public static string AdunaCandCountEZero(int i, string number, string secondNumber)
    {
        string result = "";

        if (number[i] == '0' && secondNumber[i] == '0')
        {
            result += '0';
        }
        else if ((number[i] == '0' && secondNumber[i] == '1') || (number[i] == '1' && secondNumber[i] == '0'))
        {
            result += '1';
        }
        else if (number[i] == '1' && secondNumber[i] == '1')
        {
            if (i == 0)
            {
                result += "01";
            }
            else
            {
                result += '0';
            }
        }

        return result;
    }

    public static string ScadeCandCountEZero(int i, string number, string secondNumber)
    {
        string result = "";

        if (number[i] == '0' && secondNumber[i] == '0')
        {
            result += '0';
        }
        else if ((number[i] == '0' && secondNumber[i] == '1') || (number[i] == '1' && secondNumber[i] == '0'))
        {
            result += '1';
        }
        else if (number[i] == '1' && secondNumber[i] == '1')
        {
             result += '0';
        }

        return result;
    }

    public static string AdunaCandCountEUnu(int i, string number, string secondNumber)
    {
        string result = "";

        if (number[i] == '0' && secondNumber[i] == '0')
        {
            result += '1';
        }
        else
        {
            if ((number[i] == '0' && secondNumber[i] == '1') || (number[i] == '1' && secondNumber[i] == '0'))
            {
                result += "0";
            }
            else if (number[i] == '1' && secondNumber[i] == '1')
            {
                result += "1";
            }

            if (i == 0)
            {
                result += "1";
            }
        }

        return result;
    }

    public static string ScadeCandCountEUnu(int i, string number, string secondNumber)
    {
        string result = "";

        if (number[i] == '0' && secondNumber[i] == '0')
        {
            result += '1';
        }
        else if ((number[i] == '0' && secondNumber[i] == '1') || (number[i] == '1' && secondNumber[i] == '0'))
        {
            result += "0";
        }
        else if (number[i] == '1' && secondNumber[i] == '1')
        {
            result += "1";
        }

        return result;
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

    public static string MakeTheNumbersOfSameLength(string number, string secondNumber)
    {
        string newNumber = "";
        if (number.Length > secondNumber.Length)
        {
            int differece = number.Length - secondNumber.Length;
            for (int i = 0; i < differece; i++)
            {
                newNumber += '0';
            }

            newNumber += secondNumber;
        }
        else if (secondNumber.Length > number.Length)
        {
            int differece = secondNumber.Length - number.Length;
            for (int i = 0; i < differece; i++)
            {
                newNumber += '0';
            }

            newNumber += number;
        }

        return newNumber;
    }

    public static string TransformToOr(string number, string secondNumber)
    {
        if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        string result = "";
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1' || secondNumber[i] == '1')
            {
                result += '1';
            }
            else if (number[i] == '0' && secondNumber[i] == '0')
            {
                result += '0';
            }
        }

        return result;
    }

    public static string TransformToAnd(string number, string secondNumber)
    {
        if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        string result = "";
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1' && secondNumber[i] == '1')
            {
                result += '1';
            }
            else
            {
                result += '0';
            }
        }

        return result;
    }

    public static string TransformToXor(string number, string secondNumber)
    {
        if (number.Length > secondNumber.Length)
        {
            secondNumber = MakeTheNumbersOfSameLength(number, secondNumber);
        }
        else if (number.Length < secondNumber.Length)
        {
            number = MakeTheNumbersOfSameLength(number, secondNumber);
        }

        string result = "";
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != secondNumber[i])
            {
                result += '1';
            }
            else
            {
                result += '0';
            }
        }

        return result;
    }

    public static void ApplyAll(string number, int type)
    {
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
        else if (type == OR)
        {
            ApplyOr(number);
        }
        else if (type == AND)
        {
            ApplyAnd(number);
        }
        else if (type == XOR)
        {
            ApplyXor(number);
        }
        else if (type == Left)
        {
            ApplyShiftLeft(number);
        }
        else if (type == Right)
        {
            ApplyShiftRight(number);
        }
        else
        {
            ApplyAll2(number, type);
        }
    }

    public static void ApplyAll2(string number, int type)
    {
        if (type == Less)
        {
            ApplyLessThan(number);
        }
        else if (type == Greater)
        {
            ApplyGreaterThan(number);
        }
        else if (type == Equal)
        {
            ApplyEqual(number);
        }
        else if (type == NotEqual)
        {
            ApplyNotEqual(number);
        }
        else if (type == Aduna)
        {
            ApplyAduna(number);
        }
        else if (type == Scade)
        {
            ApplyScade(number);
        }
        else if (type == Inmultire)
        {
            ApplyInmultire(number);
        }
        else if (type == Impartire)
        {
            ApplyImpartire(number);
        }
        else if (type == Factorial)
        {
            ApplyFactorial(number);
        }
        else
        {
            Console.WriteLine("Operatie invalida.");
        }
    }
}