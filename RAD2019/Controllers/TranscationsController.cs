using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RAD2019ClassLibrary;
using RAD2019ClassLibrary.Models;

namespace RAD2019.Controllers
{
    public class TranscationsController : Controller
    {
        private RadBankContext db = new RadBankContext();

        public PartialViewResult _Transactions(int id)
        {
            var qry = (
                from t in db.Transcations
                join a in db.Accounts
                on t.AccountID equals a.AccountID

                join c in db.Customers
                on a.CustomerID equals c.CustomerID

                where c.CustomerID == id
                select t
                ).ToList();
            return PartialView(qry);
        }
      
        // GET: Transcations
        public ActionResult Index()
        {
            var transcations = db.Transcations.Include(t => t.FK_Account);
            return View(transcations.ToList());
        }

        // GET: Transcations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcations transcations = db.Transcations.Find(id);
            if (transcations == null)
            {
                return HttpNotFound();
            }
            return View(transcations);
        }

        // GET: Transcations/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountName");
            return View();
        }

        // POST: Transcations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,TransactionType,Amount,transactionDate,AccountID")] Transcations transcations)
        {
            if (ModelState.IsValid)
            {
                db.Transcations.Add(transcations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountName", transcations.AccountID);
            return View(transcations);
        }

        // GET: Transcations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcations transcations = db.Transcations.Find(id);
            if (transcations == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountName", transcations.AccountID);
            return View(transcations);
        }

        // POST: Transcations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,TransactionType,Amount,transactionDate,AccountID")] Transcations transcations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transcations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountName", transcations.AccountID);
            return View(transcations);
        }

        // GET: Transcations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcations transcations = db.Transcations.Find(id);
            if (transcations == null)
            {
                return HttpNotFound();
            }
            return View(transcations);
        }

        // POST: Transcations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transcations transcations = db.Transcations.Find(id);
            db.Transcations.Remove(transcations);
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
