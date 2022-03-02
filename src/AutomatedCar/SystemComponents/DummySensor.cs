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
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            Circle circle = World.Instance.WorldObjects.Where(i => i.GetType() == typeof(Circle)).FirstOrDefault() as Circle;

            if (circle != null)
            {
                this.dummyPacket.DistanceX = Math.Abs(circle.X - World.Instance.ControlledCar.X);
                this.dummyPacket.DistanceY = Math.Abs(circle.Y - World.Instance.ControlledCar.Y);
            }
    
        }
    }
}