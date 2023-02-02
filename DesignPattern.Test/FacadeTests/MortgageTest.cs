using DesignPattern.Example.Facade;
using NSubstitute;

namespace DesignPattern.Test.FacadeTests
{
    public class MortgageTest
    {
        //public IBank Bank { get; }
        //public ICredit Credit { get; }
        //public ILoan Loan { get; }

        //public void Init()
        //{
        //    var bank = Substitute.For<IBank>();
        //    var credit = Substitute.For<ICredit>();
        //    var loan = Substitute.For<ILoan>();
        //}

        [Fact]
        public void IsEligible_Success()
        {
            var bank = Substitute.For<IBank>();
            var credit = Substitute.For<ICredit>();
            var loan = Substitute.For<ILoan>();

            bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(true);

            credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(true);

            var sut = new Mortgage(bank, credit, loan);

            var result = sut.IsEligible(new Customer("Bob", true), 1000);
            Assert.True(result);
        }

        [Fact]
        public void IsEligible_Ineligible()
        {
            var bank = Substitute.For<IBank>();
            var credit = Substitute.For<ICredit>();
            var loan = Substitute.For<ILoan>();

            bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(false);

            credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(false);

            var sut = new Mortgage(bank, credit, loan);
            var result = sut.IsEligible(new Customer("Fred", false), 1000);
            Assert.False(result);
        }


        [Fact]
        public void IsEligible_ExceedsLimit()
        {
            var bank = Substitute.For<IBank>();
            var credit = Substitute.For<ICredit>();
            var loan = Substitute.For<ILoan>();

            bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(true);

            credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(true);

            var sut = new Mortgage(bank, credit, loan);
            Assert.Throws<ArgumentException>(() => sut.IsEligible(new Customer("Jim", true), 1000001));            
        }
    }
}
