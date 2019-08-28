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

namespace DCRHAK.Controllers
{
    public class FilesController : Controller
    {
        private DCRHAKContext db = new DCRHAKContext();

        // GET: Files
        public ActionResult Index(int id)
        {
            var filetoRetrieve = db.Files.Find(id);
            return File(filetoRetrieve.Content, filetoRetrieve.ContentType);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName");
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileId,FileName,ContentType,Content,FileType,ItemId")] File file, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var content = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Content,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        content.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    file.Content = content.Content;
                    file.ContentType = content.ContentType;
                    file.FileName = content.FileName;
                    file.FileType = content.FileType;
                }
                db.Files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index", "Items");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName", file.ItemId);
            return View(file);
        }
    }
}