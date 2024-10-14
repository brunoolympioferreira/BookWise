using BookWise.Application.Models.InputModels.Account;
using BookWise.Application.Models.ViewModels.Account;
using BookWise.Application.Services.Auth;
using BookWise.Core.Exceptions;
using BookWise.Infra.Persistence.UnityOfWork;

namespace BookWise.Application.Services.Account;
public class LoginService(IAuthService authService, IUnityOfWork unityOfWork) : ILoginService
{
    public async Task<LoginViewModel> Login(LoginInputModel model)
    {
        string passworHash = authService.ComputeSha256Hash(model.Password);

        Result<Core.Entities.User> user = await unityOfWork.Users.GetUserByEmailAndPasswordAsync(model.Email, passworHash);

        if (user.IsSuccess == false)
        {
            throw new ValidationErrorsException(user.Error);
        }

        string token = authService.GenerateJwtToken(user.Value);

        return new LoginViewModel(token);
    }
}
