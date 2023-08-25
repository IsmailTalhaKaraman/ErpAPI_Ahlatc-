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
    public class PositionManager : IPositionService
    {
        private readonly IUnitOfWork _uow;
        public PositionManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Position> AddAsync(Position Entity)
        {
            await _uow.PositionRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Position>> GetAllAsync(Expression<Func<Position, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.PositionRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Position> GetAsync(Expression<Func<Position, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.PositionRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Position Entity)
        {
            await _uow.PositionRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();   
        }

        public async Task UpdateAsync(Position Entity)
        {
            await _uow.PositionRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
