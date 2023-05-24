using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;

namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentsForBlogPost(int blogPostId);
        IEnumerable<CommentDto> GetCommentsByUserId(int userId);
        CommentDto GetCommentById(int commentId);
        CommentDto CreateComment(CreateCommentDto createCommentDto);
        void UpdateComment(int commentId, UpdateCommentDto updateCommentDto);
        void DeleteComment(int commentId);
    }
}
