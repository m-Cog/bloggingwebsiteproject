using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Models;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Models;
using Castle.Components.DictionaryAdapter;

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

       public User Author { get; set; } = null!;
     
        
        public ICollection<Comment>Comments { get; set; }=new List<Comment>();
        
    }
}
