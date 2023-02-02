using DesignPattern.Example.Facade;

namespace DesignPattern.Test.FacadeTests
{
    public class BankTest
    {
        [Fact]
        public void HasFunds_IsNoble()
        {
            var sut = new Bank();
            var result = sut.HasFunds(new Customer("TestMan", true), 100);
            Assert.True(result);
        }

        [Fact]
        public void HasFunds_IsNotNoble()
        {
            var sut = new Bank();
            var result = sut.HasFunds(new Customer("TestMan", false), 100);
            Assert.False(result);
        }
    }
}
