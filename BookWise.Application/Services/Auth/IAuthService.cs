namespace BookWise.Application.Services.Auth;
public interface IAuthService
{
    string GenerateJwtToken(Core.Entities.User user);
    string ComputeSha256Hash(string password);
}
