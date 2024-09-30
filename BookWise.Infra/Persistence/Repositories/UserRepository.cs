using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infra.Persistence.Repositories;
public class UserRepository(BookWiseDbContext dbContext) : IUserRepository
{
    private readonly BookWiseDbContext _dbContext = dbContext;

    public async Task AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
    }

    public async Task<bool> ExistUserByEmail(string email, Guid id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Email.Equals(email) && u.Id != id);
    }
}
