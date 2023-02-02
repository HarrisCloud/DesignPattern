namespace DesignPattern.Example.Facade
{
    public class Mortgage : IMortgage
    {
        public Mortgage(IBank bank, ICredit credit, ILoan loan)
        {
            Bank = bank;
            Credit = credit;
            Loan = loan;
        }

        public IBank Bank { get; }
        public ICredit Credit { get; }
        public ILoan Loan { get; }

        public bool IsEligible(Customer customer, decimal amount)
        {
            return Bank.HasFunds(customer, amount)
                && Credit.HasCredit(customer)
                && Loan.HasNoBadLoans(customer);
        }

    }
}
