using EF006.DBContext.Data;
using EF006.DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBContext_Concurrency
{
    internal class Program
    {
        static AppDBContext context = null!;
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var constr = config.GetSection("constr").Value;

            var service = new ServiceCollection();

            service.AddDbContext<AppDBContext>(option => option.UseSqlServer(constr));

            IServiceProvider serviceProvider = service.BuildServiceProvider();

            context = serviceProvider.GetRequiredService<AppDBContext>();

            var task = new[]
              {
                Task.Factory.StartNew(()=>job1()),
                Task.Factory.StartNew(()=>job2())
              };
            Task.WhenAll(task).ContinueWith(t => { 
                Console.WriteLine("Job1 & Job2 Run concurrently"); 
            });

            Console.ReadKey();
        }
        static async Task job1()
        {
            var w1 = new Wallet { Holder = "Qasem", Balance = 5000m };
            context.wallets.Add(w1);
           await context.SaveChangesAsync();
        }

        static async Task job2()
        {
            var w2 = new Wallet { Holder = "Sara", Balance = 5000m };
            context.wallets.Add(w2);
           await context.SaveChangesAsync();
        }
    }
}
