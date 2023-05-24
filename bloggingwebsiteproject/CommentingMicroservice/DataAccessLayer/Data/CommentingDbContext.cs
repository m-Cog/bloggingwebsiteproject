using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Data
{
    public class CommentingDbContext : DbContext
    {
        public CommentingDbContext(DbContextOptions<CommentingDbContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Configure many-to-one relationship between Comment and BlogPost models
            modelBuilder.Entity<Comment>()
          .HasOne(c => c.BlogPost)
          .WithMany()
          .HasForeignKey(c => c.BlogPostId)
          .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-one relationship between Comment and User models
            modelBuilder.Entity<Comment>()
          .HasOne(c => c.Author)
          .WithMany()
          .HasForeignKey(c => c.AuthorId)
          .OnDelete(DeleteBehavior.Restrict);
          

        }
    }
}
   
