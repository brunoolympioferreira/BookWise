using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;
public interface IReviewRepository
{
    Task<List<Review>> GetReviewsByBookId(Guid bookId);
}
