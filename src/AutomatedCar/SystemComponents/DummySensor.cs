namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    class DummySensor : SystemComponent
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
            Circle cir = (Circle)World.Instance.WorldObjects.Where(x => x.GetType() == typeof(Circle)).FirstOrDefault();

            AutomatedCar automatedCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(cir.X - automatedCar.X);
            this.dummyPacket.DistanceX = Math.Abs(cir.Y - automatedCar.Y);
        }
    }
}
