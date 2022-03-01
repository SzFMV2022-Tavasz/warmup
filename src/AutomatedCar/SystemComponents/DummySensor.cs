namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {

        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle =
                (from worldObject in World.Instance.WorldObjects
                 where worldObject.GetType() == typeof(Circle)
                 select worldObject).ToList().FirstOrDefault();

            var car = World.Instance.ControlledCar;

            if (circle != null && car != null)
            {
                this.dummyPacket.DistanceX = Math.Abs(car.X - circle.X);
                this.dummyPacket.DistanceY = Math.Abs(car.Y - circle.Y);
            }
        }
    }
}
