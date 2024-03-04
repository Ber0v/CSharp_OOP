namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double DEFUALT_CONSUMPTION_INCREASE = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + DEFUALT_CONSUMPTION_INCREASE, tankCapacity) { }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");

                return;
            }

            double fuelAfterRefueling = FuelQuantity + fuel * 0.95;

            if (fuelAfterRefueling > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");

                return;
            }

            FuelQuantity = fuelAfterRefueling;
        }
    }
}
