namespace eBookStore.BusinessObjects.DTO.Request;

public class BookAuthorRequestDto
{
    public string? AuthorId { get; set; }
    public string? BookId { get; set; }
    public int? AuthorOrder { get; set; }
    public decimal? RoyaltyPercentage { get; set; }
}