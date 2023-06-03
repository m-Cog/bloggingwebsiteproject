using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetById(int id);
        User GetByEmail(string email);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
      
    }
}
