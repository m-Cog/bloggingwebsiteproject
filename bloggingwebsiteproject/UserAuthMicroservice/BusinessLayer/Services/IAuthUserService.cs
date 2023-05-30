using bloggingwebsiteproject.UserAuthMicroservice.BusinessLayer.ModelDto;

namespace bloggingwebsiteproject.UserAuthMicroservice.BusinessLayer.Services
{
    public interface IAuthUserService
    {
        void Signup(AuthUserDto authUserDto);
        AuthUserDto Login(LoginReq loginRequest);
        string HashPassword(string password);

    }
}
