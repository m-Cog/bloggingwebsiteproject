using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;


namespace bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly UserManagementDbContext _context;

        public CommentRepository( UserManagementDbContext context)
        {
            _context = context;
        }

        public Comment GetById(int id)
        {
            var data = _context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (data == null)
            {
                throw new Exception("comment not found");
            }
            return data;
        }

        public IEnumerable<Comment> GetByBlogPostId(int blogPostId)
        {
            var data = _context.Comments.Where(c => c.BlogPostId == blogPostId);
            if(data == null)
            {
                throw new Exception("blog id not found");
            }
            return data;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetByAuthorId(int authorId)
        {
            throw new NotImplementedException();
        }

    }
}
