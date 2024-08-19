using eBookStore.BusinessObjects.Entities;

namespace eBookStore.BusinessObjects.DTO.Response;

public class BookResponseDto
{
    public string? BookId { get; set; }
    public string? Title { get; set; }
    public string? Type { get; set; }
    public string? PublisherId { get; set; }
    public decimal? Price { get; set; }
    public string? Advance { get; set; }
    public int? Royalty { get; set; }
    public int? Sale { get; set; }
    public string? Note { get; set; }
    public DateOnly? PublishedDate { get; set; }
    public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
}