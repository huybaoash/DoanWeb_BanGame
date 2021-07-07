using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using DoanWeb_BanGame.Models;

namespace DoanWeb_BanGame.Controllers
{
    public class TypeGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeGames
        public ActionResult Index()
        {
            return View(db.TypeGames.ToList());
        }

        // GET: TypeGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGame typeGame = db.TypeGames.Find(id);
            if (typeGame == null)
            {
                return HttpNotFound();
            }
            return View(typeGame);
        }

        // GET: TypeGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] TypeGame typeGame)
        {
            if (ModelState.IsValid)
            {
                db.TypeGames.Add(typeGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeGame);
        }

        // GET: TypeGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGame typeGame = db.TypeGames.Find(id);
            if (typeGame == null)
            {
                return HttpNotFound();
            }
            return View(typeGame);
        }

        // POST: TypeGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] TypeGame typeGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeGame);
        }

        // GET: TypeGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeGame typeGame = db.TypeGames.Find(id);
            if (typeGame == null)
            {
                return HttpNotFound();
            }
            return View(typeGame);
        }

        // POST: TypeGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeGame typeGame = db.TypeGames.Find(id);
            db.TypeGames.Remove(typeGame);
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
