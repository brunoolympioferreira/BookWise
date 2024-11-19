using BookWise.Application.Models.InputModels.Book;
using FluentValidation;

namespace BookWise.Application.Validations.Book;
public class CreateBookValidation : AbstractValidator<CreateBookInputModel>
{
    public CreateBookValidation()
    {
        RuleFor(b => b.ISBN)
            .NotEmpty().WithMessage("Código ISBN não pode ser vazio.")
            .NotNull().WithMessage("Código ISBN não pode ser nulo.");
    }
}
