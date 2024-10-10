namespace BookWise.Application.Models.InputModels.User;
public class UpdateUserInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Core.Entities.User ToEntity(string passwordHash) => new(Email, passwordHash, Name);
}
