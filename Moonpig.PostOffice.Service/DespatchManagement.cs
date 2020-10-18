using Moonpig.PostOffice.Data;
using Moonpig.PostOffice.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moonpig.PostOffice.Service
{
    public class DespatchManagement : IDespatchManagement
    {
        IDbContext _dbContext;
        ISupplierService _supplier;
        IProductService _product;
        public DespatchManagement(IDbContext db, ISupplierService supplier, IProductService product)
        {
            this._dbContext = db;
            this._product = product;
            this._supplier = supplier;
        }

        public DateTime CalculateDespatch(List<int> productIds, DateTime orderDate)
        {
            DateTime _despatchlt = orderDate; 
            foreach (var ID in productIds)
            {
                var _sId = _supplier.GetSupplierID(ID);
                var _pLd = _product.GetLeadDays(_sId);
                var _tempDespatchdt = orderDate.AddWorkdays(_pLd);
                _despatchlt = _tempDespatchdt > _despatchlt ? _tempDespatchdt : _despatchlt;
                    
            }
            return _despatchlt;
            
        }

        #region Private Methods
        
        #endregion
    }
}
