using ErpAPI.DAL.Abstract;
using ErpAPI.DAL.Concrete.EntityFramework.DataManegment;
using ErpAPI.EEntity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Concrete.EntityFramework
{
    public class EfSaleRepository : EfRepository<Sale>, ISaleRepository
    {
        public EfSaleRepository(DbContext context) : base(context)
        {

        }
    }
}
