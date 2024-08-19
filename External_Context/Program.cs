using EF006.DBContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace External_Context
{
    public class Program
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
                foreach (var wallet in context.wallets) Console.WriteLine(wallet);
            }
            Console.ReadKey();
        }
    }
}
