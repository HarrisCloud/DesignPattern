namespace DesignPattern.Example.Facade
{
    public interface IMortgage
    {
        bool IsEligible(Customer customer, decimal amount);
    }
}
