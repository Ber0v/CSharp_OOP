namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal price = 3.50m;
        private const double mililiters = 50;
        public Coffee(string name, double caffeine) : base(name, price, mililiters)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; private set; }
    }
}