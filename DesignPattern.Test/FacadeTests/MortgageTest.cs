using DesignPattern.Example.Facade;
using NSubstitute;

namespace DesignPattern.Test.FacadeTests
{
    public class MortgageTest
    {
        private readonly IBank _bank = Substitute.For<IBank>();
        private readonly ICredit _credit = Substitute.For<ICredit>();
        private readonly ILoan _loan = Substitute.For<ILoan>();
        
        [Fact]
        public void IsEligible_Success()
        {
            _bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(true);

            _credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            _loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(true);

            var sut = new Mortgage(_bank, _credit, _loan);

            var result = sut.IsEligible(new Customer("Bob", true), 1000);
            Assert.True(result);
        }


        [Theory]
        [InlineData("Bob")]
        [InlineData("Jim")]
        public void IsEligible_NameSuccess(string name)
        {
            _bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(true);

            _credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            _loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(true);

            var sut = new Mortgage(_bank, _credit, _loan);

            var result = sut.IsEligible(new Customer(name, true), 1000);
            Assert.True(result);
        }


        [Fact]
        public void IsEligible_Ineligible()
        {
            _bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(false);

            _credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            _loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(false);

            var sut = new Mortgage(_bank, _credit, _loan);
            var result = sut.IsEligible(new Customer("Fred", false), 1000);
            Assert.False(result);
        }


        [Fact]
        public void IsEligible_ExceedsLimit()
        {
            _bank.HasFunds(Arg.Any<Customer>(), Arg.Any<decimal>())
                .Returns(true);

            _credit.HasCredit(Arg.Any<Customer>())
                .Returns(true);

            _loan.HasNoBadLoans(Arg.Any<Customer>())
                .Returns(true);

            var sut = new Mortgage(_bank, _credit, _loan);
            Assert.Throws<ArgumentException>(() => sut.IsEligible(new Customer("Jim", true), 1000001));            
        }
    }
}
