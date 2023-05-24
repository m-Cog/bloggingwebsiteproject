using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services
{


    public class CommentService : ICommentService

    {

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)

        {

            _commentRepository = commentRepository;

        }


        public IEnumerable<CommentDto> GetCommentsForBlogPost(int blogPostId)

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


        public IEnumerable<CommentDto> GetCommentsByUserId(int userId)

        {

            var comments = _commentRepository.GetByAuthorId(userId);

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


        public CommentDto GetCommentById(int commentId)

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


        public CommentDto CreateComment(CreateCommentDto createCommentDto)

        {

            var comment = new Comment

            {

                Content = createCommentDto.Comment,

                AuthorId = createCommentDto.AuthorId,

                BlogPostId = createCommentDto.BlogPostId

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


        public void UpdateComment(int commentId, UpdateCommentDto updateCommentDto)

        {

            var comment = _commentRepository.GetById(commentId);

            if (comment == null)
            {
                throw new Exception("Comment not found");
            }


            comment.Content = updateCommentDto.Content ?? comment.Content;

            comment.UpdatedAt = DateTime.UtcNow;


            _commentRepository.Update(comment);

            


        }

        public void DeleteComment(int commentId)

        {

            var comment = _commentRepository.GetById(commentId);

            if (comment == null)
            {
                throw new Exception("comment not found");
            }

            _commentRepository.Delete(comment);

        }




    }
}
