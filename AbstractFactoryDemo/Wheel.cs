using System;
namespace AbstractFactoryDemo
{
    public class Wheel : IWheel
    {
        public int number { get; set; }

        public string Type { get; set; }

        public void Discribe()
        {
            Console.WriteLine($"Wheel number: {number}, Type: {Type}");
        }
    }
}

