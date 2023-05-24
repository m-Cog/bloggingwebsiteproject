using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;

namespace bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUserId(int userId);
        UserDto CreateUser(CreateUserDto createUserDto);
        void UpdateUser(int userId,UpdateUserDto updateUserDto);
        void DeleteUser(int userId);
    }
}
