using System;
using System.Collections.Generic;

namespace eBookStore.DAL.Entities;

public partial class Publisher
{
    public string PubId { get; set; } = null!;

    public string PublisherName { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
