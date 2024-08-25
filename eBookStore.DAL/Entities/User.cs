using System;
using System.Collections.Generic;

namespace eBookStore.DAL.Entities;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Source { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string RoleId { get; set; } = null!;

    public string PublisherId { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
