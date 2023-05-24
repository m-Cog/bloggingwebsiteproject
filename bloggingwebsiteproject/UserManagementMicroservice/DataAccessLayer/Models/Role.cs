using System.ComponentModel.DataAnnotations;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation property for users
        public virtual ICollection<User> Users { get; set; } = null!;
    }
}
