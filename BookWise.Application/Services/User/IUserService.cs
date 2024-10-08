using BookWise.Application.Models.InputModels.User;
using BookWise.Application.Models.ViewModels.User;

namespace BookWise.Application.Services.User;
public interface IUserService
{
    Task<Guid> Create(CreateUserInputModel model);
    Task Update(UpdateUserInputModel model, Guid id);
    Task<UserDetailViewModel> GetById(Guid id);
    Task<List<UserViewModel>> GetAll();
}
