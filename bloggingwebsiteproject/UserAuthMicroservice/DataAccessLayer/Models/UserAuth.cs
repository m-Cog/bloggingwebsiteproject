using System.ComponentModel.DataAnnotations;

namespace bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Models
{
    public class UserAuth
    {
        public class AuthUser
        {
            [Key]
            public int AuthUserId { get; set; }

            [Required]
            public string Name { get; set; } = null!;

            [Required]
            public string Email { get; set; } = null!;


            [Required]
            [StringLength(150, MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null!;



            [Required]
            [StringLength(150, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
            public string PasswordConfirmation { get; set; } = null!;
            public AuthRoleType Role { get; set; }
        }
        public enum AuthRoleType
        {
            Admin,
            User
        }

    }
}
