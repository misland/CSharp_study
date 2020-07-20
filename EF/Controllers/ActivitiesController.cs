using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF.Infrastruct;
using EF.Models;

namespace EF.Controllers
{
    public class ActivitiesController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private IActivityRepository repository;
        private ITripRepository tripRepository;

        public ActivitiesController(IActivityRepository repository,ITripRepository tripRepository)
        {
            this.repository = repository;
            this.tripRepository = tripRepository;
        }

        // GET: Activities
        public ActionResult Index()
        {
            //return View(db.Activities.ToList());
            return View(repository.GetAll().ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.Trips = new SelectList(tripRepository.GetAll(), "TId", "CostUSD");
            return View();
        }

        // POST: Activities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AId,Name")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                List<Trip> trips = new List<Trip>();
                //这样会抛出“An entity object cannot be referenced by multiple instances of IEntityChangeTracker”
                //原因在于tripRpository和repository的EFContext实例不是同一个
                //暂时没有找到解决方案
                //Trip t1 = tripRepository.GetById<Guid>(new Guid("C6F0467B-7396-E611-B85B-FB2184F04853"));
                //Trip t2 = tripRepository.GetById<Guid>(new Guid("C0F80C86-7396-E611-B85B-FB2184F04853"));
                //trips.Add(t1);
                //trips.Add(t2);

                //这种方法也不行，说明确实需要两个repository的context实例一样才行
                //Activity model = new Activity();
                //model.Name = activity.Name;
                //model.Trips = trips;
                //repository.Add(model);

                //这样可以，因为没有用Trip的repository
                //Trip t = new Trip() { TId = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(5), CostUSD = 1000 };
                ////trips.Add(t);
                repository.Add(activity);

                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AId,Name")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
