namespace eBookStore.BusinessObjects.DTO.Response;

public class BookAuthorResponseDto
{
    public string? AuthorId { get; set; }
    public string? BookId { get; set; }
    public int? AuthorOrder { get; set; }
    public decimal? RoyaltyPercentage { get; set; }
}