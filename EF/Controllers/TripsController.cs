using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF.Infrastruct;
using EF.Models;

namespace EF.Controllers
{
    public class TripsController : Controller
    {
        //private EFDbContext db = new EFDbContext();
        private ITripRepository repository;

        public TripsController(ITripRepository repository)
        {
            this.repository = repository;
        }

        // GET: Trips
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Trip.ToListAsync());
        //}
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Trips/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trip trip = await db.Trip.FindAsync(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "TId,StartDate,EndDate,CostUSD")] Trip trip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        trip.TId = Guid.NewGuid();
        //        db.Trip.Add(trip);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(trip);
        //}

        [HttpPost]
        public ActionResult Create(Trip model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Add(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Trips/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trip trip = await db.Trip.FindAsync(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        // POST: Trips/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "TId,StartDate,EndDate,CostUSD")] Trip trip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(trip).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(trip);
        //}

        // GET: Trips/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trip trip = await db.Trip.FindAsync(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                repository.Remove(repository.GetById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Trips/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    Trip trip = await db.Trip.FindAsync(id);
        //    db.Trip.Remove(trip);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository = null;
            }
            base.Dispose(disposing);
        }
    }
}
