using BookWise.Core.Repositories;

namespace BookWise.Infra.Persistence.UnityOfWork;
public class UnityOfWork : IUnityOfWork
{
    private readonly BookWiseDbContext _dbContext;

    public UnityOfWork(BookWiseDbContext dbContext,
        IUserRepository users,
        IBookRepository books,
        IReviewRepository reviews)
    {
        _dbContext = dbContext;
        Users = users;
        Books = books;
        Reviews = reviews;
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public IUserRepository Users { get; }
    public IBookRepository Books { get; }
    public IReviewRepository Reviews { get; }

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
