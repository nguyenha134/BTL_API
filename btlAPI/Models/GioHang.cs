using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace btlAPI.Models
{
    public class GioHang
    {
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string Anh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public int Max { get; set; }
        public double ThanhTien
        {
            get { return DonGia * SoLuong; }
            set { }
        }
        public GioHang(string MaThietBi)
        {
            this.MaThietBi = MaThietBi;
            ThietBiYTe sanpham = db.ThietBiYTes.FirstOrDefault(x => x.MaThietBi == MaThietBi);
            TenThietBi = sanpham.TenThietBi;
            Anh = sanpham.Anh;
            DonGia = (double)sanpham.GiaBan;
            if((int)sanpham.SoLuong == 0)
            {
                SoLuong = 0;
            }
            else
            {
                SoLuong = 1;
            }
            Max = (int)sanpham.SoLuong;
        }
    }
}