using Fast.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fast.DAL
{
    public class FastDbContext : DbContext
    {
        public FastDbContext(DbContextOptions<FastDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);
        }

        public DbSet<Student> Students { get; set; }
    }
}
