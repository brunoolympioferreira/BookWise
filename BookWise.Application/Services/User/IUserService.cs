using BookWise.Application.Models.InputModels;

namespace BookWise.Application.Services.User;
public interface IUserService
{
    Task<Guid> Create(CreateUserInputModel model);
}
