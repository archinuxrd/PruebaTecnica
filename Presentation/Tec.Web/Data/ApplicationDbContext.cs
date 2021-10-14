using Tec.Web.Models.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tec.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>();
            builder.Entity<Combination>();

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Combination> Combinations { get; set; }
    }
}
