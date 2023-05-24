namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int AuthorId { get; set; }
        public int BlogPostId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
