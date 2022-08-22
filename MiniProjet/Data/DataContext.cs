using Microsoft.EntityFrameworkCore;
using MiniProjet.Model;

namespace MiniProjet.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Company>()
      .HasMany(c => c.Visits)
      .WithOne(u => u.Company)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
      .HasMany(c => c.Staffs)
      .WithOne(u => u.Company)
      .OnDelete(DeleteBehavior.Cascade);


        }
    

    }
}
