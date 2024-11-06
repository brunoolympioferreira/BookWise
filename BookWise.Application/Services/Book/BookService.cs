using BookWise.Application.Models.DTOs;
using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Models.ViewModels.Book;
using BookWise.Application.Models.ViewModels.Review;
using BookWise.Application.Validations.Book;
using BookWise.Core.Exceptions;
using BookWise.Infra.GoogleBook;
using BookWise.Infra.Persistence.UnityOfWork;

namespace BookWise.Application.Services.Book;
public class BookService(IUnityOfWork unityOfWork, IGoogleBookClient bookClient) : IBookService
{
    public async Task<Guid> Create(CreateBookInputModel model)
    {
        ModelValidate(model);

        BookModel bookResult = await bookClient.GetByISBN(model.ISBN);

        if (bookResult.TotalItems == 0)
            throw new NotFoundErrorsException($"Não foram encontrados resultados para o ISBN: {model.ISBN}");

        BookDTO bookDTO = new();
        bookDTO.FromModel(bookResult.Items.Single().VolumeInfo);

        Core.Entities.Book book = bookDTO.ToEntity();

        bool existBook = await unityOfWork.Books.FindByISBNAsync(book.ISBN);

        if (existBook)
        {
            throw new ValidationErrorsException($"Livro {book.Title} já existente na base de dados");
        }

        await unityOfWork.Books.AddAsync(book);
        await unityOfWork.CompleteAsync();

        return book.Id;
    }

    public async Task<List<BookViewModel>> GetAll()
    {
        List<Core.Entities.Book> books = await unityOfWork.Books.GetAllAsync();

        List<BookViewModel> viewModels = books.Select(book => new BookViewModel(book)).ToList();

        return viewModels;
    }

    public async Task<BookDetailViewModel> GetById(Guid id)
    {
        Result<Core.Entities.Book> book = await unityOfWork.Books.GetByIdAsync(id);

        if (!book.IsSuccess)
        {
            throw new NotFoundErrorsException(book.Error);
        }

        List<ReviewDetailViewModel> reviewViewModels = book.Value.Reviews.Select(review => new ReviewDetailViewModel(review)).ToList();

        BookDetailViewModel bookViewModel = new(book.Value, reviewViewModels);

        return bookViewModel;
    }

    public async Task Remove(Guid id)
    {
        Result<Core.Entities.Book> book = await unityOfWork.Books.GetByIdAsync(id);

        if (!book.IsSuccess)
        {
            throw new NotFoundErrorsException(book.Error);
        }

        unityOfWork.Books.Remove(book.Value);

        await unityOfWork.CompleteAsync();
    }

    private static void ModelValidate(CreateBookInputModel model)
    {
        var validator = new CreateBookValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
