using BookWise.Application.Models.ViewModels.Review;

namespace BookWise.Application.Services.Review;
public interface IReviewService
{
    Task<List<ReviewDetailViewModel>> GetByBookId(Guid bookId);
}
