namespace DesignPattern.Example.FactoryExample
{
    public class Boat : IVehicle
    {
        public double GetFuelQty()
        {
            return 10;
        }

        public int GetMileage()
        {
            return 1000;
        }

        public void StartVehicle()
        {
            Console.WriteLine("Put Put Put. Boat Started");
        }
    }
}
