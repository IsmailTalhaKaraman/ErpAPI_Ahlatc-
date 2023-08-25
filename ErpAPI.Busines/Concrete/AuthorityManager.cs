using ErpAPI.Busines.Abstract;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.EEntity.Poco;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.Busines.Concrete
{
    public class AuthorityManager : IAuthorityService
    {
        private readonly IUnitOfWork _uow;

        public AuthorityManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Authority> AddAsync(Authority Entity)
        {
            await _uow.AuthorityRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public Task<IEnumerable<Authority>> GetAllAsync(Expression<Func<Authority, bool>> Filter = null, params string[] IncludeProperties)
        {
            return _uow.AuthorityRepository.GetAllAsync(Filter, IncludeProperties);
           
        }

        public async Task<Authority> GetAsync(Expression<Func<Authority, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.AuthorityRepository.GetAsync(Filter, IncludeProperties);
            
        }

        public async Task RemoveAsync(Authority Entity)
        {
            await _uow.AuthorityRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
           
        }

        public async Task UpdateAsync(Authority Entity)
        {
            await _uow.AuthorityRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
