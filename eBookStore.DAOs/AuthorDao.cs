using System.Collections;
using eBookStore.BusinessObjects.Context;
using eBookStore.BusinessObjects.Entities;
using eBookStore.Utils;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.DAOs;

public class AuthorDao(AppDbContext context)
{
    private AppDbContext Context => context;

    public async Task<IEnumerable<Author>?> GetAuthors() => await Context.Authors.ToListAsync();

    public async Task<Author?> GetAuthorById(string id) => await Context.Authors.FindAsync(id);

    public async Task<int> CreateAuthor(Author author)
    {
        author.AuthorId = IdGenerator.GenerateId("Author");
        await Context.Authors.AddAsync(author);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> UpdateAuthor(string id, Author author)
    {
        var authorToUpdate = await Context.Authors.FindAsync(id);
        if (authorToUpdate == null) return 0;
        authorToUpdate.FirstName = author.FirstName;
        authorToUpdate.LastName = author.LastName;
        authorToUpdate.Address = author.Address;
        authorToUpdate.Email = author.Email;
        authorToUpdate.Phone = author.Phone;
        authorToUpdate.City = author.City;
        authorToUpdate.State = author.State;
        authorToUpdate.Zip = author.Zip;
        return await Context.SaveChangesAsync();
    }

    public async Task<int> DeleteAuthor(string id)
    {
        var authorToDelete = await Context.Authors.FindAsync(id);
        if (authorToDelete == null) return 0;
        Context.Authors.Remove(authorToDelete);
        return await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Author>?> SearchAuthors(string searchQuery) => await Context.Authors
        .Where(a => a.FirstName.Contains(searchQuery) || a.LastName.Contains(searchQuery))
        .ToListAsync();
}