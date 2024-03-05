namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int DefautPower = 100;
        public Paladin(string name) : base(name, DefautPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
