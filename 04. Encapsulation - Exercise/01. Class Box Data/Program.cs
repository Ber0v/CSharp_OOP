﻿namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
