using FactoryMethodPatternDemo;

CarFactory carfactory = new CarFactory();

Console.WriteLine("Start making default car...");

IProduct car1 = carfactory.MakeProduct();

car1.Discripe();

Console.WriteLine("Start making BMW car...");

IProduct car2 = carfactory.MakeProduct("BMW");

car2.Discripe();

Console.WriteLine("Start making Subaru car and price is $1500...");

IProduct car3 = carfactory.MakeProduct("Subaru", 1500);

car3.Discripe();
