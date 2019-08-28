using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCRHAK.DAL;
using DCRHAK.Models;
using DCRHAK.ViewModels;

namespace DCRHAK.Controllers
{
    [Authorize]

    public class PackagesController : Controller
    {
        private DCRHAKContext db = new DCRHAKContext();

        // GET: Packages
        public ActionResult Index()
        {
            return View(db.Packages.ToList());
        }
        // GET: Packages/Details/5
        public ActionResult Details(int? id, int? itemID)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PackageDetailData();
            viewModel.Packages = db.Packages.Where(
                i => i.PackageId == id.Value)
                .Include(i => i.Items)
                .Include(i => i.Discussions);

            if (id != null)
            {
                ViewBag.PackageId = id.Value;
                viewModel.Items = viewModel.Packages.Where(
                    i => i.PackageId == id.Value).Single().Items;
            }
            if (id != null)
            {
                ViewBag.PackageId = id.Value;
                viewModel.Discussions = viewModel.Packages.Where(
                    i => i.PackageId == id.Value).Single().Discussions;
            }
            if (itemID != null)
            {
                ViewBag.ItemId = itemID.Value;
                var selectedItem = viewModel.Items.Where(x => x.ItemId == itemID).Single();
                db.Entry(selectedItem).Collection(x => x.Files).Load();
                foreach (File file in selectedItem.Files)
                {
                    db.Entry(file).Reference(x => x.Item).Load();
                }
                viewModel.Files = selectedItem.Files;
            }
            return View(viewModel);
        }
        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackageId,PackageName,PackageDescription")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(package);
        }
        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }
        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageId,PackageName,PackageDescription")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }
        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }
        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
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