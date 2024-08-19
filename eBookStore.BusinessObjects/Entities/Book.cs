using System.ComponentModel.DataAnnotations.Schema;
using eBookStore.BusinessObjects.Entities;

public class Book
{
    
    [Column("book_id")]
    public required string BookId { get; set; }

    [Column("title")]
    public required string Title { get; set; }

    [Column("type")]
    public required string Type { get; set; }

    [Column("pub_id")]
    public required string PublisherId { get; set; }

    [Column("price")]
    public required decimal Price { get; set; }  

    [Column("advance")]
    public string? Advance { get; set; }  

    [Column("royalty")]
    public required int Royalty { get; set; }

    [Column("ytd_sales")]
    public required int Sale { get; set; }

    [Column("notes")]
    public string? Note { get; set; }  

    [Column("published_date")]
    public required DateOnly PublishedDate { get; set; }

    // Navigation property
    public virtual Publisher? Publisher { get; set; }
    public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
}