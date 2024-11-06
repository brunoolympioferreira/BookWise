using BookWise.Application.Models.ViewModels.Review;

namespace BookWise.Application.Models.ViewModels.Book;
public class BookDetailViewModel
{
    public BookDetailViewModel(Core.Entities.Book book, List<ReviewDetailViewModel> reviewViewModels)
    {
        Id = book.Id;
        Title = book.Title;
        Description = book.Description;
        ISBN = book.ISBN;
        Author = book.Author;
        Genre = book.Genre;
        PublishedAt = book.PublishedAt;
        NumberOfPages = book.NumberOfPages;
        AverageGrade = book.AverageGrade;
        Reviews = reviewViewModels;
    }

    public Guid Id { get; set; }
    public string Title { get; }
    public string Description { get; }
    public string ISBN { get; }
    public string Author { get; }
    public string Genre { get; }
    public string PublishedAt { get; }
    public int NumberOfPages { get; }
    public decimal AverageGrade { get; }
    public List<ReviewDetailViewModel> Reviews { get; }
}
