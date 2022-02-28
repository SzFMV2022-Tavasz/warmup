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
        DummyPacket packet = new DummyPacket();
        WorldObject circle;

        public DummySensor(VirtualFunctionBus bus) : base(bus)
        {
            this.circle = (from x in World.Instance.WorldObjects
                           where x.GetType() == typeof(Circle)
                           select x).ToList().FirstOrDefault();
        }

        public override void Process()
        {
            this.packet.DistanceX = Math.Abs(World.Instance.ControlledCar.X - this.circle.X);
            this.packet.DistanceY = Math.Abs(World.Instance.ControlledCar.Y - this.circle.Y);
        }
    }
}
