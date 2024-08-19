using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStore.BusinessObjects.Entities;

public class User
{
    [Column("user_id")]
    public required string UserId { get; set; }
    [Column("email")]
    [EmailAddress]
    public required string Email { get; set; }
    [Column("password")]
    public required string Password { get; set; }
    [Column("source")]
    public string? Source { get; set; }
    [Column("first_name")]
    public required string FirstName { get; set; }
    [Column("middle_name")]
    public required string MiddleName { get; set; }
    [MaxLength(255)]
    [Column("last_name")]
    public required string LastName { get; set; }
    [Column("address")]
    public string? Address { get; set; }
    [Column("role_id")]
    public required string RoleId { get; set; }
    [Column("publisher_id")]
    public required string PublisherId { get; set; }
    [Column("hire_date")]
    public DateOnly HireDate { get; set; }
    
    // Navigation Property
    public virtual Role? Role { get; set; }
    public virtual Publisher? Publisher { get; set; }
    
    
    
    
    
    
    
}