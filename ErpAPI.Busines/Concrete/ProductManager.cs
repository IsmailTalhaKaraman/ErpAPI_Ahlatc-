using ErpAPI.Busines.Abstract;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.EEntity.Poco;
using System.Linq.Expressions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.Busines.Concrete
{
    public class ProductManager : IProductService
    {
        

        private readonly IUnitOfWork _uow;
        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        int maxNo = 100000;
        public async Task<Product> AddAsync(Product Entity)
        {
            
            int maxNo = 10000;            
            var products = await _uow.ProductRepository.GetAllAsync();
            maxNo = products.OrderBy(q => q.ID).FirstOrDefault().ID;
            Entity.ProductCode = "urun" + maxNo++;
 

            await _uow.ProductRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
           
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Product Entity)
        {
            await _uow.ProductRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Product Entity)
        {
            await _uow.ProductRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
