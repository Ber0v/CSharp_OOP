using WildFarm.BaseClasses;

namespace WildFarm.Animals.Mammals
{
    using FoodTypes;
    public class Dog : Mammal
    {
        private const double WEIGHT_MODIFIER = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        public override string AskForFood() => "Woof!";

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Meat))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");

                return;
            }

            Weight += food.Quantity * WEIGHT_MODIFIER;
            FoodEaten += food.Quantity;
        }

        public override string ToString() => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
