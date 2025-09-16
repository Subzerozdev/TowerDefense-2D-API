using Microsoft.EntityFrameworkCore;
using Repository.Model;


namespace Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<GameInfo> GameInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Username)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.Password)
                      .IsRequired()
                      .HasMaxLength(100);

              
                entity.HasOne(c => c.GameInfo)
                      .WithOne(g => g.Customer)
                      .HasForeignKey<GameInfo>(g => g.Id);
            });
         
            modelBuilder.Entity<GameInfo>(entity =>
            {
                entity.ToTable("GameInfos");

                entity.HasKey(g => g.Id);

                entity.Property(g => g.Stars)
                      .HasDefaultValue(0);

                entity.Property(g => g.CurrentLevel)
                      .HasDefaultValue(1);

                entity.Property(g => g.ThunderSkill)
                      .HasDefaultValue(0);

                entity.Property(g => g.BoomSkill)
                      .HasDefaultValue(0);
            });
        }
    }
}
