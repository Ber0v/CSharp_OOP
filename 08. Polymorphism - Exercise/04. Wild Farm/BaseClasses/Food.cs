namespace WildFarm.BaseClasses
{
    public abstract class Food
    {
        public int Quantity { get; }

        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
