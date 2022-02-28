namespace AutomatedCar.SystemComponents.Packets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;

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
            Circle circle = (Circle)World.Instance.WorldObjects.Where(w => w.GetType() == typeof(Circle)).FirstOrDefault();
            AutomatedCar automatedCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(circle.X - automatedCar.X);
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - automatedCar.Y);
        }
    }
}
