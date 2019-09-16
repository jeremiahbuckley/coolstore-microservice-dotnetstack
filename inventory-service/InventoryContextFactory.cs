using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace InventoryService
{
    public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        // note according to documentation, args is never used see...
        // see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
        // breadcrumbs: Entity Framework Core -> Command-line Reference -> Design-time DbContextCreation

        public InventoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=inventory;Username=swarm;Password=password");

            return new InventoryContext(optionsBuilder.Options);
        }
    }
}