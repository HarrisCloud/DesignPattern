
using DesignPattern.Example.RepositoryPattern.Domain.Entity;

namespace DesignPattern.Example.RepositoryPattern.Domain.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author? GetWithBooks(Guid authorId);
    }
}
