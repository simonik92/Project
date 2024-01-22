//Să se scrie o aplicație consolă ce calculează și afișează diferența a două numere întregi. Cele două numere se vor citi de la tastatură, câte unul pe linie.
/*
string inputData = Console.ReadLine();
int firstNumber = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int secondNumber = Convert.ToInt32(inputData);

Console.WriteLine(firstNumber - secondNumber);
*/

//Să se scrie o aplicație consolă ce ridică un număr dat la puterea a doua.
/*
double inputData = Convert.ToDouble(Console.ReadLine());
Console.WriteLine(inputData*inputData);
*/
//Să se scrie o aplicație ce afișează la consolă True dacă un număr întreg dat este par și False altfel.
int inputData = Convert.ToInt32(Console.ReadLine());
if(inputData % 2 == 0)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}