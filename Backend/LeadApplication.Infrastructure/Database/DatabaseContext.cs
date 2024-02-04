using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LeadApplication.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<JobEntity> Job { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobEntity>().HasOne(j => j.Client).WithMany(c => c.Jobs).HasForeignKey(j => j.Client).HasPrincipalKey(j => j.Id);
            modelBuilder.Entity<JobEntity>().Property(j => j.Category).HasConversion<int>();
            modelBuilder.Entity<ClientEntity>().HasKey(c => c.Id).HasName("ID");
        }

    }
}
