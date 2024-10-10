using BookWise.Core.Entities;
using BookWise.Core.Exceptions;

namespace BookWise.Core.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);
    void Update(User user);
    Task<bool> ExistUserByEmail(string email, Guid id);
    Task<Result<User>> GetByIdAsync(Guid id);
    Task<List<User>> GetAll();
    void Remove(User user);
}
