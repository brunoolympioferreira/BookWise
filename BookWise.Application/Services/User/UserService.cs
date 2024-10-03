using BookWise.Application.Models.InputModels.User;
using BookWise.Application.Models.ViewModels.Review;
using BookWise.Application.Models.ViewModels.User;
using BookWise.Application.Services.Auth;
using BookWise.Application.Validations.User;
using BookWise.Core.Entities;
using BookWise.Core.Exceptions;
using BookWise.Infra.Persistence.UnityOfWork;

namespace BookWise.Application.Services.User;
public class UserService(IUnityOfWork unityOfWork, IAuthService authService) : IUserService
{
    public async Task<Guid> Create(CreateUserInputModel model)
    {
        Validate(model);

        string passwordHash = authService.ComputeSha256Hash(model.Password);

        var user = model.ToEntity(passwordHash);

        await ValidateEmailAlreadyIntegrated(model.Email, user.Id);

        await unityOfWork.Users.AddAsync(user);
        await unityOfWork.CompleteAsync();

        return user.Id;
    }

    public async Task<UserDetailViewModel> GetById(Guid id)
    {
        Result<Core.Entities.User> userResult = await unityOfWork.Users.GetByIdAsync(id);

        if (userResult.IsSuccess == false)
        {
            throw new NotFoundErrorsException(userResult.Error);
        }

        List<ReviewDetailViewModel> reviewsViewModel = userResult.Value.Reviews
            .Select(review => new ReviewDetailViewModel(review))
            .ToList();

        UserDetailViewModel viewModel = new(userResult.Value, reviewsViewModel);

        return viewModel;
    }

    private static void Validate(CreateUserInputModel model)
    {
        var validator = new CreateUserValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }

    private async Task ValidateEmailAlreadyIntegrated(string email, Guid id)
    {
        bool existUserWithEmail = await unityOfWork.Users.ExistUserByEmail(email, id);

        if (existUserWithEmail)
        {
            throw new ValidationErrorsException("Email já cadastrado");
        }

    }
}
