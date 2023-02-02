using DesignPattern.Example.RepositoryPattern.Domain.Entity;

namespace DesignPattern.Example.RepositoryPattern.Domain.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetTopSellingBooks(int count);
        IEnumerable<Book> GetWithAuthors(int pageIdx, int pageSize);
    }
}
