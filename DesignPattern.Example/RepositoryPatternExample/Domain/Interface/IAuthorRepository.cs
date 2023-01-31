
using DesignPattern.Example.RepositoryPatternExample.Domain.Entity;

namespace DesignPattern.Example.RepositoryPatternExample.Domain.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author? GetWithBooks(Guid authorId);
    }
}
