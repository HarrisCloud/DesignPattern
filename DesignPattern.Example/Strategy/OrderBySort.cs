namespace DesignPattern.Example.Strategy
{
    public class OrderBySort : SortStrategy
    {
        public override IEnumerable<string> Sort(IEnumerable<string> data)
        {
            return data.ToList().OrderBy(d => d);
        }
    }
}
