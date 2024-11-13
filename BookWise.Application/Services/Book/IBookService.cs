using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Models.ViewModels.Book;

namespace BookWise.Application.Services.Book;
public interface IBookService
{
    Task<Guid> Create(CreateBookInputModel model);
    Task<List<BookViewModel>> GetAll();
    Task<BookDetailViewModel> GetById(Guid id);
    Task Remove(Guid id);
    Task UpdateAverageGrade(Guid bookId);
}
