using System.Collections.Generic;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;

namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentsByBlogPostId(int blogPostId);
        CommentDto GetCommentById(int commentId);
        CommentDto CreateComment(CreateCommentDto createDto);
        void UpdateComment(int commentId, UpdateCommentDto updateDto);
        void DeleteComment(int commentId);
    }
}
