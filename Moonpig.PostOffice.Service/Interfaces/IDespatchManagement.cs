using System;
using System.Collections.Generic;
using System.Text;

namespace Moonpig.PostOffice.Service
{
    public interface IDespatchManagement
    {
        DateTime CalculateDespatch(List<int> productIds, DateTime orderDate);
    }
}
