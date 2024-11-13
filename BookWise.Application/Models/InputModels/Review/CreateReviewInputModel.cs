namespace BookWise.Application.Models.InputModels.Review;
public class CreateReviewInputModel
{
    public int Grade { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }

    public Core.Entities.Review ToEntity() => new(Grade, Description, UserId, BookId);
}
