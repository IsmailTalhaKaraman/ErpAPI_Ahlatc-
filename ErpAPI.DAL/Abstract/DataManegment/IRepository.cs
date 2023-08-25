
using ErpAPI.EEntity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ErpAPI.DAL.Abstract.DataManegment
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>>
           Filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>
            Filter = null, params string[] IncludeProperties);
        Task<EntityEntry<T>> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);
    }
}
