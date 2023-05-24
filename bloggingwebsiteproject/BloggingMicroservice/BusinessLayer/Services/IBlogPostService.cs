using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;

namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPostDto> GetAllPosts();
        IEnumerable<BlogPostDto> GetBlogPostsByUserId(int  userId);
        BlogPostDto GetAllPostById (int blogPostId);
        BlogPostDto CreateBlogPost(CreateBlogPostDto createBlogPostDto);
        void UpdateBlogPost (int blogPostId,UpdateBlogPostDto updateBlogPostDto);
        void DeleteBlogPost (int blogPostId);

    }
}
