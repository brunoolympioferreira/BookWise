namespace BookWise.Application.Models.ViewModels.Book;
public class BookViewModel
{
    public BookViewModel(Core.Entities.Book book)
    {
        Title = book.Title;
        Description = book.Description;
        ISBN = book.ISBN;
        Author = book.Author;
    }

    public string Title { get; }
    public string Description { get; }
    public string ISBN { get; }
    public string Author { get; }
}
