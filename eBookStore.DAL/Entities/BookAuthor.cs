using System;
using System.Collections.Generic;

namespace eBookStore.DAL.Entities;

public partial class BookAuthor
{
    public string AuthorId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public int? AuthorOrder { get; set; }

    public decimal? RoyaltyPercentage { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
