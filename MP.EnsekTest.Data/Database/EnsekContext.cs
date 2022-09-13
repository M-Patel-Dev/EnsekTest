using Microsoft.EntityFrameworkCore;
using MP.EnsekTest.Data.Entities;

namespace MP.EnsekTest.Data.Database
{
    public class EnsekContext : DbContext
    {
        public EnsekContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterRead>().HasKey(
                c => new { c.AccountId, c.ReadingDateTime });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public DbSet<MeterRead> MeterReads { get; set; }
        public DbSet<Account> CustomerAccounts { get; set; }
    }
}
