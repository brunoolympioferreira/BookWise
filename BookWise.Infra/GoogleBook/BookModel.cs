namespace BookWise.Infra.GoogleBook;
public class BookModel
{
    public int TotalItems { get; set; }
    public List<Item> Items { get; set; }
}

public class Item
{
    public VolumeInfo VolumeInfo { get; set; }
}

public class VolumeInfo
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public string PublishedDate { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public List<string> Categories { get; set; }
    public List<IndustryIdentifier> IndustryIdentifiers { get; set; }
}

public class IndustryIdentifier
{
    public string Type { get; set; }
    public string Identifier { get; set; }
}