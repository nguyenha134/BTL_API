using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Areas.Admin.Controllers
{
    public class KhachHangController : ApiController
    {
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        [Route("KhachHang")]
        [HttpGet]
        public List<Demo1> LayKhachHang()
        {
            return db.Demo1s.ToList();
        }
        [Route("HDBTheoMaKH/{MaKH}")]
        [HttpGet]
        public List<HDB> LayHDBTheoMaKH(string MaKH)
        {
            return db.HDBs.Where(x => x.MaKH == MaKH).ToList();
        }
        [Route("KhachHang/{idMaKH}")]
        [HttpGet]
        public Demo1 LayTTKH(string idMaKH)
        {
            return db.Demo1s.FirstOrDefault(x => x.MaKH == idMaKH);
        }
    }
}
