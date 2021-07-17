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
using PagedList;
using System.IO;

namespace DoanWeb_BanGame.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ICollection<TypeGame> dsTheLoai = new List<TypeGame>();
        ICollection<Platform> dsNentang = new List<Platform>();
        ICollection<TypeGameDetails> dsTLcuaG = new List<TypeGameDetails>();
        public GamesController()
        {
            dsTheLoai = db.TypeGames.ToList();
            dsNentang = db.Platforms.ToList();
            ViewBag.dsTheLoai = dsTheLoai;
            ViewBag.dsNentang = dsNentang;

            ViewBag.dsTheLoai = dsTheLoai;
            
            ViewBag.SLdsTheLoai = dsTheLoai.Count();

            ViewBag.dsNentang = dsNentang;

            dsTLcuaG = db.TypeGameDetails.ToList();
            


            ViewBag.dsTLcuaG = dsTLcuaG;
            ViewBag.SLdsTLcuaG = dsTLcuaG.Count();

        }

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
        public ActionResult Create([Bind(Include = "Id,Name,Image,Trailer,PublishDay,Description,SystemRequirememts,Cost,ProducerId,PublisherId")] Game game, 
            HttpPostedFileBase image, HttpPostedFileBase video, FormCollection formCollection)
        {
            // Lấy danh sách thể loại đã chọn
            List<TypeGameDetails> listTypeGamesDetails = new List<TypeGameDetails>();
            List<TypeGame> listTypeGames = new List<TypeGame>();

            // Lấy danh sách nền tảng đã chọn
            List<PlatformDetails> listPlatformDetails = new List<PlatformDetails>();
            List<Platform> listPlatforms = new List<Platform>();

            // Lấy danh sách gốc từ database, so sánh với những cái đã checked. Nếu đúng thì cho vào danh sách TypeGameDetails để lát bỏ vào database.
            listTypeGames = db.TypeGames.ToList();
            listPlatforms = db.Platforms.ToList();

            List<Game> listGame = db.Games.ToList();
            Game lastGame = listGame.Last();
            game.Id = lastGame.Id + 1;

            // Lưu folder chứa hình
            if (image.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Image"), fileName);
                var dir = Directory.CreateDirectory(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Image"));
                game.Image = "/Content/Game/GameID" + game.Id.ToString() + "/Image/" + fileName;
                image.SaveAs(path);

            }
            // Lưu folder chứa video
            if (video.ContentLength > 0)
            {
                var fileName = Path.GetFileName(video.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Trailer"), fileName);
                var dir = Directory.CreateDirectory(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Trailer"));
                game.Trailer = "/Content/Game/GameID" + game.Id.ToString() + "/Trailer/" + fileName;
                video.SaveAs(path);

            }

            
            db.Games.Add(game);
            db.SaveChanges();

            foreach (var item in listTypeGames)
            {
                if (!string.IsNullOrEmpty(formCollection[item.Name])) listTypeGamesDetails.Add(new TypeGameDetails()
                {
                    TypeGameId = item.Id,
                    GameId = game.Id
                });

            }

            foreach (var item in listTypeGamesDetails)
            {
                db.TypeGameDetails.Add(item); db.SaveChanges(); 

            }

            // Lấy danh sách gốc từ database, so sánh với những cái đã checked. Nếu đúng thì cho vào danh sách PlatformDetails để lát bỏ vào database.
            
            foreach (var item in listPlatforms)
            {
                if (!string.IsNullOrEmpty(formCollection[item.Name])) listPlatformDetails.Add(new PlatformDetails()
                {
                    PlatformId = item.Id,
                    GameId = game.Id,
                    PublicDay = game.PublishDay
                });

            }

            foreach (var item in listPlatformDetails)
            {
                db.PlatformDetails.Add(item); db.SaveChanges(); 
                
            }

            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Trailer,PublishDay,Description,SystemRequirememts,Cost,ProducerId,PublisherId,Enable")] Game game,
            HttpPostedFileBase image, HttpPostedFileBase video, FormCollection formCollection)
        {
            // Lấy danh sách thể loại đã chọn
            List<TypeGameDetails> listTypeGamesDetails = new List<TypeGameDetails>();
            List<TypeGame> listTypeGames = new List<TypeGame>();
            List<TypeGameDetails> listTypeGamesDetailsTemp = new List<TypeGameDetails>();
            // Lấy danh sách gốc từ database, so sánh với những cái đã checked. Nếu đúng thì cho vào danh sách TypeGameDetails để lát bỏ vào database.
            listTypeGames = db.TypeGames.ToList();
            listTypeGamesDetailsTemp = db.TypeGameDetails.ToList();

            if (image.ContentLength > 0)
            {
                
                var fileName = Path.GetFileName(image.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Image"), fileName);

                game.Image = "/Content/Game/GameID" + game.Id.ToString() + "/Image/" + fileName;

                image.SaveAs(path);

            }

            if (video.ContentLength > 0)
            {
                var fileName = Path.GetFileName(video.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Game/GameID" + game.Id.ToString() + "/Trailer"), fileName);
                game.Trailer = "/Content/Game/GameID" + game.Id.ToString() + "/Trailer/" + fileName;
                video.SaveAs(path);

            }
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();

            foreach (var item in listTypeGames)
            {
                if (!string.IsNullOrEmpty(formCollection[item.Name])) 
                    listTypeGamesDetails.Add(new TypeGameDetails()
                {
                    TypeGameId = item.Id,
                    GameId = game.Id
                });

            }
            // Cho 5 số :  1,2,3,4,5
            // Ta chọn thứ nhất: 1,2
            // Ta đang tính chọn lần thứ hai : 2,3,4
            // Giải quyết: Xóa hết 1,2 hiện đang chọn đi. Add 2,3,4 vào. Done !

            

            

            foreach (var item in listTypeGamesDetailsTemp)
            {
                if (item.GameId == game.Id)
                {
                    TypeGameDetails TypeGameDetails = db.TypeGameDetails.Find(item.Id);
                    db.TypeGameDetails.Remove(TypeGameDetails);
                    db.SaveChanges();
                }

            }

            foreach (var item in listTypeGamesDetails)
            {
                db.TypeGameDetails.Add(item); db.SaveChanges();

            }




            // Lấy danh sách gốc từ database, so sánh với những cái đã checked. Nếu đúng thì cho vào danh sách PlatformDetails để lát bỏ vào database.



            if (ModelState.IsValid)
            {
                
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
