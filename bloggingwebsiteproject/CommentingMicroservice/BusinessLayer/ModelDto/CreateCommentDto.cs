namespace bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.ModelDto
{
    public class CreateCommentDto
    {
        public int AuthorId { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; } = null!;
    }
}
