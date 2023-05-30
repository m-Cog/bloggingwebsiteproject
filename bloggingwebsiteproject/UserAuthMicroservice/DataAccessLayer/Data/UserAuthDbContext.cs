using Microsoft.EntityFrameworkCore;
using static bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Models.UserAuth;

namespace bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Data
{
    public class UserAuthDbContext : DbContext
    {

        public UserAuthDbContext(DbContextOptions<UserAuthDbContext> options) : base(options)
        {
        }
        public DbSet<AuthUser> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }


}

