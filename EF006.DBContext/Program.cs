using EF006.DBContext.Data;

namespace EF006.DBContext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDBContext())
            {
              foreach(var wallet in context.wallets) Console.WriteLine(wallet);
            }
            Console.ReadKey();
        }
    }
}
