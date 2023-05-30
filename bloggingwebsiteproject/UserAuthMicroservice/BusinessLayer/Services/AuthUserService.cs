using bloggingwebsiteproject.UserAuthMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Repositories;
using static bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Models.UserAuth;
using System.Text;
using System.Security.Cryptography;

namespace bloggingwebsiteproject.UserAuthMicroservice.BusinessLayer.Services
{
    public class AuthUserService : IAuthUserService
    {
        private readonly IAuthUserRepository _userRepository;
        public AuthUserService(IAuthUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Signup(AuthUserDto authUserDto)
        {
            // Check if the user with the given email already exists
            if (_userRepository.GetUserByEmail(authUserDto.Email) != null)
            {
                throw new Exception("Email already exists");
            }
            // Hash the password
            var hashedPassword = HashPassword(authUserDto.Password);



            // Add the new user to the database
            var userEntity = new AuthUser
            {
                Name = authUserDto.Name,
                Email = authUserDto.Email,
                Password = hashedPassword,
                // PasswordConfirmation = hashedPassword;
                PasswordConfirmation = authUserDto.PasswordConfirmation,
                Role = authUserDto.Role,
            };
            _userRepository.CreateUser(userEntity);
        }
        public AuthUserDto Login(LoginReq loginRequest)
        {
            // Retrieve the user with the given email from the database
            var userEntity = _userRepository.GetUserByEmail(loginRequest.Email);
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
                AuthUserDtoId = userEntity.AuthUserId,
                Name = userEntity.Name,
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

