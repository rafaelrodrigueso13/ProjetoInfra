using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<Item> Items { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Manutencoes)
                .WithOne(m => m.Item)
                .HasForeignKey(m => m.ItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
