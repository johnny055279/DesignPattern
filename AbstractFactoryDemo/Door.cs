using System;
namespace AbstractFactoryDemo
{
    public class Door : IDoor
    {
        public int Number { get; set; }

        public string Color { get; set; }

        public void Discribe()
        {
            Console.WriteLine($"Door number: {Number} with {Color} Color");
        }
    }
}

