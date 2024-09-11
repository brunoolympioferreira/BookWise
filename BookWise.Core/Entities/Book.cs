using BookWise.Core.Enums;

namespace BookWise.Core.Entities;
public class Book : BaseEntity
{
    public Book(string title, string description, string iSBN, string author, BookGenreEnum genre, DateTime publishedAt, 
        int numberOfPages, decimal averageGrade, byte bookCover)
    {
        Title = title;
        Description = description;
        ISBN = iSBN;
        Author = author;
        Genre = genre;
        PublishedAt = publishedAt;
        NumberOfPages = numberOfPages;
        AverageGrade = averageGrade;
        BookCover = bookCover;
        Reviews = [];
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ISBN { get; private set; }
    public string Author { get; private set; }
    public BookGenreEnum Genre { get; private set; }
    public DateTime PublishedAt { get; private set; }
    public int NumberOfPages { get; private set; }
    public decimal AverageGrade { get; private set; }
    public byte BookCover { get; private set; }
    public List<Review> Reviews { get; private set; }
}
