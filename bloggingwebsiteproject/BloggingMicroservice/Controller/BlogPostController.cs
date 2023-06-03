using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;
using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.BloggingMicroservice.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace bloggingwebsiteproject.BloggingMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<BlogPostDto>> GetAllPosts()
        {
            try
            {
                return Ok(_blogPostService.GetAllBlogPosts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving blog posts.");
            }
        }


        [HttpGet("{userId}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<BlogPostDto>> GetBlogPostsByUserId(int userId)
        {
            try
            {
                return Ok(_blogPostService.GetBlogPostsByUserId(userId));
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while retrieving blog posts by user ID.");
            }
        }

        [HttpGet("{blogpostId}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<BlogPostDto> GetAllPostById(int blogPostId)
        {
            try
            {
                var blogPost = _blogPostService.GetBlogPostById(blogPostId);
                if (blogPost == null)
                {
                    return NotFound();
                }
                return Ok(blogPost);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while retrieving the blog post.");
            }
        }

        [HttpPost]
        [EnableCors("AllowLocalhost")]
        public ActionResult<BlogPostDto> CreateBlogPost(CreateBlogPostDto createBlogPostDto)
        {
            try
            {
                var blogPost = _blogPostService.CreateBlogPost(createBlogPostDto);
                return Ok(blogPost);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while creating the blog post.");
            }
        }

        [HttpPut("{blogPostId}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult UpdateBlogPost(int blogPostId, UpdateBlogPostDto updateBlogPostDto)
        {
            try
            {
                _blogPostService.UpdateBlogPost(blogPostId, updateBlogPostDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while updating the blog post.");
            }
        }

        [HttpDelete("{blogPostId}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult DeleteBlogPost(int blogPostId)
        {
            try
            {
                _blogPostService.DeleteBlogPost(blogPostId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, "An error occurred while deleting the blog post.");
            }
        }
    }
}
