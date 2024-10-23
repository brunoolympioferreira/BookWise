namespace BookWise.Core.Entities;
public class Book : BaseEntity
{
    public Book(string title, string description, string iSBN, string author, string genre, DateTime publishedAt,
        int numberOfPages, decimal averageGrade)
    {
        Title = title;
        Description = description;
        ISBN = iSBN;
        Author = author;
        Genre = genre;
        PublishedAt = publishedAt;
        NumberOfPages = numberOfPages;
        AverageGrade = averageGrade;
        Reviews = [];
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ISBN { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public DateTime PublishedAt { get; private set; }
    public int NumberOfPages { get; private set; }
    public decimal AverageGrade { get; private set; }
    public List<Review> Reviews { get; private set; }
}
