using BookWise.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWise.Infra.Persistence.Configurations;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13);
        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Genre).IsRequired();
        builder.Property(b => b.PublishedAt).IsRequired().HasMaxLength(20);
        builder.Property(b => b.NumberOfPages).IsRequired();
        builder.Property(b => b.AverageGrade).IsRequired();
    }
}
