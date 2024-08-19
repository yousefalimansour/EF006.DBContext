using EF006.DBContext.Data;
using EF006.DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBContextLifeCycle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var constr = config.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();

            optionBuilder.UseSqlServer(constr);
            var options = optionBuilder.Options;

            using (var context = new AppDBContext(options))
            {
                var w1 = new Wallet { Holder = "essam", Balance = 8000m };
                context.wallets.Add(w1);

                var w2 = new Wallet { Holder = "eslam", Balance = 6000m };
                context.wallets.Add(w2);

                context.SaveChanges();

            }

            Console.ReadKey();
        }
    }
}
