namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
