using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btlAPI.Areas.Admin.Controllers
{
    public class ThemController : ApiController
    {
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        [Route("Lay")]
        [HttpGet]
        public List<HangThietBi> LaySPTheoMa()
        {
            return db.HangThietBis.ToList();
        }

        [HttpPost]
        public bool InsertSanPham(string maThietBi, string maLoai, string maHang, string tenThietBi, int giaBan, string anh, string chiTiet, int soLuong)
        {
            try
            {
                ThietBiYTe thietBiYTe = new ThietBiYTe();
                thietBiYTe.MaThietBi= maThietBi;
                thietBiYTe.MaLoai = maLoai;
                thietBiYTe.MaHang = maHang;
                thietBiYTe.TenThietBi = tenThietBi;
                thietBiYTe.GiaBan = giaBan;
                thietBiYTe.Anh = anh;
                thietBiYTe.ChiTiet= chiTiet;
                thietBiYTe.SoLuong = soLuong;
                db.ThietBiYTes.InsertOnSubmit(thietBiYTe);
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
