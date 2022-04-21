using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Areas.Admin.Controllers
{
    public class DanhSachController : ApiController
    {
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        [Route("Loai")]
        [HttpGet]
        public IEnumerable<LoaiThietBi> LayLoai()
        {
            return db.LoaiThietBis;
        }
        [Route("SP")]
        [HttpGet]
        public IEnumerable<ThietBiYTe> LaySPAll()
        {
            return db.ThietBiYTes;
        }
        [Route("SP/{ma}")]
        [HttpGet]
        public List<ThietBiYTe> LaySPTheoMa(string ma)
        {
            return db.ThietBiYTes.Where(x => x.MaLoai == ma).ToList();
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool DeleteSP(string id)
        {
            try
            {
                ThietBiYTe sanpham = db.ThietBiYTes.FirstOrDefault(x => x.MaThietBi == id);
                if (sanpham == null)
                {
                    return false;
                }
                db.ThietBiYTes.DeleteOnSubmit(sanpham);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
