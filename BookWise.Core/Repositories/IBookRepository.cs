using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;
public interface IBookRepository
{
    Task AddAsync(Book book);
}
