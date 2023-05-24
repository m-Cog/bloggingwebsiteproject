using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories;

namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPostDto> GetAllPosts()
        {
            var blogPosts =  _blogPostRepository.GetAllPost();
            return blogPosts.Select(bp => new BlogPostDto
            {
                Id = bp.Id,
                Title = bp.Title,
                Content = bp.Content,
                CreatedAt = bp.CreatedAt,
                UpdatedAt = bp.UpdatedAt,
                
            });
        }

        public IEnumerable<BlogPostDto> GetBlogPostsByUserId(int userId)
        {
            var blogPosts =  _blogPostRepository.GetByAuthorId(userId);
            return blogPosts.Select(bp => new BlogPostDto
            {
                Id = bp.Id,
                Title = bp.Title,
                Content = bp.Content,
                CreatedAt = bp.CreatedAt,
                UpdatedAt = bp.UpdatedAt,
                
            });
        }

        public BlogPostDto GetAllPostById(int blogPostId)
        {
            var blogPost = _blogPostRepository.GetById(blogPostId);
            if (blogPost == null)
            {
                throw new Exception("Blog not found");
            }
            return new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedAt = blogPost.CreatedAt,
                UpdatedAt = blogPost.UpdatedAt,
                
            };
        }

        public BlogPostDto CreateBlogPost(CreateBlogPostDto createBlogPostDto)
        {
            var blogPost = new BlogPost
            {
                Title = createBlogPostDto.Title,
                Content = createBlogPostDto.Content,
               
            };
             _blogPostRepository.Add(blogPost);
            return new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedAt = blogPost.CreatedAt,
                UpdatedAt = blogPost.UpdatedAt
            };
        }

        public void UpdateBlogPost(int blogPostId, UpdateBlogPostDto updateBlogPostDto)
        {
            var blogPost = _blogPostRepository.GetById(blogPostId);
            if (blogPost == null)
            {
                throw new Exception("Id not found");
            }
            blogPost.Title = updateBlogPostDto.Title;
            blogPost.Content = updateBlogPostDto.Content;
            blogPost.UpdatedAt = DateTime.UtcNow;

             _blogPostRepository.Update(blogPost);
        }

        public void DeleteBlogPost(int blogPostId)
        {
            var result = _blogPostRepository.GetById(blogPostId);
            _blogPostRepository.Delete(result);
        }
    }
}
