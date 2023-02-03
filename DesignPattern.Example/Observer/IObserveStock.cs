namespace DesignPattern.Example.Observer
{
    public interface IObserveStock
    {
        void Attach(IInvestor investor);

        void Detach(IInvestor investor);

        void Notify();
    }
}
