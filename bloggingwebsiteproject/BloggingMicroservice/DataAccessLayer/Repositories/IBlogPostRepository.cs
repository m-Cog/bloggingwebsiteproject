using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;

namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAllPost();
        BlogPost GetById(int id);
        IEnumerable<BlogPost> GetByAuthorId(int authorId);
        void AddPost(BlogPost blogPost);
        void UpdatePost(BlogPost blogPost);
        void DeletePost(BlogPost blogPost);
    }
}
