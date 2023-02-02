namespace DesignPattern.Example.Facade
{
    public interface IBank
    {
        bool HasFunds(Customer customer, decimal amount);
    }
}
