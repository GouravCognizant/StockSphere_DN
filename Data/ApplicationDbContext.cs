using Microsoft.EntityFrameworkCore;
using StockSphere_DN.Models.Entities;

namespace StockSphere_DN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Configure one-to-one relationship
            modelBuilder.Entity<UserInfo>() 
                .HasOne(u => u.UserProfile) 
                .WithOne() 
                .HasForeignKey<UserInfo>(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
