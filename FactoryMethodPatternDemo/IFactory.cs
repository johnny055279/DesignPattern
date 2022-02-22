using System;
namespace FactoryMethodPatternDemo
{
	public interface IFactory
	{
		public IProduct MakeProduct();
	}
}

