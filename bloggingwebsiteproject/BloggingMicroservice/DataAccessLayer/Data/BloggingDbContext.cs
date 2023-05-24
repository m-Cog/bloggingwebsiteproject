using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Data
{
  
public class BloggingDbContext : DbContext

    {

        public BloggingDbContext(DbContextOptions<BloggingDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            // Configure many-to-many relationship between BlogPost and Category models

            modelBuilder.Entity<BlogPost>()

          .HasMany(bp => bp.Categories)
          .WithMany(c => c.BlogPosts)
          .UsingEntity<Dictionary<string, object>>(
                "BlogPostCategories",
                x => x.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                x => x.HasOne<BlogPost>().WithMany().HasForeignKey("BlogPostId")
                );


        }

    }


}
