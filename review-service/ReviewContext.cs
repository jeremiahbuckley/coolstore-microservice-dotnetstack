using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReviewService.Models;

namespace ReviewService 
{
    public class ReviewContext : DbContext
    {
        public DbSet<Review> Review { get; set; }

        public ReviewContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            // example:
            // modelBuilder.Entity<Review>()
            //   .Property(r => r.Rating)
            //   .IsRequired();
        }
    }
}