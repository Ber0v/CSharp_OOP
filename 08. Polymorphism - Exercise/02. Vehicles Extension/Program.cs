namespace VehiclesExtension
{
    using VehiclesExtension.Models;
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var carFuel = new
            {
                Quantity = double.Parse(carInfo[1]),
                Consumption = double.Parse(carInfo[2]),
                Capacity = int.Parse(carInfo[3])
            };

            var truckFuel = new
            {
                Quantity = double.Parse(truckInfo[1]),
                Consumption = double.Parse(truckInfo[2]),
                Capacity = int.Parse(truckInfo[3])
            };

            var busFuel = new
            {
                Quantity = double.Parse(busInfo[1]),
                Consumption = double.Parse(busInfo[2]),
                Capacity = int.Parse(busInfo[3])
            };

            Car car = new Car(carFuel.Quantity, carFuel.Consumption, carFuel.Capacity);
            Truck truck = new Truck(truckFuel.Quantity, truckFuel.Consumption, truckFuel.Capacity);
            Bus bus = new Bus(busFuel.Quantity, busFuel.Consumption, busFuel.Capacity);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= commandCount; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandTokens[0];
                string typeOfVehicle = commandTokens[1];

                double parameter = double.Parse(commandTokens[2]);

                Vehicle vehicle = null;

                switch (typeOfVehicle)
                {
                    case "Car":
                        vehicle = car;
                        break;

                    case "Truck":
                        vehicle = truck;
                        break;

                    case "Bus":
                        vehicle = bus;
                        break;

                    default:
                        throw new ArgumentException("Invalid vehicle type!");
                }

                switch (command)
                {
                    case "Drive":
                        vehicle.Drive(parameter);
                        break;

                    case "DriveEmpty":
                        bus.DriveEmpty(parameter);
                        break;

                    case "Refuel":
                        vehicle.Refuel(parameter);
                        break;

                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
