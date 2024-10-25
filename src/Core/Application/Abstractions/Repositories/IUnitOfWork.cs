using Domain.Base;

namespace Application.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CommitAsync();

        void Commit();

        void Dispose();
    }
}