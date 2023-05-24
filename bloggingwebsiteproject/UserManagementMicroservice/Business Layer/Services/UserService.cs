using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;

namespace bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users.Select(u => new UserDto
            {
                UserId = u.Id,
                Username = u.Username,
                Email = u.Email
            });
        }

        public UserDto GetUserId(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found");
            }

            return new UserDto
            {
                UserId = user.Id,
                Username= user.Username,
                Email = user.Email
            };
        }

        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _userRepository.Add(user);

            return new UserDto
            {
                UserId = user.Id,
                Username = user.Username,           
                Email = user.Email
            };
        }

        public void UpdateUser(int userId, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found");
            }

            user.Username = updateUserDto.Username ?? user.Username;
            user.Email = updateUserDto.Email ?? user.Email;
            user.Password = updateUserDto.Password ?? user.Password;
            user.UpdatedAt = DateTime.UtcNow;

             _userRepository.Update(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found");
            }

           _userRepository.Delete(user);
        }
    }
}
