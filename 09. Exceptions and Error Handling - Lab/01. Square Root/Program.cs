namespace _01._Square_Root
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException();
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

    }
}
