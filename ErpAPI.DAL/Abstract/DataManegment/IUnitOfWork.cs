using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Abstract.DataManegment
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        IUserRepository UserRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IPositionRepository PositionRepository { get; }
        IAuthorityRepository AuthorityRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
