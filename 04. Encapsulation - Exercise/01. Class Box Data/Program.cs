namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = null;

            bool isExceptionThrown = false;

            try
            {
                box = new Box(length, width, height);
            }
            catch (Exception ex)
            {
                isExceptionThrown = true;
                Console.WriteLine(ex.Message);
            }

            if (!isExceptionThrown)
            {
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
        }
    }
}
