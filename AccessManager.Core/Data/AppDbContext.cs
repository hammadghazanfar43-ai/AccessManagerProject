using Model; // instead of AccessManager.Core.Models

using Microsoft.EntityFrameworkCore;

namespace AccessManager.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<ArchivedFormSubmission> ArchivedFormSubmissions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any fluent API configurations here if needed
        }
    }
}
    