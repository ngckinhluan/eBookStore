using System;
using System.Collections.Generic;

namespace eBookStore.DAL.Entities;

public partial class Book
{
    public string BookId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string PubId { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Advance { get; set; }

    public int Royalty { get; set; }

    public int YtdSales { get; set; }

    public string? Notes { get; set; }

    public DateOnly PublishedDate { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual Publisher Pub { get; set; } = null!;
}
