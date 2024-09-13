using BookWise.Core.Repositories;
using BookWise.Infra.Persistence;

namespace BookWise.Infra.Persistence.UnityOfWork;
public class UnityOfWork : IUnityOfWork
{
    private readonly BookWiseDbContext _dbContext;

    public UnityOfWork(BookWiseDbContext dbContext,
        IUserRepository users)
    {
        _dbContext = dbContext;
        Users = users;
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public IUserRepository Users { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
