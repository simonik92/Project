using System;
namespace FirstClass
{
    class Program
    {
        public static void Main(String[] args)
        {
            Car audi = new Car("Audi", 350, "Red");
            audi.Drive();
            audi.Details();
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                audi.Stop();
            }
            else
            {
                Console.WriteLine("Car is driving");

            }
        }
    }
} 
