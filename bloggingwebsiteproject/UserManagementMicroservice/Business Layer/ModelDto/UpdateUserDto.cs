namespace bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
