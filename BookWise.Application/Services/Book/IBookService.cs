using BookWise.Application.Models.InputModels.Book;

namespace BookWise.Application.Services.Book;
public interface IBookService
{
    Task<Guid> Create(CreateBookInputModel model);
}
