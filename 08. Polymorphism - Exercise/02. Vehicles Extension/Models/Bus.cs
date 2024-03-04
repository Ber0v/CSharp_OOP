namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_PEOPLE_INCREASE = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + FUEL_CONSUMPTION_WITH_PEOPLE_INCREASE, tankCapacity) { }

        public void DriveEmpty(double km)
        {
            FuelConsumption -= FUEL_CONSUMPTION_WITH_PEOPLE_INCREASE;

            Drive(km);

            FuelConsumption += FUEL_CONSUMPTION_WITH_PEOPLE_INCREASE;
        }
    }
}
