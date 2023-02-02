namespace DesignPattern.Example.Facade
{
    public class Loan : ILoan
    {
        public bool HasNoBadLoans(Customer customer)
        {
            return customer.IsNoble;
        }
    }
}
