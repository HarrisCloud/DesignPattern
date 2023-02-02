namespace DesignPattern.Example.Strategy
{
    public class QuickSort : SortStrategy
    {
        public override IEnumerable<string> Sort(IEnumerable<string> data)
        {
            var dataList = data.ToList();
            dataList.Sort();
            return dataList;
        }
    }
}
