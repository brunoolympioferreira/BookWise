namespace BookWise.Core.Entities;
public class Review : BaseEntity
{
    public Review(int grade, string description, Guid userId, Guid bookId)
    {
        Grade = grade;
        Description = description;
        UserId = userId;
        BookId = bookId;
    }

    public int Grade { get; private set; }
    public string Description { get; private set; }
    public Guid UserId { get; private set; }
    public Guid BookId { get; private set; }
}
