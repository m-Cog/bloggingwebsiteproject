using bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.ModelDto;
using static bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Models.UserAuth;

namespace bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Repositories
{
 
        public class AuthUserRepository : IAuthUserRepository
        {
            private readonly UserAuthDbContext _context;



            public AuthUserRepository(UserAuthDbContext applicationDbContext)
            {
                _context = applicationDbContext;
            }
            public AuthUser GetUserByEmail(string email)
            {
                var data = _context.Users.SingleOrDefault(u => u.Email == email);
              if (data != null)
              {
                    throw new Exception("no email found 435");
              }
              return data;
        }



            public void CreateUser(AuthUser user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

    }

