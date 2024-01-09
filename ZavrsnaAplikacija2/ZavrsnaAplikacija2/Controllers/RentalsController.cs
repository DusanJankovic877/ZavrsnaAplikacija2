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
    public class RentalsController : Controller
    {
        private CarRentalEntities db = new CarRentalEntities();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Car).Include(r => r.Customer);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer");
                ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,CustomerId,CarId,DateRented,DateReturned")] Rental rental)
        {
            if (ModelState.IsValid && User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", rental.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rental.CustomerId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", rental.CarId);
                ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rental.CustomerId);
                return View(rental);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,CustomerId,CarId,DateRented,DateReturned")] Rental rental)
        {
            if (ModelState.IsValid && User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", rental.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rental.CustomerId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            else if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                return View(rental);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
            {
                Rental rental = db.Rentals.Find(id);
                db.Rentals.Remove(rental);
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
