namespace _05._Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int[] integersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (counter < 3)
            {
                try
                {
                    string[] commands = Console.ReadLine().Split();
                    if (commands[0] == "Replace")
                    {
                        IsParsable(commands[1]);
                        IsParsable(commands[2]);
                        if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) >= integersArray.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        else
                        {
                            integersArray[int.Parse(commands[1])] = int.Parse(commands[2]);
                        }
                    }
                    else if (commands[0] == "Print")
                    {
                        IsParsable(commands[1]);
                        IsParsable(commands[2]);
                        if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) >= integersArray.Length || int.Parse(commands[2]) < 0 || int.Parse(commands[2]) >= integersArray.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        else
                        {
                            for (int i = int.Parse(commands[1]); i <= int.Parse(commands[2]); i++)
                            {
                                Console.Write(integersArray[i]);
                                if (i < int.Parse(commands[2]))
                                {
                                    Console.Write(", ");
                                }
                            }

                            Console.WriteLine();
                        }
                    }
                    else if (commands[0] == "Show")
                    {
                        IsParsable(commands[1]);
                        if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) >= integersArray.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        else
                        {
                            Console.WriteLine(integersArray[int.Parse(commands[1])]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    counter++;
                }
            }

            Console.WriteLine(string.Join(", ", integersArray));

        }

        public static void IsParsable(string input)
        {
            if (!int.TryParse(input, out int n))
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
        }
    }
}
