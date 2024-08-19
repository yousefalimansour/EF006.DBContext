using EF006.DBContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dependancy_Injection
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

            service.AddDbContext<AppDBContext>(option=>option.UseSqlServer(constr));// add new service

            IServiceProvider serviceProvider = service.BuildServiceProvider();


            using(var context = serviceProvider.GetService<AppDBContext>())
            {
                foreach(var contextItem in context!.wallets) Console.WriteLine(contextItem);
            }
            Console.ReadKey();
        }
    }
}
