namespace AutomatedCar.SystemComponents
{
    using System.Collections.Generic;
    using SystemComponents.Packets;

    public class VirtualFunctionBus : GameBase
    {
        private List<SystemComponent> components = new List<SystemComponent>();

        public IReadOnlyDummyPacket DummyPacket { get; set; }

    public void RegisterComponent(SystemComponent component)
        {
            this.components.Add(component);
        }

        protected override void Tick()
        {
            foreach (SystemComponent component in this.components)
            {
                component.Process();
            }
        }

        //public int IReadOnlyDummyPacket()
        //{
        //    get => DummyPacket;
        //    set => this.RaiseAndSetIfChanged(ref this.distanceX, value);

        //    return 0;              //////////////////////////////////////////////////////////////////////////////////
        //}

        //public int ReadOnlyDummyPacket()
        //{
        //    return 0;
        //}

        //public int registerComponent(SystemComponent component)
        //{
        //    components.Add(component);
        //    return 0;
        //}
    }
}