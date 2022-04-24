using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btlAPI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult TrangChuAdmin()
        {
            return View();
        }
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult Them()
        {
            return View();
        }
     
        public ActionResult HoaDon()
        {
            return View();
        }
        public ActionResult ThongKe()
        {
            return View();
        }
        public ActionResult KhachHang()
        {
            return View();
        }
    }
}