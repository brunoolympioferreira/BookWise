using BookWise.Core.Entities;
using BookWise.Core.Repositories;

namespace BookWise.Infra.Persistence.Repositories;
public class UserRepository(BookWiseDbContext dbContext) : IUserRepository
{
    private readonly BookWiseDbContext _dbContext = dbContext;

    public async Task AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
    }
}
