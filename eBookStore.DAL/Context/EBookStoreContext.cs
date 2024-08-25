using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eBookStore.DAL.Entities;

namespace eBookStore.DAL.Context;

public partial class EBookStoreContext : DbContext
{
    public EBookStoreContext()
    {
    }

    public EBookStoreContext(DbContextOptions<EBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=eBookStore;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorId)
                .HasMaxLength(6)
                .HasColumnName("author_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.PubId, "IX_Books_pub_id");

            entity.Property(e => e.BookId)
                .HasMaxLength(6)
                .HasColumnName("book_id");
            entity.Property(e => e.Advance)
                .HasMaxLength(255)
                .HasColumnName("advance");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PubId)
                .HasMaxLength(6)
                .HasColumnName("pub_id");
            entity.Property(e => e.PublishedDate).HasColumnName("published_date");
            entity.Property(e => e.Royalty).HasColumnName("royalty");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

            entity.HasOne(d => d.Pub).WithMany(p => p.Books).HasForeignKey(d => d.PubId);
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasKey(e => new { e.AuthorId, e.BookId });

            entity.HasIndex(e => e.BookId, "IX_BookAuthors_book_id");

            entity.Property(e => e.AuthorId)
                .HasMaxLength(6)
                .HasColumnName("author_id");
            entity.Property(e => e.BookId)
                .HasMaxLength(6)
                .HasColumnName("book_id");
            entity.Property(e => e.AuthorOrder).HasColumnName("author_order");
            entity.Property(e => e.RoyaltyPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("royalty_percentage");

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors).HasForeignKey(d => d.AuthorId);

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PubId);

            entity.Property(e => e.PubId)
                .HasMaxLength(6)
                .HasColumnName("pub_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(255)
                .HasColumnName("publisher_name");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId)
                .HasMaxLength(6)
                .HasColumnName("role_id");
            entity.Property(e => e.RoleDesc)
                .HasMaxLength(255)
                .HasColumnName("role_desc");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.PublisherId, "IX_Users_publisher_id");

            entity.HasIndex(e => e.RoleId, "IX_Users_role_id");

            entity.Property(e => e.UserId)
                .HasMaxLength(6)
                .HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PublisherId)
                .HasMaxLength(6)
                .HasColumnName("publisher_id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(6)
                .HasColumnName("role_id");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .HasColumnName("source");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Users).HasForeignKey(d => d.PublisherId);

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
