using Microsoft.EntityFrameworkCore;
using WebApiPostgresql.Api.Interfaces;

namespace WebApiPostgresql.Api.Models
{
    public class EfContext : DbContext, IDbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
        }
    }
}
