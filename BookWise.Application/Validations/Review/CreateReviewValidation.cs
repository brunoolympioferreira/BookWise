using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Models.InputModels.Review;
using FluentValidation;

namespace BookWise.Application.Validations.Review;
public class CreateReviewValidation : AbstractValidator<CreateReviewInputModel>
{
    public CreateReviewValidation()
    {
        RuleFor(r => r.Grade)
            .NotNull().WithMessage("Campo Grade não pode ser nulo")
            .GreaterThanOrEqualTo(1).WithMessage("Nota deve ser maior ou igual a 1")
            .LessThanOrEqualTo(5).WithMessage("Nota deve ser menor ou igual a 5");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("Campo Description não pode ser vazio")
            .NotNull().WithMessage("Campo Description não pode ser nulo");

        RuleFor(r => r.UserId)
            .NotNull().WithMessage("Id do Usuário é requerido");

        RuleFor(r => r.BookId)
            .NotNull().WithMessage("Id do Livro é requerido");
    }
}
