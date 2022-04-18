using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<DanhMuc> GetCustomerLists()
        {
            DataBaseYTeDataContext dbCustomer = new DataBaseYTeDataContext();
            return dbCustomer.DanhMucs.ToList();
        }
        
    }
}
