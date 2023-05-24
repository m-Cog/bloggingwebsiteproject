namespace bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.ModelDto
{
    public class CreateBlogPostDto
    {
        public int AuthorId {get; set;}
        public string Title { get; set; } = null!;
        public string Content{ get; set; } = null!;
    }
}
