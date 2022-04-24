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
        [Route("SPTheoMa/{maTB}")]
        [HttpGet]
        public Demo LaySPTheoMaTB(string maTB)
        {
            return db.Demos.FirstOrDefault(x => x.MaThietBi == maTB);
        }
        [HttpPut]
        public bool UpdateSanPham(string maThietBi, string maLoai, string maHang, string tenThietBi, int giaBan, string anh, string chiTiet, int soLuong)
        {
            try
            {
                ThietBiYTe thietBiYTe = db.ThietBiYTes.FirstOrDefault(x => x.MaThietBi == maThietBi);
                if (thietBiYTe == null)
                {
                    return false;
                }
                thietBiYTe.MaThietBi = maThietBi;
                thietBiYTe.MaLoai = maLoai;
                thietBiYTe.MaHang = maHang;
                thietBiYTe.TenThietBi = tenThietBi;
                thietBiYTe.GiaBan = giaBan;
                thietBiYTe.Anh = anh;
                thietBiYTe.ChiTiet = chiTiet;
                thietBiYTe.SoLuong = soLuong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        [Route("SuaTT/{id}")]
        [HttpPut]
        public bool SuaTT(string id)
        {
            try
            {
                ThietBiYTe sanpham = db.ThietBiYTes.FirstOrDefault(x => x.MaThietBi == id);
                if (sanpham == null)
                {
                    return false;
                }
                sanpham.An = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [Route("CTHD")]
        [HttpGet]
        public List<CTHD> Demo()
        {
            return db.CTHDs.ToList();
        }
    }
}
