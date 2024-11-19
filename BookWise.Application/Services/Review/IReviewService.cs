using BookWise.Application.Models.InputModels.Review;
using BookWise.Application.Models.ViewModels.Review;

namespace BookWise.Application.Services.Review;
public interface IReviewService
{
    Task<Guid> Create(CreateReviewInputModel model);
    Task<List<ReviewDetailViewModel>> GetByBookId(Guid bookId);
}
