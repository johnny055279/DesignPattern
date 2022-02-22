using System;
namespace FactoryMethodPatternDemo
{
	public class Car : IProduct
	{
        private decimal defaultPrice = 1000;

        private string defaultType = "default";

        public decimal Price { get => defaultPrice; set => defaultPrice = value; }

        public string Type { get => defaultType; set => defaultType = value; }

        public Car() { }

        public Car(string type)
        {
            this.Type = type;
        }

        public Car(decimal price)
        {
            this.Price = price;
        }

        public Car(string type, decimal price)
        {
            this.Type = type;

            this.Price = price;
        }

  

        public void Discripe()
        {
            Console.WriteLine($"I an a car of {Type}. cost ${Price}");
        }
	}
}

