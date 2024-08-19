using EF006.DBContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBContextFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var constr = config.GetSection("constr").Value;

            var service = new ServiceCollection();

            service.AddDbContextFactory<AppDBContext>(option => option.UseSqlServer(constr));

            IServiceProvider serviceProvider = service.BuildServiceProvider();

            var contextfactory= serviceProvider.GetService<IDbContextFactory<AppDBContext>>();


            using (var context = contextfactory!.CreateDbContext())
            {
                foreach (var contextItem in context!.wallets) Console.WriteLine(contextItem);
            }
            Console.ReadKey();
        }
    }
}
