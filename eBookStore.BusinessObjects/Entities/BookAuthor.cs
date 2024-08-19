
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eBookStore.BusinessObjects.Entities
{
    public class BookAuthor
    {
        
        [Column("author_id")]
        public required string AuthorId { get; set; }

        [Column("book_id")]
        public required string BookId { get; set; }

        [Column("author_order")]
        public int? AuthorOrder { get; set; }

        [Column("royalty_percentage")]
        public decimal? RoyaltyPercentage { get; set; }

        // Navigation Properties
        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }

        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }
    }
}
