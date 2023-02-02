namespace DesignPattern.Example.Facade
{
    public class Bank : IBank
    {  
        public bool HasFunds(Customer customer, decimal amount)
        {
            // check funds
            return customer.IsNoble;
        }
    }
}
