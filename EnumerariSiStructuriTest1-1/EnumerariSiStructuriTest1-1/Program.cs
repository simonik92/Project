using System;

namespace Shopping
{
    enum ShippingType
    {
        Warehouse,
        Courier,
        Priority
    }

    struct Product
    {
        public string Name;
        public decimal Price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }

    class Program
    {
        public const decimal FreeCourier = 150;
        public const decimal CourierTax = 45;
        public const decimal FreePriority = 450;
        public const decimal PriorityTax = 90;

        static void Main()
        {
            Product[] shoppingList = ReadShoppingList();
            ShippingType shippingMethod = (ShippingType)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetTotalPrice(shoppingList, shippingMethod));
            Console.Read();
        }

        static decimal GetTotalPrice(Product[] shoppingList, ShippingType shippingMethod)
        {
            decimal result = 0;
            for (int i = 0; i < shoppingList.Length; i++)
            {
                result += shoppingList[i].Price;
            }

            result += GetShippingPrice(result, shippingMethod);
            return result;
        }

        static decimal GetShippingPrice(decimal productsPrice, ShippingType shippingMethod)
        {
            decimal result = 0;
            if (shippingMethod == ShippingType.Courier)
            {
                result = productsPrice < FreeCourier ? result + CourierTax : result;
                return result;
            }
            else if (shippingMethod == ShippingType.Priority)
            {
                result = productsPrice < FreePriority ? result + PriorityTax : result;
                return result;
            }
            else
            {
                return result;
            }
        }

        static Product[] ReadShoppingList()
        {
            int numberOfProducts = Convert.ToInt32(Console.ReadLine());
            Product[] result = new Product[numberOfProducts];
            for (int i = 0; i < numberOfProducts; i++)
            {
                string[] item = Console.ReadLine().Split(':');
                result[i] = new Product(item[0], Convert.ToDecimal(item[1]));
            }

            return result;
        }
    }
}
