namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;
        private AutomatedCar car;

        public DummySensor(AutomatedCar car) : base(car.VirtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.car = car;
            this.car.VirtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects[0];

            int distanceX = Math.Abs(circle.X - this.car.X);
            int distanceY = Math.Abs(circle.Y - this.car.Y);

            this.dummyPacket.DistanceX = distanceX;
            this.dummyPacket.DistanceY = distanceY;
        }
    }
}
