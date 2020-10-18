using Moonpig.PostOffice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonpig.PostOffice.Service
{
    public class SupplierService : ISupplierService
    {
        IDbContext _dbContext;
        public SupplierService(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int GetSupplierID(int ProductID)
        {
            return _dbContext.Products.Single(x => x.ProductId == ProductID).SupplierId;
        }
    }
}
