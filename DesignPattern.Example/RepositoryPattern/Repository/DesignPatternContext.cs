using DesignPattern.Example.RepositoryPattern.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesignPattern.Example.RepositoryPattern.Repository
{
    public class DesignPatternContext : DbContext
    {
        //public DesignPatternContext(DbContextOptions<DesignPatternContext> options) : base(options)
        //{

        //}

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                     // .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                     .AddJsonFile("appsettings.json", optional: false)
                     .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            }
        }
    }
}
