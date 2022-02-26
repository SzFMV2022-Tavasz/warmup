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

        public DummySensor(VirtualFunctionBus vbf) : base(vbf)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects[0];
            var car = World.Instance.ControlledCar;

            int distanceX = Math.Abs(circle.X - car.X);
            int distanceY = Math.Abs(circle.Y - car.Y);

            this.dummyPacket.DistanceX = distanceX;
            this.dummyPacket.DistanceY = distanceY;
        }
    }
}
