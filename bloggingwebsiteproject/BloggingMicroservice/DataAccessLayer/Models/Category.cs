namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation property for blog posts
        public virtual ICollection<BlogPost> BlogPosts { get; set; } = null!;
    }
}
