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
    public DateTime PublishedAt { get; set; }
    public string PublishedAtStr { get; set; }
    public int NumberOfPages { get; set; }

    public Core.Entities.Book ToEntity() => new(Title, Description, ISBN, Author, Genre, PublishedAt, NumberOfPages);

    public BookDTO FromModel(BookModel bookModel) => new ()
    {
        Title = bookModel.Items
            .Select(v => v.VolumeInfo.Title)
            .FirstOrDefault() ?? string.Empty,
        Description = bookModel.Items
            .Select(v => v.VolumeInfo.Description)
            .FirstOrDefault() ?? string.Empty,
        ISBN = bookModel.Items
            .Select(v => v.VolumeInfo.IndustryIdentifiers
                .Where(i => i.Type.Equals("SBN_13"))
                .Select(i => i.Identifier)
                .FirstOrDefault())
            .FirstOrDefault() ?? string.Empty,
        Authors = bookModel.Items
            .SelectMany(v => v.VolumeInfo.Authors)
            .ToList(),
        Author = string.Join(",", Authors),
        Genres = bookModel.Items
            .SelectMany(g => g.VolumeInfo.Categories)
            .ToList(),
        Genre = string.Join(",", Genres),
        PublishedAtStr = bookModel.Items
            .Select(v => v.VolumeInfo.PublishedDate)
            .FirstOrDefault() ?? string.Empty,
        PublishedAt = DateTime.Parse(PublishedAtStr),
        NumberOfPages = bookModel.Items
            .Select(v => v.VolumeInfo.PageCount)
            .FirstOrDefault(),
    }; 
}
