using System;
using System.Collections.Generic;
using System.Linq;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories;

namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<CommentDto> GetCommentsByBlogPostId(int blogPostId)
        {
            try
            {
                var comments = _commentRepository.GetByBlogPostId(blogPostId);

                return comments.Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    Content = c.Content,
                    AuthorId = c.AuthorId,
                    BlogPostId = c.BlogPostId,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving comments: {ex.Message}");
                throw;
            }
        }

        public CommentDto GetCommentById(int commentId)
        {
            try
            {
                var comment = _commentRepository.GetById(commentId);

                if (comment == null)
                {
                    throw new Exception("Comment not found");
                }

                return new CommentDto
                {
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    AuthorId = comment.AuthorId,
                    BlogPostId = comment.BlogPostId,
                    CreatedAt = comment.CreatedAt,
                    UpdatedAt = comment.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving comment: {ex.Message}");
                throw;
            }
        }

        public CommentDto CreateComment(CreateCommentDto createDto)
        {
            try
            {
                var comment = new Comment
                {
                    Content = createDto.Comment,
                    AuthorId = createDto.AuthorId,
                    BlogPostId = createDto.BlogPostId
                };

                _commentRepository.Add(comment);

                return new CommentDto
                {
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    AuthorId = comment.AuthorId,
                    BlogPostId = comment.BlogPostId,
                    CreatedAt = comment.CreatedAt,
                    UpdatedAt = comment.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating comment: {ex.Message}");
                throw;
            }
        }

        public void UpdateComment(int commentId, UpdateCommentDto updateDto)
        {
            try
            {
                var comment = _commentRepository.GetById(commentId);

                if (comment == null)
                {
                    throw new Exception("Comment not found");
                }

                comment.Content = updateDto.Content ?? comment.Content;
                comment.UpdatedAt = DateTime.UtcNow;

                _commentRepository.Update(comment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating comment: {ex.Message}");
                throw;
            }
        }

        public void DeleteComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.GetById(commentId);

                if (comment == null)
                {
                    throw new Exception("Comment not found");
                }

                _commentRepository.Delete(comment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting comment: {ex.Message}");
                throw;
            }
        }
    }
}
