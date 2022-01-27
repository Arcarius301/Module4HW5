using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module4HW3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Module4HW3.Helpers;
using Module4HW3.Data.Queries;

namespace Module4HW3.Helpers
{
    public static class Helper
    {
        public static async Task TryCatchTransaction(Func<Task> function, string[] args)
        {
            await using (var transaction = await new SampleContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
            {
                try
                {
                    await function();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
