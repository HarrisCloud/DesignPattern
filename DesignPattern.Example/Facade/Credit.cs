namespace DesignPattern.Example.Facade
{
    public class Credit : ICredit
    {
        public bool HasCredit(Customer customer)
        {
            // Check for credit
            return customer.IsNoble;
        }
    }
}
