using BookWise.Application.Models.DTOs;
using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Validations.Book;
using BookWise.Core.Exceptions;
using BookWise.Infra.GoogleBook;
using BookWise.Infra.Persistence.UnityOfWork;
using System.Runtime.CompilerServices;

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

        if (!existBook)
        {
            throw new NotFoundErrorsException($"Livro {book.Title} não existe na base de dados");
        }

        await unityOfWork.Books.AddAsync(book);
        await unityOfWork.CompleteAsync();

        return book.Id;
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
