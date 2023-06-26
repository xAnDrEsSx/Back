using Microsoft.EntityFrameworkCore;
using TestQuala.Domain.Entities;

namespace TestQuala.Infrastructure.Persistence
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
        public TestDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Forzamos llaves FK
        }

        public DbSet<BranchStore>? BranchStores { get; set; }
        public DbSet<CurrencyType>? CurrencyTypes { get; set; }


    }
}
