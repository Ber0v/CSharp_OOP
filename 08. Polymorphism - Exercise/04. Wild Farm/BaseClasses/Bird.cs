namespace WildFarm.BaseClasses
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; }

        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString() => $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
