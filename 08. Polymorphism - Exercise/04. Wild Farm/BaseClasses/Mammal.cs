namespace WildFarm.BaseClasses
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; }

        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
    }
}
