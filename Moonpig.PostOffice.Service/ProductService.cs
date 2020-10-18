using Moonpig.PostOffice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonpig.PostOffice.Service
{
    public class ProductService : IProductService
    {
        IDbContext _dbContext;
        public ProductService(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int GetLeadDays(int SupplierID)
        {
            return _dbContext.Suppliers.Single(x => x.SupplierId == SupplierID).LeadTime;
        }
    }
}
