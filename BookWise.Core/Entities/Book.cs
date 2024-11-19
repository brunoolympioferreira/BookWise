namespace BookWise.Core.Entities;
public class Book : BaseEntity
{
    public Book(string title, string description, string iSBN, string author, string genre, string publishedAt,
        int numberOfPages)
    {
        Title = title;
        Description = description;
        ISBN = iSBN;
        Author = author;
        Genre = genre;
        PublishedAt = publishedAt;
        NumberOfPages = numberOfPages;
        Reviews = [];
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ISBN { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public string PublishedAt { get; private set; }
    public int NumberOfPages { get; private set; }
    public decimal AverageGrade { get; private set; }
    public List<Review> Reviews { get; private set; }

    public void UpdateAverageGrade(decimal average)
    {
        AverageGrade = average;
        Updated();
    }
}
