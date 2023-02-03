namespace DesignPattern.Example.Factory
{
    public class CarFactory : VehicleFactory
    {
        public CarFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override IVehicle MakeVehicle()
        {
            return (IVehicle)serviceProvider.GetService(typeof(Car));
        }
    }
}
