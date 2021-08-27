using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.Repositories
{
    public class ApplicationDbContext : DbContext, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();

            optionsBuilder.UseSqlServer("not empty");

            return new(optionsBuilder.Options);
        }
    }
}
