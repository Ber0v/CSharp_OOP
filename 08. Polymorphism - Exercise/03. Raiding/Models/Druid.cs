namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DefautPower = 80;
        public Druid(string name) : base(name, DefautPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
