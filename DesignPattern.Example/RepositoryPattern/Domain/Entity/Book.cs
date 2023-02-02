
namespace DesignPattern.Example.RepositoryPattern.Domain.Entity
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid AuthorID { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual Author Author { get; set; }
    }
}
