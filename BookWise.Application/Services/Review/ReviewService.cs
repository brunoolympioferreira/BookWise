using BookWise.Application.Models.ViewModels.Review;
using BookWise.Core.Exceptions;
using BookWise.Infra.Persistence.UnityOfWork;

namespace BookWise.Application.Services.Review;
public class ReviewService(IUnityOfWork unityOfWork) : IReviewService
{
    public async Task<List<ReviewDetailViewModel>> GetByBookId(Guid bookId)
    {
        List<Core.Entities.Review> reviews = await unityOfWork.Reviews.GetReviewsByBookId(bookId);

        if (reviews.Count == 0)
        {
            throw new NotFoundErrorsException($"Não existe avaliações para o livro com o Id: {bookId} informado");
        }

        List<ReviewDetailViewModel> viewModels = reviews.Select(review => new ReviewDetailViewModel(review)).ToList();

        return viewModels;
    }
}
