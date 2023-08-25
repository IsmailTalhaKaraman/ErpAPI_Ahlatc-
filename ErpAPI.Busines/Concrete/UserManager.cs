﻿using ErpAPI.Busines.Abstract;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.EEntity.Poco;
using System.Linq.Expressions;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.Busines.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;

        }
            

        public async Task<User> AddAsync(User Entity)
        {
            await _uow.UserRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public Task GetAllAsync(ClaimsPrincipal user1, User user2)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(User Entity)
        {
            await _uow.UserRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(User Entity)
        {
            await _uow.UserRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
