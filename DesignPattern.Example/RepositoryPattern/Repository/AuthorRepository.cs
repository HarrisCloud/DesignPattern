using DesignPattern.Example.RepositoryPattern.Domain.Entity;
using DesignPattern.Example.RepositoryPattern.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Example.RepositoryPattern.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DesignPatternContext context) : base(context)
        {
        }

        public Author? GetWithBooks(Guid authorId)
        {
            var authors = PatternContext.Author.ToList();
            return PatternContext.Author.Include(a => a.Books).SingleOrDefault(a => a.AuthorId == authorId);
        }

        public DesignPatternContext PatternContext => Context as DesignPatternContext;
    }
}
