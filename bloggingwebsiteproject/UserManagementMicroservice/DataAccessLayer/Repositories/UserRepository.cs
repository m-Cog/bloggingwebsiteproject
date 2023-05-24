using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository

    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetById(int id)

        {

           var data= _context.Users.FirstOrDefault(u => u.Id == id);
            if(data == null)
            {
                throw new Exception("no id found ");
            }
            return data;
        }


        public User GetByEmail(string email)

        {

            var data = _context.Users.FirstOrDefault(u => u.Email == email);
            if (data == null)
            {
                throw new Exception("no email found");
            }
            return data;

        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(User user)

        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
