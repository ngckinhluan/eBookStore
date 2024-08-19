using System.Data;

namespace eBookStore.BusinessObjects.DTO.Request;

public class AuthorRequestDto
{
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Email { get; set; }
}

