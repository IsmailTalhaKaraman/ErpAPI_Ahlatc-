using ErpAPI.DAL.Abstract;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.DAL.Concrete.EntityFramework.Context;
using ErpAPI.EEntity.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Concrete.EntityFramework.DataManegment
{
    public class EfUnitOfWork : IUnitOfWork

    {
        private readonly ErpContext _erpContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EfUnitOfWork(ErpContext erpContext, IHttpContextAccessor httpContextAccessor)
        {
           _erpContext = erpContext;
            _httpContextAccessor = httpContextAccessor;
            CustomerRepository = new EfCustomerRepository(_erpContext);
            OrderRepository = new EfOrderRepository(_erpContext);
            SaleRepository = new EfSaleRepository(_erpContext);
            PositionRepository = new EfPositionRepository(_erpContext);
            ProductRepository = new EfProductRepository(_erpContext);
            UserRepository = new EfUserRepository(_erpContext);
            AuthorityRepository = new EfAuthorityRepository(_erpContext);

        }


        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }

        public ISaleRepository SaleRepository { get; }

        public IUserRepository UserRepository { get; }

        public ICustomerRepository CustomerRepository { get; }
        public IPositionRepository PositionRepository { get; }
        public IAuthorityRepository AuthorityRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _erpContext.ChangeTracker.Entries<AuditableEntity>()) 
            {
                
                if (item.State==Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddTime = DateTime.Now;
                    item.Entity.UpdatedTime=DateTime.Now;
                    item.Entity.AddUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.AddedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedAIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    
                    if (item.Entity.IsActive==null)
                    {
                        item.Entity.IsActive = true;

                    }
                    item.Entity.IsDelete=false;
                }
                else if (item.State==Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedAIPV4Adress=_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }

            }

            return await _erpContext.SaveChangesAsync();
        }
    }
}
