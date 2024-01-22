//La un examen au luat notă de trecere N studenți, ceea ce reprezintă X% din numărul total de studenți care au dat examenul.
//Scrie o aplicație ce calculează câți studenți ar trece examenul dacă Y% dintre ei ar lua notă de trecere.
//Datele de intrare (N, X și Y) sunt numere întregi și se vor citi de la tastatură, câte un număr pe linie.
/*
string inputData = Console.ReadLine();
int n = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int x = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int y = Convert.ToInt32(inputData);
int studentsNumber = (n * 100) / x;
int result = (studentsNumber * y) / 100;
Console.WriteLine(result);
*/

//În X zile Y capre mănâncă Z kilograme de fân.
//Să se scrie o aplicație ce returnează numărul de kilograme de fân pe care le mănâncă Q capre în W zile.
//Datele de intrare sunt numere întregi și se vor citi de la tastatură, câte un număr pe linie, în următoarea ordine: X, Y, Z, Q, W.
string inputData = Console.ReadLine();
int xZile = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int yCapre = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int zKilograme = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int qCapre = Convert.ToInt32(inputData);
inputData = Console.ReadLine();
int wZile = Convert.ToInt32(inputData);
float oCapraPeZi = (float)zKilograme / (float)yCapre / (float)xZile;
float result = oCapraPeZi * (float)qCapre * (float)wZile;
Console.WriteLine(result);