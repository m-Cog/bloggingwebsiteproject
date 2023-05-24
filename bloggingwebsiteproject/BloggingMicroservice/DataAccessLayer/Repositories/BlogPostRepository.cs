using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Data;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories
{

    public class BlogPostRepository : IBlogPostRepository

    {
        private readonly BloggingDbContext _context;
        public BlogPostRepository(BloggingDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BlogPost> GetAllPost()
        {
            return _context.BlogPosts.ToList();
        }
        public BlogPost GetById(int id)

        {

            var data = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
            if (data == null)
            {
                throw new Exception("no blog found");
            }
            return data;

        }


        public IEnumerable<BlogPost> GetByAuthorId(int authorId)

        {

            var data = _context.BlogPosts.Where(bp => bp.AuthorId == authorId);
            if (data == null)
            {
                throw new Exception("no id found");
            }
            return data;

        }


        public void Add(BlogPost blogPost)

        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }


        public void Update(BlogPost blogPost)

        {
            _context.Entry(blogPost).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(BlogPost blogPost)
        {
            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
        }

    }

}
