using BookWise.Application.Models.InputModels.Account;
using BookWise.Application.Models.ViewModels.Account;

namespace BookWise.Application.Services.Account;
public interface ILoginService
{
    Task<LoginViewModel> Login(LoginInputModel model);
}
