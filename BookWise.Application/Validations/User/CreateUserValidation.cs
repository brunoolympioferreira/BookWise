using BookWise.Application.Models.InputModels.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BookWise.Application.Validations.User;
public class CreateUserValidation : AbstractValidator<CreateUserInputModel>
{
    public CreateUserValidation()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido");

        RuleFor(u => u.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        RuleFor(u => u.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome do usuário não pode ser nulo ou vazio");
    }

    private static bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
