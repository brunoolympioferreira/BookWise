using BookWise.Application.Models.InputModels.Review;
using BookWise.Application.Models.ViewModels.Review;
using BookWise.Application.Validations.Review;
using BookWise.Core.Exceptions;
using BookWise.Infra.Persistence.UnityOfWork;

namespace BookWise.Application.Services.Review;
public class ReviewService(IUnityOfWork unityOfWork) : IReviewService
{
    public async Task<Guid> Create(CreateReviewInputModel model)
    {
        ModelValidate(model);

        Core.Entities.Review review = model.ToEntity();

        await unityOfWork.Reviews.Add(review);
        await unityOfWork.CompleteAsync();

        return review.Id;
    }

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

    private static void ModelValidate(CreateReviewInputModel model)
    {
        var validator = new CreateReviewValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
