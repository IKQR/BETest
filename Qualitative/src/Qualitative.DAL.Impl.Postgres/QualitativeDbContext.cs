using Microsoft.EntityFrameworkCore;
using Qualitative.DAL.Entities;

namespace Qualitative.DAL.Impl.Postgres
{
    public class QualitativeDbContext : DbContext
    {
        public QualitativeDbContext(DbContextOptions<QualitativeDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);
        }

        private DbSet<Student> Students { get; set; }
    }
}
