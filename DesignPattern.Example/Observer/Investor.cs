namespace DesignPattern.Example.Observer
{
    public class Investor : IInvestor
    {
        public Investor(string name)
        {
            Name = name;
            InvestedStock = null;
        }

        public string Name { get; private set; }
        private Stock? InvestedStock { get; set; }

        public void Update(Stock stock)
        {
            InvestedStock = stock;
            Console.WriteLine($"Investor: {Name}, Stock name: {InvestedStock.Name}, New Stock Price: {InvestedStock.Price}");
        }
    }
}
