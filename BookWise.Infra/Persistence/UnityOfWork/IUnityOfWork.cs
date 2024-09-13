using BookWise.Core.Repositories;

namespace BookWise.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    IUserRepository Users { get; }

    Task<int> CompleteAsync();
}
