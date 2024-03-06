using WildFarm.BaseClasses;

namespace WildFarm.Animals.Birds
{
    using FoodTypes;
    public class Owl : Bird
    {
        private const double WEIGHT_MODIFIER = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override string AskForFood() => "Hoot Hoot";

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
    }
}
