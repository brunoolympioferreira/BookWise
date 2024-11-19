using BookWise.Core.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookWise.Application.Services.Auth;
public class AuthService : IAuthService
{
    public string GenerateJwtToken(Core.Entities.User user)
    {
        var issuer = Environment.GetEnvironmentVariable("BookWise_Issuer") ?? throw new NotFoundErrorsException("Issuer nao pode ser nulo");
        var audience = Environment.GetEnvironmentVariable("BookWise_Audience") ?? throw new NotFoundErrorsException("Audience não pode ser nulo");
        var key = Environment.GetEnvironmentVariable("BookWise_Key") ?? throw new NotFoundErrorsException("Key não pode ser nulo");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new ("user-name", user.Name),
            new ("email", user.Email),
            new ("user-id", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials,
                claims: claims
            );

        JwtSecurityTokenHandler tokenHandler = new();

        string stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
    public string ComputeSha256Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new();

        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }
}
