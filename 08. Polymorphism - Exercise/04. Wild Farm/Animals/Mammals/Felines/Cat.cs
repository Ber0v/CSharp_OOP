using WildFarm.BaseClasses;

namespace WildFarm.Animals.Mammals.Felines
{
    using FoodTypes;
    public class Cat : Feline
    {
        private const double WEIGHT_MODIFIER = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        public override string AskForFood() => "Meow";

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Vegetable) && food.GetType() != typeof(Meat))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");

                return;
            }

            Weight += food.Quantity * WEIGHT_MODIFIER;

            FoodEaten += food.Quantity;
        }
    }
}
