using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infra.Persistence.Repositories;
public class BookRepository(BookWiseDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }

    public async Task<bool> FindByISBNAsync(string isbn)
    {
        return await dbContext.Books.AnyAsync(x => x.ISBN == isbn);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await dbContext.Books.AsNoTracking().ToListAsync();
    }
}
