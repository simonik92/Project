using System;
namespace FirstClass
{
	internal class Car
	{
		private string _name;
		private int _hp;
		private string _color;
		public Car(string name, int hp = 0, string color = "black")
		{
			_name = name;
			Console.WriteLine("Car was created");
			_hp = hp;
			_color = color;
		}

        public void Drive()
        {
            Console.WriteLine(_name + " is driving ");
        }

		public void Stop()
		{
			Console.WriteLine(_name + " Stopped");
		}

		public void Details()
		{
			Console.WriteLine("Name: " + _name);
			Console.WriteLine("HP: " + _hp);
			Console.WriteLine("Color: " + _color);
		}
    }
}

