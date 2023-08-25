using ErpAPI.Busines.Abstract;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.EEntity.Poco;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.Busines.Concrete
{
    public class SaleManagar : ISaleService
    {
        private readonly IUnitOfWork _uow;
        public SaleManagar(IUnitOfWork uow)
        {
            _uow = uow;
        }
    
        public async Task<Sale> AddAsync(Sale Entity)
        {
            int maxNo = 1000;
            var sales = await _uow.SaleRepository.GetAllAsync();
            maxNo = sales.OrderBy(q => q.ID).FirstOrDefault().ID;
            Entity.SaleCode = "sts" + maxNo++;

            await _uow.SaleRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync(Expression<Func<Sale, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.SaleRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Sale> GetAsync(Expression<Func<Sale, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.SaleRepository.GetAsync(Filter,IncludeProperties);
        }

        public async Task RemoveAsync(Sale Entity)
        {
            await _uow.SaleRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Sale Entity)
        {
            await _uow.SaleRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
