namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        public DummyPacket DummyPacket { get; set; }

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.DummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.DummyPacket;
        }

        public override void Process()
        {
            Circle circle = World.Instance.WorldObjects.FirstOrDefault(c => c is Circle) as Circle;

            if (circle is not null)
            {
                this.DummyPacket.DistanceX = Math.Abs(World.Instance.ControlledCar.X - circle.X);
                this.DummyPacket.DistanceY = Math.Abs(World.Instance.ControlledCar.Y - circle.Y);
            }
        }
    }
}
