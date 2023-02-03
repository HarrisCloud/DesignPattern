namespace DesignPattern.Example.Factory
{
    public abstract class VehicleFactory
    {

        protected readonly IServiceProvider serviceProvider;

        public VehicleFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected abstract IVehicle MakeVehicle();

        public IVehicle CreateVehicle()
        {
            return MakeVehicle();
        }
    }
}
