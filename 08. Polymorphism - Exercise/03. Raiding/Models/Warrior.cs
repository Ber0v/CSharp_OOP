namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DefautPower = 100;

        public Warrior(string name) : base(name, DefautPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
