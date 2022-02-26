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
        private World World;
        private AutomatedCar parentCar;
        public DummySensor(VirtualFunctionBus vb,World world,AutomatedCar car): base(vb)
        {
            this.DummyPacket = (DummyPacket)this.virtualFunctionBus.DummyPacket;
            this.World = world;
            this.parentCar = car;
        }

        public override void Process()
        {
            Circle kor = (Circle)this.World.WorldObjects.Where(i => i.GetType()==typeof(Circle)).FirstOrDefault();

            int xD = Math.Abs(this.parentCar.X - kor.X);
            int yD = Math.Abs(this.parentCar.Y - kor.Y);

            this.DummyPacket.DistanceX = xD;
            this.DummyPacket.DistanceY = yD;
        }
    }
}
