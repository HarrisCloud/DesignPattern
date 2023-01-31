namespace DesignPattern.Example.FactoryExample
{
    public class Car : IVehicle
    {
        public double GetFuelQty()
        {
            return 10.5;
        }

        public int GetMileage()
        {
            return 123000;
        }

        public void StartVehicle()
        {
            Console.WriteLine("Brrm Brrm. Car Started");
        }
    }
}
