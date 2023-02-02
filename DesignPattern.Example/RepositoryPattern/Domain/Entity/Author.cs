
namespace DesignPattern.Example.RepositoryPattern.Domain.Entity
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public Guid AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; } = string.Empty;

        public virtual ICollection<Book> Books { get; set; }
    }
}
