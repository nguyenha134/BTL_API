using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Areas.Admin.Controllers
{
    public class HoaDonController : ApiController
    {
        public class DemoController : ApiController
        {
            DataBaseYTeDataContext bd = new DataBaseYTeDataContext();
            // GET: api/Demo
            [Route("HoaDonBan")]
            [HttpGet]
            public List<HDB> HoaDonBan()
            {
                return bd.HDBs.ToList();
            }
            [Route("CTHD/{idCTHDB}")]
            [HttpGet]
            public List<CTHD> ChiTietHoaDon(string idCTHDB)
            {
                return bd.CTHDs.Where(x => x.SoHDB == idCTHDB).ToList();
            }
        }
    }
}
