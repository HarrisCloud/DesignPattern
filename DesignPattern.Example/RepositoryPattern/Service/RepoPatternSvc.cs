using DesignPattern.Example.RepositoryPattern.Domain.Entity;
using DesignPattern.Example.RepositoryPattern.Domain.Interface;
using DesignPattern.Example.RepositoryPattern.Repository;

namespace DesignPattern.Example.RepositoryPattern.Service
{
    public class RepoPatternSvc : IRepoPatternSvc
    {
        //public RepoPatternSvc(IUnitOfWork unitOfWork)
        //{
        //    UnitOfWork = unitOfWork;
        //}

        //public IUnitOfWork UnitOfWork { get; }

        public void RunExample()
        {
            
            using (var unitOfWork = new UnitOfWork(new DesignPatternContext()))
            // using (UnitOfWork)
            {
                // Example1
                var author = unitOfWork.Authors.Get(Guid.Parse("89610EDC-4352-4D38-9F08-6069C34A3028"));

                Console.WriteLine($"Author={author.Name}");

                // Example2
                var authors = unitOfWork.Authors.GetWithBooks(Guid.Parse("89610EDC-4352-4D38-9F08-6069C34A3028"));

                // Example3
                var books = unitOfWork.Books.GetWithAuthors(1, 5);

                //if (author != null)
                //{
                //    author.Name = author.Name + " 1";
                //    unitOfWork.Save();
                //}

                //var book = new Book()
                //{
                //    BookId = Guid.NewGuid(),
                //    AuthorID = author.AuthorId,
                //    Title = "My New Book",
                //    Description = "Book Description"
                //};
                //unitOfWork.Books.Add(book);
                //unitOfWork.Save();
            }
        }

            //public void TestConnection()
            //{

            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //    builder.DataSource = "LAPTOP-4EQA7AMD";
            //    builder.IntegratedSecurity = true;
            //    builder.InitialCatalog = "HarriTest";
            //    builder.TrustServerCertificate = true;

            //    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //    {
            //        connection.Open();

            //        String sql = "SELECT name FROM dbo.Author";

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine($"My Data = {reader.GetString(0)}");
            //                }
            //            }
            //        }
            //    }
            // }
        }
}
