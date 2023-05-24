namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto
{
    public class UpdateCommentDto
    {
        public int AuthorId { get; set; }
        public int BlogPostId { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsActive { get; set; }

    }
}
