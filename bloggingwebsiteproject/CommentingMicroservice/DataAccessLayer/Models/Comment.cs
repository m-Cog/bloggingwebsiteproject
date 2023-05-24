using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;

namespace bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public int BlogPostId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation property for blog post
        public virtual BlogPost BlogPost { get; set; } = null!;

        // Navigation property for author user
        public virtual User Author { get; set; } = null!;
    }
}
