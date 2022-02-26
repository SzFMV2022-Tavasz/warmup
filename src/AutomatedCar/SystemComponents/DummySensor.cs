namespace AutomatedCar.SystemComponents
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using global::AutomatedCar.SystemComponents.Packets;

    public class DummySensor: SystemComponent
    {
        public DummyPacket DummyPacket { get; set; }

        public DummySensor(VirtualFunctionBus vb): base(vb)
        {
            this.DummyPacket = (DummyPacket)this.virtualFunctionBus.DummyPacket;
        }

        public override void Process()
        {
            Circle kor = (Circle)World.Instance.WorldObjects.Where(i => i.GetType()==typeof(Circle)).FirstOrDefault();

            int xD = Math.Abs(World.Instance.ControlledCar.X - kor.X);
            int yD = Math.Abs(World.Instance.ControlledCar.Y - kor.Y);

            this.DummyPacket.DistanceX = xD;
            this.DummyPacket.DistanceY = yD;
        }
    }
}
