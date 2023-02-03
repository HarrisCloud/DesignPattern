namespace DesignPattern.Example.Factory
{
    public class BoatFactory : VehicleFactory
    {
        public BoatFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override IVehicle MakeVehicle()
        {
            return (IVehicle)serviceProvider.GetService(typeof(Boat));
        }
    }
}
