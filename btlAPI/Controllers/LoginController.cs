using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using btlAPI.Models;

namespace btlAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DataBaseYTeDataContext db = new DataBaseYTeDataContext();
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection f)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                String sTaiKhoan = f["name"].ToString();
                String sMatKhau = GetMd5Hash(md5Hash, f["pass"].ToString());
                var NguoiDung = from p in db.TaiKhoans
                                where p.UserName == sTaiKhoan && p.Password == sMatKhau
                                select p;
                if (NguoiDung.Count() == 0)
                {
                    ViewBag.Thongbao = "Tài khoản hoặc mật khẩu sai";
                    return View();
                }
                else
                {
                    return RedirectToAction("TrangChuAdmin", "Admin");
                }
            }

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}