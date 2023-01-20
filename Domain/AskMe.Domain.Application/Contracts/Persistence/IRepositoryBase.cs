using AskMe.Domain.Entities.Common;

namespace AskMe.Domain.Application.Contracts.Persistence
{
    public interface IRepositoryBase<T> where T : BaseDomainEntity, new()
    {

        Task<T> Get(string id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(string id);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
