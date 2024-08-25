using System;
using System.Collections.Generic;

namespace eBookStore.DAL.Entities;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public string RoleDesc { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
