using static bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Models.UserAuth;

namespace bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Repositories
{
    public interface IAuthUserRepository
    {
        AuthUser GetUserByEmail(string email);
        void CreateUser(AuthUser user);

    }
}
