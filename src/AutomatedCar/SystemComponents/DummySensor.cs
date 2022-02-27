
namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using System;
    using System.Linq;
    using SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket = new DummyPacket();

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects.Where(o => o.GetType() == typeof(Circle)).FirstOrDefault();
            if (circle != null)
            {
                this.dummyPacket.DistanceX = Math.Abs(World.Instance.ControlledCar.X - circle.X);
                this.dummyPacket.DistanceY = Math.Abs(World.Instance.ControlledCar.Y - circle.Y);
            }
            else
            {
                this.dummyPacket.DistanceX = int.MaxValue;
                this.dummyPacket.DistanceY = int.MaxValue;
            }

        }
    }
}
