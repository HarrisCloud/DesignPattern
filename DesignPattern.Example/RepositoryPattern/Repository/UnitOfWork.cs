using DesignPattern.Example.RepositoryPattern.Domain.Interface;

namespace DesignPattern.Example.RepositoryPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesignPatternContext _context;

        public UnitOfWork(DesignPatternContext context) //, IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _context= context;
            //Authors= authorRepository;
            //Books= bookRepository;
            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
        }

        public IBookRepository Books { get; private set; }

        public IAuthorRepository Authors { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
