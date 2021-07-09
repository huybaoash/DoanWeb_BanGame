using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanWeb_BanGame.Models;


namespace DoanWeb_BanGame.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        
        
        public ActionResult Index()
        {
            IList<TypeGame> dsTheLoai = new List<TypeGame>();
            dsTheLoai = db.TypeGames.ToList();
            ViewBag.dsTheLoai = dsTheLoai;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}