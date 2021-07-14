

namespace Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
            
        }

        public string Name { get; private set; }
        public virtual int Power { get; }

        public abstract string CastAbility();
    }
}
