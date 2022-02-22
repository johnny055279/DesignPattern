using System;
namespace AbstractFactoryDemo
{
    public class SubaruFactory : CarFactory
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

            wheel.Type = "Subaru";

            return wheel;
        }
    }
}

