
using eBookStore.BusinessObjects.Entities;

namespace eBookStore.BusinessObjects.DTO.Response;

public class AuthorResponseDto
{
    public string? AuthorId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Email { get; set; }
    public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
}