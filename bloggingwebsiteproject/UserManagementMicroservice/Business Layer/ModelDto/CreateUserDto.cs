namespace bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
