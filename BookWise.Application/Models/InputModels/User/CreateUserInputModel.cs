namespace BookWise.Application.Models.InputModels.User;
public class CreateUserInputModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public Core.Entities.User ToEntity(string passwordHash) => new(Email, passwordHash, Name);
}
