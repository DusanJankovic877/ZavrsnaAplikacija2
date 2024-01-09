using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZavrsnaAplikacija2.Models;
namespace ZavrsnaAplikacija2.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private CarRentalEntities db = new CarRentalEntities();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Manufacturer,Model,LicensePlate,Year,Available")] Car car)
        {
            if (ModelState.IsValid && User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            else if(User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                return View(car);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Manufacturer,Model,LicensePlate,Year,Available")] Car car)
        {
            if (ModelState.IsValid && User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            else if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                return View(car);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                Car car = db.Cars.Find(id);
                db.Cars.Remove(car);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");
            }
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
