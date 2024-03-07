namespace _04._Sum_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string number = input[i];
                try
                {
                    if (int.TryParse(input[i], out int n))
                    {
                        sum += n;
                    }
                    else
                    {
                        if (long.TryParse(input[i], out long h))
                        {
                            if (h < -2147483648 || h > 2147483647)
                            {
                                throw new OverflowException($"The element '{number}' is out of range!");
                            }
                        }

                        else
                        {
                            throw new FormatException($"The element '{number}' is in wrong format!");
                        }

                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Element '{number}' processed - current sum: {sum}");

            }

            Console.WriteLine($"The total sum of all integers is: {sum}");

        }
    }

}
