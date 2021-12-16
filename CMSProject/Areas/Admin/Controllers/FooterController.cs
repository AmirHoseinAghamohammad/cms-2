using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CMSProject.Areas.Admin.Controllers
{
    [Authorize]
    public class FooterController : Controller
    {
        private IFooterRepository footerRepository;

        private CMSContext db = new CMSContext();
        public FooterController()
        {
            footerRepository = new FooterRepository(db);
        }
        // GET: Admin/Logos
        public ActionResult Index()
        {
            return View(footerRepository.GetAll());
        }


        // GET: Admin/logos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/logos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ShortDescriptionAboutFirm")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                var getcount = footerRepository.CountFooter();
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت فوتر تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }

                footerRepository.Create(footer);
                footerRepository.Save();
                return RedirectToAction("Index");
            }

            return View(footer);
        }

        // GET: Admin/Logos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = footerRepository.GetById(id.Value);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ShortDescriptionAboutFirm")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                footerRepository.Edit(footer);
                footerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(footer);
        }

        // GET: Admin/Logos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = footerRepository.GetById(id.Value);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            footerRepository.DeleteById(id);
            footerRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                footerRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
