using ErpAPI.DAL.Abstract;
using ErpAPI.DAL.Concrete.EntityFramework.DataManegment;
using ErpAPI.EEntity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Concrete.EntityFramework
{
    public class EfCustomerRepository:EfRepository<Customer>,ICustomerRepository
    {
        public EfCustomerRepository(DbContext context) : base(context)
        {

        }
    }
}
