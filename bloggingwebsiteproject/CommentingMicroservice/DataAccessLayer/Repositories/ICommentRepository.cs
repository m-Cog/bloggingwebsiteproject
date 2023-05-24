using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;

namespace bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories
{
    public interface ICommentRepository
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetByBlogPostId(int blogPostId);
        IEnumerable<Comment> GetByAuthorId(int authorId);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
