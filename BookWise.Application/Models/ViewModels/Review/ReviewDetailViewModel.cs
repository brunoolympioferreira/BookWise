namespace BookWise.Application.Models.ViewModels.Review;
public class ReviewDetailViewModel
{
    public ReviewDetailViewModel(Core.Entities.Review review)
    {
        UserName = review.User.Name;
        BookTitle = review.Book.Title;
        Grade = review.Grade;
        Description = review.Description;
    }

    public string UserName { get; }
    public string BookTitle { get; }
    public int Grade { get; }
    public string Description { get; }
}
