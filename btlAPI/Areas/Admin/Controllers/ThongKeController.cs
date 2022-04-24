using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Areas.Admin.Controllers
{
    public class ThongKeController : ApiController
    {
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        [Route("ThongKe/{year}")]
        [HttpGet]
        public List<Demo2> LayTTB(int year)
        {
            return db.Demo2s.Where(x => x.Nam == year).ToList();
        }
        [HttpGet]
        public List<Demo3> LayTT(int year, int month)
        {
            return db.Demo3s.Where(x => x.Nam == year && x.Thang == month).Take(4).ToList();
        }
    }
}
