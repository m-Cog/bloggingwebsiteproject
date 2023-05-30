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

       public BlogPost BlogPost { get; set; } = null!;
        public User Author { get; set; } = null!;
    }
}
