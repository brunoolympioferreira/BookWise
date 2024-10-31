using System.Text.Json;

namespace BookWise.Infra.GoogleBook;
public class GoogleBookClient : IGoogleBookClient
{
    private static readonly HttpClient client = new();
    public async Task<BookModel> GetByParametersAsync(string? title, string? author)
    {
        string url = $"https://www.googleapis.com/books/v1/volumes?q={string.Empty}+intitle:{title}+inauthor:{author}";
        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        string responsebody = await response.Content.ReadAsStringAsync();

        BookModel model = JsonSerializer.Deserialize<BookModel>(responsebody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Houve um problema ao buscar o Livro");

        return model;
    }

    public async Task<BookModel> GetByISBN(string ISBN)
    {
        string url = $"https://www.googleapis.com/books/v1/volumes?q={string.Empty}+isbn:{ISBN}";
        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        string responsebody = await response.Content.ReadAsStringAsync();

        BookModel model = JsonSerializer.Deserialize<BookModel>(responsebody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Houve um problema ao buscar o Livro");

        return model;
    }
}
