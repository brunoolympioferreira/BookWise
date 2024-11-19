namespace BookWise.Application.Models.ViewModels.Account;
public class LoginViewModel
{
    public LoginViewModel(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}
