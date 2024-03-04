using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var carFuel = new
            {
                Quantity = double.Parse(carInfo[1]),
                Consumption = double.Parse(carInfo[2])
            };

            var truckFuel = new
            {
                Quantity = double.Parse(truckInfo[1]),
                Consumption = double.Parse(truckInfo[2])
            };

            Vehicle car = new Car(carFuel.Quantity, carFuel.Consumption);
            Vehicle truck = new Truck(truckFuel.Quantity, truckFuel.Consumption);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= commandCount; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandTokens[0];
                string typeOfVehicle = commandTokens[1];

                double parameter = double.Parse(commandTokens[2]);

                Vehicle vehicle;

                if (typeOfVehicle == "Car")
                    vehicle = car;

                else if (typeOfVehicle == "Truck")
                    vehicle = truck;

                else
                    throw new ArgumentException("Invalid vehicle type");


                if (command == "Drive")
                    vehicle.Drive(parameter);

                else if (command == "Refuel")
                    vehicle.Refuel(parameter);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
