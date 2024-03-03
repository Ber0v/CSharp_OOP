namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
            => $"I am {this.Name} and my favorite food is {this.FavouriteFood}";
    }
}
