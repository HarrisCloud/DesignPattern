namespace DesignPattern.Example.FactoryExample
{
    public class CarFactory : VehicleFactory
    {
        protected override IVehicle MakeVehicle()
        {
            IVehicle vehicle = new Car();
            return vehicle;
        }
    }
}
