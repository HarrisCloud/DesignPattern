namespace DesignPattern.Example.RepositoryPattern.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        int Save();
    }
}
