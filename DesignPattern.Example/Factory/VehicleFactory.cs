namespace DesignPattern.Example.Factory
{
    public abstract class VehicleFactory
    {
        protected abstract IVehicle MakeVehicle();

        public IVehicle CreateVehicle()
        {
            return MakeVehicle();
        }
    }
}
