using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace bloggingwebsiteproject.BloggingMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        public readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public IEnumerable<BlogPostDto> GetAllPosts()
        {
            return _blogPostService.GetAllPosts();
        }

        [HttpGet("{userId}")]
        public IEnumerable<BlogPostDto> GetBlogPostsByUserId(int userId) 
        {
            return _blogPostService.GetBlogPostsByUserId(userId);
        }

        [HttpGet("{blogpostId}")]
        public BlogPostDto GetAllPostById(int blogPostId)
        {
            return _blogPostService.GetAllPostById(blogPostId);
        }

        [HttpPost]
        public BlogPostDto CreateBlogPost(CreateBlogPostDto createBlogPostDto)
        {
            return _blogPostService.CreateBlogPost(createBlogPostDto);
        }

        [HttpPut("{blogPostId}")]
        public void UpdateBlogPost(int blogPostId, UpdateBlogPostDto updateBlogPostDto)
        {
            _blogPostService.UpdateBlogPost (blogPostId, updateBlogPostDto);
        }
        [HttpDelete("{blogPostId}")]
        public void DeleteBlogPost(int blogPostId)
        {
            _blogPostService.DeleteBlogPost (blogPostId);
        }
    }
}
