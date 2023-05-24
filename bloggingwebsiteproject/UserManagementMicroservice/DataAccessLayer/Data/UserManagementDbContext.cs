using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Data
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between User and Role models
            modelBuilder.Entity<User>()
          .HasMany(u => u.Roles)
          .WithMany(r => r.Users)
          .UsingEntity<Dictionary<string, object>>(
                "UserRoles",
                ur=>ur.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Restrict),
                 ur => ur.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict),
                 ur =>
                 {
                     ur.HasKey("UserId", "RoleId");
                 });
        }
    }
}
