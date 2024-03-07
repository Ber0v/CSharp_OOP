namespace _02._Enter_Numbers
{
    class Program
    {
        public static int start = 1;
        public static int end = 100;
        public static List<int> numbers = new List<int>();
        static void Main(string[] args)
        {
            ReadNumber();
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ReadNumber()
        {
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    string number = Console.ReadLine();
                    int n = 0;
                    if (!int.TryParse(number, out n))
                    {
                        throw new ArgumentException("Invalid Number!");
                    }
                    else if (int.Parse(number) <= start || int.Parse(number) >= end)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - 100!");
                    }
                    else
                    {
                        start = int.Parse(number);
                        numbers.Add(int.Parse(number));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
        }
    }
}
