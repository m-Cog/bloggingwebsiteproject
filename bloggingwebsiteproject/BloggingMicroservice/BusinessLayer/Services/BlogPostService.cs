using System;
using System.Collections.Generic;
using System.Linq;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.BloggingMicroservice.Services;

namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPostDto> GetAllBlogPosts()
        {
            try
            {
                var blogPosts = _blogPostRepository.GetAllPost();
                return blogPosts.Select(bp => new BlogPostDto
                {
                    Id = bp.Id,
                    AuthorId = bp.AuthorId,
                    Title = bp.Title,
                    Content = bp.Content,
                    IsActive = (bp.DeletedAt == null),
                    CreatedAt = bp.CreatedAt,
                    UpdatedAt = bp.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving all blog posts: {ex.Message}");
                throw;
            }
        }

        public BlogPostDto GetBlogPostById(int id)
        {
            try
            {
                var blogPost = _blogPostRepository.GetById(id);
                if (blogPost == null)
                {
                    throw new Exception("Blog post not found");
                }

                return new BlogPostDto
                {
                    Id = blogPost.Id,
                    AuthorId = blogPost.AuthorId,
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    IsActive = (blogPost.DeletedAt == null),
                    CreatedAt = blogPost.CreatedAt,
                    UpdatedAt = blogPost.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving blog post by ID: {ex.Message}");
                throw;
            }
        }

        public BlogPostDto CreateBlogPost(CreateBlogPostDto createDto)
        {
            try
            {
                var blogPost = new BlogPost
                {
                    AuthorId = createDto.AuthorId,
                    Title = createDto.Title,
                    Content = createDto.Content,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _blogPostRepository.AddPost(blogPost);

                return new BlogPostDto
                {
                    Id = blogPost.Id,
                    AuthorId = blogPost.AuthorId,
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    IsActive = (blogPost.DeletedAt == null),
                    CreatedAt = blogPost.CreatedAt,
                    UpdatedAt = blogPost.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating a new blog post: {ex.Message}");
                throw;
            }
        }

        public BlogPostDto UpdateBlogPost(int id, UpdateBlogPostDto updateDto)
        {
            try
            {
                var blogPost = _blogPostRepository.GetById(id);
                if (blogPost == null)
                {
                    throw new Exception("Blog post not found");
                }

                blogPost.Title = updateDto.Title;
                blogPost.Content = updateDto.Content;
                blogPost.UpdatedAt = DateTime.UtcNow;

                _blogPostRepository.UpdatePost(blogPost);

                return new BlogPostDto
                {
                    Id = blogPost.Id,
                    AuthorId = blogPost.AuthorId,
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    IsActive = (blogPost.DeletedAt == null),
                    CreatedAt = blogPost.CreatedAt,
                    UpdatedAt = blogPost.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating blog post: {ex.Message}");
                throw;
            }
        }

        public bool DeleteBlogPost(int id)
        {
            try
            {
                var blogPost = _blogPostRepository.GetById(id);
                if (blogPost == null)
                {
                    throw new Exception("Blog post not found");
                }

                _blogPostRepository.DeletePost(blogPost);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting blog post: {ex.Message}");
                throw;
            }
        }

        void IBlogPostService.UpdateBlogPost(int id, UpdateBlogPostDto updateDto)
        {
            throw new NotImplementedException();
        }

        void IBlogPostService.DeleteBlogPost(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BlogPostDto> GetBlogPostsByUserId(int userId)
        {
            try
            {
                var blogPosts = _blogPostRepository.GetByAuthorId(userId);

                return blogPosts.Select(bp => new BlogPostDto
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    CreatedAt = bp.CreatedAt,
                    UpdatedAt = bp.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving blog posts by user ID: {ex.Message}");
                throw;
            }
        }

    }
}
