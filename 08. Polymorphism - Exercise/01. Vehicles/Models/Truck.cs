namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption) { }

        public sealed override double FuelConsumption
        {
            get => fuelConsumption;

            protected set => fuelConsumption = value + 1.6;
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel * 0.95;
        }
    }
}
