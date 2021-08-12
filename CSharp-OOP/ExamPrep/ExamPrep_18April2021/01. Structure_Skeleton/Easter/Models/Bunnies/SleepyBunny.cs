
namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialSleepyBunnyEnergy = 50;
        private const int AdditionalEnergyDrop = 5;
        public SleepyBunny(string name)
            : base(name, InitialSleepyBunnyEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= AdditionalEnergyDrop;
        }
    }
}
