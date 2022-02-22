using System;
namespace AbstractFactoryDemo
{
	public interface IDoor
	{
        public int Number { get; set; }

        public string Color { get; set; }

        public void Discribe();
    }
}

