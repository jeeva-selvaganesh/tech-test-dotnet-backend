using System;
using System.Collections.Generic;
using System.Text;

namespace Moonpig.PostOffice.Service
{
    public interface IProductService
    {
        int GetLeadDays(int SupplierID);
    }
}
