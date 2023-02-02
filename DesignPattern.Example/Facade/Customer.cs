namespace DesignPattern.Example.Facade
{
    public class Customer
    {
        public string Name { get; set; }

        public bool IsNoble { get; set; }

        public Customer(string name, bool isNoble)
        {
            Name = name;
            IsNoble = isNoble;
        }
    }
}
