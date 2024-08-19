using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eBookStore.BusinessObjects.Context;
using eBookStore.BusinessObjects.Entities;
using eBookStore.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Xunit;

namespace eBookStore.UnitTests.DAOsTests
{
    public class AuthorDaoTest
    {
        private readonly Mock<DbSet<Author>> _mockSet;
        private readonly Mock<AppDbContext> _mockContext;
        private readonly List<Author> _authorList;

        public AuthorDaoTest()
        {
            _mockSet = new Mock<DbSet<Author>>();
            _mockContext = new Mock<AppDbContext>();

            _authorList = new List<Author>
            {
                new Author
                {
                    AuthorId = "A00002",
                    LastName = "Doe",
                    FirstName = "John",
                    Phone = "123-456-7890",
                    Address = "123 Maple Street",
                    City = "Anytown",
                    State = "CA",
                    Zip = "90210",
                    Email = "john.doe@example.com",
                },
                new Author
                {
                    AuthorId = "A00003",
                    LastName = "Smith",
                    FirstName = "Jane",
                    Phone = "987-654-3210",
                    Address = "456 Oak Avenue",
                    City = "Somecity",
                    State = "NY",
                    Zip = "10001",
                    Email = "jane.smith@example.com",
                },
                new Author
                {
                    AuthorId = "A00004",
                    LastName = "Johnson",
                    FirstName = "Michael",
                    Phone = "555-555-5555",
                    Address = "789 Pine Road",
                    City = "Othercity",
                    State = "TX",
                    Zip = "75001",
                    Email = "michael.johnson@example.com",
                }
            };

            var queryable = _authorList.AsQueryable();
            _mockSet.As<IQueryable<Author>>().Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Author>(queryable.Provider));
            _mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _mockSet.As<IAsyncEnumerable<Author>>()
                .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(new TestAsyncEnumerator<Author>(queryable.GetEnumerator()));

            // AddAsync method
            _mockSet.Setup(m => m.AddAsync(It.IsAny<Author>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Author author, CancellationToken token) =>
                {
                    _authorList.Add(author);
                    return default(EntityEntry<Author>); 
                });


            
            // Update method
            _mockSet.Setup(m => m.Update(It.IsAny<Author>())).Callback<Author>(updatedAuthor =>
            {
                var existingAuthor = _authorList.SingleOrDefault(a => a.AuthorId == updatedAuthor.AuthorId);
                if (existingAuthor != null)
                {
                    existingAuthor.FirstName = updatedAuthor.FirstName;
                    existingAuthor.LastName = updatedAuthor.LastName;
                    existingAuthor.Address = updatedAuthor.Address;
                    existingAuthor.Email = updatedAuthor.Email;
                    existingAuthor.Phone = updatedAuthor.Phone;
                    existingAuthor.City = updatedAuthor.City;
                    existingAuthor.State = updatedAuthor.State;
                    existingAuthor.Zip = updatedAuthor.Zip;
                }
            });
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => 1);

            // Delete method
            _mockSet.Setup(m => m.Remove(It.IsAny<Author>())).Callback<Author>(author =>
            {
                _authorList.Remove(author);
            });
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => 1);
            
            // FindAsync method
            _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
                .ReturnsAsync((object[] ids) =>
                    _authorList.SingleOrDefault(a => a.AuthorId == (string)ids[0]));
            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
        }

        [Fact]
        public async Task GetAuthors_ReturnsAuthors()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var authors = await dao.GetAuthors();
            Assert.Equal(3, authors.ToList().Count);
        }

        [Fact]
        public async Task GetAuthorById_ReturnsCorrectAuthor()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var author = await dao.GetAuthorById("A00003");
            Assert.NotNull(author);
            Assert.Equal("A00003", author.AuthorId);
        }

        [Fact]
        public async Task CreateAuthor_AddsNewAuthor()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var newAuthor = new Author
            {
                AuthorId = "A00005",
                LastName = "New",
                FirstName = "Author",
                Phone = "111-111-1111",
                Address = "111 New Street",
                City = "Newcity",
                State = "NC",
                Zip = "11111",
                Email = "new.author@example.com",
            };
            var result = await dao.CreateAuthor(newAuthor);
            Assert.Equal(1, result);
            _mockSet.Verify(m => m.AddAsync(It.IsAny<Author>(), It.IsAny<CancellationToken>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }



        [Fact]
        public async Task UpdateAuthor_UpdatesExistingAuthor()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var updatedAuthor = new Author
            {
                AuthorId = "A00009",
                FirstName = "Updated",
                LastName = "Author",
                Phone = "222-222-2222",
                Address = "222 Updated Street",
                City = "Updatedcity",
                State = "UC",
                Zip = "22222",
                Email = "updated.author@example.com",
            };
            var result = await dao.UpdateAuthor("A00002", updatedAuthor);
            Assert.Equal(1, result);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task DeleteAuthor_RemovesAuthor()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var result = await dao.DeleteAuthor("A00002");
            Assert.Equal(1, result);
            _mockSet.Verify(m => m.Remove(It.IsAny<Author>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task SearchAuthors_ReturnsCorrectAuthors()
        {
            var dao = new AuthorDao(_mockContext.Object);
            var authors = await dao.SearchAuthors("John");
            Assert.NotNull(authors);
            Assert.Equal(2, authors.Count()); 
            Assert.Contains(authors, a => a.FirstName == "John");
        }
    }
}