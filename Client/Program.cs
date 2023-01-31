using DesignPattern.Example.FactoryExample;
using DesignPattern.Example.RepositoryPatternExample.Repository;
using DesignPattern.Example.RepositoryPatternExample.Service;
using DesignPattern.Example.RepositoryPatternExample.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

internal class Program
{
    // Repository Pattern
    private static void Main(string[] args)
    {
        Console.WriteLine("Running program");
        IConfigurationRoot configuration = new ConfigurationBuilder()
                     // .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                     .AddJsonFile("appsettings.json", optional: false)
                     .Build();

        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) => services
                //.AddDbContext<DesignPatternContext>(
                //    options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")))
                //.AddScoped<IAuthorRepository, AuthorRepository>()
                //.AddScoped<IBookRepository, BookRepository>()
                //.AddTransient<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRepoPatternSvc, RepoPatternSvc>()
                )
            .Build();


        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        // var uow = provider.GetRequiredService<IUnitOfWork>();
        var repoPatternSvc = provider.GetRequiredService<IRepoPatternSvc>();
        repoPatternSvc.RunExample();

        Console.WriteLine("Completed program");
    }

    // Factory Pattern
    //private static void Main(string[] args)
    //{
    //    IVehicle vehicle = new CarFactory().CreateVehicle();
    //    Console.WriteLine($"Mileage={vehicle.GetMileage()}");
    //    Console.WriteLine($"FuelQty={vehicle.GetFuelQty()}");
    //    vehicle.StartVehicle();

    //    vehicle = new BoatFactory().CreateVehicle();
    //    Console.WriteLine($"Mileage={vehicle.GetMileage()}");
    //    Console.WriteLine($"FuelQty={vehicle.GetFuelQty()}");
    //    vehicle.StartVehicle();
    //}



    //public void ConfigureServices(IServiceCollection services)
    //{
    //    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
    //    var configuration = builder.Build();
    //    var conn = configuration.GetConnectionString("DbConnection");

    //    services.AddDbContext<DesignPatternContext>(options => options.UseSqlServer(conn));
    //}
}