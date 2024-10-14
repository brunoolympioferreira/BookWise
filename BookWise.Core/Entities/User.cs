namespace BookWise.Core.Entities;
public class User : BaseEntity
{
    public User(string email, string password, string name)
    {
        Email = email;
        Password = password;
        Name = name;
        Reviews = [];
    }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public List<Review> Reviews { get; private set; }

    public void Update(User user)
    {
        Email = user.Email;
        Password = user.Password;
        Name = user.Name;
    }
}
