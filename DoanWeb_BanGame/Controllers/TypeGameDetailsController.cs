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
    public class TypeGameDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ICollection<TypeGame> dsTheLoai = new List<TypeGame>();
        ICollection<Platform> dsNentang = new List<Platform>();
        public TypeGameDetailsController()
        {
            HomeController homeController = new HomeController();

            ViewBag.dsTheLoai = homeController.ViewBag.dsTheLoai;
            ViewBag.dsNentang = homeController.ViewBag.dsNentang;


        }

        // GET: TypeGameDetails
        public ActionResult Index()
        {
            var TypeGameDetails = db.TypeGameDetails.Include(t => t.Game).Include(t => t.TypeGame);
            return View(TypeGameDetails.ToList());
        }

        // GET: TypeGameDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGameDetails typeGameDetails = db.TypeGameDetails.Find(id);
            if (typeGameDetails == null)
            {
                return HttpNotFound();
            }
            return View(typeGameDetails);
        }

        // GET: TypeGameDetails/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.TypeGameId = new SelectList(db.TypeGames, "Id", "Name");
            return View();
        }

        // POST: TypeGameDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeGameId,GameId")] TypeGameDetails typeGameDetails)
        {
            if (ModelState.IsValid)
            {
                db.TypeGameDetails.Add(typeGameDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", typeGameDetails.GameId);
            ViewBag.TypeGameId = new SelectList(db.TypeGames, "Id", "Name", typeGameDetails.TypeGameId);
            return View(typeGameDetails);
        }

        // GET: TypeGameDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGameDetails typeGameDetails = db.TypeGameDetails.Find(id);
            if (typeGameDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", typeGameDetails.GameId);
            ViewBag.TypeGameId = new SelectList(db.TypeGames, "Id", "Name", typeGameDetails.TypeGameId);
            return View(typeGameDetails);
        }

        // POST: TypeGameDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeGameId,GameId")] TypeGameDetails typeGameDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeGameDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", typeGameDetails.GameId);
            ViewBag.TypeGameId = new SelectList(db.TypeGames, "Id", "Name", typeGameDetails.TypeGameId);
            return View(typeGameDetails);
        }

        // GET: TypeGameDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGameDetails typeGameDetails = db.TypeGameDetails.Find(id);
            if (typeGameDetails == null)
            {
                return HttpNotFound();
            }
            return View(typeGameDetails);
        }

        // POST: TypeGameDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeGameDetails typeGameDetails = db.TypeGameDetails.Find(id);
            db.TypeGameDetails.Remove(typeGameDetails);
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
