using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanWeb_BanGame.Models;
using PagedList;


namespace DoanWeb_BanGame.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ICollection<TypeGame> dsTheLoai = new List<TypeGame>();
        ICollection<Platform> dsNentang = new List<Platform>();

        public HomeController()
        {
            TypesGameViewPatient();
        }

        public ActionResult TypesGameViewPatient()
        {
            ICollection<TypeGame> tempTG = db.TypeGames.ToList();
            ICollection<Platform> tempNT = db.Platforms.ToList();

            if (db.TypeGames != null)
            {

                dsTheLoai = tempTG.ToList();
                dsNentang = tempNT.ToList();
                ViewBag.dsTheLoai = dsTheLoai;
                ViewBag.dsNentang = dsNentang;
                return PartialView();
            }

            else
            {
                ViewBag.dsTheLoai = null;
                ViewBag.dsNentang = null;
                return PartialView();
            }
        }

        public ActionResult Index()
        {
            

            ICollection<Game> dsGame = new List<Game>();
            dsGame = db.Games.ToList();


           
            ViewBag.dsGame = dsGame;


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