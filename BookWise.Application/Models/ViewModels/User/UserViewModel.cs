namespace BookWise.Application.Models.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel(Core.Entities.User user)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.Name;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Name { get; }
    }
}
