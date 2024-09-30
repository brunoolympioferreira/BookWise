namespace BookWise.Application.Services.Auth;
public interface IAuthService
{
    string ComputeSha256Hash(string password);
}
