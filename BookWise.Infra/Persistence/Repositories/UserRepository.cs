using BookWise.Core.Entities;
using BookWise.Core.Exceptions;
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

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }

    public async Task<bool> ExistUserByEmail(string email, Guid id)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.Email.Equals(email) && u.Id != id);
    }

    public async Task<List<User>> GetAll()
    {
        List<User> users = await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<Result<User>> GetByIdAsync(Guid id)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Reviews)
            .SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return Result<User>.Failure($"User with ID {id} not found");
        }

        return Result<User>.Success(user);
    }

    public async Task<Result<User>> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

        if(user == null)
        {
            return Result<User>.Failure("Usuário e/ou senha inválido");
        }

        return Result<User>.Success(user);
    }

    public void Remove(User user)
    {
        _dbContext.Remove(user);
    }
}
