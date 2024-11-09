using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infra.Persistence.Repositories;
public class ReviewRepository(BookWiseDbContext dbContext) : IReviewRepository
{
    public async Task Add(Review review)
    {
        await dbContext.AddAsync(review);
    }

    public async Task<List<Review>> GetReviewsByBookId(Guid bookId)
    {
        List<Review> reviews = await dbContext.Reviews
            .Include(b => b.Book)
            .Include(u => u.User)
            .Where(r => r.BookId == bookId)
            .ToListAsync();

        return reviews;
    }
}
