namespace DesignPattern.Example.Strategy
{
    public abstract class SortStrategy
    {
        public abstract IEnumerable<string> Sort(IEnumerable<string> data);
    }
}
