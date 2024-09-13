using BookWise.Core.Entities;

namespace BookWise.Application.Models.InputModels;
public class CreateUserInputModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public User ToEntity(string passwordHash) => new(Email, passwordHash, Name);
}
