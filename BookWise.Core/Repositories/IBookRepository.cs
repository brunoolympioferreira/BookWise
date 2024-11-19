using BookWise.Core.Entities;
using BookWise.Core.Exceptions;

namespace BookWise.Core.Repositories;
public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<bool> FindByISBNAsync(string isbn);
    Task<List<Book>> GetAllAsync();
    Task<List<Book>> GetAllByYearAsync(int year);
    Task<Result<Book>> GetByIdAsync(Guid id);
    Task<Book> GetToUpdateByIdAsync(Guid id);
    void Remove(Book book);
    void Update(Book book);
}
