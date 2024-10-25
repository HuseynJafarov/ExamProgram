using Domain.Base;
using System.Linq.Expressions;

namespace Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);

        Task<T> GetById(int id, params Expression<Func<T, object>>[] includes);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task SoftDelete(T entity);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression);
    }
}