using BookWise.Infra.GoogleBook;

namespace BookWise.Application.Models.DTOs;
public class BookDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }
    public List<string> Authors { get; set; }
    public string Genre { get; set; }
    public List<string> Genres { get; set; }
    public string PublishedAt { get; set; }
    public int NumberOfPages { get; set; }

    public Core.Entities.Book ToEntity() => new(Title, Description, ISBN, Author, Genre, PublishedAt, NumberOfPages);

    public void FromModel(VolumeInfo volumeInfo)
    {

        Title = volumeInfo.Title;
        Description = volumeInfo.Description;
        ISBN = volumeInfo.IndustryIdentifiers.Where(i => i.Type.Equals("ISBN_13")).Select(i => i.Identifier).FirstOrDefault() ?? string.Empty;
        Authors = volumeInfo.Authors;
        Author = string.Join(", ", Authors);
        Genres = volumeInfo.Categories;
        Genre = string.Join(", ", Genres);
        PublishedAt = volumeInfo.PublishedDate;
        NumberOfPages = volumeInfo.PageCount;      
    }
}
