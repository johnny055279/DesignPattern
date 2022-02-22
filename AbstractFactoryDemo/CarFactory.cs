using System;
namespace AbstractFactoryDemo
{
	public abstract class CarFactory
	{
        public abstract IDoor GetDoor(int doorNumber, string doorColor);

        public abstract IWheel GetWheel(int wheelNumber);
    }
}

