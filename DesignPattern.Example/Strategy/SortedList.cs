namespace DesignPattern.Example.Strategy
{
    public class SortedList
    {
        private SortStrategy sortStrategy;

        public SortedList(SortStrategy strategy)
        {
            sortStrategy= strategy;
        }
        
        public IEnumerable<string> Sort(IEnumerable<string> listToSort)
        {
            return sortStrategy.Sort(listToSort);            
        }
    }
}
