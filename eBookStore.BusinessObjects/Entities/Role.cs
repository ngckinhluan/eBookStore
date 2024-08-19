using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStore.BusinessObjects.Entities;

public class Role
{
    [Column("role_id")]
    public required string RoleId { get; set; }
    [Column("role_name")]
    public required string RoleName { get; set; }
    [Column("role_desc")]
    public required string RoleDescription { get; set; }
    
    // Navigation Property
    public virtual ICollection<User>? Users { get; set; }
}