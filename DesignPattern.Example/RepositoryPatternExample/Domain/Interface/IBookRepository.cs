using DesignPattern.Example.RepositoryPatternExample.Domain.Entity;

namespace DesignPattern.Example.RepositoryPatternExample.Domain.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetTopSellingBooks(int count);
        IEnumerable<Book> GetWithAuthors(int pageIdx, int pageSize);
    }
}
