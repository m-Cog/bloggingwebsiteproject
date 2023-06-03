
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagementManagement.Business_Layer.ModelDto;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;
using System.Security.Cryptography;
using System.Text;

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

            //new addition start

            //new addition end
        }

        public void Signup(AuthUserDto authUserDto)
        {
            // Check if the user with the given email already exists
            if (_userRepository.GetByEmail(authUserDto.Email) != null)
            {
                throw new Exception("Email already exists");
            }
            // Hash the password
            var hashedPassword = HashPassword(authUserDto.Password);



            // Add the new user to the database
            var userEntity = new User
            {
                Username = authUserDto.Username,
                Email = authUserDto.Email,
                Password = hashedPassword,
                // PasswordConfirmation = hashedPassword;
                PasswordConfirmation = authUserDto.PasswordConfirmation,
                Role = authUserDto.Role,
            };
            _userRepository.Add(userEntity);
        }

        public AuthUserDto Login(LoginReq loginRequest)
        {
            // Retrieve the user with the given email from the database
            var userEntity = _userRepository.GetByEmail(loginRequest.Email);
            if (userEntity == null)
            {
                throw new Exception("Email does not exist");
            }



            // Check if the given password matches the user's password
            var hashedPassword = HashPassword(loginRequest.Password);
            if (userEntity.Password != hashedPassword)
            {
                throw new Exception("Invalid password");
            }



            // Return the user object
            return new AuthUserDto
            {
                AuthUserDtoId = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
                PasswordConfirmation = userEntity.PasswordConfirmation,
                Role = userEntity.Role



            };
        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
