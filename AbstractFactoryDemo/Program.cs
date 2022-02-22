using AbstractFactoryDemo;

var BMWFactory = new BMWFactory();

Console.WriteLine($"Satrt creating BMW...");

CreateCar(BMWFactory, 4, "red", 4);

Console.WriteLine("finish!");

Console.WriteLine(" ");

var subaruFactory = new SubaruFactory();

Console.WriteLine($"Satrt creating Subaru...");

CreateCar(subaruFactory, 2, "blue", 4);

Console.WriteLine("finish!");


void CreateCar(CarFactory carFactory, int doorNumber, string doorColor, int wheelNumber)
{
    var door = carFactory.GetDoor(doorNumber, doorColor);

    var wheel = carFactory.GetWheel(wheelNumber);

    Console.WriteLine("-------");

    door.Discribe();

    wheel.Discribe();

    Console.WriteLine("-------");

}