using DesignPattern.Example.RepositoryPattern.Domain.Entity;
using DesignPattern.Example.RepositoryPattern.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Example.RepositoryPattern.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DesignPatternContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetWithAuthors(int pageIndex, int pageSize)
        {
            return PatternContext.Book
               .Include(c => c.Author)
               .OrderBy(c => c.Title)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();
        }

        public IEnumerable<Book> GetTopSellingBooks(int count)
        {
            return PatternContext.Book.OrderByDescending(c => c.Title).Take(count).ToList();
        }

        public DesignPatternContext PatternContext => Context as DesignPatternContext;
    }
}
