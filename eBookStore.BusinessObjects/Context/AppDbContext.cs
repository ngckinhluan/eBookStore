using eBookStore.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eBookStore.BusinessObjects.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookAuthor> BookAuthors { get; set; }
    public virtual DbSet<Publisher> Publishers { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }

    private static string? GetConnectionString()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = config["ConnectionStrings:eBookStore"];
        if (string.IsNullOrEmpty(strConn))
        {
            throw new InvalidOperationException("Connection string 'eBookStore' not found.");
        }

        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=(local);Database=eBookStore;uid=sa;pwd=12345;TrustServerCertificate=True");
        }
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         var builder = new ConfigurationBuilder()
    //             .SetBasePath(Directory.GetCurrentDirectory())
    //             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    //         IConfigurationRoot configurationRoot = builder.Build();
    //         var connectionString = configurationRoot.GetConnectionString("Server=(local);Database=eBookStore;uid=sa;pwd=12345;TrustServerCertificate=True");
    //         if (string.IsNullOrEmpty(connectionString))
    //         {
    //             throw new InvalidOperationException("The connection string 'eBookStore' is not configured in the appsettings.json.");
    //         }
    //         optionsBuilder.UseSqlServer(connectionString);
    //     }
    // }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Primary Keys

        modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
        modelBuilder.Entity<Book>().HasKey(b => b.BookId);
        modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookId });
        modelBuilder.Entity<Publisher>().HasKey(p => p.PublisherId);
        modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
        modelBuilder.Entity<User>().HasKey(u => u.UserId);

        #endregion

        #region Author entity configurations
        modelBuilder.Entity<Author>()
            .Property(a => a.AuthorId)
            .HasMaxLength(6);
        modelBuilder.Entity<Author>()
            .Property(a => a.FirstName)
            .HasMaxLength(255);
        modelBuilder.Entity<Author>()
            .Property(a => a.LastName)
            .HasMaxLength(255);
        modelBuilder.Entity<Author>()
            .Property(a => a.Phone)
            .HasMaxLength(15);
        modelBuilder.Entity<Author>()
            .Property(a => a.Address)
            .HasMaxLength(255);
        modelBuilder.Entity<Author>()
            .Property(a => a.City)
            .HasMaxLength(50);
        modelBuilder.Entity<Author>()
            .Property(a => a.State)
            .HasMaxLength(50);
        modelBuilder.Entity<Author>()
            .Property(a => a.Zip)
            .HasMaxLength(10);
        modelBuilder.Entity<Author>()
            .Property(a => a.Email)
            .HasMaxLength(255);
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                AuthorId = "1",
                LastName = "Smith",
                FirstName = "John",
                Phone = "123-456-7890",
                Address = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345",
                Email = "john.smith@example.com"
            },
            new Author
            {
                AuthorId = "2",
                LastName = "Doe",
                FirstName = "Jane",
                Phone = "987-654-3210",
                Address = "456 Elm St",
                City = "Othertown",
                State = "NY",
                Zip = "67890",
                Email = "jane.doe@example.com"
            }
        );

        #endregion

        #region Book entity configurations
        modelBuilder.Entity<Book>()
            .Property(b => b.BookId)
            .HasMaxLength(6);
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .HasMaxLength(255);
        modelBuilder.Entity<Book>()
            .Property(b => b.Type)
            .HasMaxLength(50);
        modelBuilder.Entity<Book>()
            .Property(b => b.PublisherId)
            .HasMaxLength(6);
        modelBuilder.Entity<Book>()
            .Property(b => b.Advance)
            .HasMaxLength(255);
        modelBuilder.Entity<Book>()
            .Property(b => b.Royalty)
            .HasColumnType("int");
        modelBuilder.Entity<Book>()
            .Property(b => b.Note)
            .HasMaxLength(255);
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                BookId = "1",
                Title = "The Great Adventure",
                Type = "Fiction",
                PublisherId = "1",
                Price = 19.99m,
                Advance = "5000",
                Royalty = 10,
                Sale = 50,
                Note = "First Edition",
                PublishedDate = new DateOnly(2024, 1, 15)
            },
            new Book
            {
                BookId = "2",
                Title = "Learning C#",
                Type = "Education",
                PublisherId = "2",
                Price = 29.99m,
                Advance = "3000",
                Royalty = 12,
                Sale = 50,
                Note = "Second Edition",
                PublishedDate = new DateOnly(2024, 5, 22)
            }
        );
        #endregion

        #region BookAuthor entiy configurations
        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.AuthorId)
            .HasMaxLength(6);
        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.BookId)
            .HasMaxLength(6);
        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.AuthorOrder)
            .HasMaxLength(10);
        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.RoyaltyPercentage)
            .HasColumnType("decimal(5,2)");
        modelBuilder.Entity<BookAuthor>().HasData(new
        {
            AuthorId = "1",
            BookId = "1",
            AuthorOrder = 1,
            RoyaltyPercentage = 0.5m
        }, new
        {
            AuthorId = "2",
            BookId = "2",
            AuthorOrder = 2,
            RoyaltyPercentage = 0.5m
        });

        #endregion

        #region Role entity configurations
        modelBuilder.Entity<Role>()
            .Property(r => r.RoleId)
            .HasMaxLength(6);
        modelBuilder.Entity<Role>()
            .Property(r => r.RoleName)
            .HasMaxLength(50);
        modelBuilder.Entity<Role>()
            .Property(r => r.RoleDescription)
            .HasMaxLength(255);
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleId = "1",
                RoleName = "Admin",
                RoleDescription = "Administrator"
            },
            new Role
            {
                RoleId = "2",
                RoleName = "User",
                RoleDescription = "Regular User"
            });
        #endregion

        #region User entity configurations
        modelBuilder.Entity<User>()
            .Property(u => u.UserId)
            .HasMaxLength(6);
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.Source)
            .HasMaxLength(50);
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.MiddleName)
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.Address)
            .HasMaxLength(255);
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = "1",
                Email = "john.public@example.com",
                Password = "12345",
                Source = "Local",
                FirstName = "John",
                MiddleName = "Q",
                LastName = "Public",
                Address = "123 Main St",
                RoleId = "1",
                PublisherId = "1",
                HireDate = new DateOnly(2023, 1, 1)
            },
            new User
            {
                UserId = "2",
                Email = "jane.doe@example.com",
                Password = "67890",
                Source = "Local",
                FirstName = "Jane",
                MiddleName = "A",
                LastName = "Doe",
                Address = "456 Elm St",
                RoleId = "2",
                PublisherId = "2",
                HireDate = new DateOnly(2023, 2, 1)
            });

        #endregion

        #region Publisher entity configurations
        modelBuilder.Entity<Publisher>()
            .Property(p => p.PublisherId)
            .HasMaxLength(6);
        modelBuilder.Entity<Publisher>()
            .Property(p => p.PublisherName)
            .HasMaxLength(255);
        modelBuilder.Entity<Publisher>()
            .Property(p => p.City)
            .HasMaxLength(100);
        modelBuilder.Entity<Publisher>()
            .Property(p => p.State)
            .HasMaxLength(100);
        modelBuilder.Entity<Publisher>()
            .Property(p => p.Country)
            .HasMaxLength(100);
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                PublisherId = "1",
                PublisherName = "Publisher 1",
                City = "Anytown",
                State = "CA",
                Country = "USA"
            },
            new Publisher
            {
                PublisherId = "2",
                PublisherName = "Publisher 2",
                City = "Othertown",
                State = "NY",
                Country = "USA"
            });

        #endregion
        
        #region Relationships

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Publisher)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.PublisherId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

        #endregion
    }
}