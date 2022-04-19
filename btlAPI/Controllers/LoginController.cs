using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btlAPI.Models;

namespace btlAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        BTL_WebEntities1 db = new BTL_WebEntities1();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string TenDangNhap, string MatKhau)
        {
            TaiKhoan tk = db.TaiKhoans.Where(s => s.UserName == TenDangNhap).SingleOrDefault<TaiKhoan>();
            if (tk == null)
            {
                TempData["Err"] = "Tài khoản không hợp lệ!";
                return RedirectToAction("Index");
            }
            else
            {
                if (tk.Password == MatKhau)
                {

                    ChuQuanLy user = db.ChuQuanLies.Where(s => s.ID == tk.ID).SingleOrDefault<ChuQuanLy>();
                    Session["User"] = user.Ten;
                    Session["TK"] = tk.Password;
                    if (Session["Type"].ToString().ToUpper().Equals("Admin".ToUpper()))
                    {
                        return RedirectToAction("Index", "Admin/NhanVien");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Client/TB_YTE");
                    }
                }
            }
            TempData["Err"] = "Sai mật khẩu!";
            return RedirectToAction("Index");

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}