using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;

namespace bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }

        // Navigation property for author user
        public virtual User Author { get; set; } = null!;

        // Navigation property for categories
        public virtual ICollection<Category> Categories { get; set; } = null!;
    }
}
