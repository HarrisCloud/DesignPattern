namespace DesignPattern.Example.Strategy
{
    public class ReveseSort : SortStrategy
    {
        public override IEnumerable<string> Sort(IEnumerable<string> data)
        {
            return data.ToList().OrderByDescending(d => d);
        }
    }
}
