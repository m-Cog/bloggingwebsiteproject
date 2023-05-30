using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Data
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<BlogPost> BlogPosts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasMany(u => u.BlogPosts)
              .WithOne(bp => bp.Author)
              .HasForeignKey(bp => bp.AuthorId);

            modelBuilder.Entity<User>()
              .HasMany(u => u.Comments)
              .WithOne(c => c.Author)
              .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Comment>()
              .HasOne(c => c.BlogPost)
              .WithMany(bp => bp.Comments)
              .HasForeignKey(c => c.BlogPostId);

            modelBuilder.Entity<BlogPost>()
              .HasOne(bp => bp.Author)
              .WithMany(u => u.BlogPosts)
              .HasForeignKey(bp => bp.AuthorId);


            

            base.OnModelCreating(modelBuilder);
        }





    }
}
