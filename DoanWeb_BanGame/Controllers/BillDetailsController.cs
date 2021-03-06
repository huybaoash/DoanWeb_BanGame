using DoanWeb_BanGame.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DoanWeb_BanGame.Controllers
{
    public class BillDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ICollection<TypeGame> dsTheLoai = new List<TypeGame>();
        ICollection<Platform> dsNentang = new List<Platform>();
        public BillDetailsController()
        {
            HomeController homeController = new HomeController();

            ViewBag.dsTheLoai = homeController.ViewBag.dsTheLoai;
            ViewBag.dsNentang = homeController.ViewBag.dsNentang;


        }
        // GET: BillDetails
        public ActionResult Index()
        {
            var billDetails = db.BillDetails.Include(b => b.Bill).Include(b => b.Game).Include(b => b.Sale);
            return View(billDetails.ToList());
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var items = db.BillDetails.Include(b => b.Bill).Include(b => b.Game).Include(b => b.Sale).Where(x => x.BillId == id);
            return View(items);
        }

        // GET: BillDetails/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<BillDetail> list = new List<BillDetail>();
            list = db.BillDetails.ToList();
            List<BillDetail> listTemp = new List<BillDetail>();
            listTemp = list;
            foreach (var i in listTemp)
            {
                if (i.BillId != id)
                {
                    list.Remove(i);
                }
            }
            return View(list);
        }

        // GET: BillDetails/Create
        public ActionResult Create()
        {
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id");
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.SaleId = new SelectList(db.Sales, "Id", "Code");
            return View();
        }

        // POST: BillDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,BillId,Cost,SaleId")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.BillDetails.Add(billDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id", billDetail.BillId);
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", billDetail.GameId);
            ViewBag.SaleId = new SelectList(db.Sales, "Id", "Code", billDetail.SaleId);
            return View(billDetail);
        }

        // GET: BillDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id", billDetail.BillId);
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", billDetail.GameId);
            ViewBag.SaleId = new SelectList(db.Sales, "Id", "Code", billDetail.SaleId);
            return View(billDetail);
        }

        // POST: BillDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,BillId,Cost,SaleId")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id", billDetail.BillId);
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", billDetail.GameId);
            ViewBag.SaleId = new SelectList(db.Sales, "Id", "Code", billDetail.SaleId);
            return View(billDetail);
        }

        // GET: BillDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // POST: BillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillDetail billDetail = db.BillDetails.Find(id);
            db.BillDetails.Remove(billDetail);
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
