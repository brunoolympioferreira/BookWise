using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;
public interface IReviewRepository
{
    Task Add(Review review);
    Task<List<Review>> GetReviewsByBookId(Guid bookId);
}
