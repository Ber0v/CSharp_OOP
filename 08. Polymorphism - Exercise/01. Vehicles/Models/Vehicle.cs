namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        protected double fuelConsumption;

        public double FuelQuantity { get; protected set; }

        public abstract double FuelConsumption { get; protected set; }

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

        public virtual void Refuel(double fuel) => FuelQuantity += fuel;

        public override string ToString() => $"{GetType().Name}: {Math.Round(FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}";
    }
}
