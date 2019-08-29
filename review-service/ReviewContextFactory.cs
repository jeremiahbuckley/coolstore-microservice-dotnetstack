using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace ReviewService
{
    public class ReviewContextFactory : IDesignTimeDbContextFactory<ReviewContext>
    {
        // note according to documentation, args is never used see...
        // see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
        // breadcrumbs: Entity Framework Core -> Command-line Reference -> Design-time DbContextCreation

        public ReviewContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReviewContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=review;Username=swarm;Password=password");

            return new ReviewContext(optionsBuilder.Options);
        }
    }
}