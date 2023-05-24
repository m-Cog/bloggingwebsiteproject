using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;

namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAllPost();
        BlogPost GetById(int id);
        IEnumerable<BlogPost> GetByAuthorId(int authorId);
        void Add(BlogPost blogPost);
        void Update(BlogPost blogPost);
        void Delete(BlogPost blogPost);
    }
}
