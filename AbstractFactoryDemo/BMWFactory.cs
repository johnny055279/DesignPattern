using System;
namespace AbstractFactoryDemo
{
	public class BMWFactory : CarFactory
	{
        public override IDoor GetDoor(int doorNumber, string doorColor)
        {
            IDoor door = new Door();

            door.Number = doorNumber;

            door.Color = doorColor;

            return door;
        }

        public override IWheel GetWheel(int wheelNumber)
        {
            IWheel wheel = new Wheel();

            wheel.number = wheelNumber;

            wheel.Type = "BMW";

            return wheel;
        }


    }
}

