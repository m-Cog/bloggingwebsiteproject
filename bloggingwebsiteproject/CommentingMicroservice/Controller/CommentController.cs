using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace bloggingwebsiteproject.CommentingMicroservice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("blogpost/{blogPostId}")]
        public ActionResult<IEnumerable<CommentDto>> GetCommentsForBlogPost(int blogPostId)
        {
            try
            {
                return Ok(_commentService.GetCommentsByBlogPostId(blogPostId));
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while retrieving comments for the blog post.");
            }
        }

        [HttpGet("{commentId}")]
        public ActionResult<CommentDto> GetCommentById(int commentId)
        {
            try
            {
                var comment = _commentService.GetCommentById(commentId);
                if (comment == null)
                {
                    return NotFound();
                }
                return Ok(comment);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while retrieving the comment.");
            }
        }

        [HttpPost]
        public ActionResult<CommentDto> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            try
            {
                var comment = _commentService.CreateComment(createCommentDto);
                return CreatedAtAction(nameof(GetCommentById), new { commentId = comment.AuthorId }, comment);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while creating the comment.");
            }
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(int commentId, [FromBody] UpdateCommentDto updateCommentDto)
        {
            try
            {
                _commentService.UpdateComment(commentId, updateCommentDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while updating the comment.");
            }
        }

        [HttpDelete("{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            try
            {
                _commentService.DeleteComment(commentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while deleting the comment.");
            }
        }
    }
}
