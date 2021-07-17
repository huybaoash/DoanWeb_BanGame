using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoanWeb_BanGame.Models;
using PagedList;
namespace DoanWeb_BanGame.Controllers
{
    public class PlatformDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ICollection<TypeGame> dsTheLoai = new List<TypeGame>();
        ICollection<Platform> dsNentang = new List<Platform>();
        public PlatformDetailsController()
        {
            HomeController homeController = new HomeController();

            ViewBag.dsTheLoai = homeController.ViewBag.dsTheLoai;
            ViewBag.dsNentang = homeController.ViewBag.dsNentang;
        }

        // GET: PlatformDetails
        public ActionResult Index()
        {
            var platformDetails = db.PlatformDetails.Include(p => p.Game).Include(p => p.Platform);
            return View(platformDetails.ToList());
        }

        public ActionResult IndexForAGame(int? id)
        {

            var PDList = db.PlatformDetails.Include(p => p.Game).Include(p => p.Platform).Where(p=>p.GameId == id);

            

            
            return View(PDList.ToList());
        }

        // GET: PlatformDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformDetails platformDetails = db.PlatformDetails.Find(id);
            if (platformDetails == null)
            {
                return HttpNotFound();
            }
            return View(platformDetails);
        }

        

        // GET: PlatformDetails/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name");
            return View();
        }

        // POST: PlatformDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlatformId,GameId,PublicDay")] PlatformDetails platformDetails)
        {
            if (ModelState.IsValid)
            {
                db.PlatformDetails.Add(platformDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", platformDetails.GameId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", platformDetails.PlatformId);
            return View(platformDetails);
        }

        // GET: PlatformDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformDetails platformDetails = db.PlatformDetails.Find(id);
            if (platformDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", platformDetails.GameId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", platformDetails.PlatformId);
            return View(platformDetails);
        }

        // POST: PlatformDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlatformId,GameId,PublicDay")] PlatformDetails platformDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platformDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", platformDetails.GameId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", platformDetails.PlatformId);
            return View(platformDetails);
        }

        // GET: PlatformDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformDetails platformDetails = db.PlatformDetails.Find(id);
            if (platformDetails == null)
            {
                return HttpNotFound();
            }
            return View(platformDetails);
        }

        // POST: PlatformDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatformDetails platformDetails = db.PlatformDetails.Find(id);
            db.PlatformDetails.Remove(platformDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
