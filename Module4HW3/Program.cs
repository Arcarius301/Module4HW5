using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Module4HW3.Data;
using Module4HW3.Helpers;
using Module4HW3.Data.Queries;

namespace Module4HW3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                var queries = new Queries(context);
                await Helper.TryCatchTransaction(() => queries.FirstQuery(), args);
                await Helper.TryCatchTransaction(() => queries.SecondQuery(), args);
                await Helper.TryCatchTransaction(() => queries.ThirdQuery(), args);
                await Helper.TryCatchTransaction(() => queries.FourthQuery(), args);
                await Helper.TryCatchTransaction(() => queries.FifthQuery(), args);
                await Helper.TryCatchTransaction(() => queries.SixthQuery(), args);
            }

            Console.Read();
        }
    }
}
