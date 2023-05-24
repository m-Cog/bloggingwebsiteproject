namespace bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

    }
}
