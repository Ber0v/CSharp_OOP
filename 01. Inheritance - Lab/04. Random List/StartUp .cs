namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("metko");
            list.Add("rifko");

            Console.WriteLine(list.RandomString());
        }
    }
}
