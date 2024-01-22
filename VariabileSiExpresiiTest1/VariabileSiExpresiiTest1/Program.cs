//Ce valoare are variabila x după ce s-au executat instrucțiunile de mai jos?

/*byte x = 5;
byte y = 10;
x = (byte)(x - y);
Console.WriteLine(x);*/

/*
checked
{
    int x = 2147483640;
    int y = 10;
    x = x + y;
    Console.WriteLine(x);//eroare de executie
}
*/

/*
int x;
x = x + 2;
Console.WriteLine(x);
//eroare de compilare
*/

/*int y = 100;
int x = y / 2;
y = y / 10;
Console.WriteLine(x); //50
*/

/*
int y = 2;
{
    y *= 3;
}
int x = y * 2;

Console.WriteLine(x); //6 */

/*
int x = 2;
{
    int y = x;
    y++;
}
x = (x + y) * 10;
Console.WriteLine(x); //eroare de compilare
*/

/*
int y = 2;
const int z = 10;
const int t = z + 2;
const int x = t + y + 2;
Console.WriteLine(x);//eroare de compilare
*/