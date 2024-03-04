namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption) { }

        public sealed override double FuelConsumption
        {
            get => fuelConsumption;

            protected set => fuelConsumption = value + 0.9;
        }
    }
}
