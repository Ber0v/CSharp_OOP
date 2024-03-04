namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double DEFUALT_CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + DEFUALT_CONSUMPTION_INCREASE, tankCapacity) { }
    }
}
