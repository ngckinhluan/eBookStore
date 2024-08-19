namespace eBookStore.BusinessObjects.DTO.Request;

public class UserRequestDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Source { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? RoleId { get; set; }
    public string? PublisherId { get; set; }
    public DateOnly? HireDate { get; set; }
}