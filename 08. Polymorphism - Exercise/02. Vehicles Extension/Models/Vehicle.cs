namespace VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
                FuelQuantity = 0;

            else
                FuelQuantity = fuelQuantity;

            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

        }

        protected double fuelConsumption;

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public int TankCapacity { get; protected set; }

        public virtual void Drive(double distance)
        {
            double fuelToConsume = distance * FuelConsumption;

            if (FuelQuantity - fuelToConsume < 0)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");

                return;
            }

            FuelQuantity -= fuelToConsume;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");

                return;
            }

            double fuelAfterRefueling = FuelQuantity + fuel;

            if (fuelAfterRefueling > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");

                return;
            }

            FuelQuantity = fuelAfterRefueling;
        }

        public override string ToString() => $"{GetType().Name}: {Math.Round(FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}";
    }
}
