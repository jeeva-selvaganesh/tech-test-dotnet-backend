namespace Moonpig.PostOffice.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using Moonpig.PostOffice.Service;

    [Route("api/[controller]")]
    public class DespatchController : Controller
    {
        IDespatchManagement _despatchManagement;

        public DespatchController(IDespatchManagement despatchManagement)
        {
            this._despatchManagement = despatchManagement;
        }

        [HttpGet]
        [Route("date")]
        public DespatchDate GetDate(List<int> productIds, DateTime orderDate)
        {
            var _despatchDate = new DespatchDate
            {
                Date = _despatchManagement.CalculateDespatch(productIds, orderDate)
            };
            return _despatchDate;
        }
    }
}
