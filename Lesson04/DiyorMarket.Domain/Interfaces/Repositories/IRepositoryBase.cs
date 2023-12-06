using DiyorMarket.Domain.Common;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        void UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
