namespace DesignPattern.Example.Facade
{
    public class Mortgage : IMortgage
    {
        private const int MaxLoanAmount = 1000000;

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
            if (amount > MaxLoanAmount)
            {
                throw new ArgumentException("requested amount is too high");
            }

            return Bank.HasFunds(customer, amount)
                && Credit.HasCredit(customer)
                && Loan.HasNoBadLoans(customer);
        }

    }
}
