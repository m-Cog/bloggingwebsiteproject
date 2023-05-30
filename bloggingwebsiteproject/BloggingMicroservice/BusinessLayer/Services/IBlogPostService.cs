using System.Collections.Generic;
using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto;

namespace bloggingwebsiteproject.BloggingMicroservice.Services
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPostDto> GetAllBlogPosts();
        BlogPostDto GetBlogPostById(int id);
        BlogPostDto CreateBlogPost(CreateBlogPostDto createDto);
        void UpdateBlogPost(int id, UpdateBlogPostDto updateDto);
        void DeleteBlogPost(int id);

        IEnumerable<BlogPostDto> GetBlogPostsByUserId(int userId);

    }

}

