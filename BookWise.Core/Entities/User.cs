namespace BookWise.Core.Entities;
public class User : BaseEntity
{
    public User(string email, string nome)
    {
        Email = email;
        Nome = nome;
        Reviews = [];
    }

    public string Email { get; private set; }
    public string Nome { get; private set; }
    public List<Review> Reviews { get; private set; }
}
