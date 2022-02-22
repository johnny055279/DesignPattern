using System;
namespace FactoryMethodPatternDemo
{
    public class CarFactory : IFactory
    {
        public IProduct MakeProduct()
        {
            return new Car();
        }

        public IProduct MakeProduct(string type)
        {
            return new Car(type);
        }

        public IProduct MakeProduct(string type, decimal price)
        {
            return new Car(type, price);
        }

        public IProduct MakeProduct(decimal price)
        {
            return new Car(price);
        }
    }
}

