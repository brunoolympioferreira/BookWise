using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;
public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<bool> FindByISBNAsync(string isbn);
    Task<List<Book>> GetAllAsync();
}
