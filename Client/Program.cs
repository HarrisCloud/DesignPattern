using DesignPattern.Example.Factory;
using DesignPattern.Example.RepositoryPattern.Repository;
using DesignPattern.Example.RepositoryPattern.Service;
using DesignPattern.Example.RepositoryPattern.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using DesignPattern.Example.Singleton;
using DesignPattern.Example.Strategy;
using DesignPattern.Example.Observer;
using DesignPattern.Example.Facade;

internal class Program
{
    // Repository Pattern
    private static void Main(string[] args)
    {
        Console.WriteLine("Running program");
        // RunRepoPattern(args);
        // RunFactoryPattern(args);
        // RunSingletonPattern();
        // RunStrategyPattern();
        // RunObserverPattern();
        RunFacadePattern();
        Console.WriteLine("Completed program");
    }

    // Facade Pattern
    private static void RunFacadePattern()
    {
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) => services
                .AddScoped<IBank, Bank>()
                .AddScoped<ICredit, Credit>()
                .AddScoped<ILoan, Loan>()
                .AddScoped<IMortgage, Mortgage>())
            .Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        var mortgage = provider.GetRequiredService<IMortgage>();
        var customer1 = new Customer("Bob", true);
        var customer2 = new Customer("Fred", false);

        if (mortgage.IsEligible(customer1, 100000))
        {
            Console.WriteLine($"{customer1.Name} is eligible");
        }
        else
        {
            Console.WriteLine($"{customer1.Name} is not eligible");
        }

        if (mortgage.IsEligible(customer2, 100000))
        {
            Console.WriteLine($"{customer2.Name} is eligible");
        }
        else
        {
            Console.WriteLine($"{customer2.Name} is not eligible");
        }

    }

    // Observer Pattern
    private static void RunObserverPattern()
    {
        var apple = new Apple(10.1m);
        var tesla = new Tesla(22.2m);
        var investor1 = new Investor("Joe"); 
        var investor2 = new Investor("Bill");
        var investor3 = new Investor("Elon");
        apple.Attach(investor1);
        apple.Attach(investor2);
        tesla.Attach(investor3);

        apple.Price = 10.5m;
        apple.Price = 11.2m;
        tesla.Price = 23.3m;

        Console.ReadKey();

        apple.Detach(investor1);
        apple.Price = 11.5m;

        Console.ReadKey();
    }


    // Strategy Pattern
    private static void RunStrategyPattern()
    {
        var animals = new List<string>
        {
            "Cat", "Dog", "Girraffe", "Tiger", "Fish", "Hippo"
        };
        Console.WriteLine("QuickSort");
        var sorter = new SortedList(new QuickSort());
        var sortedList = sorter.Sort(animals);
        foreach (var animal in sortedList)
        {
            Console.WriteLine(animal.ToString());
        }

        Console.WriteLine("\nReveseSort");
        sorter = new SortedList(new ReveseSort());
        sortedList = sorter.Sort(animals);
        foreach (var animal in sortedList)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    // Singleton Pattern
    private static void RunSingletonPattern()
    {
        var logger1 = Logger.GetLogger("Starter1");
        var logger2 = Logger.GetLogger("Starter2");
        logger1.WriteMessage("Test1");
        logger2.WriteMessage("Test2");
    }

    // Repository Pattern
    private static void RunRepoPattern(string[] args)
    {
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
    }

    // Factory Pattern
    private static void RunFactoryPattern(string[] args)
    {
        IVehicle vehicle = new CarFactory().CreateVehicle();
        Console.WriteLine($"Mileage={vehicle.GetMileage()}");
        Console.WriteLine($"FuelQty={vehicle.GetFuelQty()}");
        vehicle.StartVehicle();

        vehicle = new BoatFactory().CreateVehicle();
        Console.WriteLine($"Mileage={vehicle.GetMileage()}");
        Console.WriteLine($"FuelQty={vehicle.GetFuelQty()}");
        vehicle.StartVehicle();
    }



    //public void ConfigureServices(IServiceCollection services)
    //{
    //    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
    //    var configuration = builder.Build();
    //    var conn = configuration.GetConnectionString("DbConnection");

    //    services.AddDbContext<DesignPatternContext>(options => options.UseSqlServer(conn));
    //}
}