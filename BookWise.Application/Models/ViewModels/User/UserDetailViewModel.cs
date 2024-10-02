using BookWise.Application.Models.ViewModels.Review;

namespace BookWise.Application.Models.ViewModels.User;
public class UserDetailViewModel
{
    public UserDetailViewModel(Core.Entities.User user, List<ReviewDetailViewModel> reviews)
    {
        Id = user.Id;
        Email = user.Email;
        Name = user.Name;
        Reviews = reviews;
    }

    public Guid Id { get; }
    public string Email { get; }
    public string Name { get; }
    public List<ReviewDetailViewModel> Reviews { get; }
}
