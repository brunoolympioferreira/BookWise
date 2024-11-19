namespace BookWise.Core.Entities;
public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow.AddHours(-3);
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Updated()
    {
        UpdatedAt = DateTime.UtcNow.AddHours(-3);
    }
}
