using System;
namespace AbstractFactoryDemo
{
	public interface IWheel
	{
        public int number { get; set; }

        public string Type { get; set; }

        public void Discribe();
    }
}

