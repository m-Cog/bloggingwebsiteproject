namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto
{
    public class UpdateBlogPostDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
