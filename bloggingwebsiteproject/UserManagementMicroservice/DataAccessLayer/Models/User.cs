using System.ComponentModel.DataAnnotations;
using System.Data;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation property for roles
        public virtual ICollection<Role> Roles { get; set; } = null!;
    }

}
