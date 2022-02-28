namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            var TargetCircle = World.Instance.WorldObjects.Where(w => w.GetType() == typeof(Circle)).FirstOrDefault();

            this.dummyPacket.DistanceX = Math.Abs(TargetCircle.X - World.Instance.ControlledCar.X);
            this.dummyPacket.DistanceY = Math.Abs(TargetCircle.Y - World.Instance.ControlledCar.Y);
        }
    }
}
