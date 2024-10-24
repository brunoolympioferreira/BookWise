using BookWise.Core.Entities;
using BookWise.Core.Repositories;

namespace BookWise.Infra.Persistence.Repositories;
public class BookRepository(BookWiseDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }
}
