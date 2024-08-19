using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStore.BusinessObjects.Entities
{
    public class Author
    {
        [Column("author_id")]
        public required string AuthorId { get; set; }
        
        [Column("last_name")]
        public required string LastName { get; set; }
        
        [Column("first_name")]
        public required string FirstName { get; set; }
        
        [Column("phone")]
        public string? Phone { get; set; }
        
        [Column("address")]
        public string? Address { get; set; }
        
        [Column("city")]
        public string? City { get; set; }
        
        [Column("state")]
        public string? State { get; set; }
        
        [Column("zip")]
        public string? Zip { get; set; }
        
        [Column("email")]
        [EmailAddress]
        public string? Email { get; set; }
        
        // Navigation Property
        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
