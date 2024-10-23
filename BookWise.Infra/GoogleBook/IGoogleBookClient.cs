namespace BookWise.Infra.GoogleBook;
public interface IGoogleBookClient
{
    public Task<BookModel> GetByParametersAsync(string? title, string? author);
    public Task<BookModel> GetByISBN(string ISBN);
}
