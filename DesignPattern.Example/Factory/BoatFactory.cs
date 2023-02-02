namespace DesignPattern.Example.Factory
{
    public class BoatFactory : VehicleFactory
    {
        protected override IVehicle MakeVehicle()
        {
            IVehicle vehicle = new Boat();
            return vehicle;
        }
    }
}
