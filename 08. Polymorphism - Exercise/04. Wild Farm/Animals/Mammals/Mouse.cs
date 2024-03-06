using WildFarm.BaseClasses;

namespace WildFarm.Animals.Mammals
{
    using FoodTypes;
    public class Mouse : Mammal
    {
        private const double WEIGHT_MODIFIER = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        public override string AskForFood() => "Squeak";

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Vegetable) && food.GetType() != typeof(Fruit))
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
