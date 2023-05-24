using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace bloggingwebsiteproject.CommentingMicroservice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController (ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("blogpost/{blogPostId}")]
        public IEnumerable<CommentDto> GetCommentsForBlogPost(int blogPostId)
        {
            return _commentService.GetCommentsForBlogPost(blogPostId);
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<CommentDto> GetCommentsByUserId(int userId)
        {
            return _commentService.GetCommentsByUserId(userId);
        }

        [HttpGet("{commentId}")]
        public CommentDto GetCommentById(int commentId)
        {
            return _commentService.GetCommentById(commentId);
        }

        [HttpPost]
        public CommentDto CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            return _commentService.CreateComment(createCommentDto);
        }

        [HttpPut("{commentId}")]
        public void UpdateComment(int commentId, [FromBody] UpdateCommentDto updateCommentDto)
        {
            _commentService.UpdateComment(commentId, updateCommentDto);
        }

        [HttpDelete("{commentId}")]
        public void DeleteComment(int commentId)
        {
            _commentService.DeleteComment(commentId);
        }
    }
}

