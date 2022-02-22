using System;
namespace FactoryMethodPatternDemo
{

    public interface IProduct
	{
        public decimal Price { get; set; }

        public string Type { get; set; }

        public void Discripe();
	}
}

