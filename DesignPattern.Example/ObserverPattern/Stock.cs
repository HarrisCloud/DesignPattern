namespace DesignPattern.Example.ObserverPattern
{
    public abstract class Stock
    {
        public Stock(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        private decimal _price = 0; 
        public decimal Price {
            get 
            { 
                return _price; 
            }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        private IList<IInvestor> Investors = new List<IInvestor>();

        public void Attach(IInvestor investor) 
        {
            if (!Investors.Any(inv => inv == investor))
            {
                Investors.Add(investor);
            }
        }

        public void Detach(IInvestor investor) 
        {
            if (Investors.Any(inv => inv == investor))
            {
                Investors.Remove(investor);
            }
        }
        
        public void Notify()
        {
            foreach (var investor in Investors)
            {
                investor.Update(this);
            }
        }
    }
}
