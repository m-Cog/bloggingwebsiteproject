using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordConfirmation { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public AuthRoleType Role { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = null!;
        }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuthRoleType
    {
        Admin,
        User
    }

}
