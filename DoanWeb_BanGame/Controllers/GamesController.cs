using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoanWeb_BanGame.Models;
using DoanWeb_BanGame.ViewModel;

namespace DoanWeb_BanGame.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Producer).Include(g => g.Publisher);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);

            // Lấy thể loại của game đó
            List<TypeGameDetails> typeList = new List<TypeGameDetails>();
                typeList = db.TypeGameDetails.ToList();

            List<string> theloai = new List<string>();

            for (int i = 0; i < typeList.Count; i++)
            {

                if (typeList[i].GameId == id)
                {
                    
                        theloai.Add(db.TypeGames.Find(typeList[i].TypeGameId).Name);
                   
                }
            }
            if (theloai.Count == 0)
            {
                theloai.Add(" ");
            }
            string tl = theloai[0];
            for (int i = 1; i < theloai.Count(); i++)
            {
                tl += "," + theloai[i] ;
            }

            // Lấy nền tảng của game đó

            List<PlatformDetails> platformList = new List<PlatformDetails>();
            platformList = db.PlatformDetails.ToList();

            List<string> nentang = new List<string>();

            for (int i = 0; i < platformList.Count; i++)
            {

                if (platformList[i].GameId == id)
                {
                   
                        nentang.Add(db.Platforms.Find(platformList[i].PlatformId).Name);

                }
            }
            if (nentang.Count == 0)
            {
                nentang.Add(" ");
            }
            string nt = nentang[0];
            for (int i = 1; i < nentang.Count(); i++)
            {
                nt += "," + nentang[i];
            }

            GameViewModel viewGame = new GameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Image = game.Image,
                Trailer = game.Trailer,
                PublishDay = game.PublishDay,
                Description = game.Description,
                SystemRequirememts = game.SystemRequirememts,
                Cost = game.Cost,
                ProducerName = db.Producers.Find(game.ProducerId).Name,
                PublisherName = db.Publishers.Find(game.PublisherId).Name,
                Enable = game.Enable,
                TypeGameDetails = tl,
                PlatformDetails = nt
            };

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(viewGame);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Trailer,PublishDay,Description,SystemRequirememts,Cost,ProducerId,PublisherId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", game.ProducerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", game.ProducerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Trailer,PublishDay,Description,SystemRequirememts,Cost,ProducerId,PublisherId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", game.ProducerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
