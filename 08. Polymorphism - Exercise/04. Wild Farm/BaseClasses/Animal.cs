namespace WildFarm.BaseClasses
{
    public abstract class Animal
    {
        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public abstract string AskForFood();

        public abstract void Feed(Food food);
    }
}
